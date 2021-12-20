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
        public static string filename = Application.StartupPath + @"\mod_packages.json";
        public static string filename_config = Application.StartupPath + @"\config.json";
        public static ConfiguracaoModel Configuracao { get; set; }
    }
}
