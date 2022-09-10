using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public class GenericConfigModel
    {
        public EnvironmentModel.EnvironmentMode Enviroment { get; set; }

        public List<ConfigModel> Configs { get; set; }
    }
}
