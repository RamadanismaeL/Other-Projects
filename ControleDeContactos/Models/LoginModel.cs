using System.ComponentModel.DataAnnotations;

namespace ControleDeContactos.Models
{
/*
*@author Ramadan ismaeL
*/
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter a Username.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please enter a Password.")]
        public string? Password { get; set;}
    }
}