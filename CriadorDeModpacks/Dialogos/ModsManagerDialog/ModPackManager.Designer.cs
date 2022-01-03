﻿namespace CriadorDeModpacks.Dialogos.ModsManagerDialog
{
    partial class ModPackManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_modpack = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_generate_modpack = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_count = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_modpack)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_modpack
            // 
            this.dgv_modpack.AllowUserToAddRows = false;
            this.dgv_modpack.AllowUserToDeleteRows = false;
            this.dgv_modpack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_modpack.Location = new System.Drawing.Point(-3, 54);
            this.dgv_modpack.MultiSelect = false;
            this.dgv_modpack.Name = "dgv_modpack";
            this.dgv_modpack.RowHeadersWidth = 51;
            this.dgv_modpack.RowTemplate.Height = 29;
            this.dgv_modpack.ShowCellToolTips = false;
            this.dgv_modpack.ShowEditingIcon = false;
            this.dgv_modpack.Size = new System.Drawing.Size(847, 213);
            this.dgv_modpack.TabIndex = 0;
            this.dgv_modpack.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_modpack_CellClick);
            this.dgv_modpack.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_modpack_CellContentClick);
            this.dgv_modpack.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_modpack_CellValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_generate_modpack
            // 
            this.btn_generate_modpack.Location = new System.Drawing.Point(696, 287);
            this.btn_generate_modpack.Name = "btn_generate_modpack";
            this.btn_generate_modpack.Size = new System.Drawing.Size(148, 42);
            this.btn_generate_modpack.TabIndex = 2;
            this.btn_generate_modpack.Text = "Generate";
            this.btn_generate_modpack.UseVisualStyleBackColor = true;
            this.btn_generate_modpack.Click += new System.EventHandler(this.btn_generate_modpack_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(542, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 42);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 287);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(502, 53);
            this.progressBar1.TabIndex = 4;
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(203, 20);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(50, 20);
            this.lbl_count.TabIndex = 5;
            this.lbl_count.Text = "label1";
            // 
            // ModPackManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 352);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_generate_modpack);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgv_modpack);
            this.Name = "ModPackManager";
            this.Text = "ModPackManager";
            this.Load += new System.EventHandler(this.ModPackManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_modpack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgv_modpack;
        private ComboBox comboBox1;
        private Button btn_generate_modpack;
        private Button button2;
        private ProgressBar progressBar1;
        private Label lbl_count;
    }
}