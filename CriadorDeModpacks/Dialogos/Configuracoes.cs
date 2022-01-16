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

            txb_api_url.Text = Globals.Configuracao.Url_Api;
            txb_web_url.Text = Globals.Configuracao.Url;
            txb_api_key.Text = Globals.Configuracao.Api_Key;
            txb_api_header.Text = Globals.Configuracao.Api_Header;

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
    }
}
