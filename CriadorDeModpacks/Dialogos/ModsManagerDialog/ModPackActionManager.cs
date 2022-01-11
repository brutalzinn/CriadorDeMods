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
        }

        private void ModPackActionManager_Load(object sender, EventArgs e)
        {

        }
       async void StartBackground()
        {
            string path = Path.Combine(Globals.modpack_root, $"{ModPack.directory.Replace(" ", "_").ToLower()}.zip");
            Utils.ApiUtils.progress_bar = progressBar1;

            label1.Invoke(() => label1.Text = "Preparing to zip modpack.. 1/2");
             Utils.ApiUtils.GenerateModPackZip(ModPack);
            label1.Invoke(() => label1.Text =  "Zip Ready. Sending modpack to server.. 2/2");
            await Utils.ApiUtils.UploadModPack(path, ModPack.directory);
            label1.Invoke(() => label1.Text = "Modpack uploaded with success");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(StartBackground);          // Kick off a new thread
            t.Start();
            

        }
    }
}
