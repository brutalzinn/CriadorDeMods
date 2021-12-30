using CriadorDeModpacks.Models;
using fNbt;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Utils
{
    public static class FileUtils
    {

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
        public static void GerarModPackZip(ModPack modpack)
        {
            string caminho = Path.Combine(Globals.modpack_root, $"{modpack.directory.Replace(" ", "_").ToLower()}.zip");
            bool zipExists = File.Exists(caminho);
            if (zipExists) File.Delete(caminho);
            ZipFile.CreateFromDirectory(Path.Combine(Globals.modpack_root, modpack.directory), caminho);
        }
        public static void UploadMultipart(byte[] file, string filename, string contentType, string url)
        {
            var webClient = new WebClient();
            string boundary = "------------------------" + DateTime.Now.Ticks.ToString("x");
            webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);
            webClient.Headers.Add("api-key", "teste");
            var fileData = webClient.Encoding.GetString(file);
            var package = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"file\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", boundary, filename, contentType, fileData);

            var nfile = webClient.Encoding.GetBytes(package);
            Uri uri = new Uri(url);
            webClient.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressWCallback);


            webClient.UploadDataAsync(uri, "POST", nfile);
        }
       

        private static void UploadProgressWCallback(object sender, UploadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            Debug.WriteLine("{0}    uploaded {1} of {2} bytes. {3} % complete...",
                (string)e.UserState,
                e.BytesSent,
                e.TotalBytesToSend,
                e.ProgressPercentage);
        }

    }
}
