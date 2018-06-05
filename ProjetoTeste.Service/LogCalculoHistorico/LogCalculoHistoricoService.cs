using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoTeste.Repository.Repositories;
using ProjetoTeste.Domain.Entities;

namespace ProjetoTeste.Service.Usuario
{
    public class CalculoHistoricoLogService
    {
        readonly CalculoHistoricoLogRepositorio _calculoHistoricoLogRepositorio;

        public CalculoHistoricoLogService()
        {
            _calculoHistoricoLogRepositorio = new CalculoHistoricoLogRepositorio();
        }

        public bool SalvarLog(CalculoHistoricoLog obj)
        {
            try
            {
                _calculoHistoricoLogRepositorio.Insert(ref obj);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
