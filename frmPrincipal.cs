using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriaBD_Crud
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair da Aplicação?", "SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                Application.Exit();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //Apresenta a versão do Software
            lblVersao.Text = Vars.versao;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void btnVisualizarTudo_Click(object sender, EventArgs e)
        {

        }

        private void btnZeraBD_Click(object sender, EventArgs e)
        {
            cl_GestorBD gestor = new cl_GestorBD("teste");
            gestor.CriarBD("teste");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            cl_GestorBD gestor = new cl_GestorBD("teste");
            string query = "SELECT *FROM contatos";

            List<cl_GestorBD.SQLParametro> Parametros = new List<cl_GestorBD.SQLParametro>();
            Parametros.Add(new cl_GestorBD.SQLParametro("@item_pesquisa", txtPesquisa.Text));

            DataTable dados = gestor.EXE_READER(query);

            /*
               Com os comando acima facilmente temos a informação gravada em uma DataTable preenchida com as informações
            de acordo com a string query definida como parâmetro no comando gestor.EXE_READER.
            Sendo assim, abaixo pode ser tralhado no método que lhe chamou da forma que necessitar
             */
            MessageBox.Show(dados.Rows.Count.ToString());
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            int idNovoContato = -1;
            if (txtNome.Text == "" || txtTelefone.Text == "")
            {
                MessageBox.Show("Os dados devem estar todos preenchidos","ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cl_GestorBD gestor = new cl_GestorBD("teste");

            idNovoContato = gestor.ID_DISPONIVEL("contatos", "id_contato");


            //criando a lista de parametros para INSERT
            List<cl_GestorBD.SQLParametro> parametros = new List<cl_GestorBD.SQLParametro>();
            parametros.Add(new cl_GestorBD.SQLParametro("@id", idNovoContato));
            parametros.Add(new cl_GestorBD.SQLParametro("@nome", txtNome.Text));
            parametros.Add(new cl_GestorBD.SQLParametro("@telefone", txtTelefone.Text));
            parametros.Add(new cl_GestorBD.SQLParametro("@data", DateTime.Now));

            //string de INSERT
            string query = "INSERT INTO contatos VALUES(@id, @nome, @telefone, @data)";

            gestor.EXE_NON_QUERY(query, parametros);
            MessageBox.Show("registrou");
        }
    }
}
