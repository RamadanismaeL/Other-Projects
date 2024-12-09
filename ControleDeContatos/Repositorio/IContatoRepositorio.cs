using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContactoModel> BuscarTodos(int usuarioId);
        ContactoModel BuscarPorID(int id);
        ContactoModel Adicionar(ContactoModel contato);

        // Editar
        ContactoModel ListPorId(int id);
        ContactoModel Atualizar(ContactoModel contacto);

        // APAGAR
        bool Apagar(int id);
    }
}