using ControleDeContactos.Models;

namespace ControleDeContactos.Repositories.Interfaces
{
/*
*@author Ramadan ismaeL
*/
    public interface IUserRepository
    {
        Task<List<UserModel>> ListAll();
        UserModel FindByUsername(string username);
        Task<UserModel> ListByID(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}