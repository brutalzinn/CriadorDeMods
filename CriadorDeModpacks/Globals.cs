﻿using CriadorDeModpacks.Models;
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
        public static List<ModPack> ModPacks { get; set; } = new List<ModPack>();
        public static string api_key { get; set; } = "teste";
        public static ConfiguracaoModel Configuracao { get; set; }
    }
}
