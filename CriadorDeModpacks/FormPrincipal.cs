using CriadorDeModpacks.Dialogos;
using CriadorDeModpacks.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Forms;

namespace CriadorDeModpacks
{
    public partial class FormPrincipal : Form
    {

      

        public FormPrincipal()
        {
            InitializeComponent();
            CarregarModPacks();
            CarregarModPacksComboBox();
            SalvarConfiguracoes("http://boberto.net");
        }

   

        public List<ModPack> ModPacks { get; set; } = new List<ModPack>();

        public ModPack ModPack { get; set; }

        public void CarregarModPacksComboBox()
        {
            comboBox1.Items.Clear();
            foreach (var item in ModPacks)
            {
                comboBox1.Items.Add(item);
            }
        }
        private void CarregarConfiguracoes()
        {
            var config_json = File.ReadAllText(Globals.filename_config);
            Globals.Configuracao = JsonConvert.DeserializeObject<ConfiguracaoModel>(config_json);
        }
        private void CarregarModPacks()
        {
            if (!File.Exists(Globals.filename))
            {
                return;
            }
            var json = File.ReadAllText(Globals.filename);
            ModPacks = JsonConvert.DeserializeObject<List<ModPack>>(json);
            CarregarModPacksComboBox();
            ListarDataGrid();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModPack = (ModPack)comboBox1.SelectedItem;
            //ListaMods = ModPack.Mods;
            //lbl_modpack_info.Text = $"Nome: {ModPack.Nome} {Environment.NewLine}" +
            //    $"ForgeVersion: {ModPack.ForgeVersion} {Environment.NewLine}" +
            //$"MinecraftVersion: {ModPack.MinecraftVersion}";
            //textBox1.Text = ModPack.Nome;
            ListarDataGrid();
        }

        //botao salvar em json
        private void button3_Click(object sender, EventArgs e)
        {

            var modpacks_defauls = ModPacks.FindAll(e => e.@default == true);

            if(modpacks_defauls.Count != 1) {
                string modpacks_errados = "Há mais de um modpack padrão criado.Faça a correção" + Environment.NewLine;
                foreach(var item in modpacks_defauls)
                {
                    modpacks_errados += item.id + Environment.NewLine;
                }
                MessageBox.Show(modpacks_errados);
            }

            var json = JsonConvert.SerializeObject(ModPacks, Formatting.Indented);
            File.WriteAllText(Globals.filename, json);



        }
        private void ListarDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var mod in ModPacks)
            {
                dataGridView1.Rows.Add(mod.id, mod.name, mod.game_version, mod.forge_version, mod.@default);
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
            //ModGenerator.GerarManifesto(ModPacks);
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
            criarModPack.ShowDialog();
            if (criarModPack.DialogResult == DialogResult.OK)
            {
                ModPacks.Add(criarModPack.ModPack);
                CarregarModPacksComboBox();
            }

        }
        //remover item 
        private void button8_Click(object sender, EventArgs e)
        {
            ModPack = (ModPack)comboBox1.SelectedItem;
            ModPacks.Remove(ModPack);
            ModPacks.Clear();

            CarregarModPacksComboBox();
            ListarDataGrid();
        }

        private void SalvarConfiguracoes(string url)
        {
            var configuracoes = new ConfiguracaoModel();
            configuracoes.Url = url;
            var json = JsonConvert.SerializeObject(configuracoes, Formatting.Indented);
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
       
                var modpack_old = ModPacks.Where(e => e.id == criarModPack.ModPack.id).FirstOrDefault();
                ModPacks.Remove(modpack_old);
                ModPacks.Add(criarModPack.ModPack);
            }

            CarregarModPacksComboBox();
            ListarDataGrid();
        }
    }
}