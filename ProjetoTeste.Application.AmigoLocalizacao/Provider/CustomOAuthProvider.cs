using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using ProjetoTeste.Service.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ProjetoTeste.Application.AmigoLocalizacao.Provider
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public CustomOAuthProvider() { }
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            try
            {
                UsuarioService _usuarioService = new UsuarioService();
                var usuario = _usuarioService.Login(context.UserName, context.Password);
                if (usuario != null)
                {
                    if (usuario.Ativo == 1)
                    {
                        
                        var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                        oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                        oAuthIdentity.AddClaim(new Claim("userId", usuario.Id.ToString()));
                        var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
                        context.Validated(ticket);
                        return base.GrantResourceOwnerCredentials(context);
                    }
                    else
                    {
                        context.SetError("invalid_grant", "Usuario inativo");
                        return Task.FromResult<object>(null); ;
                    }
                }
                else
                {
                    context.SetError("invalid_grant", "Usuario e senha invalidos");
                    return Task.FromResult<object>(null); ;
                }
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", "Ocorreu um erro ao processar a requisição");
                return Task.FromResult<object>(null); ;
            }
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}