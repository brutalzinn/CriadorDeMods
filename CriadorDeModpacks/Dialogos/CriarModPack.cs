using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadorDeModpacks.Dialogos
{
    public partial class CriarModPack : Form
    {
        public CriarModPack()
        {
            InitializeComponent();
        }

        public string Nome { get; set; }
        public string MinecraftVersion { get; set; }
        public string ForgeVersion { get; set; }
        public string PublicZipUrl { get; set; }
        private void CloseForm(DialogResult result)
        {
            DialogResult = result;
            Close();
        }
   

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Nome = txb_nome.Text;
            ForgeVersion = txb_forge.Text;
            MinecraftVersion = txb_minecraft.Text;
            CloseForm(DialogResult.OK);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            CloseForm(DialogResult.Cancel);
        }

        private void CriarModPack_Load(object sender, EventArgs e)
        {

        }
    }
}
