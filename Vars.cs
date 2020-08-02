using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CriaBD_Crud
{
    public static partial class Vars
    {
        public static string versao = "Versão 1.0.0";
        private static string dataBase = "teste";
        public static string string_Conn = "server=localhost;port=3306;User Id = ricardo; database=world;password=281212";
        private static MySqlConnection Conexao;
        private static MySqlCommand Comando;

        //Mecanismos de iniciação da aplicação (verificação de BD existente, etc)
        public static void Iniciar()
        {
            //verifica se a BD existe
            try
            {
                #region Método 1
                using (Conexao = new MySqlConnection(string_Conn))
                {
                    string query = "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'teste'";
                    Conexao.Open();
                    Comando = new MySqlCommand(query, Conexao);
                    var i = Comando.ExecuteScalar();

                    if (i != null)
                    {
                        //se existir segue 
                        System.Windows.Forms.MessageBox.Show(i.ToString() + " não foi necessário criar BD");
                    }
                    else {
                        // se não existir
                        //cria bd
                        CriarBD();
                    }
                }
                
                #endregion
                #region Método 2

                //using (Conexao = new MySqlConnection(string_Conn))
                //{
                //    string query = "CREATE DATABASE IF NOT EXISTS teste;";
                //    Conexao.Open();
                //    Comando = new MySqlCommand(query, Conexao);
                //    var i = Comando.ExecuteNonQuery();

                //    if (i != 0)
                //    {
                //        //se existir 
                //        System.Windows.Forms.MessageBox.Show(i.ToString() + "criado o BD");
                //    }
                //    else
                //    {
                //        // se não existir
                //        //cria bd
                //        //Comando = null;

                //        System.Windows.Forms.MessageBox.Show("não existe");

                //        //query = "CREATE DATABASE teste";
                //        //Comando.CommandText = query;
                //        //Comando.ExecuteNonQuery();

                //        //query = "USE teste";
                //        //Comando.CommandText = query;
                //        //Comando.ExecuteNonQuery();
                //    }

                //}
                #endregion
            }
            catch (Exception ex)
            {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public static void CriarBD()
        {
            try
            {
                //conectar à alguma BD já existente
                using (Conexao = new MySqlConnection(string_Conn))
                {
                    Conexao.Open();
                    //query criação da DataBse
                    string query = "CREATE DATABASE teste";
                    Comando = new MySqlCommand(query, Conexao);
                    int i = Comando.ExecuteNonQuery();

                    //se criou o banco de dados...
                    if (i > 0)
                    {
                        // banco de dados criado, muda a connection string para criar as tabelas
                        string_Conn = "server=localhost; port=3306; User Id = ricardo; database=" + dataBase +";password=281212;";
                        // mudando a conection string da conexão, fecha a conexão e atribui uma nova connectionstring e ABRE novamente a conexão
                        Conexao.Close();
                        Conexao.Dispose();

                        Conexao.ConnectionString = string_Conn;
                        Conexao.Open();
                        System.Windows.Forms.MessageBox.Show("BD Criado");

                        //criando as tabelas
                        Comando.CommandText = "USE teste; " +
                                              "CREATE TABLE contatos(" +
                                                                    "id_contato         INT NOT NULL PRIMARY KEY," +
                                                                    "nome               VARCHAR(50) NOT NULL," +
                                                                    "telefone           VARCHAR(15)," +
                                                                    "atualizacao        DATETIME);";
                        
                        Comando.Connection = Conexao;
                        int t = Comando.ExecuteNonQuery();
                        //if(t > 0)
                        //{
                        //    System.Windows.Forms.MessageBox.Show("Tabelas criadas com sucesso");
                        //}
                        //else
                        //{
                        //    System.Windows.Forms.MessageBox.Show("Ocorreu um erro ao criar as tabelas");
                        //}
                    }
                    else { System.Windows.Forms.MessageBox.Show("ocorreou um erro"); }
                } 
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
