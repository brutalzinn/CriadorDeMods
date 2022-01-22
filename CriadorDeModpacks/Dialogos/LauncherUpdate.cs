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
    public partial class LauncherUpdate : Form
    {
        public LauncherUpdateModel launcherUpdate { get; set; }
        public enum SYSTEM
        {
            win = 0,
            linux,
            mac
        }
        public class LauncherUrl
        {
            public string file { get; set; }
            public SYSTEM system { get; set; }

            public LauncherUrl(string file, SYSTEM system)
            {
                this.file = file;
                this.system = system;
            }

        
          
        }

        public List<LauncherUrl> files = new List<LauncherUrl>();
        public LauncherUpdate()
        {
            InitializeComponent();
        }

        private void LauncherUpdate_Load(object sender, EventArgs e)
        {
            var server = Utils.ApiUtils.LauncherGetVersion();
            if(server != null)
            {
                launcherUpdate = new LauncherUpdateModel()
                {
                    packages = new Packages()
                    {
                        win64 = server.packages.win64 != null ? new Win64(server.packages.win64.url) : new Win64(),
                        mac64 = server.packages.mac64 != null ? new Mac64(server.packages.mac64.url) : new Mac64(),
                        linux64 = server.packages.linux64 != null ? new Linux64(server.packages.linux64.url) : new Linux64()
                    },
                    version = server.version,
                    files = new List<string>()
  
                };
                txb_launcher_version.Text = launcherUpdate.version;
            }
            else
            {
                launcherUpdate = new LauncherUpdateModel();
            }

        }
        private void CloseForm(DialogResult result)
        {
            DialogResult = result;
            Close();
        }
        async void StartBackground()
        {
            Utils.ApiUtils.progress_bar = progressBar1;
            Utils.ApiUtils.progress_txt = lbl_status;
            if (await Utils.ApiUtils.LauncherUpdateVersion(launcherUpdate))
            {
                await Utils.ApiUtils.UploadLauncherUpdate(launcherUpdate);
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            launcherUpdate.version = txb_launcher_version.Text;
            launcherUpdate.packages = new Packages();
           
            string url = $"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url}/data/cliente/launcher/update-launcher";

            UpdateList();

            foreach (var item in files)
            {
                if (!listBox1.Items.Contains(item))
                {
                    listBox1.Items.Add(item);
                }
                switch (item.system)
                {
                    case SYSTEM.linux:
                        launcherUpdate.packages.linux64 = new Linux64($"{url}/{Path.GetFileName(item.file)}");
                    break;
                    case SYSTEM.mac:
                        launcherUpdate.packages.mac64 = new Mac64($"{url}/{Path.GetFileName(item.file)}");
                    break;
                    case SYSTEM.win:
                        launcherUpdate.packages.win64 = new Win64($"{url}/{Path.GetFileName(item.file)}");
                    break;
                }
            }
            Thread t = new Thread(StartBackground);          // Kick off a new thread
            t.Start();



            //CloseForm(DialogResult.OK);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseForm(DialogResult.Cancel);

        }
        private string GetFilePath()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Zip files|*.zip";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                return openFileDialog.FileName;
            }
            return "";
        }
        private void btn_open_windows_Click(object sender, EventArgs e)
        {
            string path = GetFilePath();
            txb_launcher_windows.Text = path;
            files.Add(new LauncherUrl(path,SYSTEM.win));
        }

        private void btn_open_linux_Click(object sender, EventArgs e)
        {
            string path = GetFilePath();
            txb_launcher_linux.Text = path;
            files.Add(new LauncherUrl(path, SYSTEM.linux));


        }

        private void btn_open_mac_Click(object sender, EventArgs e)
        {
            string path = GetFilePath();
            txb_launcher_mac.Text = path;
            files.Add(new LauncherUrl(path, SYSTEM.mac));


        }
        private void UpdateList()
        {
            listBox1.Items.Clear();
            if (files.Count > 0)
            {
                launcherUpdate.files = files.Select(v => v.file).ToList();
            }
        }
        private void btn_remove_windows_Click(object sender, EventArgs e)
        {
            var Launcher = files.Where(v=>v.system == SYSTEM.win).FirstOrDefault();
            if(Launcher != null)
                files.Remove(Launcher);
                UpdateList();
        }

        private void btn_remove_linux_Click(object sender, EventArgs e)
        {
            var Launcher = files.Where(v => v.system == SYSTEM.linux).FirstOrDefault();
            if (Launcher != null)
                files.Remove(Launcher);
                UpdateList();
        }

        private void btn_remove_mac_Click(object sender, EventArgs e)
        {
            var Launcher = files.Where(v => v.system == SYSTEM.mac).FirstOrDefault();
            if (Launcher != null)
               files.Remove(Launcher);
               UpdateList();

        }
    }
}
