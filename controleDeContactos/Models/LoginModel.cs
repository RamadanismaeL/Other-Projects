using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace controleDeContactos.Models
{
    /*
    *@author Ramadan ismaeL
    */
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter a Username.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please enter a Password.")]
        public string? Password { get; set; }
    }
}