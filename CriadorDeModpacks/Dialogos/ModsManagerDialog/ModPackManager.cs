﻿using CriadorDeModpacks.Models;
using CriadorDeModpacks.Utils;
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
    public partial class ModPackManager : Form
    {

        private List<ModPack> ModPacksChecked { get; set; } = new List<ModPack>();

        public ModPackManager()
        {
            InitializeComponent();
            DataGridViewCheckBoxColumn modselected = new DataGridViewCheckBoxColumn();
            modselected.Width = 200;
            modselected.Name = "modpack_checked";
            modselected.HeaderText = "Select";


            DataGridViewTextBoxColumn modpack_id = new DataGridViewTextBoxColumn();
            modpack_id.Width = 200;
            modpack_id.Name = "file_id";
            modpack_id.HeaderText = "Name";

            DataGridViewTextBoxColumn modpackname = new DataGridViewTextBoxColumn();
            modpackname.Width = 200;
            modpackname.Name = "file_name";
            modpackname.HeaderText = "Name";
            DataGridViewTextBoxColumn modpack_dir = new DataGridViewTextBoxColumn();
            modpack_dir.Width = 200;
            modpack_dir.Name = "file_dir";
            modpack_dir.HeaderText = "Dir";

            DataGridViewButtonColumn buttonmodpack = new DataGridViewButtonColumn();
            buttonmodpack.Name = "openmodpack_column";
            buttonmodpack.HeaderText = "Controller";
            buttonmodpack.Width = 200;
            dgv_modpack.Columns.Add(modselected);
            dgv_modpack.Columns.Add(modpack_id);
            dgv_modpack.Columns.Add(modpackname);
            dgv_modpack.Columns.Add(modpack_dir);
            dgv_modpack.Columns.Add(buttonmodpack);

            HostUtils.FillHostModPack(comboBox1);

        }
        private void GenerateLocalModPacks()
        {
            dgv_modpack.Rows.Clear();
            foreach (var modpack in Globals.ModPacks)
            {
                string path_name = Path.Combine(Globals.modpack_root, modpack.directory);
                dgv_modpack.Rows.Add(false, modpack.id, modpack.name, path_name, "Ações");
            }
        }
        private void GenerateRemoteModPacks()
        {

        }

        private void ModPackManager_Load(object sender, EventArgs e)
        {


        }

        private void dgv_modpack_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_modpack.Rows[e.RowIndex];

            if (e.ColumnIndex == dgv_modpack.Columns["openmodpack_column"].Index)
            {
                string modpack_name = row.Cells[1].Value.ToString();
                string modpack_dir = row.Cells[2].Value.ToString();
                var modpackAction = new ModPackActionManager(modpack_name, modpack_dir);
                modpackAction.ShowDialog();
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tipo = comboBox1.SelectedItem;

            switch (tipo)
            {
                case HostUtils.TIPOS.local:
                    GenerateLocalModPacks();
                    break;
            }
        }
        async void StartBackground()

        {
            Utils.ApiUtils.progress_bar = progress_bar_modpack;
            Utils.ApiUtils.progress_txt = lbl_progress_bar_modpack;

            progress_bar_complete.Invoke(() => progress_bar_complete.Maximum = ModPacksChecked.Count);
            progress_bar_complete.Invoke(() => progress_bar_complete.Value = 0);
            progress_bar_modpack.Invoke(() => progress_bar_modpack.Value = 0);
            foreach (ModPack modpack in ModPacksChecked)
            {
                string path = Path.Combine(Globals.modpack_root, $"{modpack.directory.Replace(" ", "_").ToLower()}.zip");
                lbl_status.Invoke(() => lbl_status.Text = $"Preparing to zip modpack.. {modpack.name} 1/2");
                Utils.ApiUtils.GenerateModPackZip(modpack);
                lbl_status.Invoke(() => lbl_status.Text = $"Zip Ready. Sending modpack to server.. {modpack.name} 2/2");
                if(!await Utils.ApiUtils.UploadModPack(path, modpack.directory))
                {
                    lbl_status.Invoke(() => lbl_status.Text = $"Modpack uploaded {modpack.name} with error.");
                }

                lbl_status.Invoke(() => lbl_status.Text = $"Modpack uploaded {modpack.name} with success.");
                progress_bar_complete.Invoke(() => progress_bar_complete.Value += 1);
                lbl_progress_complete.Invoke(() => lbl_progress_complete.Text = $"{progress_bar_complete.Value}/{ModPacksChecked.Count}");
                if (Utils.ApiUtils.AppendModPack(modpack))
                {
                    lbl_status.Invoke(() => lbl_status.Text = $"{modpack.name} uploaded.");
                }
                try
                {
                    Utils.ApiUtils.RedisClearModPack(modpack);
                }
                catch (System.Net.WebException)
                {

                }
            }

            lbl_progress_bar_modpack.Invoke(() => lbl_progress_bar_modpack.Text = $"All modpacks uploaded.");
         
        }


        private void btn_generate_modpack_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(StartBackground);          // Kick off a new thread
            t.Start();
        }

        private void dgv_modpack_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_modpack.Rows[e.RowIndex];

            var ch1 = (DataGridViewCheckBoxCell)dgv_modpack.Rows[dgv_modpack.CurrentRow.Index].Cells[0];
            var modpack_id = (DataGridViewTextBoxCell)dgv_modpack.Rows[dgv_modpack.CurrentRow.Index].Cells[1];
            var modpack_name = (DataGridViewTextBoxCell)dgv_modpack.Rows[dgv_modpack.CurrentRow.Index].Cells[2];
            var modpack_dir = (DataGridViewTextBoxCell)dgv_modpack.Rows[dgv_modpack.CurrentRow.Index].Cells[3];

            bool modpack_cheked = false;

            if (ch1.Value == null)
                modpack_cheked = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    modpack_cheked = false;
                    ch1.Value = false;
                    break;
                case "False":
                    ch1.Value = true;
                    modpack_cheked = true;
                    break;
            }
    
            var modpack_finder = Globals.ModPacks.Where(v => v.id.Equals(modpack_id.Value.ToString())).FirstOrDefault();
            var checkModpackChecked = ModPacksChecked.Where(v => v.id.Equals(modpack_id.Value.ToString())).FirstOrDefault();
            if (modpack_cheked)
            {
                if (modpack_finder != null && checkModpackChecked == null)
                {
                    ModPacksChecked.Add(modpack_finder);
                }
            }
            else
            {

                if (modpack_finder != null && checkModpackChecked != null)
                {
                    ModPacksChecked.Remove(modpack_finder);
                }

            }

            lbl_count.Text = ModPacksChecked.Count.ToString();


        }

        private void dgv_modpack_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
