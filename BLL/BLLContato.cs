using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Diagnostics;


namespace BLL
{
    
    public class BLLContato
    {
        cl_GestorBD gestor;
        DataTable tabelaTemp;
        
        public BLLContato()
        {
        }

        public int Incluir(string query, List<cl_GestorBD.SQLParametro>parametros)
        {
            //validar os dados

            // Instancia a classe que irá tratar de INSERIR/ALTERAR/DELETAR/SELECIONAR, passando como parametro o nome do banco a ser utilizado
            gestor = new cl_GestorBD("teste");
            
            //passar objeto contato para _clGestor e informar o banco que será gravado no caso é o BD de nome teste
            gestor.EXE_NON_QUERY(query, parametros);
            int id = Convert.ToInt32(parametros[0].Valor);

            return id;
        }

        //public void Incluir(DTOContato contato)
        //{
        //    //validar os dados

        //    // Instancia a classe que irá tratar de INSERIR/ALTERAR/DELETAR/SELECIONAR, passando como parametro o nome do banco a ser utilizado
        //    gestor = new cl_GestorBD("teste");
        //    // cria os parametros
        //    List<cl_GestorBD.SQLParametro> parametros = new List<cl_GestorBD.SQLParametro>();
        //    parametros.Add(new cl_GestorBD.SQLParametro("@id", contato.IdContato));
        //    parametros.Add(new cl_GestorBD.SQLParametro("@nome", contato.Nome));
        //    parametros.Add(new cl_GestorBD.SQLParametro("@telefone", contato.Telefone));
        //    parametros.Add(new cl_GestorBD.SQLParametro("@atualizacao", DateTime.Now));
        //    string query = "INSERT INTO contatos (nome, telefone, atualizacao) VALUES(@nome, @telefone, @atualizacao)";
        
        //    //passar objeto contato para _clGestor e informar o banco que será gravado no caso é o BD de nome teste
        //    gestor.EXE_NON_QUERY(query, parametros);
        //    contato.IdContato = Convert.ToInt32(parametros[0].Valor);
        //}

        public void Alterar(string query, List<cl_GestorBD.SQLParametro> parametros)
        {
            gestor = new cl_GestorBD("teste");

            gestor.EXE_NON_QUERY(query, parametros);
        }
        public void Excluir(string query, List<cl_GestorBD.SQLParametro> parametros)
        {
            gestor = new cl_GestorBD("teste");
            gestor.EXE_NON_QUERY(query, parametros);
        }

        public DataTable Localizar(string query, List<cl_GestorBD.SQLParametro> parametros = null)
        {
            gestor = new cl_GestorBD("teste");

            using (tabelaTemp = new DataTable())
            {
                tabelaTemp = gestor.EXE_READER(query, parametros);
            }
            return tabelaTemp;
        }

        public DTOContato CarregaContato(string query, List<cl_GestorBD.SQLParametro> parametros)
        {
            DTOContato dto = new DTOContato();
            gestor = new cl_GestorBD("teste");
            using (tabelaTemp = new DataTable())
            {
                tabelaTemp = gestor.EXE_READER(query, parametros);
                dto.IdContato = (int)tabelaTemp.Rows[0].ItemArray[0];
                dto.Nome = tabelaTemp.Rows[0].ItemArray[1].ToString();
                dto.Telefone = tabelaTemp.Rows[0].ItemArray[2].ToString();
                dto.Atualizacao = (DateTime)tabelaTemp.Rows[0].ItemArray[3];
            }

            return dto;
        }
    }
}
