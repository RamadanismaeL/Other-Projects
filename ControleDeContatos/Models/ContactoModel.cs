using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContactoModel
    {
        public int Id { get; set;}
        [Required(ErrorMessage = "Digite o nome do contacto.")]
        public string? Nome { get; set;}
        [Required(ErrorMessage = "Digite o e-mail do contacto.")]
        [EmailAddress(ErrorMessage = "E-mail não é válido!")]
        public string? Email {get; set;}
        [Required(ErrorMessage = "Digite o celular do contacto.")]
        [Phone(ErrorMessage = "O celular informado não é válido!")]
        public string? Celular { get; set;}
        public int? UsuarioID { get; set;}
        public UsuarioModel? Usuario {get; set;}
    }
}