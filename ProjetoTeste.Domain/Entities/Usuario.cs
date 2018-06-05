using ProjetoTeste.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Domain.Entities
{
    public class Usuario : BaseEntity
    {

        public int Id { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public int Ativo { get; set; }


    }
}
