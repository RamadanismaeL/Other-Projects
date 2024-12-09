using ControleDeContatos.Models;

namespace ControleDeContatos.Helper
{
/*
*@author Ramadan ismaeL
*/
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}