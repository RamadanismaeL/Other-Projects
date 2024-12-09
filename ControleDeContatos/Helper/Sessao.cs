using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace ControleDeContatos.Helper
{
    /*
    *@author Ramadan ismaeL
    */
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public UsuarioModel BuscarSessaoDoUsuario()
        {
            var httpContext = _httpContext.HttpContext;
            if (httpContext == null)
            {
                // Log que HttpContext é nulo
                Console.WriteLine("HttpContext é nulo.");
                return null;
            }

            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string sessaoUsuario = httpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                // Log que a sessão está vazia
                Console.WriteLine("Sessão 'sessaoUsuarioLogado' está vazia ou não existe.");
                return null;
            }

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario); // INSTALE PACOTE JSON NO PROJECTO := dotnet add package Newtonsoft.Json

            #pragma warning disable CS8602
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
            _httpContext.HttpContext.Session.Clear();
        }
    }
}