using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CriaBD_Crud
{
    public partial class frmContato : CriaBD_Crud.Modelos.Modelo_Cadastro
    {
        DTOContato DTOContato;
        BLLContato BLLContato;

        public void LimpaTela()
        {
            List<Control> LimpaCampos = new List<Control>() { txtNome, txtTelefone };

            foreach (Control campo in LimpaCampos)
            {
                campo.Text = "";
            }
            txtNome.Focus();
        }
        public frmContato()
        {
            InitializeComponent();
            AlteraBotoes(1);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaTela();
            AlteraBotoes(2);
            txtNome.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            DTOContato = new DTOContato();
            DTOContato.Nome = txtNome.Text;
            DTOContato.Telefone = txtTelefone.Text;

            BLLContato = new BLLContato();
            BLLContato.Incluir(DTOContato);

            if (DTOContato.IdContato != 0)
            {
                MessageBox.Show("Cadastro nº " + DTOContato.IdContato + " efetuado com sucesso", "CADASTRO CONTATO");
                AlteraBotoes(2);
                LimpaTela();
            }
            else
            {
                MessageBox.Show("Registro não efetuado", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //fazer pergunta se quer sair (FALTA FAZER)
            AlteraBotoes(1);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
