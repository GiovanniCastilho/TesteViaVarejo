using Dapper.FluentMap.Dommel.Mapping;
using ProjetoTeste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Repository.Mappers
{
    /// <summary>
    /// Classe responsável pelo mapeamento entre classe Domain.Cliente (aplicação) e ProjetoTeste.tb_cliente (banco de dados)
    /// </summary>
    public class AmigoMap : DommelEntityMap<Amigo>
    {
        public AmigoMap()
        {
            ToTable("TB_AMIGO"); // Tabela
            Map(x => x.Id).ToColumn("ID_AMIGO").IsKey().IsIdentity(); // Id - Chave primária da tabela
            Map(x => x.Nome).ToColumn("NOME");
            Map(x => x.Idade).ToColumn("IDADE");
            Map(x => x.latitude).ToColumn("LATITUDE");
            Map(x => x.longitude).ToColumn("LONGITUDE");
        }
    }
}
