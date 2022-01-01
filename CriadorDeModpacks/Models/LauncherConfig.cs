using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public class LauncherConfig
    {
        public string maintenance { get; set; }
        public string maintenance_message { get; set; }
        public string offline { get; set; }
        public string client_id { get; set; }
        public bool custom { get; set; }
        public bool verify { get; set; }
        public bool java { get; set; }
        public string dataDirectory { get; set; }
        public List<string> ignored { get; set; }
    }
}
