using CriadorDeModpacks.Messages.Launcher;
using CriadorDeModpacks.Models;
using fNbt;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace CriadorDeModpacks.Utils
{
    public static class ApiUtils
    {
        public static ProgressBar progress_bar { get; set; }

        public static event EventHandler FinishedUpload = delegate { };

        public static Label progress_txt { get; set; }

        public static void CreateServerFile(ModPack  modpack)
     {
            if(string.IsNullOrEmpty(modpack.ServerIp) && string.IsNullOrEmpty(modpack.ServerPort))
            {
                return;
            }
            var serverInfo = new NbtCompound("");
            var list = new NbtList("servers");
            var server = new NbtCompound();
            server.Add(new NbtString("ip", modpack.ServerIp + ":" + modpack.ServerPort));
            server.Add(new NbtString("name", modpack.Name));
            list.Add(server);
            serverInfo.Add(list);            
            var serverFile = new NbtFile(serverInfo);
            serverFile.SaveToFile(Path.Combine(Globals.modpack_root, modpack.Directory, "servers.dat"), NbtCompression.None);
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
            string caminho = Path.Combine(Globals.modpack_root, $"{modpack.Directory.ToLower()}.zip");
            bool zipExists = File.Exists(caminho);
            if (zipExists) File.Delete(caminho);

            //await Archive.CreateFromFolderAsync(Path.Combine(Globals.modpack_root, modpack.directory), caminho,(V)=>Debug.WriteLine(V));
            CompressFolder(Path.Combine(Globals.modpack_root, modpack.Directory), Path.Combine(Globals.modpack_root, Path.GetFileName(caminho)));
            //  ZipFile.CreateFromDirectory(Path.Combine(Globals.modpack_root, modpack.directory), caminho);

        }
        async public static Task<bool> UploadModPack(string path, ModPack modpack)
        {
        
            FileStream file = File.OpenRead(path);
            Uri uri = new Uri($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).UrlApi}/modpack/upload/{modpack.Id}");
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(120);
            httpClient.DefaultRequestHeaders.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiHeader, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiKey);
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent(modpack.Directory), "directory");
            form.Add(new StreamContent(file), "file", Path.GetFileName(path));
            bool keepTracking = true; //to start and stop the tracking thread
            new Task(new Action(() => { progressTracker(file, ref keepTracking); })).Start();
            var result = await httpClient.PostAsync(uri, form);
            keepTracking = false;
            httpClient.Dispose();
            file.Close();

            // result.Content.ReadAsStringAsync().Result;
            FinishedUpload(null, EventArgs.Empty);

            return result.StatusCode == HttpStatusCode.OK;
        }
        async public static Task<bool> UploadLauncherUpdate(LauncherVersionModel launcher)
        {
            Uri uri = new Uri($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).UrlApi}/launcher");
            List<FileUploadModel> files = new List<FileUploadModel>();
           
            //foreach(FileUploadModel item in launcher.Files)
            //{
            //    FileStream file = File.OpenRead(item.path);
            //    files.Add(new FileUploadModel(file, item.path));
            //}

            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(120);
            httpClient.DefaultRequestHeaders.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiHeader, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiKey);
            MultipartFormDataContent form = new MultipartFormDataContent();
            bool keepTracking = true;
            foreach (FileUploadModel file in files)
            {
               form.Add(new StreamContent(file.file), "file[]", Path.GetFileName(file.path));
               new Task(new Action(() => { progressTracker(file.file, ref keepTracking); })).Start();
            }
            //to start and stop the tracking thread
            var result = await httpClient.PostAsync(uri, form);
            keepTracking = false;
            httpClient.Dispose();
            foreach (FileUploadModel file in files)
            {
                file.file.Close();
            }
            FinishedUpload(null, EventArgs.Empty);

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
                Thread.Sleep(50); //update every 50ms
            }
        }
 
       public static bool SyncModPacks(List<ModPack> modpacks)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).UrlApi}/modpackcreator/modpacks/sync");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiHeader, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiKey);
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
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).UrlApi}/redis/clear");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiHeader, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiKey);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse.StatusCode == HttpStatusCode.OK;
        }
        public static bool RedisClearModPack(ModPack modpack)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).UrlApi}/redis/del");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiHeader, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiKey);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            var resultado = new RedisClearModPackMessage()
            {
                id = modpack.Id
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

        async public static Task<bool> AppendModPack(ModPack modpack)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).UrlApi}/modpack/add");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiHeader, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiKey);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(modpack, Formatting.Indented);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse.StatusCode == HttpStatusCode.OK;
        }

        async public static Task<bool> LauncherUpdateVersion(LauncherVersionModel launcherVersionModel)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).UrlApi}/launcher");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiHeader, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiKey);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(launcherVersionModel, Formatting.Indented);
                
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse.StatusCode == HttpStatusCode.OK;
        }

         public static LauncherVersionModel LauncherGetVersion()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).UrlApi}/launcher");
            httpWebRequest.Headers.Add(EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiHeader, EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).ApiKey);
            httpWebRequest.Method = "GET";
            string json = null;
            var response = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }
            LauncherVersionModel resultado = JsonConvert.DeserializeObject<LauncherVersionModel>(json);
            if(resultado == null || resultado.Packages == null || resultado.Version == null){
                return null;
            }
            return new LauncherVersionModel()
            {
                Packages = new LauncherVersionModel.PackagesModel
                {
                    Win64 = resultado.Packages.Win64 != null ? new LauncherVersionModel.Win64Model(resultado.Packages.Win64.Url) : new LauncherVersionModel.Win64Model(),
                    Mac64 = resultado.Packages.Mac64 != null ? new LauncherVersionModel.Mac64Model(resultado.Packages.Mac64.Url) : new LauncherVersionModel.Mac64Model(),
                    Linux64 = resultado.Packages.Linux64 != null ? new LauncherVersionModel.Linux64Model(resultado.Packages.Linux64.Url) : new LauncherVersionModel.Linux64Model()
                },
                Version = resultado.Version
            };       
        }
    }
}
