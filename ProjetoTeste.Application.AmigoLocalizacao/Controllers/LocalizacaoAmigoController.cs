using Newtonsoft.Json;
using ProjetoTeste.Domain.Entities;
using ProjetoTeste.Repository.Repositories;
using ProjetoTeste.Service.Amigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoTeste.Application.AmigoLocalizacao.Controllers
{
    public class LocalizacaoAmigoController : ApiController
    {
        AmigoService _amigoService = new AmigoService();
        /// <summary>
        /// Serviço responsável por listar todos os Localizacaos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IEnumerable<Amigo> ListarAmigos()
        {
            return _amigoService.ListarAmigos();
        }
        /// <summary>
        /// Serviço responsável por listar todos os amigos proximos a localização enviada no obj localizacaoAtual
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IEnumerable<AmigosProximos> ObterAmigosProximos(Amigo localizacaoAtual)
        {
            return _amigoService.ObterAmigosProximos(JsonConvert.SerializeObject(localizacaoAtual));
        }
    }
}
