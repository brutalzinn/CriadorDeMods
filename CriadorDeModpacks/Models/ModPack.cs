﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public class ModPack
    {

        public string id { get; set; } = Guid.NewGuid().ToString();
        public string name { get; set; }
        public string directory { get; set; }
        public bool @default { get; set; }
        public string description { get; set; }
        public string game_version { get; set; }
        public string forge_version { get; set; }
        public string server_ip { get; set; }
        public string server_port { get; set; }
        public string img { get; set; }
        public string author { get; set; }

        public ModPack(string id,
            string name, 
            string directory,
            bool @default, 
            string description,
            string game_version, 
            string forge_version, 
            string server_ip, 
            string server_port, 
            string img, 
            string author)
        {
            this.id = id;
            this.name = name;
            this.directory = directory;
            this.@default = @default;
            this.description = description;
            this.game_version = game_version;
            this.forge_version = forge_version;
            this.server_ip = server_ip;
            this.server_port = server_port;
            this.img = img;
            this.author = author;
        }

        public ModPack()
        {

        }

        public override string ToString()
        {
            return this.name;
        }


    }
}
