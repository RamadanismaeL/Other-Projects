using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }
        public ContactoModel Adicionar(ContactoModel contato)
        {
            _bancoContext.Contactos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public bool Apagar(int id)
        {
            ContactoModel contactoDB = ListPorId(id);

            if(contactoDB == null) throw new System.Exception("Houve um erro ao tentar deletar o contacto!");

            _bancoContext.Contactos.Remove(contactoDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public ContactoModel Atualizar(ContactoModel contacto)
        {
            ContactoModel contactoDB = ListPorId(contacto.Id);

            if(contacto == null) throw new System.Exception("Houve um erro na actualização do contacto!");
            contactoDB.Nome = contacto.Nome;
            contactoDB.Email = contacto.Email;
            contactoDB.Celular = contacto.Celular;

            _bancoContext.Contactos.Update(contactoDB);
            _bancoContext.SaveChanges();

            return contactoDB;
        }

        public ContactoModel BuscarPorID(int id)
        {
            return _bancoContext.Contactos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactoModel> BuscarTodos(int usuarioId)
        {
            try
            {
                //return _bancoContext.Contactos.ToList();
                return _bancoContext.Contactos.Where(x => x.UsuarioID == usuarioId).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ContactoModel>();
            }
        }

        public ContactoModel ListPorId(int id)
        {
            return _bancoContext.Contactos.FirstOrDefault(x => x.Id == id);
        }
    }
}