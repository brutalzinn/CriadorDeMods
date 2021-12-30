using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadorDeModpacks.Dialogos.ModsManagerDialog
{
    public partial class ModPackManager : Form
    {
        public ModPackManager()
        {
            InitializeComponent();
            DataGridViewTextBoxColumn modpackname = new DataGridViewTextBoxColumn();
            modpackname.Width = 200;
            modpackname.Name = "file_name";
            modpackname.HeaderText = "ModPack";
            DataGridViewTextBoxColumn modpack_dir = new DataGridViewTextBoxColumn();
            modpack_dir.Width = 200;
            modpack_dir.Name = "file_name";
            modpack_dir.HeaderText = "ModPack";

            DataGridViewButtonColumn buttonmodpack = new DataGridViewButtonColumn();
            buttonmodpack.Name = "openmodpack_column";
            buttonmodpack.HeaderText = "Controller";
            buttonmodpack.Width = 200;
            dgv_modpack.Columns.Add(modpackname);
            dgv_modpack.Columns.Add(modpack_dir);
            dgv_modpack.Columns.Add(buttonmodpack);

        }

        private void ModPackManager_Load(object sender, EventArgs e)
        {
            foreach (string item in Directory.GetFileSystemEntries(Globals.modpack_root))
                if(Path.GetExtension(item) != ".zip")
                {
                    dgv_modpack.Rows.Add(Path.GetFileName(item),item, "Ações");
                }
          
        }

        private void dgv_modpack_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_modpack.Columns["openmodpack_column"].Index)
            {
                DataGridViewRow row = dgv_modpack.Rows[e.RowIndex];
                string modpack_name = row.Cells[0].Value.ToString();
                string modpack_dir = row.Cells[0].Value.ToString();
                var modpackAction = new ModPackActionManager(modpack_name, modpack_dir);
                modpackAction.ShowDialog();
            }
        }
    }
}
