using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriaBD_Crud.Modelos
{
    public partial class Modelo_Cadastro : Form
    {
        int LX, LY;             // Capturar a posição da tela antes de maximizar.

        /// <summary>
        /// 1 - Prepara para Inserir(Novo) e Localizar; 2 - Prepara para Gravar/Alterar; 3 - Prepara para Excluir ou Alterar
        /// </summary>
        /// <param name="opcao"></param>
        public void AlteraBotoes(int opcao)
        {
            pnDados.Enabled = false;
            pnBotoes.Enabled = true;
            //iniciando a aplicação com todos botões inativos
            List<Button> botoes = new List<Button>() { btnNovo, btnAlterar, btnGravar, btnLocalizar, btnExcluir, btnCancelar };
            foreach (Button button in botoes)
            {
                button.Enabled = false;
            }

            switch (opcao)
            {
                case 1:
                    btnNovo.Enabled = true;
                    btnLocalizar.Enabled = true;
                    
                    break;
                case 2:
                    btnCancelar.Enabled = true;
                    btnGravar.Enabled = true;
                    pnDados.Enabled = true;
                    break;
                case 3:
                    btnExcluir.Enabled = true;
                    btnAlterar.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        public Modelo_Cadastro()
        {
            InitializeComponent();
            AlteraBotoes(1);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            LX = this.Location.X;
            LY = this.Location.Y;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(800, 400);
            this.Location = new Point(LX, LY);
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void Modelo_Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            
        }
    }
}
