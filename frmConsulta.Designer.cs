namespace CriaBD_Crud
{
    partial class frmConsulta
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
            this.dgvContato = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbNome = new System.Windows.Forms.RadioButton();
            this.boxOpConsulta = new System.Windows.Forms.GroupBox();
            this.rbTelefone = new System.Windows.Forms.RadioButton();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.lblTotalLinhas = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContato)).BeginInit();
            this.boxOpConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvContato
            // 
            this.dgvContato.AllowUserToAddRows = false;
            this.dgvContato.AllowUserToDeleteRows = false;
            this.dgvContato.AllowUserToResizeColumns = false;
            this.dgvContato.AllowUserToResizeRows = false;
            this.dgvContato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvContato.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvContato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvContato.EnableHeadersVisualStyles = false;
            this.dgvContato.Location = new System.Drawing.Point(12, 95);
            this.dgvContato.MultiSelect = false;
            this.dgvContato.Name = "dgvContato";
            this.dgvContato.ReadOnly = true;
            this.dgvContato.RowHeadersVisible = false;
            this.dgvContato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContato.Size = new System.Drawing.Size(480, 187);
            this.dgvContato.StandardTab = true;
            this.dgvContato.TabIndex = 0;
            this.dgvContato.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContato_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pesquisar";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(218, 64);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(274, 23);
            this.btnPesquisar.TabIndex = 2;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // rbNome
            // 
            this.rbNome.AutoSize = true;
            this.rbNome.Location = new System.Drawing.Point(6, 17);
            this.rbNome.Name = "rbNome";
            this.rbNome.Size = new System.Drawing.Size(53, 17);
            this.rbNome.TabIndex = 3;
            this.rbNome.TabStop = true;
            this.rbNome.Text = "Nome";
            this.rbNome.UseVisualStyleBackColor = true;
            this.rbNome.CheckedChanged += new System.EventHandler(this.rbNome_CheckedChanged);
            // 
            // boxOpConsulta
            // 
            this.boxOpConsulta.Controls.Add(this.rbTelefone);
            this.boxOpConsulta.Controls.Add(this.rbNome);
            this.boxOpConsulta.Location = new System.Drawing.Point(12, 22);
            this.boxOpConsulta.Name = "boxOpConsulta";
            this.boxOpConsulta.Size = new System.Drawing.Size(200, 65);
            this.boxOpConsulta.TabIndex = 4;
            this.boxOpConsulta.TabStop = false;
            this.boxOpConsulta.Text = "Opções de Consulta";
            // 
            // rbTelefone
            // 
            this.rbTelefone.AutoSize = true;
            this.rbTelefone.Location = new System.Drawing.Point(6, 40);
            this.rbTelefone.Name = "rbTelefone";
            this.rbTelefone.Size = new System.Drawing.Size(67, 17);
            this.rbTelefone.TabIndex = 4;
            this.rbTelefone.TabStop = true;
            this.rbTelefone.Text = "Telefone";
            this.rbTelefone.UseVisualStyleBackColor = true;
            this.rbTelefone.CheckedChanged += new System.EventHandler(this.rbTelefone_CheckedChanged);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Location = new System.Drawing.Point(218, 38);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(274, 20);
            this.txtPesquisa.TabIndex = 5;
            // 
            // lblTotalLinhas
            // 
            this.lblTotalLinhas.AutoSize = true;
            this.lblTotalLinhas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLinhas.Location = new System.Drawing.Point(9, 286);
            this.lblTotalLinhas.Name = "lblTotalLinhas";
            this.lblTotalLinhas.Size = new System.Drawing.Size(102, 15);
            this.lblTotalLinhas.TabIndex = 6;
            this.lblTotalLinhas.Text = "Total de linhas";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(246, 288);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(246, 33);
            this.btnFechar.TabIndex = 7;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 347);
            this.ControlBox = false;
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblTotalLinhas);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.boxOpConsulta);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvContato);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmConsulta";
            this.Load += new System.EventHandler(this.frmConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContato)).EndInit();
            this.boxOpConsulta.ResumeLayout(false);
            this.boxOpConsulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbNome;
        private System.Windows.Forms.GroupBox boxOpConsulta;
        private System.Windows.Forms.RadioButton rbTelefone;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label lblTotalLinhas;
        private System.Windows.Forms.Button btnFechar;
    }
}