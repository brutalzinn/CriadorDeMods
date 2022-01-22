namespace CriadorDeModpacks.Dialogos
{
    partial class Configuracoes
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
            this.btn_salvar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.txb_api_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_api_key = new System.Windows.Forms.TextBox();
            this.txb_web_url = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_api_header = new System.Windows.Forms.TextBox();
            this.cbx_dev_mode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_salvar
            // 
            this.btn_salvar.Location = new System.Drawing.Point(313, 228);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(102, 46);
            this.btn_salvar.TabIndex = 0;
            this.btn_salvar.Text = "SAVE";
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(205, 228);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(102, 46);
            this.btn_cancelar.TabIndex = 1;
            this.btn_cancelar.Text = "CANCEL";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // txb_api_url
            // 
            this.txb_api_url.Location = new System.Drawing.Point(125, 85);
            this.txb_api_url.Name = "txb_api_url";
            this.txb_api_url.Size = new System.Drawing.Size(290, 27);
            this.txb_api_url.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "API-URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "API-KEY:";
            // 
            // txb_api_key
            // 
            this.txb_api_key.Location = new System.Drawing.Point(125, 150);
            this.txb_api_key.Name = "txb_api_key";
            this.txb_api_key.Size = new System.Drawing.Size(290, 27);
            this.txb_api_key.TabIndex = 4;
            // 
            // txb_web_url
            // 
            this.txb_web_url.Location = new System.Drawing.Point(125, 118);
            this.txb_web_url.Name = "txb_web_url";
            this.txb_web_url.Size = new System.Drawing.Size(290, 27);
            this.txb_web_url.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "URL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "API-HEADER:";
            // 
            // txb_api_header
            // 
            this.txb_api_header.Location = new System.Drawing.Point(125, 183);
            this.txb_api_header.Name = "txb_api_header";
            this.txb_api_header.Size = new System.Drawing.Size(290, 27);
            this.txb_api_header.TabIndex = 8;
            // 
            // cbx_dev_mode
            // 
            this.cbx_dev_mode.FormattingEnabled = true;
            this.cbx_dev_mode.Location = new System.Drawing.Point(125, 12);
            this.cbx_dev_mode.Name = "cbx_dev_mode";
            this.cbx_dev_mode.Size = new System.Drawing.Size(290, 28);
            this.cbx_dev_mode.TabIndex = 10;
            this.cbx_dev_mode.SelectedIndexChanged += new System.EventHandler(this.cbx_dev_mode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ambient:";
            // 
            // Configuracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 296);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbx_dev_mode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_api_header);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_web_url);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_api_key);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_api_url);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_salvar);
            this.Name = "Configuracoes";
            this.Text = "Configurations";
            this.Load += new System.EventHandler(this.Configuracoes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_salvar;
        private Button btn_cancelar;
        private Label label1;
        public TextBox txb_api_url;
        private Label label2;
        public TextBox txb_api_key;
        public TextBox txb_web_url;
        private Label label3;
        private Label label4;
        public TextBox txb_api_header;
        private Label label5;
        public ComboBox cbx_dev_mode;
    }
}