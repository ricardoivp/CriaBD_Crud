using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOContato
    {
        public DTOContato()
        {
        }

        public DTOContato(int idContato, string nome, string telefone, DateTime atualizacao)
        {
            IdContato = idContato;
            Nome = nome;
            Telefone = telefone;
            Atualizacao = atualizacao;
        }

        public int IdContato { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime Atualizacao { get; set; }
    }
}
