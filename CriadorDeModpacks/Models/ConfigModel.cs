using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public class ConfigModel
    {
        public EnvironmentModel.ENV Dev_mode { get; set; }

        public string Url_Api { get; set; } = "http://boberto.net";

        public string Url { get; set; } = "http://boberto.net";
        
        public string Api_Key { get; set; } = "teste";

        public string Api_Header { get; set; } = "api-key";
    }
}
