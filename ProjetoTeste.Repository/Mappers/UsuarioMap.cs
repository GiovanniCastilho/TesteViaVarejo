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
    public class UsuarioMap : DommelEntityMap<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("TB_USUARIO"); // Tabela
            Map(x => x.Id).ToColumn("ID_USUARIO").IsKey().IsIdentity(); // Id - Chave primária da tabela
            Map(x => x.Login).ToColumn("USUARIO");
            Map(x => x.Senha).ToColumn("SENHA");
            Map(x => x.Ativo).ToColumn("ATIVO");
        }
    }
}
