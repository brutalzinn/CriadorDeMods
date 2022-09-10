using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public class ConfigModel
    {
        public EnvironmentModel.EnvironmentMode DevMode { get; set; }

        public string UrlApi { get; set; } = "http://boberto.net";

        public string Url { get; set; } = "http://boberto.net";
        
        public string ApiKey { get; set; } = "teste";

        public string ApiHeader { get; set; } = "api-key";
    }
}
