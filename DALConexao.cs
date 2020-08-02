using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class DALConexao : IDisposable
    {

        private string _strConn;
        private MySqlConnection _conexao;
        private MySqlTransaction _transacao;

        public static string servidor = "localhost";
        //public static string servidor = "SERVER-MYSQL";
        public static string portaBD = "3306";
        public static string nomeBD = "rmcontrol";
        public static string usuarioBD = "ricardo";
        public static string senhaBD = "281212";

        //server=SERVER-MYSQL;port=3306;User Id = ricardo; database=ricardo;password=281212"

        private string _stringConexao = "server=" + servidor + ";port=" + portaBD + ";User Id = " + usuarioBD + "; database=" + nomeBD + ";password=" + senhaBD;

        public string StrConn { get => _strConn; set => _strConn = value; }
        public MySqlConnection ObjConexao { get => _conexao; set => _conexao = value; }
        public MySqlTransaction ObjTransacao { get => _transacao; set => _transacao = value; }

        public DALConexao()
        {
            try
            {
                this._conexao = new MySqlConnection();
                this._strConn = _stringConexao;
                this._conexao.ConnectionString = _strConn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Conectar()
        {
            try
            {
                if (_conexao.State != System.Data.ConnectionState.Open)
                {
                    this._conexao.ConnectionString = StrConn;
                    this._conexao.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Desconectar()
        {
            try
            {
                if (_conexao.State != System.Data.ConnectionState.Closed)
                {
                    this._conexao.Close();
                    this._conexao.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void IniciarTransacao()
        {
            try
            {
                this._transacao = _conexao.BeginTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void TerminarTransacao()
        {
            try
            {
                this._transacao.Commit();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Transação já confirmada ou não está pendente(existe)", "DALCONEXAO - TerminarTransacao");
            }
        }

        public void CancelarTransacao()
        {
            try
            {
                this._transacao.Rollback();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //catch (InvalidOperationException)
            //{
            //    MessageBox.Show("erro de dados invalidos", "catch - DalConexao");
            //    return;
            //}
        }

        public void Dispose()
        {
            try
            {
                if (_conexao != null)
                    _conexao.Dispose();

                if (_transacao != null)
                    _transacao.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
