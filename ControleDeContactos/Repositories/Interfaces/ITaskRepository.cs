using ControleDeContactos.Models;

namespace ControleDeContactos.Repositories.Interfaces
{
/*
*@author Ramadan ismaeL
*/
    public interface ITaskRepository
    {
        Task<List<TaskModel>> ListAll();
        Task<TaskModel> ListByID(int id);
        Task<TaskModel> Add(TaskModel task);
        Task<TaskModel> Update(TaskModel task, int id);
        Task<bool> Delete(int id);
    }
}