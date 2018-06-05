using ProjetoTeste.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Domain.Entities
{ 
    public class Amigo : BaseEntity
    {
        
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public string Idade { get; set; }
        
        public double latitude { get; set; }

        public double longitude { get; set; }
    }
}
