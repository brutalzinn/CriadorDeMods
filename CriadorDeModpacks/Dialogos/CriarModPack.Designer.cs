namespace CriadorDeModpacks.Dialogos
{
    partial class CriarModPack
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
            this.txb_forge_version = new System.Windows.Forms.TextBox();
            this.txb_minecraft_version = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_error = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txb_fabric_version = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txb_id = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_img = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_port = new System.Windows.Forms.TextBox();
            this.txb_ip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_nome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_salvar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.ckb_default = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_install_fabric = new System.Windows.Forms.Button();
            this.ckb_verify_mods = new System.Windows.Forms.CheckBox();
            this.ckb_premium = new System.Windows.Forms.CheckBox();
            this.btn_install_forge = new System.Windows.Forms.Button();
            this.txb_description = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_autor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_diretory = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txb_forge_version
            // 
            this.txb_forge_version.Location = new System.Drawing.Point(97, 106);
            this.txb_forge_version.Name = "txb_forge_version";
            this.txb_forge_version.Size = new System.Drawing.Size(126, 27);
            this.txb_forge_version.TabIndex = 0;
            this.txb_forge_version.TextChanged += new System.EventHandler(this.txb_forge_version_TextChanged);
            // 
            // txb_minecraft_version
            // 
            this.txb_minecraft_version.Location = new System.Drawing.Point(97, 181);
            this.txb_minecraft_version.Name = "txb_minecraft_version";
            this.txb_minecraft_version.Size = new System.Drawing.Size(125, 27);
            this.txb_minecraft_version.TabIndex = 1;
            this.txb_minecraft_version.TextChanged += new System.EventHandler(this.txb_minecraft_version_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_error);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txb_fabric_version);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txb_id);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txb_img);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txb_port);
            this.groupBox1.Controls.Add(this.txb_ip);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txb_nome);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txb_minecraft_version);
            this.groupBox1.Controls.Add(this.txb_forge_version);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 385);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurations - Modpack";
            // 
            // lbl_error
            // 
            this.lbl_error.AutoSize = true;
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(11, 351);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(41, 20);
            this.lbl_error.TabIndex = 12;
            this.lbl_error.Text = "Error";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Fabric:";
            // 
            // txb_fabric_version
            // 
            this.txb_fabric_version.Location = new System.Drawing.Point(97, 141);
            this.txb_fabric_version.Name = "txb_fabric_version";
            this.txb_fabric_version.Size = new System.Drawing.Size(126, 27);
            this.txb_fabric_version.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Id:";
            // 
            // txb_id
            // 
            this.txb_id.Location = new System.Drawing.Point(96, 27);
            this.txb_id.Name = "txb_id";
            this.txb_id.Size = new System.Drawing.Size(126, 27);
            this.txb_id.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Image Url:";
            // 
            // txb_img
            // 
            this.txb_img.Location = new System.Drawing.Point(96, 285);
            this.txb_img.Name = "txb_img";
            this.txb_img.Size = new System.Drawing.Size(125, 27);
            this.txb_img.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ip:";
            // 
            // txb_port
            // 
            this.txb_port.Location = new System.Drawing.Point(96, 252);
            this.txb_port.Name = "txb_port";
            this.txb_port.Size = new System.Drawing.Size(125, 27);
            this.txb_port.TabIndex = 8;
            // 
            // txb_ip
            // 
            this.txb_ip.Location = new System.Drawing.Point(96, 217);
            this.txb_ip.Name = "txb_ip";
            this.txb_ip.Size = new System.Drawing.Size(125, 27);
            this.txb_ip.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name:";
            // 
            // txb_nome
            // 
            this.txb_nome.Location = new System.Drawing.Point(97, 68);
            this.txb_nome.Name = "txb_nome";
            this.txb_nome.Size = new System.Drawing.Size(126, 27);
            this.txb_nome.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Minecraft:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Forge:";
            // 
            // btn_salvar
            // 
            this.btn_salvar.Location = new System.Drawing.Point(576, 363);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(101, 34);
            this.btn_salvar.TabIndex = 7;
            this.btn_salvar.Text = "SAVE";
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(469, 363);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(101, 34);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "CANCEL";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // ckb_default
            // 
            this.ckb_default.AutoSize = true;
            this.ckb_default.Location = new System.Drawing.Point(17, 38);
            this.ckb_default.Name = "ckb_default";
            this.ckb_default.Size = new System.Drawing.Size(80, 24);
            this.ckb_default.TabIndex = 9;
            this.ckb_default.Text = "Default";
            this.ckb_default.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_install_fabric);
            this.groupBox2.Controls.Add(this.ckb_verify_mods);
            this.groupBox2.Controls.Add(this.ckb_premium);
            this.groupBox2.Controls.Add(this.btn_install_forge);
            this.groupBox2.Controls.Add(this.txb_description);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txb_autor);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txb_diretory);
            this.groupBox2.Controls.Add(this.ckb_default);
            this.groupBox2.Location = new System.Drawing.Point(303, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 331);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configurations - Importants";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btn_install_fabric
            // 
            this.btn_install_fabric.Enabled = false;
            this.btn_install_fabric.Location = new System.Drawing.Point(239, 82);
            this.btn_install_fabric.Name = "btn_install_fabric";
            this.btn_install_fabric.Size = new System.Drawing.Size(122, 37);
            this.btn_install_fabric.TabIndex = 19;
            this.btn_install_fabric.Text = "Install fabric";
            this.btn_install_fabric.UseVisualStyleBackColor = true;
            this.btn_install_fabric.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ckb_verify_mods
            // 
            this.ckb_verify_mods.AutoSize = true;
            this.ckb_verify_mods.Location = new System.Drawing.Point(232, 37);
            this.ckb_verify_mods.Name = "ckb_verify_mods";
            this.ckb_verify_mods.Size = new System.Drawing.Size(109, 24);
            this.ckb_verify_mods.TabIndex = 18;
            this.ckb_verify_mods.Text = "Verify Mods";
            this.ckb_verify_mods.UseVisualStyleBackColor = true;
            // 
            // ckb_premium
            // 
            this.ckb_premium.AutoSize = true;
            this.ckb_premium.Location = new System.Drawing.Point(103, 37);
            this.ckb_premium.Name = "ckb_premium";
            this.ckb_premium.Size = new System.Drawing.Size(127, 24);
            this.ckb_premium.TabIndex = 17;
            this.ckb_premium.Text = "Premium users";
            this.ckb_premium.UseVisualStyleBackColor = true;
            // 
            // btn_install_forge
            // 
            this.btn_install_forge.Enabled = false;
            this.btn_install_forge.Location = new System.Drawing.Point(239, 126);
            this.btn_install_forge.Name = "btn_install_forge";
            this.btn_install_forge.Size = new System.Drawing.Size(122, 37);
            this.btn_install_forge.TabIndex = 16;
            this.btn_install_forge.Text = "Install forge";
            this.btn_install_forge.UseVisualStyleBackColor = true;
            this.btn_install_forge.Click += new System.EventHandler(this.button1_Click);
            // 
            // txb_description
            // 
            this.txb_description.Location = new System.Drawing.Point(17, 169);
            this.txb_description.Name = "txb_description";
            this.txb_description.Size = new System.Drawing.Size(344, 147);
            this.txb_description.TabIndex = 15;
            this.txb_description.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Description:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Author:";
            // 
            // txb_autor
            // 
            this.txb_autor.Location = new System.Drawing.Point(95, 103);
            this.txb_autor.Name = "txb_autor";
            this.txb_autor.Size = new System.Drawing.Size(125, 27);
            this.txb_autor.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Directory:";
            // 
            // txb_diretory
            // 
            this.txb_diretory.Location = new System.Drawing.Point(96, 67);
            this.txb_diretory.Name = "txb_diretory";
            this.txb_diretory.Size = new System.Drawing.Size(124, 27);
            this.txb_diretory.TabIndex = 10;
            this.txb_diretory.TextChanged += new System.EventHandler(this.txb_diretory_TextChanged);
            // 
            // CriarModPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 406);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_salvar);
            this.Name = "CriarModPack";
            this.Text = "ModPack creator";
            this.Load += new System.EventHandler(this.CriarModPack_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btn_salvar;
        private Button btn_cancelar;
        private Label label5;
        private Label label4;
        private GroupBox groupBox2;
        private Label label7;
        private Label label6;
        private Label label9;
        private Label label8;
        public TextBox txb_ip;
        public TextBox txb_port;
        public CheckBox ckb_default;
        public TextBox txb_autor;
        public TextBox txb_diretory;
        public TextBox txb_img;
        public RichTextBox txb_description;
        public TextBox txb_forge_version;
        public TextBox txb_minecraft_version;
        public TextBox txb_nome;
        private Label label10;
        public TextBox txb_id;
        private Label lbl_error;
        private Button btn_install_forge;
        private CheckBox ckb_premium;
        private CheckBox ckb_verify_mods;
        private Button btn_install_fabric;
        private Label label11;
        public TextBox txb_fabric_version;
    }
}