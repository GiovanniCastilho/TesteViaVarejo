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
    public class CalculoHistoricoLogMap : DommelEntityMap<CalculoHistoricoLog>
    {
        public CalculoHistoricoLogMap()
        {
            ToTable("TB_CALCULO_HISTORICO_LOG"); // Tabela
            Map(x => x.Id).ToColumn("ID_CALCULO_HISTORICO_LOG").IsKey().IsIdentity(); // Id - Chave primária da tabela            
            Map(x => x.LatitudeAtual).ToColumn("LATITUDE_ATUAL");
            Map(x => x.LongitudeAtual).ToColumn("LONGITUDE_ATUAL");
            Map(x => x.Resultado).ToColumn("RESULTADO");
        }
    }
}
