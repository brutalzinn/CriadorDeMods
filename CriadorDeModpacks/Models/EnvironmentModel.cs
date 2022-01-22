using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public static class EnvironmentModel
    {
        public enum ENV
        {
            DEV = 0,
            PROD = 1
        }

        public static ConfigModel GetConfigEnv(ENV mode)
        {
            var found = Globals.Configuracao.Configs.Find((e) => e.Dev_mode == mode);
            if(found == null)
            {
                return new ConfigModel()
                {
                    Dev_mode = ENV.DEV,
                    Api_Header = "api-key",
                    Api_Key = "teste",
                    Url_Api = "http://127.0.0.1",
                    Url = "http://127.0.0.1"
                };
            }
            else
            {
                return found;
            }
        }

        public static void addConfigEnv(ConfigModel model, ENV environment)
        {
            var count = Globals.Configuracao.Configs.FindAll((e) => e.Dev_mode == environment).ToList().Count();
            if(count == 0)
            {
              Globals.Configuracao.Configs.Add(model);
            }
        }

        public static void FillConfigComboBox(ComboBox combobox)
        {
            foreach (int value in Enum.GetValues(typeof(ENV)))
            {
                combobox.Items.Add((ENV)value);
            }
            combobox.SelectedIndex = 0;
        }
    }
}
