using System.ComponentModel.DataAnnotations;
using ControleDeContactos.Enums;

namespace ControleDeContactos.Models
{
/*
*@author Ramadan ismaeL
*/
    public class TaskModel
    {
        public int Id { get; set;}
        [Required(ErrorMessage = "Please enter your first name.")]
        public string? Name { get; set;}
        [Required(ErrorMessage = "Please enter a description.")]
        public string? Description {get; set;}
        [Required(ErrorMessage = "Please select the status.")]
        public StatusTask Status {get; set;}
        public DateTime DateRegister { get; set;}
        public int? UserID { get; set;}
        public UserModel? User { get; set;}
    }
}