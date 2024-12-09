using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
/*
*@author Ramadan ismaeL
*/
    public enum StatusTask
    {
        [Description("To Do")]
        ToDo = 1,
        [Description("In Progress")]
        InProgress = 2,
        [Description("Completed")]
        Completed = 3
    }
}