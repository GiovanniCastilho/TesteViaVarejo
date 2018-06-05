using ProjetoTeste.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ProjetoTeste.Application.AmigoLocalizacao
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterMappings.Register();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
