using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriadorDeModpacks.Models
{
    public static class Search
    {
       public enum TIPOS
        {
            [Description("ID")]
            id = 0,
            [Description("Nome")]
            nome,
            [Description("Game_version")]
            game_version,
            [Description("Forge_version")]
            forge_version,
            [Description("Author")]
            author
          
        }

        public static void FillSearchComboBox(ComboBox combobox)
        {
            foreach (int value in Enum.GetValues(typeof(TIPOS)))
            {
                combobox.Items.Add((TIPOS)value);
            }
            combobox.SelectedIndex = 0;
        }
    }
}
