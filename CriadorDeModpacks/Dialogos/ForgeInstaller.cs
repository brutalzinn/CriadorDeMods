using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriadorDeModpacks.Dialogos
{
    public partial class ForgeInstaller : Form
    {
        public string minecraft_version { get; set; }
        public string forge_version { get; set; }
        public string modpack_name { get; set; }
        private string modpack_directory { get; set; }
        private string forge_name { get; set; }

        public ForgeInstaller()
        {
            InitializeComponent();
        }
        enum STEP {
        one = 0,
        two,
        three,
        four
        }

        string GetUrl()
        {
            return $"https://maven.minecraftforge.net/net/minecraftforge/forge/{minecraft_version}-{forge_version}/forge-{minecraft_version}-{forge_version}-installer.jar";

        }
        private void startDownload()
        {
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(GetUrl()), Path.Combine(Application.StartupPath,"web","files","files", modpack_name, forge_name));
            });
            thread.Start();
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                lbl_info.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {              
                NextStep(STEP.one);


            });
        }
        private void downloadforge_click(object sender, EventArgs e)
        {
            var modpack_directory = Path.Combine(Globals.modpack_root, modpack_name);
            if (!Directory.Exists(modpack_directory))
            {
                Directory.CreateDirectory(modpack_directory);
            }
            File.Copy(@"Arquivos\launcher_profiles.json", Path.Combine(modpack_directory, "launcher_profiles.json"), true);
            File.Copy(@"Arquivos\.htaccess", Path.Combine(modpack_directory, ".htaccess"), true);
            
            startDownload();
        }

        private void clipboard_copy_click(object sender, EventArgs e)
        {
            Clipboard.SetText(modpack_directory);
            MessageBox.Show(modpack_directory + " paste this folder to forge installer client");
            NextStep(STEP.two);
   

        }
        private string GetJavaInstallationPath()
        {
            string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(environmentPath))
            {
                return environmentPath;
            }

            string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(javaKey))
            {
                string currentVersion = rk.GetValue("CurrentVersion").ToString();
                using (Microsoft.Win32.RegistryKey key = rk.OpenSubKey(currentVersion))
                {
                    return Path.Combine(key.GetValue("JavaHome").ToString(),"bin","java.exe");
                }
            }
        }
         

        private void NextStep(STEP step)
        {
            switch (step)
            {
                case STEP.one:
                btn_download_forge.BackColor = Color.Green;
                btn_download_forge.Enabled = false;
                btn_clipboard_copy.Enabled = true;
                lbl_info.Text = "Download complete. Ready for next step";
                break;

                case STEP.two:
                btn_clipboard_copy.BackColor = Color.Green;
                btn_start_forge.Enabled = true;
                lbl_info.Text = "You clipboard was updated! Paste this to forge installer client";

                break;

                case STEP.three:
                btn_start_forge.BackColor = Color.Green;
                btn_start_forge.Enabled = true;
                lbl_info.Text = "Forge install is complete. Ready for verification step";
                break;

                case STEP.four:
                 lbl_info.Text = "Forge installation complete and modpack created with forge client.";
                break;


            }
        }
        private void checkModPack()
        {
            if (Directory.Exists(Path.Combine(modpack_directory, "versions", minecraft_version)))
            {
                Directory.Delete(Path.Combine(modpack_directory, "versions", minecraft_version), true);
               
            }
            File.Delete(Path.Combine(modpack_directory, forge_name));
            File.Delete(Path.Combine(modpack_directory, "installer.log"));
            NextStep(STEP.four);


        }
        private void startforge_click(object sender, EventArgs e)
        {
            string workingdir = Path.Combine(Application.StartupPath, "web", "files", "files", modpack_name);
         
            Process p = new Process();
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = GetJavaInstallationPath();
            p.StartInfo.WorkingDirectory = workingdir;
            p.StartInfo.Arguments = @"-jar .\" + forge_name;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();
            NextStep(STEP.three);
            checkModPack();

        }

        private void ForgeInstaller_Load(object sender, EventArgs e)
        {
            modpack_directory = Path.Combine(Globals.modpack_root, modpack_name ?? "default");
            forge_name = $"forge-{minecraft_version}-{forge_version}-installer.jar";
            lbl_forge_version.Text = "Installing forge " + forge_version;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

      
        

     
    }
}
