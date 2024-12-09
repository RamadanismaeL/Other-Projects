using ControleDeContactos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContactos.Repositories.Interfaces
{
/*
*@author Ramadan ismaeL
*/
    public interface IUserController
    {
        Task<ActionResult<List<UserModel>>> ListAll();
        Task<ActionResult<UserModel>> ListByID(int id);
        Task<ActionResult<UserModel>> Add([FromBody] UserModel user);
        Task<ActionResult<UserModel>> Update([FromBody] UserModel user, int id);
        Task<ActionResult<UserModel>> Delete(int id);
    }
}