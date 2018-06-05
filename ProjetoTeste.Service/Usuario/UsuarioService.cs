using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoTeste.Repository.Repositories;


namespace ProjetoTeste.Service.Usuario
{
    public class UsuarioService
    {
        readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioService()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public ProjetoTeste.Domain.Entities.Usuario Login(string login, string senha)
        {
            return _usuarioRepositorio.GetAll().Where(x => x.Login == login && x.Senha == senha).FirstOrDefault();
        }
    }
}
