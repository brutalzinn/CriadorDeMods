using CriadorDeModpacks.Dialogos;
using CriadorDeModpacks.Models;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using CriadorDeModpacks.Dialogos.ModsManagerDialog;
using CriadorDeModpacks.Utils;

namespace CriadorDeModpacks
{
    public partial class FormPrincipal : Form
    {

        public DataTable dt = new DataTable();
        public ModPack ModPack { get; set; }

        public FormPrincipal()
        {
            InitializeComponent();

      
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.Name = "id_column_column";
            id.HeaderText = "Id";
            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            name.Name = "name_column_column";
            name.HeaderText = "Name";
            DataGridViewTextBoxColumn game_version = new DataGridViewTextBoxColumn();
            game_version.Name = "game_version_column";
            game_version.HeaderText = "Game version";
            DataGridViewTextBoxColumn forge_version = new DataGridViewTextBoxColumn();
            forge_version.Name = "forge_version_column";
            forge_version.HeaderText = "Forge versiom";

            DataGridViewCheckBoxColumn default_Cell = new DataGridViewCheckBoxColumn();
            default_Cell.Name = "defailt_column";
            default_Cell.HeaderText = "Default modpack";

            DataGridViewCheckBoxColumn premium_cell = new DataGridViewCheckBoxColumn();
            premium_cell.Name = "premium_column";
            premium_cell.HeaderText = "Premium modpack";

            DataGridViewButtonColumn openmodpack = new DataGridViewButtonColumn();
            openmodpack.Name = "openmodpack_column";

            //dt.Columns.Add(new DataColumn("id", typeof(string)));
            //dt.Columns.Add(new DataColumn("name", typeof(string)));
            //dt.Columns.Add(new DataColumn("game_version", typeof(string)));
            //dt.Columns.Add(new DataColumn("forge_version", typeof(string)));
            //dt.Columns.Add(new DataColumn("default", typeof(bool)));




            //     dataGridView1.DataSource = dt;
            dataGridView1.Columns.Add(id);
            dataGridView1.Columns.Add(name);
            dataGridView1.Columns.Add(game_version);
            dataGridView1.Columns.Add(forge_version);
            dataGridView1.Columns.Add(default_Cell);
            dataGridView1.Columns.Add(premium_cell);
            dataGridView1.Columns.Add(openmodpack);
            
            CarregarModPacks();
            CarregarModPacksComboBox();
            CarregarConfiguracoes();
           // SalvarConfiguracoes("http://boberto.net");
            Search.FillSearchComboBox(cbx_search);

        }
   
        public void CarregarModPacksComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.SelectedText = String.Empty;
            foreach (var item in Globals.ModPacks)
            {
                comboBox1.Items.Add(item);
            }
        }
        private void CarregarConfiguracoes()
        {
            if (!File.Exists(Globals.filename_config))
            {
                var config = new GenericConfigModel();
                config.Enviroment = EnvironmentModel.ENV.DEV;
                var model = new ConfigModel()
                {
                    Dev_mode = EnvironmentModel.ENV.DEV,
                    Api_Header = "api-key",
                    Api_Key = "teste",
                    Url_Api = "http://127.0.0.1",
                    Url = "http://127.0.0.1"
                };
                config.Configs = new List<ConfigModel>();
                config.Configs.Add(model);
                var json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(Globals.filename_config, json);
            }
            var config_json = File.ReadAllText(Globals.filename_config);
            Globals.Configuracao = JsonConvert.DeserializeObject<GenericConfigModel>(config_json);
        }
        private void CarregarModPacks()
        {
            if (!File.Exists(Globals.filename))
            {
                return;
            }
            var json = File.ReadAllText(Globals.filename);
            Globals.ModPacks = JsonConvert.DeserializeObject<List<ModPack>>(json);
            CarregarModPacksComboBox();
            ListarDataGrid();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModPack = (ModPack)comboBox1.SelectedItem;
            ListarDataGrid();
        }

        public void saveAllModpacks()
        {
            var modpacks_defauls = Globals.ModPacks.FindAll(e => e.@default == true);

            if (modpacks_defauls.Count > 1)
            {
                string modpacks_errados = "Há mais de um modpack padrão criado.Faça a correção" + Environment.NewLine;
                foreach (var item in modpacks_defauls)
                {
                    modpacks_errados += item.id + Environment.NewLine;
                }
                MessageBox.Show(modpacks_errados);
                return;
            }
            if (!File.Exists(Globals.filename))
            {
                File.Create(Globals.filename);
            }
            var json = JsonConvert.SerializeObject(Globals.ModPacks, Formatting.Indented);
            File.WriteAllText(Globals.filename, json);
        }
        //botao salvar em json
        private void button3_Click(object sender, EventArgs e)
        {
            saveAllModpacks();





        }
        private void ListarDataGrid()
        {
            if(dataGridView1.Rows.Count > 0)
            {
               dataGridView1.Rows.Clear();

            }
            foreach (var mod in Globals.ModPacks)
            {
                dataGridView1.Rows.Add(mod.id, mod.name, mod.game_version, mod.forge_version, mod.@default, mod.premium, "Open modpack folder");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories);

                    foreach (var item in files)
                    {
                        FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(item);

                        //var mod = new Mod
                        //{
                        //    Caminho = item,
                        //    Pasta = Path.GetFileName(Path.GetDirectoryName(item)),
                        //    Nome = Path.GetFileName(item),
                        //    Versao = myFileVersionInfo.FileVersion ?? "1.0.0.0"

                        //};
                        //ListaMods.Add(mod);
                    }
                    //ModPack.Mods = ListaMods;
                    ListarDataGrid();
                }
            }
        }
        // carregar mods

   
        private void button4_Click(object sender, EventArgs e)
        {
            CarregarModPacks();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var modpack = new ModPackManager();
            modpack.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
             
                CheckFileExists = true,
                CheckPathExists = true,
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

               
                FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(openFileDialog1.FileName);

                //var mod = new Mod
                //{
                //    Caminho = openFileDialog1.FileName,
                //    Nome = Path.GetFileName(openFileDialog1.FileName),
                //    Versao = myFileVersionInfo.FileVersion ?? "1.0.0.0"
                //};
                //AdicionarMod(mod);
            }
        }
        private void AdicionarModPack(ModPack mod)
        {
            //ListaMods.Add(mod);
            ListarDataGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //adicionar novo item
        private void addmodpack_click(object sender, EventArgs e)
        {
            var criarModPack = new CriarModPack();
            criarModPack.txb_id.Text  = Guid.NewGuid().ToString();
            criarModPack.creat_at = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

            criarModPack.ShowDialog();
            if (criarModPack.DialogResult == DialogResult.OK)
            {
                var modpack_directory = Path.Combine(Globals.modpack_root, criarModPack.txb_diretory.Text);
                if (!Directory.Exists(modpack_directory))
                {
                    Directory.CreateDirectory(modpack_directory);
                }
                Utils.ApiUtils.CreateServerFile(criarModPack.ModPack);
                Utils.ApiUtils.CreateModPackFiles(criarModPack.ModPack.directory);
                //  criarModPack.ModPack.datetime_creat_at = d
                Globals.ModPacks.Add(criarModPack.ModPack);

                CarregarModPacksComboBox();
                saveAllModpacks();
            }
            ListarDataGrid();
        }
        //remover item 
        private void button8_Click(object sender, EventArgs e)
        {
            ModPack = (ModPack)comboBox1.SelectedItem;
            Globals.ModPacks.Remove(ModPack);
         

            CarregarModPacksComboBox();
            ListarDataGrid();
            saveAllModpacks();
        }

        private void SalvarConfiguracoes(ConfigModel model)
        {
            EnvironmentModel.addConfigEnv(model, Globals.Configuracao.Enviroment);
            Globals.Configuracao.Enviroment = model.Dev_mode;
            var json = JsonConvert.SerializeObject(Globals.Configuracao, Formatting.Indented);
            File.WriteAllText(Application.StartupPath + @"\config.json", json);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ModPack = (ModPack)comboBox1.SelectedItem;
            if(ModPack == null)
            {
                return;
            }
            var criarModPack = new CriarModPack(ModPack);
    
            criarModPack.ShowDialog();
            if (criarModPack.DialogResult == DialogResult.OK)
            {
       
                var modpack_old = Globals.ModPacks.Where(e => e.id == criarModPack.ModPack.id).FirstOrDefault();
                Globals.ModPacks.Remove(modpack_old);
                Globals.ModPacks.Add(criarModPack.ModPack);
                ApiUtils.CreateModPackFiles(criarModPack.ModPack.directory);

                saveAllModpacks();
            }
            
            
            CarregarModPacksComboBox();
            ListarDataGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<ModPack> ModPacks_Filters = new List<ModPack>();
            switch (cbx_search.SelectedItem)
            {
                case Search.TIPOS.id:
                ModPacks_Filters = Globals.ModPacks.FindAll(e => e.id.Contains(textBox1.Text)).ToList();
                break;
                case Search.TIPOS.nome:
                ModPacks_Filters = Globals.ModPacks.FindAll(e => e.name.Contains(textBox1.Text)).ToList();
                break;
                case Search.TIPOS.game_version:
                ModPacks_Filters = Globals.ModPacks.FindAll(e => e.game_version.Contains(textBox1.Text)).ToList();
                break;
                case Search.TIPOS.forge_version:
                ModPacks_Filters = Globals.ModPacks.FindAll(e => e.forge_version.Contains(textBox1.Text)).ToList();
                break;
                case Search.TIPOS.author:
                ModPacks_Filters = Globals.ModPacks.FindAll(e => e.author.Contains(textBox1.Text)).ToList();
                break;
            }
            dataGridView1.Rows.Clear();
            foreach (var mod in ModPacks_Filters)
            {
                dataGridView1.Rows.Add(mod.id, mod.name, mod.game_version, mod.forge_version, mod.@default, mod.premium, "Open modpack");
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            ListarDataGrid();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //dt.Rows.Add(mod.id, mod.name, mod.game_version, mod.forge_version, mod.@default);

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string id = row.Cells[0].Value.ToString();
            string name = row.Cells[1].Value.ToString();
            string game_version = row.Cells[2].Value.ToString();
            string forge_version = row.Cells[3].Value.ToString();
            bool  @default = (bool)row.Cells[4].Value;

            var modpack_old = Globals.ModPacks.Where(e => e.id == id).FirstOrDefault();
            modpack_old.name = name;
            modpack_old.game_version = game_version;
            modpack_old.forge_version = forge_version;
            modpack_old.@default = @default;
            Globals.ModPacks.Remove(modpack_old);
            Globals.ModPacks.Add(modpack_old);
            CarregarModPacksComboBox();




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["openmodpack_column"].Index) {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string id = row.Cells[0].Value.ToString();
                var modpack = Globals.ModPacks.Where(e => e.id == id).FirstOrDefault();
                string modpack_dir = Path.Combine(Globals.modpack_root, modpack.directory);
                if (Directory.Exists(modpack_dir))
                {
                    Process.Start("explorer.exe", modpack_dir);
                }
                else
                {
                    MessageBox.Show("Modpack without folder created.");
                }

                //Do something with your button.
            }
        }

        private void btn_sync_modpack_Click(object sender, EventArgs e)
        {
            Utils.ApiUtils.SyncModPacks(Globals.ModPacks);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_configuracoes_Click(object sender, EventArgs e)
        {
            var configuracoesForm = new Configuracoes();
            CarregarConfiguracoes();
            configuracoesForm.txb_web_url.Text = EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url;
            configuracoesForm.txb_api_url.Text = EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url_Api;
            configuracoesForm.txb_api_key.Text = EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Key;
            configuracoesForm.txb_api_header.Text = EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Header;


            configuracoesForm.ShowDialog();
            if (configuracoesForm.DialogResult == DialogResult.OK)
            {
                var config = new ConfigModel();

                var ConfigModel = configuracoesForm.cbx_dev_mode.SelectedItem;
                if (ConfigModel != null)
                {
                    config.Dev_mode = (EnvironmentModel.ENV)ConfigModel;
                }
                config.Url = configuracoesForm.txb_web_url.Text;
                config.Url_Api = configuracoesForm.txb_api_url.Text;
                config.Api_Key = configuracoesForm.txb_api_key.Text;
                config.Api_Header = configuracoesForm.txb_api_header.Text;
                SalvarConfiguracoes(config);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
           
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var launcherUpdateForm = new LauncherUpdate();
            CarregarConfiguracoes();
            launcherUpdateForm.ShowDialog();
        
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var launcherUpdateForm = new WebViewForgeInstaller("1.12.2");
            launcherUpdateForm.ShowDialog();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {

        }
    }
}