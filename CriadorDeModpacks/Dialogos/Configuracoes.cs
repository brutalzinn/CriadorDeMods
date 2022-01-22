using CriadorDeModpacks.Models;
using Newtonsoft.Json;
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
    public partial class Configuracoes : Form
    {
        public Configuracoes()
        {
            InitializeComponent();
            EnvironmentModel.FillConfigComboBox(cbx_dev_mode);

            txb_api_url.Text = EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url_Api;
            txb_web_url.Text = EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Url;
            txb_api_key.Text = EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Key;
            txb_api_header.Text = EnvironmentModel.GetConfigEnv(Globals.Configuracao.Enviroment).Api_Header;
            cbx_dev_mode.SelectedItem = Globals.Configuracao.Enviroment;
        }
        private void CloseForm(DialogResult result)
        {
            DialogResult = result;
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CloseForm(DialogResult.OK);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            CloseForm(DialogResult.Cancel);
        }

        private void Configuracoes_Load(object sender, EventArgs e)
        {

        }

        private void cbx_dev_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Enviroment = (EnvironmentModel.ENV)cbx_dev_mode.SelectedItem;
      
            txb_web_url.Text = EnvironmentModel.GetConfigEnv(Enviroment).Url;
            txb_api_url.Text = EnvironmentModel.GetConfigEnv(Enviroment).Url_Api;
            txb_api_key.Text = EnvironmentModel.GetConfigEnv(Enviroment).Api_Key;
            txb_api_header.Text = EnvironmentModel.GetConfigEnv(Enviroment).Api_Header;

        }
    }
}
