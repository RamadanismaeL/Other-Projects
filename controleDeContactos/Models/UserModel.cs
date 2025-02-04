using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Emuns;
using controleDeContactos.ram;

namespace controleDeContactos.Models
{
    /*
    *@author Ramadan ismaeL
    */
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; } = "--";
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; } = "--";
        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = "--";
        [Required(ErrorMessage = "Please select your username.")]
        public string UserName { get; set; } = "--";
        [Required(ErrorMessage = "Please select a profile.")]
        public ProfileEnum Profile { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime DateUpdate { get; set; }
        public virtual List<ContactModel>? Contacts { get; set; }

        public bool ValidPassword(string password)
        {
            //return Password == password.CreateHash();
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
        public void SetPassword()
        {
            if(!string.IsNullOrEmpty(Password))
            {
                Password = Password.CreateHash();
            }
            else
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }
        }
        public void SetNewPassword(string newPassword)
        {
            if(!string.IsNullOrEmpty(newPassword)) throw new ArgumentException("Password cannot be null or empty.");
            Password = newPassword.CreateHash();
        }
        public string CreateNewPassword()
        {
            string newPassword = Guid.NewGuid().ToString()[..8];
            Password = newPassword.CreateHash();
            return newPassword;
        }
    }
}