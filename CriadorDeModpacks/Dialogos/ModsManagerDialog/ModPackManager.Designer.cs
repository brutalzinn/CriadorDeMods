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
            this.btn_generate_modpack = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.progress_bar_modpack = new System.Windows.Forms.ProgressBar();
            this.lbl_count = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.progress_bar_complete = new System.Windows.Forms.ProgressBar();
            this.lbl_progress_complete = new System.Windows.Forms.Label();
            this.lbl_progress_bar_modpack = new System.Windows.Forms.Label();
            this.lbl_enviroment = new System.Windows.Forms.Label();
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
            this.dgv_modpack.Size = new System.Drawing.Size(1082, 213);
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
            this.btn_generate_modpack.Location = new System.Drawing.Point(931, 287);
            this.btn_generate_modpack.Name = "btn_generate_modpack";
            this.btn_generate_modpack.Size = new System.Drawing.Size(148, 42);
            this.btn_generate_modpack.TabIndex = 2;
            this.btn_generate_modpack.Text = "Upload";
            this.btn_generate_modpack.UseVisualStyleBackColor = true;
            this.btn_generate_modpack.Click += new System.EventHandler(this.btn_generate_modpack_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(777, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 42);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // progress_bar_modpack
            // 
            this.progress_bar_modpack.Location = new System.Drawing.Point(12, 311);
            this.progress_bar_modpack.Name = "progress_bar_modpack";
            this.progress_bar_modpack.Size = new System.Drawing.Size(502, 29);
            this.progress_bar_modpack.TabIndex = 4;
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(817, 12);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(50, 20);
            this.lbl_count.TabIndex = 5;
            this.lbl_count.Text = "label1";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(996, 15);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(70, 20);
            this.lbl_status.TabIndex = 6;
            this.lbl_status.Text = "lbl_status";
            // 
            // progress_bar_complete
            // 
            this.progress_bar_complete.Location = new System.Drawing.Point(12, 276);
            this.progress_bar_complete.Name = "progress_bar_complete";
            this.progress_bar_complete.Size = new System.Drawing.Size(502, 29);
            this.progress_bar_complete.TabIndex = 7;
            // 
            // lbl_progress_complete
            // 
            this.lbl_progress_complete.AutoSize = true;
            this.lbl_progress_complete.Location = new System.Drawing.Point(532, 285);
            this.lbl_progress_complete.Name = "lbl_progress_complete";
            this.lbl_progress_complete.Size = new System.Drawing.Size(17, 20);
            this.lbl_progress_complete.TabIndex = 8;
            this.lbl_progress_complete.Text = "0";
            // 
            // lbl_progress_bar_modpack
            // 
            this.lbl_progress_bar_modpack.AutoSize = true;
            this.lbl_progress_bar_modpack.Location = new System.Drawing.Point(532, 320);
            this.lbl_progress_bar_modpack.Name = "lbl_progress_bar_modpack";
            this.lbl_progress_bar_modpack.Size = new System.Drawing.Size(17, 20);
            this.lbl_progress_bar_modpack.TabIndex = 9;
            this.lbl_progress_bar_modpack.Text = "0";
            // 
            // lbl_enviroment
            // 
            this.lbl_enviroment.AutoSize = true;
            this.lbl_enviroment.Location = new System.Drawing.Point(207, 15);
            this.lbl_enviroment.Name = "lbl_enviroment";
            this.lbl_enviroment.Size = new System.Drawing.Size(50, 20);
            this.lbl_enviroment.TabIndex = 10;
            this.lbl_enviroment.Text = "label1";
            // 
            // ModPackManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 352);
            this.Controls.Add(this.lbl_enviroment);
            this.Controls.Add(this.lbl_progress_bar_modpack);
            this.Controls.Add(this.lbl_progress_complete);
            this.Controls.Add(this.progress_bar_complete);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.progress_bar_modpack);
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
        private ProgressBar progress_bar_modpack;
        private Label lbl_count;
        private Label lbl_status;
        private ProgressBar progress_bar_complete;
        private Label lbl_progress_complete;
        private Label lbl_progress_bar_modpack;
        private Label lbl_enviroment;
    }
}