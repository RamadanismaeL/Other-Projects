using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
/*
*@author Ramadan ismaeL
*/
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string? Login{ get; set; }
        [Required(ErrorMessage = "Digite o e-mail")]
        public string? Email { get; set; }
    }
}