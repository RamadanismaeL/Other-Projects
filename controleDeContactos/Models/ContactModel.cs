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
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; } = "--";
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; } = "--";
        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = "--";
        [Required(ErrorMessage = "Please enter your phone number.")]
        public int? PhoneNumber { get; set; }
        public DateTime DateRegister { get; set; }
        public int UserID { get; set; }
        public UserModel? UserModel { get; set; }
    }
}