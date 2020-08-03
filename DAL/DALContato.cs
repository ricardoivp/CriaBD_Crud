using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;

namespace DAL

{
    public class DALContato
    {
        public MySqlConnection Conexao { get; set; }
        public MySqlCommand Cmd { get; set; }


        public void Incluir(DTOContato Contato)
        {
            cl_GestorBD gestor = new cl_GestorBD("teste");

            
            
        }
    }
}
