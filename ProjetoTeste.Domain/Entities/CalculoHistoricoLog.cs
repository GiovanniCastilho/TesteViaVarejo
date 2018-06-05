using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Domain.Entities
{
    public class CalculoHistoricoLog : BaseEntity
    {
        public int Id { get; set; }        
        public double LatitudeAtual { get; set; }
        public double LongitudeAtual { get; set; }
        public string Resultado { get; set; }
    }
}
