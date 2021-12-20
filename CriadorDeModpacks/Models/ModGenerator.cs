using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public static class ModGenerator
    {

        public static void GerarManifesto(List<ModPack> modpacks)
        {
            string caminho = Application.StartupPath + $@"\builds\manifesto.json";
            var json = JsonConvert.SerializeObject(modpacks, Formatting.Indented);
            foreach(ModPack item in modpacks)
            {
                GerarModPack(item);
            }
            File.WriteAllText(caminho, json);

        }
        private static void GerarModPack(ModPack modpack)
        {
            string caminho = Application.StartupPath + $@"\builds\{modpack.Nome.Replace(" ", "_").ToLower()}.zip" ;
            bool zipExists = File.Exists(caminho);
            if (zipExists) File.Delete(caminho);
            var zip = ZipFile.Open(caminho, ZipArchiveMode.Create);
                foreach (var file in modpack.Mods)
                {
                
                    zip.CreateEntryFromFile(file.Caminho, Path.GetFileName(file.Caminho), CompressionLevel.Optimal);
                }
           
            zip.Dispose();
        }
    }
}
