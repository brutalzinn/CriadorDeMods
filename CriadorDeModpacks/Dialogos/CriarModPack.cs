using CriadorDeModpacks.Models;
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
        public ModPack ModPack { get; set; }
        public string creat_at { get; set; }

        public CriarModPack()
        {
            InitializeComponent();
            
        }

        public void AdicionarError(string erro)
        {
            lbl_error.Visible = true;
            lbl_error.Text = erro;
        }
        public CriarModPack(ModPack ModPack)
        {
            InitializeComponent();

            if (ModPack != null)
            {
                this.ModPack = ModPack;
                this.txb_id.Text = ModPack.id ?? Guid.NewGuid().ToString();
                this.txb_nome.Text = ModPack.name;
                this.creat_at = ModPack.datetime_creat_at;
                this.txb_diretory.Text = ModPack.directory;
                this.ckb_default.Checked = ModPack.@default;
                this.ckb_premium.Checked = ModPack.premium;
                this.ckb_verify_mods.Checked = ModPack.verify_mods;
                this.txb_description.Text = ModPack.description;
                this.txb_minecraft_version.Text = ModPack.game_version;
                this.txb_forge_version.Text = ModPack.forge_version;
                this.txb_ip.Text = ModPack.server_ip;
                this.txb_port.Text = ModPack.server_port;
                this.txb_img.Text = ModPack.img;
                this.txb_autor.Text = ModPack.author;
            }

        }

        private void CloseForm(DialogResult result)
        {
            DialogResult = result;
            Close();
        }
   

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            ModPack = new ModPack()
            {
                id = this.txb_id.Text ?? Guid.NewGuid().ToString(),
                name = this.txb_nome.Text,
                datetime_creat_at = creat_at,
                datetime_updat_at = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                forge_version = this.txb_forge_version.Text,
                game_version = this.txb_minecraft_version.Text,
                verify_mods = this.ckb_verify_mods.Checked,
                directory = this.txb_diretory.Text,
                server_ip = this.txb_ip.Text,
                server_port = this.txb_port.Text,
                img = this.txb_img.Text,
                premium = this.ckb_premium.Checked,
                @default = this.ckb_default.Checked,
                author = this.txb_autor.Text,
                description = this.txb_description.Text,

            };
            Utils.FileUtils.CreateServerFile(ModPack);
            CloseForm(DialogResult.OK);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            CloseForm(DialogResult.Cancel);
        }

        private void CriarModPack_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ForgeInstaller();
            form.minecraft_version = this.txb_minecraft_version.Text;
            form.forge_version = this.txb_forge_version.Text;
            form.modpack_name = this.txb_diretory.Text;
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if(ModPack != null)
            //Utils.FileUtils.GerarModPackZip(ModPack);

        }
    }
}
