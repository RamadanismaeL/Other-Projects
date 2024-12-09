using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
/*
*@author Ramadan ismaeL
*/
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string? Senha { get; set; }
    }
}