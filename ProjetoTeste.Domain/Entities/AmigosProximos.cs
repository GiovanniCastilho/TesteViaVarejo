using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Domain.Entities
{
    public class AmigosProximos
    {
        public int idAmigo { get; set; }
        public string Nome { get; set; }

        public string Idade { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }
        public int distancia { get; set; }
    }
}
