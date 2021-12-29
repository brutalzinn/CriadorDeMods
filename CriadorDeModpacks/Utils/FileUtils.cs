using CriadorDeModpacks.Models;
using fNbt;
using System;
using System.Collections.Generic;
using System.Linq;
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



    }
}
