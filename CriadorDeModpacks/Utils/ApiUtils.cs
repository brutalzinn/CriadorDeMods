using CriadorDeModpacks.Messages.Launcher;
using CriadorDeModpacks.Models;
using fNbt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Utils
{
    public static class ApiUtils
    {
        public static ProgressBar progress_bar { get; set; }

        public static Label progress_txt { get; set; }

        public static void CreateServerFile(ModPack  modpack)
     {
            if(string.IsNullOrEmpty(modpack.server_ip) && string.IsNullOrEmpty(modpack.server_port))
            {
                return;
            }
            var serverInfo = new NbtCompound("");
            var list = new NbtList("servers");
            var server = new NbtCompound();
            server.Add(new NbtString("ip", modpack.server_ip + ":" + modpack.server_port));
            server.Add(new NbtString("name", modpack.name));
            list.Add(server);
            serverInfo.Add(list);            
            var serverFile = new NbtFile(serverInfo);
            serverFile.SaveToFile(Path.Combine(Globals.modpack_root, modpack.directory, "servers.dat"), NbtCompression.None);
      }
    public static void CreateModPackFiles(string mod_directory)
    {
        var modpackDirectory = Path.Combine(Globals.modpack_root, mod_directory);
            if (Directory.Exists(modpackDirectory))
            {
                return;
            }
        Directory.CreateDirectory(modpackDirectory);

        File.Copy(@"Arquivos\launcher_profiles.json", Path.Combine(modpackDirectory, "launcher_profiles.json"), true);
        File.Copy(@"Arquivos\.htaccess", Path.Combine(modpackDirectory, ".htaccess"), true);
    }
       private class MyEncoder : UTF8Encoding
        {
            public MyEncoder()
            {

            }
            public override byte[] GetBytes(string s)
            {
                s = s.Replace("\\", "/");
                return base.GetBytes(s);
            }
        }
        public static void CompressFolder(string folder, string targetFilename)
        {
            string[] allFilesToZip = Directory.GetFiles(folder, "*.*", System.IO.SearchOption.AllDirectories);

            // You can use the size as the progress total size
            int size = allFilesToZip.Length;
            progress_bar.Invoke(() => progress_bar.Maximum = size);
            // You can use the progress to notify the current progress.
            int progress = 0;
            progress_bar.Invoke(() => progress_bar.Value = 0);
            // To have relative paths in the zip.
            string pathToRemove = folder + "\\";

            using (ZipArchive zip = ZipFile.Open(targetFilename, ZipArchiveMode.Create, new MyEncoder()))
            {
                // Go over all files and zip them.
                foreach (var file in allFilesToZip)
                {
                    String fileRelativePath = file.Replace(pathToRemove, "");

                    // It is not mentioned in MS documentation, but the name can be
                    // a relative path with the file name, this will create a zip 
                    // with folders and not only with files.
                    zip.CreateEntryFromFile(file, fileRelativePath, CompressionLevel.Fastest);
                    progress++;
                    progress_txt.Invoke(() => progress_txt.Text = $"Compressing.. {progress}/100");
                    progress_bar.Invoke(() => progress_bar.Value = progress);


                    // ---------------------------
                    // TBD: Notify about progress.
                    // ---------------------------
                }

            }
        }


        public static  void GenerateModPackZip(ModPack modpack)
        {
            string caminho = Path.Combine(Globals.modpack_root, $"{modpack.directory.ToLower()}.zip");
            bool zipExists = File.Exists(caminho);
            if (zipExists) File.Delete(caminho);

            //await Archive.CreateFromFolderAsync(Path.Combine(Globals.modpack_root, modpack.directory), caminho,(V)=>Debug.WriteLine(V));
            CompressFolder(Path.Combine(Globals.modpack_root, modpack.directory), Path.Combine(Globals.modpack_root, Path.GetFileName(caminho)));
            //  ZipFile.CreateFromDirectory(Path.Combine(Globals.modpack_root, modpack.directory), caminho);

        }
        async public static Task<bool> UploadModPack(string path, string directory)
        {
        
            FileStream file = File.OpenRead(path);
            Uri uri = new Uri($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url_Api}/launcher/modpacks/upload");
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Header, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Key);
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent(directory), "directory");
            form.Add(new StreamContent(file), "file", Path.GetFileName(path));
            bool keepTracking = true; //to start and stop the tracking thread
            new Task(new Action(() => { progressTracker(file, ref keepTracking); })).Start();
            var result = await httpClient.PostAsync(uri, form);
            keepTracking = false;
            httpClient.Dispose();
            file.Close();

           // result.Content.ReadAsStringAsync().Result;
           return  result.StatusCode == HttpStatusCode.OK;
        }
        public class Teste
        {
            public FileStream file { get; set; }
            public string path { get; set; }
            public Teste(FileStream file, string path)
            {
                this.file = file;
                this.path = path;
            }

  
        }
        async public static Task<bool> UploadLauncherUpdate(LauncherUpdateModel launcher)
        {

            Uri uri = new Uri($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url_Api}/launcher/version/upload");
            List<Teste> files = new List<Teste>();
            foreach(var item in launcher.data.files)
            {
                FileStream file = File.OpenRead(item);
                files.Add(new Teste(file,item));
            }

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Header, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Key);
            MultipartFormDataContent form = new MultipartFormDataContent();
            bool keepTracking = true;
            foreach (Teste file in files)
            {
               form.Add(new StreamContent(file.file), "file[]", Path.GetFileName(file.path));
               new Task(new Action(() => { progressTracker(file.file, ref keepTracking); })).Start();
            }
            //to start and stop the tracking thread
            var result = await httpClient.PostAsync(uri, form);
            keepTracking = false;
            httpClient.Dispose();
            foreach (Teste file in files)
            {
                file.file.Close();
            }
            return result.StatusCode == HttpStatusCode.OK;


        }
        static void progressTracker(FileStream streamToTrack, ref bool keepTracking)
        {
            int prevPos = -1;
            progress_bar.Invoke(() => progress_bar.Maximum = 100);
            progress_bar.Invoke(() => progress_bar.Value = 0);
                
             while (keepTracking)
            {
                int pos = (int)Math.Round(100 * (streamToTrack.Position / (double)streamToTrack.Length));
                if (pos != prevPos)
                {
                  
                    progress_bar.Invoke(() => progress_bar.Value = pos);
                    progress_txt.Invoke(() => progress_txt.Text = $"Uploading.. {pos}/100");

                    Debug.WriteLine(pos + "%");

                }
                prevPos = pos;

                Thread.Sleep(100); //update every 100ms
            }
        }
 
       public static bool SyncModPacks(List<ModPack> modpacks)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url_Api}/modpackcreator/modpacks/sync");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Header, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Key);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(modpacks, Formatting.Indented);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse.StatusCode == HttpStatusCode.OK;
        }
        public static bool RedisClearAll()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url_Api}/redis/clear");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Header, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Key);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse.StatusCode == HttpStatusCode.OK;
        }
        public static bool RedisClearModPack(ModPack modpack)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url_Api}/redis/del");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Header, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Key);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            var resultado = new RedisClearModPackMessage()
            {
                id = modpack.id
            };
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(resultado, Formatting.Indented);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse.StatusCode == HttpStatusCode.OK;
        }

        public static bool AppendModPack(ModPack modpacks)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url_Api}/modpackcreator/modpacks/append");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Header, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Key);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(modpacks, Formatting.Indented);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse.StatusCode == HttpStatusCode.OK;
        }

        async public static Task<bool> LauncherUpdateVersion(LauncherUpdateModel launcherUpdateModel)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url_Api}/launcher/version");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Header, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Key);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var update = new LauncherUpdateMessage()
                {
                    packages = new Messages.Launcher.Packages()
                    {
                        win64 = launcherUpdateModel.data.packages.win64 != null ? new Messages.Launcher.Win64(launcherUpdateModel.data.packages.win64.url) : null,
                        mac64 = launcherUpdateModel.data.packages.mac64 != null ? new Messages.Launcher.Mac64(launcherUpdateModel.data.packages.mac64.url) : null,
                        linux64 = launcherUpdateModel.data.packages.linux64 != null ? new Messages.Launcher.Linux64(launcherUpdateModel.data.packages.linux64.url) : null
                    },
                    version = launcherUpdateModel.data.version
                };
                var json = JsonConvert.SerializeObject(update, Formatting.Indented);
                
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse.StatusCode == HttpStatusCode.OK;
        }

         public static LauncherUpdateMessage LauncherGetVersion()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url_Api}/launcher/version");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Header, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Key);
            httpWebRequest.Method = "GET";


            string json = null;
            var response = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }
            LauncherUpdateModel resultado = JsonConvert.DeserializeObject<LauncherUpdateModel>(json);
            if(resultado.data.packages == null || resultado.data.version == null){
                return null;
            }
            return new LauncherUpdateMessage()
            {
                packages = new Messages.Launcher.Packages()
                {
                    win64 = resultado.data.packages.win64 != null ? new Messages.Launcher.Win64(resultado.data.packages.win64.url) : new Messages.Launcher.Win64(),
                    mac64 = resultado.data.packages.mac64 != null ? new Messages.Launcher.Mac64(resultado.data.packages.mac64.url) : new Messages.Launcher.Mac64(),
                    linux64 = resultado.data.packages.linux64 != null ? new Messages.Launcher.Linux64(resultado.data.packages.linux64.url) : new Messages.Launcher.Linux64()
                },
                version = resultado.data.version
            };
          

        }

    }
}
