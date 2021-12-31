using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Utils
{
    public static class HostUtils
    {
        public enum TIPOS
        {
            [Description("LOCAL")]
            local = 0,
            [Description("HOST")]
            host,
        }
        public static void FillHostModPack(ComboBox combobox)
        {
            foreach (int value in Enum.GetValues(typeof(TIPOS)))
            {
                combobox.Items.Add((TIPOS)value);
            }
            combobox.SelectedIndex = 0;
        }
    }
}
