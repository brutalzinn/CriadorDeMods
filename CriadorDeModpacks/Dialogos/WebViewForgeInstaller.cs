using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Timers;
using System.Web;

namespace CriadorDeModpacks.Dialogos
{
    public partial class WebViewForgeInstaller : Form
    {
        private string minecraft_version { get; set; }
        private string modpack_path { get; set; }
        public string forge_url { get; set; }

        private static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();


        public WebViewForgeInstaller(string minecraft_version, string modpack_path = "")
        {
            InitializeComponent();
            this.minecraft_version = minecraft_version;
            this.modpack_path = modpack_path;
            this.webView21.CoreWebView2InitializationCompleted += WebView21_CoreWebView2InitializationCompleted;
            string url = $"https://files.minecraftforge.net/net/minecraftforge/forge/index_{minecraft_version}.html";
            webView21.Source = new System.Uri(url);
        }

        private void WebView21_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            string script = File.ReadAllText(Path.Combine(Application.StartupPath, "mouse.js"));
            webView21.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(script);
          
        }

        private void WebViewForgeInstaller_Load(object sender, EventArgs e)
        {

        }
        private void CloseForm(DialogResult result)
        {
            DialogResult = result;
            Close();
        }


        private void webView21_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            var jsonObject = JsonConvert.DeserializeObject<JsonButton>(e.WebMessageAsJson);

            switch (jsonObject.Key)
            {
                case "click":
                    var uri = new System.Uri(jsonObject.Value);
                    if (uri == null)
                    {
                        return;
                    }
                    var url = HttpUtility.ParseQueryString(uri.Query).Get("url");
                    if (url != null && url.EndsWith(".jar"))
                    {
                        forge_url = url;
                        Debug.WriteLine("Wait for ads");
                        myTimer.Tick += (o, ea) =>
                        {
                            myTimer.Stop();
                            Debug.WriteLine("User already choose forge version and this tab will close.");
                            Invoke(() => CloseForm(DialogResult.OK));

                        };
                        myTimer.Interval = 12000; // 5 seconds
                        myTimer.Start();

                    }
                  

                break;

            }
        }

       

        public class JsonButton
        {
           
                public string Key { get; set; }
                public string Value { get; set; }
        }
    }
}
