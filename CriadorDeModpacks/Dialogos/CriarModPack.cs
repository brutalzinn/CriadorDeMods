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
                this.txb_id.Text = ModPack.Id ?? Guid.NewGuid().ToString();
                this.txb_nome.Text = ModPack.Name;
               // this.creat_at = ModPack.datetime_creat_at;
                this.txb_diretory.Text = ModPack.Directory;
                this.ckb_default.Checked = ModPack.IsDefault;
                this.ckb_premium.Checked = ModPack.IsPremium;
                this.ckb_verify_mods.Checked = ModPack.IsVerifyMods;
                this.txb_description.Text = ModPack.Description;
                this.txb_minecraft_version.Text = ModPack.GameVersion;
                this.txb_forge_version.Text = ModPack.ForgeVersion;
                this.txb_ip.Text = ModPack.ServerIp;
                this.txb_fabric_version.Text = ModPack.FabricVersion;
                this.txb_port.Text = ModPack.ServerPort;
                this.txb_img.Text = ModPack.Img;
                this.txb_autor.Text = ModPack.Author;
            }

        }

        private void CloseForm(DialogResult result)
        {
            DialogResult = result;
            Close();
        }
   
        private bool CheckRequiredFields()
        {
            List<Control> list = new List<Control>();
            list.Add(txb_diretory);
            list.Add(txb_minecraft_version);
            bool valid = true;
            foreach(Control item in list)
            {
                if(item.Text.Length == 0)
                {
                    valid = false;
                }
            }

            return valid;
        }
        private void btn_salvar_Click(object sender, EventArgs e)
        {

            if (!CheckRequiredFields())
            {
                lbl_error.Text = "Required field is invalid";
                return;
            }


            ModPack = new ModPack()
            {
                Id = this.txb_id.Text ?? Guid.NewGuid().ToString(),
                Name = this.txb_nome.Text,
             //  datetime_creat_at = creat_at,
             //   datetime_updat_at = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                ForgeVersion = this.txb_forge_version.Text,
                GameVersion = this.txb_minecraft_version.Text,
                IsVerifyMods = this.ckb_verify_mods.Checked,
                Directory = this.txb_diretory.Text,
                ServerIp = this.txb_ip.Text,
                ServerPort = this.txb_port.Text,
                Img = this.txb_img.Text,
                IsPremium = this.ckb_premium.Checked,
                IsDefault = this.ckb_default.Checked,
                Author = this.txb_autor.Text,
                Description = this.txb_description.Text,
                FabricVersion = this.txb_fabric_version.Text

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
            form.mod_directory = this.txb_diretory.Text;
            form.ShowDialog();
            if(form.DialogResult == DialogResult.OK)
            {
                this.txb_forge_version.Text = form.forge_version;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if(ModPack != null)
            //Utils.FileUtils.GerarModPackZip(ModPack);

        }

        private void txb_forge_version_TextChanged(object sender, EventArgs e)
        {
            //if(txb_forge_version.Text.Length == 0)
            //{
            //    btn_install_forge.Enabled = false;
            //}
            //else
            //{
            //    btn_install_forge.Enabled = true;
            //}
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
         
        }

        private void txb_minecraft_version_TextChanged(object sender, EventArgs e)
        {
            if (txb_minecraft_version.Text.Length == 0)
            {
                btn_install_forge.Enabled = false;
                btn_install_fabric.Enabled = false;
            }
            else
            {
                btn_install_forge.Enabled = true;
                btn_install_fabric.Enabled = true;

            }
        }
    }
}
