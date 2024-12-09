using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    /*
    *@author Ramadan ismaeL
    */
    public class UserRepository : IUserRepository
    {
        private readonly SistemaDeTarefasDB sistemaDeTarefasDB;
        public UserRepository(SistemaDeTarefasDB sistemaDeTarefasDB)
        {
            this.sistemaDeTarefasDB = sistemaDeTarefasDB;
        }
        public async Task<UserModel> Add(UserModel user)
        {
            await sistemaDeTarefasDB.Users.AddAsync(user);
            await sistemaDeTarefasDB.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserModel>> ListAll()
        {
            return await sistemaDeTarefasDB.Users.ToListAsync();
        }

        public async Task<UserModel> ListById(int id)
        {
            return await sistemaDeTarefasDB.Users.FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception($"User with ID {id} not found. Please, try again!");
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await ListById(id) ?? throw new Exception($"User with ID {id} not found. Please, try again!");

            sistemaDeTarefasDB.Users.Remove(userById);
            await sistemaDeTarefasDB.SaveChangesAsync();
            return true;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await ListById(id) ?? throw new Exception($"User with ID {id} not found. Please, try again!");
            userById.Name = user.Name;
            userById.Email = user.Email;

            sistemaDeTarefasDB.Users.Update(userById);
            await sistemaDeTarefasDB.SaveChangesAsync();
            return userById;
        }
    }
}