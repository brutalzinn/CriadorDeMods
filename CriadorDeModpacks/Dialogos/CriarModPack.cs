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
using System.Xml;

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
                this.txb_fabric_version.Text = ModPack.fabric_version;
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
                fabric_version = this.txb_fabric_version.Text

            };
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
            form.mod_directory = this.txb_diretory.Text;
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if(ModPack != null)
            //Utils.FileUtils.GerarModPackZip(ModPack);

        }

        private void txb_forge_version_TextChanged(object sender, EventArgs e)
        {
            if(txb_forge_version.Text.Length == 0)
            {
                btn_install_forge.Enabled = false;
            }
            else
            {
                btn_install_forge.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new FabricInstaller();
            string baseURL = "https://maven.fabricmc.net/net/fabricmc/fabric-installer/maven-metadata.xml";

            XmlDocument doc1 = new XmlDocument();
            doc1.Load(baseURL);
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/metadata/versioning");
            string version = "";
            foreach (XmlNode node in nodes)
            {
                version = node["latest"].InnerText;
            }
            form.minecraft_version = this.txb_minecraft_version.Text;
            form.fabric_version = version;
            form.mod_directory = this.txb_diretory.Text;
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                var modpackDirectory = Path.Combine(Globals.modpack_root, form.mod_directory);
                var version_path =  Path.Combine(modpackDirectory, "versions");
                var fabric_version = "";
                //pegarversão da pasta é mais fácil que ler o json quebrado.
                var versions_folder = Directory.GetDirectories(version_path);
               
                foreach(string item in versions_folder)
                {
                    var dir = new DirectoryInfo(item);
                    var dirName = dir.Name;

                    foreach (FileInfo file in dir.GetFiles("*.jar"))
                    {
                        if(File.Exists(file.FullName))
                        {
                            File.Delete(file.FullName);
                        }
                    }
                    fabric_version = dirName.Replace("fabric-loader-","");
                }

                this.txb_fabric_version.Text = fabric_version;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txb_diretory_TextChanged(object sender, EventArgs e)
        {
            if (txb_diretory.Text.Length == 0)
            {
                btn_salvar.Enabled = false;
                lbl_error.Text = "Fill the mod pack directory name.";
            }
            else
            {
                lbl_error.Text = "";
                btn_salvar.Enabled = true;
            }
        }

        private void txb_minecraft_version_TextChanged(object sender, EventArgs e)
        {
            if (txb_minecraft_version.Text.Length == 0)
            {
                btn_salvar.Enabled = false;
                lbl_error.Text = "Fill the minecraft version";
            }
            else
            {
                lbl_error.Text = "";
                btn_salvar.Enabled = true;
            }
        }
    }
}
