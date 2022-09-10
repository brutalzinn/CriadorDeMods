using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public class ModPack
    {

        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }
        public string Directory { get; set; }
        public bool IsDefault { get; set; }
        public bool IsPremium { get; set; }
        public bool IsVerifyMods { get; set; }
        public string Description { get; set; }
        public string GameVersion { get; set; }
        public string ForgeVersion { get; set; }
        public string FabricVersion { get; set; }
        public string ServerIp { get; set; }
        public string ServerPort { get; set; }
        public string Img { get; set; }
        public string Author { get; set; }

        public ModPack()
        {

        }

        public ModPack(string id,
            string name,
            string directory, 
            bool isDefault, 
            bool isPremium,
            string description, 
            string game_version, 
            string forge_version, 
            string fabric_version,
            string server_ip, 
            string server_port, 
            string img, 
            string author)
        {
            this.Id = id;
            this.Name = name;
            this.Directory = directory;
            this.IsDefault = isDefault;
            this.IsPremium = isPremium;
            this.Description = description;
            this.GameVersion = game_version;
            this.ForgeVersion = forge_version;
            this.FabricVersion = fabric_version;
            this.ServerIp = server_ip;
            this.ServerPort = server_port;
            this.Img = img;
            this.Author = author;
        }

        public override string ToString()
        {
            return this.Name;
        }


    }
}
