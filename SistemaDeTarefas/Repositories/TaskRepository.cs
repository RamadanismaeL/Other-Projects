using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    /*
    *@author Ramadan ismaeL
    */
    public class TaskRepository : ITaskRepository
    {
        private readonly SistemaDeTarefasDB sistemaDeTarefasDB;
        public TaskRepository(SistemaDeTarefasDB sistemaDeTarefasDB)
        {
            this.sistemaDeTarefasDB = sistemaDeTarefasDB;
        }
        public async Task<TaskModel> Add(TaskModel task)
        {
            await sistemaDeTarefasDB.Tasks.AddAsync(task);
            await sistemaDeTarefasDB.SaveChangesAsync();

            return task;
        }

        public async Task<List<TaskModel>> ListAll()
        {
            return await sistemaDeTarefasDB.Tasks.Include(t => t.User).ToListAsync();
        }

        public async Task<TaskModel> ListById(int id)
        {
            return await sistemaDeTarefasDB.Tasks.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException($"Task with ID {id} not found. Please, try again!");
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel taskById = await ListById(id) ?? throw new Exception($"Task with ID {id} not found. Please, try again!");

            sistemaDeTarefasDB.Tasks.Remove(taskById);
            await sistemaDeTarefasDB.SaveChangesAsync();
            return true;
        }

        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel taskById = await ListById(id) ?? throw new Exception($"Task with ID {id} not found. Please, try again!");
            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserID = task.UserID;

            sistemaDeTarefasDB.Tasks.Update(taskById);
            await sistemaDeTarefasDB.SaveChangesAsync();
            return taskById;
        }
    }
}