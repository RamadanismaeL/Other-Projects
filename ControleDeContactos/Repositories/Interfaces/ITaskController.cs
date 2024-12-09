using ControleDeContactos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContactos.Repositories.Interfaces
{
/*
*@author Ramadan ismaeL
*/
    public interface ITaskController
    {
        Task<ActionResult<List<TaskModel>>> ListAll();
        Task<ActionResult<TaskModel>> ListByID(int id);
        Task<ActionResult<TaskModel>> Add([FromBody] TaskModel task);
        Task<ActionResult<TaskModel>> Update([FromBody] TaskModel task, int id);
        Task<ActionResult<TaskModel>> Delete(int id);
    }
}