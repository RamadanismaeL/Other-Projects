using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces
{
/*
*@author Ramadan ismaeL
*/
    public interface IUserRepository
    {
        Task<List<UserModel>> ListAll();
        Task<UserModel> ListById(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}