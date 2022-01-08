using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
   
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Win64
        {
        public string url { get; set; }

        public Win64(string url)
        {
            this.url = url;
        }
        }

        public class Mac64
        {
        public string url { get; set; }

        public Mac64(string url)
        {
            this.url = url;
        }
        }

        public class Linux64
        {
        public string url { get; set; }

        public Linux64(string url)
        {
            this.url = url;
        }

        }

        public class Packages
        {
        public Win64 win64 { get; set; }
        public Mac64 mac64 { get; set; }
        public Linux64 linux64 { get; set; }

        public Packages()
        {

        }
        public Packages(Win64 win64, Mac64 mac64, Linux64 linux64)
        {
            this.win64 = win64;
            this.mac64 = mac64;
            this.linux64 = linux64;
        }
      


     
        }

        public class LauncherUpdateModel
        {
            public string version { get; set; }
            public Packages packages { get; set; }
            public List<string> files { get; set; }
        }


    
}
