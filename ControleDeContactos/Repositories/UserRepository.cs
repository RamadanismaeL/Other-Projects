using ControleDeContactos.Data;
using ControleDeContactos.Models;
using ControleDeContactos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContactos.Repositories
{
    /*
    *@author Ramadan ismaeL
    */
    public class UserRepository : IUserRepository
    {
        private readonly _ControleDeContactos _controleDeContactos;
        public UserRepository(_ControleDeContactos controleDeContactos)
        {
            _controleDeContactos = controleDeContactos;
        }
        public async Task<UserModel> Add(UserModel user)
        {
            user.DateRegister = DateTime.Now;
            user.SetPassword();
            await _controleDeContactos.Users.AddAsync(user);
            await _controleDeContactos.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userID = await ListByID(id) ?? throw new KeyNotFoundException($"User with ID: {id}, not found. Please, try again!");
            _controleDeContactos.Users.Remove(userID);
            await _controleDeContactos.SaveChangesAsync();
            return true;
        }

        public UserModel FindByUsername(string username)
        {
            return _controleDeContactos.Users.FirstOrDefault(u => (u.UserName ?? "").ToUpper() == username.ToUpper()) ?? throw new KeyNotFoundException($"Username : {username}, not found. Please, try again!");
        }

        public async Task<List<UserModel>> ListAll()
        {
            return await _controleDeContactos.Users.ToListAsync();
        }

        public async Task<UserModel> ListByID(int id)
        {
            return await _controleDeContactos.Users.FirstOrDefaultAsync(u => u.Id == id) ?? throw new KeyNotFoundException($"User with ID: {id}, not found. Please, try again!");
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userID = await ListByID(id) ?? throw new KeyNotFoundException($"User with ID: {id}, not found. Please, try again!");
            userID.Name = user.Name;
            userID.LastName = user.LastName;
            userID.Email = user.Email;
            userID.UserName = user.UserName;
            userID.Profile = user.Profile;
            userID.DateUpdate = DateTime.Now;
            _controleDeContactos.Users.Update(userID);
            await _controleDeContactos.SaveChangesAsync();

            return userID;
        }
    }
}