using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces
{
/*
*@author Ramadan ismaeL
*/
    public interface ITaskRepository
    {
        Task<List<TaskModel>> ListAll();
        Task<TaskModel> ListById(int id);
        Task<TaskModel> Add(TaskModel task);
        Task<TaskModel> Update(TaskModel task, int id);
        Task<bool> Delete(int id);
    }
}