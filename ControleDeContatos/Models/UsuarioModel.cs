using System.ComponentModel.DataAnnotations;
using ControleDeContatos.Enums;
using ControleDeContatos.Helper;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id {get; set;}
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string? Nome {get; set;}
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string? Login {get; set;}
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string? Email {get; set;}
        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil {get; set;}
        [Required(ErrorMessage = "Digite a senha do Usuário")]
        public string? Senha {get; set;}
        public DateTime DataCadastro {get; set;}
        public DateTime? DataAtualizacao {get; set;}
        public virtual List<ContactoModel>? Contatos {get; set;}
        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }
        public void SetSenhaHash()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            Senha = Senha.GerarHash();
#pragma warning restore CS8604 // Possible null reference argument.
        }
        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }
        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}