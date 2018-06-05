using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using ProjetoTeste.Repository.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Repository
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {                
                config.AddMap(new AmigoMap());
                config.AddMap(new UsuarioMap());
                config.AddMap(new CalculoHistoricoLogMap());
                config.ForDommel();
            });
        }
    }
}
