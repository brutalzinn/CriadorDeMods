using CriadorDeModpacks.Models;
using fNbt;
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
    public static class FileUtils
    {
        public static ProgressBar progress_bar { get; set; }


    public static void CreateServerFile(ModPack  modpack)
     {
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
       static void CompressFolder(string folder, string targetFilename)
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

            using (ZipArchive zip = ZipFile.Open(targetFilename, ZipArchiveMode.Create))
            {
                // Go over all files and zip them.
                foreach (var file in allFilesToZip)
                {
                    String fileRelativePath = file.Replace(pathToRemove, "");

                    // It is not mentioned in MS documentation, but the name can be
                    // a relative path with the file name, this will create a zip 
                    // with folders and not only with files.
                    zip.CreateEntryFromFile(file, fileRelativePath);
                    Debug.WriteLine(progress);
                    progress++;
                    progress_bar.Invoke(() => progress_bar.Value = progress);

                    // ---------------------------
                    // TBD: Notify about progress.
                    // ---------------------------
                }
            }
        }

        public static void GerarModPackZip(ModPack modpack)
        {
            string caminho = Path.Combine(Globals.modpack_root, $"{modpack.directory.Replace(" ", "_").ToLower()}.zip");
            bool zipExists = File.Exists(caminho);
            if (zipExists) File.Delete(caminho);

            CompressFolder(Path.Combine(Globals.modpack_root, modpack.directory), caminho);
            //  ZipFile.CreateFromDirectory(Path.Combine(Globals.modpack_root, modpack.directory), caminho);

        }
        async public static void UploadMultipart(string path, string directory, string url)
        {
        
            FileStream file = File.OpenRead(path);
            Uri uri = new Uri(url);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("api-key", "teste");
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new StringContent(directory), "directory");
            form.Add(new StreamContent(file), "file", Path.GetFileName(path));
            bool keepTracking = true; //to start and stop the tracking thread
            new Task(new Action(() => { progressTracker(file, ref keepTracking); })).Start();
            var result = await httpClient.PostAsync(uri, form);
            keepTracking = false;
            result.EnsureSuccessStatusCode();
            httpClient.Dispose();
            string sd = result.Content.ReadAsStringAsync().Result;
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

                    Debug.WriteLine(pos + "%");

                }
                prevPos = pos;

                Thread.Sleep(100); //update every 100ms
            }
        }

       
    }
}
