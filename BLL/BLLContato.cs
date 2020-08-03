using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    
    public class BLLContato
    {
        cl_GestorBD gestor;
        
        public BLLContato()
        {
        }

        public void Incluir(DTOContato contato)
        {
            //validar os dados

            // Instancia a classe que irá tratar de INSERIR/ALTERAR/DELETAR/SELECIONAR, passando como parametro o nome do banco a ser utilizado
            gestor = new cl_GestorBD("teste");
            // cria os parametros
            List<cl_GestorBD.SQLParametro> parametros = new List<cl_GestorBD.SQLParametro>();
            parametros.Add(new cl_GestorBD.SQLParametro("@id", contato.IdContato));
            parametros.Add(new cl_GestorBD.SQLParametro("@nome", contato.Nome));
            parametros.Add(new cl_GestorBD.SQLParametro("@telefone", contato.Telefone));
            parametros.Add(new cl_GestorBD.SQLParametro("@atualizacao", DateTime.Now));
            string query = "INSERT INTO contatos (nome, telefone, atualizacao) VALUES(@nome, @telefone, @atualizacao)";
            //passar objeto contato para _clGestor e informar o banco que será gravado no caso é o BD de nome teste
            gestor.EXE_NON_QUERY(query, parametros);
            contato.IdContato = Convert.ToInt32(parametros[0].Valor);
        }
    }
}
