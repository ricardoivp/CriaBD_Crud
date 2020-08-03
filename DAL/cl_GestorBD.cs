using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;

//==============================================================================================================
// Classe responsável pela comunicação com o banco de dados
// Versão 1.0.0
// 01/08/2020
//==============================================================================================================
namespace DAL
{
    public class cl_GestorBD
    {
        public MySqlCommand Cmd { get; set; }
        public MySqlConnection Conexao { get; set; }
        public MySqlTransaction Transacao { get; set; }
        public MySqlDataAdapter Adaptador { get; set; }
        public MySqlDataReader Reader { get; set; }
        public DataTable Tabela { get; set; }

        string Str_Conn = "";
        string Str_VerificaBD = ""; //Utilizada para conectar a algum DataBse para criar a DataBase a ser criada pelo sistema
        string ServerBD = "localhost";
        string portBD = "3306";
        string DataBase = "";
        string userBD = "ricardo";
        string PwdBD = "281212";

        /// <summary>
        /// Classe utlizada para passar dados por parametros
        /// </summary>
        public class SQLParametro
        {
            public string Parametro { get; set; }
            public object Valor { get; set; }
            /// <summary>
            /// Ex: parametro = @name , txtName.Text ou Variable
            /// </summary>
            /// <param name="parametro"></param>
            /// <param name="valor"></param>
            public SQLParametro(string parametro, object valor)
            {
                this.Parametro = parametro;
                this.Valor = valor;
            }
        }

        //construtor da Classe
        public cl_GestorBD(string dataBase)
        {
            this.DataBase = dataBase;
            this.Str_Conn = "server=" + this.ServerBD + ";port=" + this.portBD + ";User Id=" + this.userBD + ";database=" + this.DataBase + ";password=" + this.PwdBD;

            this.Str_VerificaBD = "server=" + this.ServerBD + ";port=" + this.portBD + ";User Id=" + this.userBD + ";database=world" + ";password=" + this.PwdBD;
        }

        //===============================================================================================
        #region Tratamento da DataBase

        public void CriarBD(string nameBD)
        {
            this.DataBase = nameBD;
            //verifica se a BD existe usando uma stringConnection com outro DataBase (base de dados World)
            try
            {
                #region VERIFICAÇÃO SE EXISTE BANCO DE DADOS

                using (Conexao = new MySqlConnection(Str_VerificaBD))
                {
                    string query = "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '" + this.DataBase + "';";
                    Conexao.Open();
                    Cmd = new MySqlCommand(query, Conexao);
                    var verifica = Cmd.ExecuteScalar();
                    //Se existir a DataBase
                    if (verifica != null)
                    {
                        //se existir pergunta se deseja recriar a DataBase 
                        if (MessageBox.Show("Já existe um banco de dados criado, \nDeseja substituir o banco de dados existente?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            //aqui irá recriar a BD, então ela deve ser reconstruída, mas primeiro deve ser DROPADA.
                            Cmd = new MySqlCommand();
                            Cmd.CommandText = "DROP DATABASE teste;";
                            Cmd.Connection = Conexao;
                            Cmd.ExecuteNonQuery();
                            CriaNovaBD(this.DataBase);
                            MessageBox.Show("Banco de dados redefinido \ncom sucesso", "INFORMAÇÃO");
                        }
                    }
                    else
                    {
                        // se não existir
                        //cria bd
                        CriaNovaBD(this.DataBase);
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CriaNovaBD(string NovaBD_Criar)
        {
            try
            {
                //conectar à alguma BD já existente, usando uma stringconnection de verificação
                using (Conexao = new MySqlConnection(Str_VerificaBD))
                {
                    Conexao.Open();
                    //query criação da DataBse
                    string query = "CREATE DATABASE " + NovaBD_Criar;
                    Cmd = new MySqlCommand(query, Conexao);
                    int i = Cmd.ExecuteNonQuery();

                    //se criou o banco de dados...
                    if (i > 0)
                    {
                        // banco de dados criado, muda a connection string para criar as tabelas
                        this.Str_Conn = "server=localhost; port=3306; User Id = ricardo; database=" + NovaBD_Criar + ";password=281212;";
                        // mudando a conection string da conexão, fecha a conexão e atribui uma nova connectionstring e ABRE    novamente a conexão
                        Conexao.Close();
                        Conexao.Dispose();

                        Conexao.ConnectionString = this.Str_Conn;
                        Conexao.Open();

                        //criando as tabelas
                        Cmd.CommandText = "USE teste; " +
                                          "CREATE TABLE contatos(" +
                                                                 "id_contato         INT NOT NULL PRIMARY KEY AUTO_INCREMENT," +
                                                                 "nome               VARCHAR(50) NOT NULL," +
                                                                 "telefone           VARCHAR(15)," +
                                                                 "atualizacao        DATETIME);";

                        Cmd.Connection = Conexao;
                        Cmd.ExecuteNonQuery();
                        MessageBox.Show("Banco de dados criado", "CRIAÇÃO BD");
                    }
                    else { MessageBox.Show("ocorreou um erro"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        //===============================================================================================
        /// <summary>
        /// parametros = null permite não definir na query(ex: caso seja query  = select *from clientes...sem WHERE
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parametros"></param>
        /// <returns>DataTable [name]</returns>
        public DataTable EXE_READER(string query, List<SQLParametro> parametros = null)
        {
            // Execute query in the database
            using (Tabela = new DataTable())
            {
                try
                {
                    using (Adaptador = new MySqlDataAdapter(query, Str_Conn))
                    {
                        //Limpa os parametros do Adaptador
                        Adaptador.SelectCommand.Parameters.Clear();

                        //se houver parametros executa um foreach agregando ao Adaptador
                        if (parametros != null)
                            foreach (SQLParametro p in parametros)
                                Adaptador.SelectCommand.Parameters.AddWithValue(p.Parametro, p.Valor);

                        Adaptador.Fill(Tabela);
                    }
                }

                catch (MySqlException exSQL)
                { MessageBox.Show("Erro-SQL: " + exSQL.Message); }

                catch (Exception ex)
                { MessageBox.Show("Erro: " + ex.Message); }
            }
            return Tabela;  //caso der erro colocar uma chave "}" antes
        }

        //===============================================================================================

        /// <summary>
        /// Executa queries INSERT, UPDATE, DELETE, CREATE TABLE, CREATE DATABASE
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parametros"></param>
        public void EXE_NON_QUERY(string query, List<SQLParametro> parametros = null)
        {

            using (Conexao = new MySqlConnection(Str_Conn))
            {
                try
                {
                    Conexao.Open();
                    Transacao = Conexao.BeginTransaction();
                    //using (Cmd = new MySqlCommand(query, Conexao))

                    using (Cmd = new MySqlCommand(query, Conexao, Transacao))
                        Cmd.Parameters.Clear(); //Efetuando a limpeza caso haja parametros.

                    //verifica se parametros é diferente de Null, ou seja, se tem dados, assim ele add aos parametros do COMANDO
                    if (parametros != null)
                        foreach (SQLParametro p in parametros)
                            Cmd.Parameters.AddWithValue(p.Parametro, p.Valor);

                    /*
                    O DANILO(TORNA-SE UM PROGRAMADOR) fez algo do tipo:
                        *pedido.clienteID = Convert.toINT32(cmd.ExecuteScalar()) - ->Aqui ele capturou o id a ser salvo(Commit não executado ainda)
                        
                    https://www.youtube.com/watch?v=dt1u_UUH4Ro
                    
                    RESOLVER ESSE TRECHO AQUI PARA QUE RETORNE O ID INSERIDO OU ID REFERENTE A ALTERAÇÃO

                    var linhaafetada = cmd.ExecuteNonQuery();
                    if (linhaafetada > 0)
                    {
                        cmd.CommandText = "SELECT @@IDENTITY";
                        DTO.EstadoId = Convert.ToInt16(cmd.ExecuteScalar());
                    }
                     */

                    Cmd.ExecuteNonQuery();
                    
                    //===================
                    Transacao.Commit();
                    parametros[0].Valor = Cmd.LastInsertedId;
                    //===================

                }
                catch (SqlException exSQL)
                {
                    Transacao.Rollback();
                    MessageBox.Show("Erro-SQL: " + exSQL.Message);
                }
                catch (Exception ex)
                {
                    Transacao.Rollback();
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }


        //===============================================================================================
        /// <summary>
        /// Busca coluna de identificação de uma tabela, caso seja necessário o controle via código que não seja AUTO_INCREMENT
        /// </summary>
        /// <param name="nomeTabela"></param>
        /// <param name="nomeColuna"></param>
        /// <returns>integer</returns>
        public int ID_DISPONIVEL(string nomeTabela, string nomeColuna)
        {
            int idtemp = -1;

            string query = "SELECT max(" + nomeColuna + ") as maxID FROM " + nomeTabela;

            using (Tabela = new DataTable())
            {
                using (Adaptador = new MySqlDataAdapter(query, Str_Conn))
                {
                    Adaptador.Fill(Tabela);
                    //se existir linhas na TABELA
                    if (Tabela.Rows.Count != 0)
                    {
                        // Se a tabela retornar DBnull, então idtemp = 1, pois será o primeiro registro
                        if (DBNull.Value.Equals(Tabela.Rows[0][0]))
                            idtemp = 1;
                        else
                            idtemp = Convert.ToInt32(Tabela.Rows[0][0]) + 1;
                    }
                }
            }
            return idtemp;
        }
    }
}

