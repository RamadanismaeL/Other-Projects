using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ControleDeContatos.Filters
{
/*
*@author Ramadan ismaeL
*/
    public class PaginaRestritaSomenteAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string? sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if(string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary {{"controller", "Login"}, {"action", "Index"}});
                //context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            else
            {
                UsuarioModel? usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary {{"controller", "Login"}, {"action", "Index"}});
                    //context.Result = new RedirectToActionResult("Index", "Login", null);
                }

                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (usuario.Perfil != Enums.PerfilEnum.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary {{"controller", "Restrito"}, {"action", "Index"}});
                }
            }
            base.OnActionExecuted(context);
        }
    }
}