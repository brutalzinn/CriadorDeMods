namespace CriadorDeModpacks
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.add_modpack = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.lbl_modpack_info = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diretorio = new System.Windows.Forms.DataGridViewButtonColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.game_version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forge_version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbx_search = new System.Windows.Forms.ComboBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_sync_modpack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "ModPack:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(606, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Adicionar mod";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(754, 22);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Remover mod";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(153, 528);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 56);
            this.button3.TabIndex = 5;
            this.button3.Text = "Salvar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(29, 528);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 56);
            this.button4.TabIndex = 6;
            this.button4.Text = "Open";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(910, 530);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 53);
            this.button5.TabIndex = 7;
            this.button5.Text = "Gerar ModPack";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(882, 23);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(142, 31);
            this.button6.TabIndex = 8;
            this.button6.Text = "Carregar pasta";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(104, 26);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 28);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // add_modpack
            // 
            this.add_modpack.Location = new System.Drawing.Point(281, 23);
            this.add_modpack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.add_modpack.Name = "add_modpack";
            this.add_modpack.Size = new System.Drawing.Size(47, 31);
            this.add_modpack.TabIndex = 10;
            this.add_modpack.Text = "+";
            this.add_modpack.UseVisualStyleBackColor = true;
            this.add_modpack.Click += new System.EventHandler(this.addmodpack_click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(334, 24);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 31);
            this.button8.TabIndex = 11;
            this.button8.Text = "-";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // lbl_modpack_info
            // 
            this.lbl_modpack_info.AutoSize = true;
            this.lbl_modpack_info.Location = new System.Drawing.Point(29, 72);
            this.lbl_modpack_info.Name = "lbl_modpack_info";
            this.lbl_modpack_info.Size = new System.Drawing.Size(50, 20);
            this.lbl_modpack_info.TabIndex = 12;
            this.lbl_modpack_info.Text = "label2";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(387, 24);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(125, 30);
            this.button10.TabIndex = 14;
            this.button10.Text = "Configurar";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Width = 125;
            // 
            // name
            // 
            this.name.HeaderText = "Nome";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.Width = 125;
            // 
            // directory
            // 
            this.directory.HeaderText = "Diretorio";
            this.directory.MinimumWidth = 6;
            this.directory.Name = "directory";
            this.directory.Width = 125;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1019, 369);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // nome
            // 
            this.nome.HeaderText = "nome";
            this.nome.MinimumWidth = 6;
            this.nome.Name = "nome";
            this.nome.Width = 125;
            // 
            // diretorio
            // 
            this.diretorio.HeaderText = "diretorio";
            this.diretorio.MinimumWidth = 6;
            this.diretorio.Name = "diretorio";
            this.diretorio.Width = 125;
            // 
            // descricao
            // 
            this.descricao.HeaderText = "descricao";
            this.descricao.MinimumWidth = 6;
            this.descricao.Name = "descricao";
            this.descricao.Width = 125;
            // 
            // game_version
            // 
            this.game_version.HeaderText = "minecraft_version";
            this.game_version.MinimumWidth = 6;
            this.game_version.Name = "game_version";
            this.game_version.Width = 125;
            // 
            // forge_version
            // 
            this.forge_version.HeaderText = "forge_version";
            this.forge_version.MinimumWidth = 6;
            this.forge_version.Name = "forge_version";
            this.forge_version.Width = 125;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 27);
            this.textBox1.TabIndex = 16;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cbx_search
            // 
            this.cbx_search.FormattingEnabled = true;
            this.cbx_search.Location = new System.Drawing.Point(281, 109);
            this.cbx_search.Name = "cbx_search";
            this.cbx_search.Size = new System.Drawing.Size(151, 28);
            this.cbx_search.TabIndex = 17;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(438, 109);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(94, 29);
            this.btn_clear.TabIndex = 18;
            this.btn_clear.Text = "Clear Filters";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(733, 118);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // btn_sync_modpack
            // 
            this.btn_sync_modpack.Location = new System.Drawing.Point(754, 531);
            this.btn_sync_modpack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_sync_modpack.Name = "btn_sync_modpack";
            this.btn_sync_modpack.Size = new System.Drawing.Size(141, 53);
            this.btn_sync_modpack.TabIndex = 20;
            this.btn_sync_modpack.Text = "Sincronizar modpacks";
            this.btn_sync_modpack.UseVisualStyleBackColor = true;
            this.btn_sync_modpack.Click += new System.EventHandler(this.btn_sync_modpack_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 600);
            this.Controls.Add(this.btn_sync_modpack);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.cbx_search);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.lbl_modpack_info);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.add_modpack);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private ComboBox comboBox1;
        private Button add_modpack;
        private Button button8;
        private Label lbl_modpack_info;
        private Button button10;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn directory;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn nome;
        private DataGridViewButtonColumn diretorio;
        private DataGridViewTextBoxColumn descricao;
        private DataGridViewTextBoxColumn game_version;
        private DataGridViewTextBoxColumn forge_version;
        private TextBox textBox1;
        public ComboBox cbx_search;
        private Button btn_clear;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_sync_modpack;
    }
}