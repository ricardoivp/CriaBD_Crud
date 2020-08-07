using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CriaBD_Crud
{
    public partial class frmContato : CriaBD_Crud.Modelos.Modelo_Cadastro
    {
        DTOContato DTOContato;
        BLLContato BLLContato;
        List<cl_GestorBD.SQLParametro> param;
        int idContato = -1;
        string query = "";
        string acao = "Inserir"; // será alternado entre Inserir e Alterar

        public void LimpaTela()
        {
            List<Control> LimpaCampos = new List<Control>() { txtNome, txtTelefone, lbl_idContato };

            foreach (Control campo in LimpaCampos)
            {
                campo.Text = "";
            }
            txtNome.Focus();
            lbl_idContato.Visible = false;
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
            acao = "Inserir";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlteraBotoes(2);
            acao = "Alterar";
        }

        private void btnGravar_Click(object sender, EventArgs e) //informar a query aqui neste método...ele está em BLL.
        {
            DTOContato = new DTOContato();
            DTOContato.Nome = txtNome.Text;
            DTOContato.Telefone = txtTelefone.Text;

            BLLContato = new BLLContato();

            DateTime data = new DateTime();
            data = DateTime.Now;
                
                param = new List<cl_GestorBD.SQLParametro>() {  new cl_GestorBD.SQLParametro("@idContato", DTOContato.IdContato),//vai com o valor Zero
                                                                new cl_GestorBD.SQLParametro("@nome",DTOContato.Nome),
                                                                new cl_GestorBD.SQLParametro("@telefone", DTOContato.Telefone),
                                                                new cl_GestorBD.SQLParametro("@atualizacao", data)
                                                                };
            if (acao == "Inserir")
            {
                query = "INSERT INTO contatos (nome,telefone,atualizacao) VALUES(@nome, @telefone, @atualizacao)";
                
                //Foi no param com o valor Zero, agora recebe o número de id retornado do banco.
                DTOContato.IdContato = BLLContato.Incluir(query, param);

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
            else
            {
                //acao = Alterar
                param[0].Valor = lbl_idContato.Text;
                query = "UPDATE contatos SET nome = @nome, telefone = @telefone, atualizacao = @atualizacao WHERE id_contato = @idContato";
                BLLContato.Alterar(query, param);

                MessageBox.Show("Cadastro nº " + lbl_idContato.Text.ToString() + " alterado com sucesso", "ALTERAÇÃO DE CONTATO");
                LimpaTela();
                AlteraBotoes(1);
            }
            
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            using (frmConsulta f = new frmConsulta())
            {
                this.Hide();
                f.ShowDialog();
                idContato = f.codLinha;
                
            }
            this.Show();

            if (idContato > 0) 
            {
                List<cl_GestorBD.SQLParametro> parametros = new List<cl_GestorBD.SQLParametro>();
                parametros.Add(new cl_GestorBD.SQLParametro("@idContato", idContato));
                query = "SELECT *FROM contatos WHERE  id_contato = @idContato";
                DTOContato = new DTOContato();
                BLLContato BLLContato = new BLLContato();

                DTOContato = BLLContato.CarregaContato(query, parametros);

                // Preenchendo as TextBox
                lbl_idContato.Visible = true;
                lbl_idContato.Text = DTOContato.IdContato.ToString();
                txtNome.Text = DTOContato.Nome;
                txtTelefone.Text = DTOContato.Telefone;
                AlteraBotoes(3);
            }
            else { return; }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Deseja excluir este contato?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                param = new List<cl_GestorBD.SQLParametro>() { new cl_GestorBD.SQLParametro("@idcontato", DTOContato.IdContato) };
                query = "DELETE FROM contatos WHERE id_contato = @idcontato";
                BLLContato = new BLLContato();
                BLLContato.Excluir(query, param);
                MessageBox.Show("Cadastro nº " + DTOContato.IdContato + " excluído com sucesso", "EXCLUSÃO DE CONTATO");
                LimpaTela();
                AlteraBotoes(1);
            }
            else
            {
                return;
            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //fazer pergunta se quer sair (FALTA FAZER)
            if (MessageBox.Show("Deseja cancelar o preenchimento do formulário? \nIsso irá apagar todas as informações digitadas !!!", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpaTela();
                AlteraBotoes(1);
                txtNome.Focus();
            }
            else
            {
                txtNome.Focus();
                return;
            }
            
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
