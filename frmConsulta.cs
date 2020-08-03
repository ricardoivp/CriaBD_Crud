using DAL;
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
    public partial class frmConsulta : Form
    {
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
            cl_GestorBD gestor = new cl_GestorBD("teste");
            dgvContato.DataSource = gestor.EXE_READER("SELECT *FROM contatos");
            lblTotalLinhas.Text = "Total de Linhas: " + dgvContato.Rows.Count.ToString();
        }
    }
}
