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

namespace CriadorDeModpacks.Dialogos.ModsManagerDialog
{
    public partial class ModPackActionManager : Form
    {
        private ModPack ModPack { get; set; }
        public ModPackActionManager()
        {
            InitializeComponent();
        }

        public ModPackActionManager(string modpack_name,string modpack_dir)
        {
            InitializeComponent();
            ModPack = new ModPack()
            {
                name = modpack_name,
                directory = Path.GetFileNameWithoutExtension(modpack_dir)
            };
            label1.Text = "Modpack: " + ModPack.name;
        }

        private void ModPackActionManager_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Utils.FileUtils.GerarModPackZip(ModPack);
            byte[] data = File.ReadAllBytes(Path.Combine(Globals.modpack_root, $"{ModPack.directory.Replace(" ", "_").ToLower()}.zip"));
            Utils.FileUtils.UploadMultipart(data,"file", "data", "http://127.0.0.1:5000/uploader");
        }
    }
}
