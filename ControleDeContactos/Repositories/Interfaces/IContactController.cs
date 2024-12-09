using ControleDeContactos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContactos.Repositories.Interfaces
{
/*
*@author Ramadan ismaeL
*/
    public interface IContactController
    {
        Task<ActionResult<List<ContactModel>>> ListAll();
        Task<ActionResult<ContactModel>> ListByID(int id);
        Task<ActionResult<ContactModel>> Add([FromBody] ContactModel user);
        Task<ActionResult<ContactModel>> Update([FromBody] ContactModel user, int id);
        Task<ActionResult<ContactModel>> Delete(int id);
    }
}