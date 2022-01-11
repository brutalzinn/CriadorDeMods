namespace CriadorDeModpacks.Dialogos
{
    partial class ForgeInstaller
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
            this.modpack_creator_backgroundwork = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_download_forge = new System.Windows.Forms.Button();
            this.btn_clipboard_copy = new System.Windows.Forms.Button();
            this.btn_start_forge = new System.Windows.Forms.Button();
            this.lbl_info = new System.Windows.Forms.Label();
            this.lbl_forge_version = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 357);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(561, 33);
            this.progressBar1.TabIndex = 0;
            // 
            // btn_download_forge
            // 
            this.btn_download_forge.Location = new System.Drawing.Point(200, 80);
            this.btn_download_forge.Name = "btn_download_forge";
            this.btn_download_forge.Size = new System.Drawing.Size(185, 60);
            this.btn_download_forge.TabIndex = 2;
            this.btn_download_forge.Text = "1 - Download Forge";
            this.btn_download_forge.UseVisualStyleBackColor = true;
            this.btn_download_forge.Click += new System.EventHandler(this.downloadforge_click);
            // 
            // btn_clipboard_copy
            // 
            this.btn_clipboard_copy.Enabled = false;
            this.btn_clipboard_copy.Location = new System.Drawing.Point(200, 162);
            this.btn_clipboard_copy.Name = "btn_clipboard_copy";
            this.btn_clipboard_copy.Size = new System.Drawing.Size(185, 60);
            this.btn_clipboard_copy.TabIndex = 5;
            this.btn_clipboard_copy.Text = "2 - Copy ModPack directory";
            this.btn_clipboard_copy.UseVisualStyleBackColor = true;
            this.btn_clipboard_copy.Click += new System.EventHandler(this.clipboard_copy_click);
            // 
            // btn_start_forge
            // 
            this.btn_start_forge.Enabled = false;
            this.btn_start_forge.Location = new System.Drawing.Point(147, 246);
            this.btn_start_forge.Name = "btn_start_forge";
            this.btn_start_forge.Size = new System.Drawing.Size(286, 60);
            this.btn_start_forge.TabIndex = 6;
            this.btn_start_forge.Text = "3 - Run Forge and put modpack folder on client";
            this.btn_start_forge.UseVisualStyleBackColor = true;
            this.btn_start_forge.Click += new System.EventHandler(this.startforge_click);
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(22, 323);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(498, 20);
            this.lbl_info.TabIndex = 7;
            this.lbl_info.Text = "Start the process clicking in 1 - download forge and follow the intructions.";
            // 
            // lbl_forge_version
            // 
            this.lbl_forge_version.AutoSize = true;
            this.lbl_forge_version.Location = new System.Drawing.Point(234, 24);
            this.lbl_forge_version.Name = "lbl_forge_version";
            this.lbl_forge_version.Size = new System.Drawing.Size(102, 20);
            this.lbl_forge_version.TabIndex = 8;
            this.lbl_forge_version.Text = "Forge Version:";
            // 
            // ForgeInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 423);
            this.Controls.Add(this.lbl_forge_version);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.btn_start_forge);
            this.Controls.Add(this.btn_clipboard_copy);
            this.Controls.Add(this.btn_download_forge);
            this.Controls.Add(this.progressBar1);
            this.Name = "ForgeInstaller";
            this.Text = "ForgeInstaller";
            this.Load += new System.EventHandler(this.ForgeInstaller_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker modpack_creator_backgroundwork;
        private ProgressBar progressBar1;
        private Button btn_download_forge;
        private Button btn_clipboard_copy;
        private Button btn_start_forge;
        private Label lbl_info;
        private Label lbl_forge_version;
    }
}