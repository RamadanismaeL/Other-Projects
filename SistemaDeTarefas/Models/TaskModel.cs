using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.Models
{
/*
*@author Ramadan ismaeL
*/
    public class TaskModel
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? Description {get; set;}
        public StatusTask Status {get; set;}
        public int? UserID {get; set;}
        public virtual UserModel? User {get; set;}
    }
}