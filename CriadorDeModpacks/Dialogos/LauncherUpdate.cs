using CriadorDeModpacks.Models;
using System.Data;


namespace CriadorDeModpacks.Dialogos
{
    public partial class LauncherUpdate : Form
    {
        public LauncherVersionModel launcherVersionModel { get; set; }
        public List<LauncherUrl> files = new List<LauncherUrl>();
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

            public override string ToString()
            {
                return Path.GetFileName(file);
            }
        }

        public LauncherUpdate()
        {
            InitializeComponent();
        }

        private void LauncherUpdate_Load(object sender, EventArgs e)
        {
            var server = Utils.ApiUtils.LauncherGetVersion();
            if(server != null)
            {
                launcherVersionModel = new LauncherVersionModel()
                {
                    Packages = new LauncherVersionModel.PackagesModel
                    {
                       Win64 = new LauncherVersionModel.Win64Model()
                       {
                           Url = server.Packages.Win64.Url
                       },
                       Linux64 = new LauncherVersionModel.Linux64Model()
                       {
                           Url = server.Packages.Linux64.Url
                       },
                       Mac64 = new LauncherVersionModel.Mac64Model()
                       {
                           Url = server.Packages.Mac64.Url
                       }
                    },
                    Version = server.Version
                };

                txb_launcher_version.Text = launcherVersionModel.Version;
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

            if (await Utils.ApiUtils.LauncherUpdateVersion(launcherVersionModel))
            {
                await Utils.ApiUtils.UploadLauncherUpdate(launcherVersionModel);
            }



        }

        private void ApiUtils_FinishedUpload(object? sender, EventArgs e)
        {
            lbl_status.Invoke(() => lbl_status.Text = "Upload finished.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            launcherVersionModel.Version = txb_launcher_version.Text;
            launcherVersionModel.Packages = new LauncherVersionModel.PackagesModel();
           
            string url = $"{EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url}/launcher/upload/";

         //   UpdateList();

            foreach (var item in files)
            {
       
                if (!listBox1.Items.Contains(item))
                {
                    listBox1.Items.Add(item);
                }
                switch (item.system)
                {
                    case SYSTEM.linux:
                        launcherVersionModel.Packages.Linux64 = new LauncherVersionModel.Linux64Model($"{url}/linux");
                    break;
                    case SYSTEM.mac:
                        launcherVersionModel.Packages.Mac64 = new LauncherVersionModel.Mac64Model($"{url}/mac");
                    break;
                    case SYSTEM.win:
                        launcherVersionModel.Packages.Win64 = new LauncherVersionModel.Win64Model($"{url}/windows");
                    break;
                }
            }
            Thread t = new Thread(StartBackground);          // Kick off a new thread
            t.Start();

            Utils.ApiUtils.FinishedUpload += ApiUtils_FinishedUpload;



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
            files.Add(new LauncherUrl(path, SYSTEM.win));
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
              files.Select(v => listBox1.Items.Add(v.file)).ToList();
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
