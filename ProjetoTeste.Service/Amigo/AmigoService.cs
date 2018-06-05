using Newtonsoft.Json;
using ProjetoTeste.Domain.Entities;
using ProjetoTeste.Repository.Repositories;
using ProjetoTeste.Service.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Service.Amigo
{
    public class AmigoService
    {
        readonly AmigoRepositorio _amigoRepositorio;
        private const double km = 6367.0;

        public AmigoService()
        {
            _amigoRepositorio = new AmigoRepositorio();
        }

        public List<ProjetoTeste.Domain.Entities.Amigo> ListarAmigos()
        {
            return _amigoRepositorio.GetAll().ToList();
        }

        public List<AmigosProximos> ObterAmigosProximos(string jsonInput)
        {
            var _calculoHistoricoLogService = new CalculoHistoricoLogService();
            var localizacaoAtual = JsonConvert.DeserializeObject<ProjetoTeste.Domain.Entities.Amigo>(jsonInput);
            var listAmigos = _amigoRepositorio.GetAll().ToList();

            #region Calculo
            var oListAmigosProximos = new List<AmigosProximos>();
            foreach (var item in listAmigos)
            {
                var oAmigosProximos = new AmigosProximos();
                oAmigosProximos.idAmigo = item.Id;
                oAmigosProximos.Idade = item.Idade;
                oAmigosProximos.Nome = item.Nome;
                oAmigosProximos.latitude = item.latitude;
                oAmigosProximos.longitude = item.longitude;
                oAmigosProximos.distancia = (int)CalcularDistancia(localizacaoAtual.latitude, localizacaoAtual.longitude, item.latitude, item.longitude);
                oListAmigosProximos.Add(oAmigosProximos);
            }
            oListAmigosProximos.Sort((x, y) => x.distancia - y.distancia);
            oListAmigosProximos = oListAmigosProximos.Take(3).ToList();
            #endregion
            
            #region Log
            var _calculoHistoricoLog = new CalculoHistoricoLog();
            _calculoHistoricoLog.LatitudeAtual = localizacaoAtual.latitude;
            _calculoHistoricoLog.LongitudeAtual = localizacaoAtual.longitude;
            _calculoHistoricoLog.Resultado = JsonConvert.SerializeObject(oListAmigosProximos);
            _calculoHistoricoLogService.SalvarLog(_calculoHistoricoLog);
            #endregion

            return oListAmigosProximos;
        }


        #region Metodos Privados
        private static double CalcularDistancia(double latitudeInicial, double longitudeInicial, double latitudeFinal, double longitudeFinal)
        {
            var dLatitude = ConverterGrausParaRadiano(latitudeFinal) - ConverterGrausParaRadiano(latitudeInicial);
            var dLongitude = ConverterGrausParaRadiano(longitudeFinal) - ConverterGrausParaRadiano(longitudeInicial);
            var a = Math.Sin(dLatitude / 2) * Math.Sin(dLatitude / 2) + Math.Cos(ConverterGrausParaRadiano(latitudeInicial)) * Math.Cos(ConverterGrausParaRadiano(latitudeFinal)) * Math.Sin(dLongitude / 2) * Math.Sin(dLongitude / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distancia = c * km;
            return Math.Round(distancia, 2);
        }
        private static double ConverterGrausParaRadiano(double graus)
        {
            return Math.PI * graus / 180.0;
        }
        private static double ConverterRadianoParaGraus(double radiano)
        {
            return 180.0 * radiano / Math.PI;
        }
        #endregion


    }
}
