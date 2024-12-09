using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ControleDeContatos.ViewComponents
{
/*
*@author Ramadan ismaeL
*/
    public class Menu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (string.IsNullOrEmpty(sessaoUsuario)) return Content("Usuário não está logado");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return View(usuario);
        }
    }
}

/*
public IViewComponentResult Invoke()
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return Content("Usuário não está logado");

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return View(usuario);
        }
        */