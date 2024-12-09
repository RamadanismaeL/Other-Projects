using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [Filters.PaginaParaUsuarioLogado]
    public class ContactoController : Controller
    {
        private readonly IContatoRepositorio _icontactoRepositorio;
        private readonly ISessao _sessao;
        public ContactoController(IContatoRepositorio icontactoRepositorio, ISessao sessao)
        {
            _icontactoRepositorio = icontactoRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            List<ContactoModel> contactos = _icontactoRepositorio.BuscarTodos(usuarioLogado.Id);
            return View(contactos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContactoModel contacto = _icontactoRepositorio.ListPorId(id);
            if(contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContactoModel contacto = _icontactoRepositorio.ListPorId(id);
            return View(contacto);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _icontactoRepositorio.Apagar(id);
                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Contacto apagado com sucesso!";
                } else {
                    TempData["MensagemErro"] = "Ups, não conseguimos apagar seu contacto!";
                }
                return RedirectToAction("Index");
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contacto, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContactoModel contacto)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contacto.UsuarioID = usuarioLogado.Id;
                    _icontactoRepositorio.Adicionar(contacto);
                    TempData["MensagemSucesso"] = "Contacto cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contacto);
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contacto, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContactoModel contacto)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    contacto.UsuarioID = usuarioLogado.Id;
                    _icontactoRepositorio.Atualizar(contacto);
                    TempData["MensagemSucesso"] = "Contacto atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", contacto);
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contacto, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}