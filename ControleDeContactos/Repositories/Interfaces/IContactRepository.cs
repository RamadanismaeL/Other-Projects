using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeContactos.Models;

namespace ControleDeContactos.Repositories.Interfaces
{
/*
*@author Ramadan ismaeL
*/
    public interface IContactRepository
    {
        Task<List<ContactModel>> ListAll();
        Task<ContactModel> ListByID(int id);
        Task<ContactModel> Add(ContactModel contact);
        Task<ContactModel> Update(ContactModel contact, int id);
        Task<bool> Delete(int id);
    }
}