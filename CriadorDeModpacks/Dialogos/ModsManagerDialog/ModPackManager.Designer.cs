namespace CriadorDeModpacks.Dialogos.ModsManagerDialog
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_modpack)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_modpack
            // 
            this.dgv_modpack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_modpack.Location = new System.Drawing.Point(-3, 54);
            this.dgv_modpack.Name = "dgv_modpack";
            this.dgv_modpack.RowHeadersWidth = 51;
            this.dgv_modpack.RowTemplate.Height = 29;
            this.dgv_modpack.Size = new System.Drawing.Size(735, 213);
            this.dgv_modpack.TabIndex = 0;
            this.dgv_modpack.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_modpack_CellClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 28);
            this.comboBox1.TabIndex = 1;
            // 
            // ModPackManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 298);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgv_modpack);
            this.Name = "ModPackManager";
            this.Text = "ModPackManager";
            this.Load += new System.EventHandler(this.ModPackManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_modpack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgv_modpack;
        private ComboBox comboBox1;
    }
}