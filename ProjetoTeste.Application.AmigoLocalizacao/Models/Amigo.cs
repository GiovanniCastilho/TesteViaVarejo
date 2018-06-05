using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoTeste.Application.AmigoLocalizacao.Models
{
    public class Amigo
    {
        public string Nome { get; set; }

        public string Idade { get; set; }

        public double latitude { get; set; }

        public double longitude { get; set; }
    }
}