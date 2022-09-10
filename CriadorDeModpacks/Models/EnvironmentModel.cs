using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public static class EnvironmentModel
    {
        public enum EnvironmentMode
        {
            DEV = 0,
            PROD = 1
        }

        public static ConfigModel GetConfigEnv(EnvironmentMode mode)
        {
            var found = Globals.Configuracao.Configs.Find((e) => e.DevMode == mode);
            if(found == null)
            {
                return new ConfigModel()
                {
                    DevMode = EnvironmentMode.DEV,
                    ApiHeader = "api-key",
                    ApiKey = "teste",
                    UrlApi = "http://127.0.0.1",
                    Url = "http://127.0.0.1"
                };
            }
            else
            {
                return found;
            }
        }

        public static void SaveConfig(ConfigModel model)
        {
            var configs = Globals.Configuracao.Configs.FindIndex((e) => e.DevMode == model.DevMode);
            if(configs != -1)
            {
                Globals.Configuracao.Configs[configs] = model;
            }
            Globals.Configuracao.Enviroment = model.DevMode;
            var json = JsonConvert.SerializeObject(Globals.Configuracao, Formatting.Indented);
            File.WriteAllText(Application.StartupPath + @"\config.json", json);
        }

        public static void FillConfigComboBox(ComboBox combobox)
        {
            foreach (int value in Enum.GetValues(typeof(EnvironmentMode)))
            {
                combobox.Items.Add((EnvironmentMode)value);
            }
            combobox.SelectedIndex = 0;
        }

        public static ConfigModel GetConfigComboBox(ComboBox combobox)
        {
            var ConfigModel = combobox.SelectedItem;
            return GetConfigEnv((EnvironmentModel.EnvironmentMode)ConfigModel);
        }

        public static string GetConfigDescription(ConfigModel config)
        {
            var mode = config.DevMode;

            switch (mode)
            {
                case EnvironmentMode.DEV:
                    return "Desenvolvimento";

                case EnvironmentMode.PROD:
                    return "Produção";

                default:
                    return "Sem descrição";
            }
        }

    }
}
