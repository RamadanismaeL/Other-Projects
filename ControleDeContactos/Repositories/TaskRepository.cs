using ControleDeContactos.Models;
using ControleDeContactos.Repositories.Interfaces;
using ControleDeContactos.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContactos.Repositories
{
    /*
    *@author Ramadan ismaeL
    */
    public class TaskRepository : ITaskRepository
    {
        private readonly _ControleDeContactos _controleDeContactos;
        public TaskRepository(_ControleDeContactos controleDeContactos)
        {
            _controleDeContactos = controleDeContactos;
        }
        public async Task<TaskModel> Add(TaskModel task)
        {
            task.DateRegister = DateTime.Now;
            await _controleDeContactos.Tasks.AddAsync(task);
            await _controleDeContactos.SaveChangesAsync();
            return task;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel taskID = await ListByID(id) ?? throw new KeyNotFoundException($"Task with ID: {id}, not found. Please, try again!");
            _controleDeContactos.Tasks.Remove(taskID);
            await _controleDeContactos.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskModel>> ListAll()
        {
            return await _controleDeContactos.Tasks.ToListAsync();
        }

        public async Task<TaskModel> ListByID(int id)
        {
            return await _controleDeContactos.Tasks.FirstOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException($"Task with ID: {id}, not found. Please, try again!");
        }
        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel taskID = await ListByID(id) ?? throw new KeyNotFoundException($"Task with ID: {id} not found. Please, try again");
            taskID.Name = task.Name;
            taskID.Description = task.Description;
            taskID.Status = task.Status;
            _controleDeContactos.Tasks.Update(taskID);
            await _controleDeContactos.SaveChangesAsync();
            return taskID;
        }
    }
}