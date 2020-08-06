using DAL;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Relational;

namespace CriaBD_Crud
{
    public partial class frmConsulta : Form
    {
        BLLContato BLL;
        DataTable Tabela;
        cl_GestorBD gestor;
        public int codLinha = -1; //receberá o código do idcontato selecionado pelo DoubleClick
        string query = "SELECT *FROM contatos ORDER BY id_contato ASC"; //query padrão abertura da tela
        string criterioBusca = "";  // receberá o critério de busca ao banco de dados (WHERE)

        public void PreencheDGV(string query)
        {
            //passa a query e os parâmetros(se houver)
            BLL = new BLLContato();
            //Preenche a DataGridView 
            dgvContato.DataSource = BLL.Localizar(query);

            //Contando número de linhas;
            lblTotalLinhas.Text = "Total de Linhas: " + dgvContato.Rows.Count.ToString();
        }

        //============================================================================================
        public frmConsulta()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            PreencheDGV(query);
        }

        private void rbNome_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton senderControl = sender as RadioButton;
                if (!senderControl.Checked)
                    return;

                switch ((sender as RadioButton).Text)
                {
                    case "Nome":
                        query = "SELECT *FROM contatos ORDER BY nome ASC";
                        PreencheDGV(query);
                        break;
                    case "Telefone":
                        query = "SELECT *FROM contatos ORDER BY telefone ASC";
                        PreencheDGV(query);
                        break;
                    default:
                        query = "SELECT *FROM contatos ORDER BY id_contato ASC";    //Nenhum selecionado será essa a query de consulta
                        PreencheDGV(query);
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void rbTelefone_CheckedChanged(object sender, EventArgs e)
        {
            rbNome_CheckedChanged(sender, e);
        }

        private void dgvContato_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            codLinha = (int)dgvContato.Rows[e.RowIndex].Cells[0].Value;
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            /*
             * Pode ser feito a procura com o critério do RadioButton selecionado (que é o correto).
             * ex: se o RadioButton telefone estiver selecionado a query será SELECT *FROM [nometabela] WHERE [campo] = @[nomeParametro]
             * outra coisa na query deve contar a claúsula LIKE caso desejar, isso possibilita buscar no nome por exemplo com a parte que foi pesquisado. Ex: digitou para pesquisar "vivi", no banco vai ser buscado em nome onde estiver a palavra vivi.
             *Assim, fica mais flexivel.
             *
             *neste exemplo tentei demonstrar a funcionalidade de utilizar os métodos da classe cl_gestor.
             */
            
            // cria lista de parametros p pesquisa
            List<cl_GestorBD.SQLParametro> paramemetros = new List<cl_GestorBD.SQLParametro>();
            paramemetros.Add(new cl_GestorBD.SQLParametro("@nomePesquisa", txtPesquisa.Text));
            
            // cria instancia
            gestor = new cl_GestorBD("teste");
            BLL = new BLLContato();
            
            // cria a query
            query = "SELECT *FROM contatos where nome = @nomePesquisa";

            // preenche DataGridView com a query  e parametros passados para BLL
            dgvContato.DataSource = BLL.Localizar(query, paramemetros);

        }
    }
}
