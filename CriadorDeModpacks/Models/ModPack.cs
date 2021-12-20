using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public class ModPack
    {
        public string Nome { get; set; }
        public string MinecraftVersion { get; set; }
        public string ForgeVersion { get; set; }
        public string PublicZipUrl { get => PegarUrl(); }
        
        public string PegarUrl()
        {
            return $"{Globals.Configuracao.Url}/{Nome.Replace(" ", "_").ToLower()}";
        }
        public override string ToString()
        {
            return Nome;
        }
        public List<Mod> Mods { get; set; } = new List<Mod>();
    }
}
