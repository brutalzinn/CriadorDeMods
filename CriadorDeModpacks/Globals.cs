using CriadorDeModpacks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks
{
    public static class Globals
    {
        public static string modpack_root = Path.Combine(Application.StartupPath, "web", "files", "files");
        public static string filename = Path.Combine(Application.StartupPath,"web","launcher", "config-launcher", "modpacks.json");
        public static string filename_config = Application.StartupPath + @"\config.json";
        public static ConfiguracaoModel Configuracao { get; set; }
    }
}
