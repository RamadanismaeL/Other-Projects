using ControleDeContactos.Data;
using ControleDeContactos.Models;
using ControleDeContactos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContactos.Repositories
{
    /*
    *@author Ramadan ismaeL
    */
    public class ContactRepository : IContactRepository
    {
        private readonly _ControleDeContactos _controleDeContactos;
        public ContactRepository(_ControleDeContactos controleDeContactos)
        {
            _controleDeContactos = controleDeContactos;
        }
        public async Task<ContactModel> Add(ContactModel contact)
        {
            contact.DateRegister = DateTime.Now;
            await _controleDeContactos.Contacts.AddAsync(contact);
            await _controleDeContactos.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> Delete(int id)
        {
            ContactModel contact = await ListByID(id) ?? throw new KeyNotFoundException($"Contact with ID: {id}, not found. Please, try again!");
            _controleDeContactos.Contacts.Remove(contact);
            await _controleDeContactos.SaveChangesAsync();
            return true;
        }

        public async Task<List<ContactModel>> ListAll()
        {
            return await _controleDeContactos.Contacts.ToListAsync();
        }

        public async Task<ContactModel> ListByID(int id)
        {
            return await _controleDeContactos.Contacts.FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException($"Contact with ID: {id}, not found. Please, try again!");
        }

        public async Task<ContactModel> Update(ContactModel contact, int id)
        {
            ContactModel contactID = await ListByID(id) ?? throw new KeyNotFoundException($"Contact with ID: {id}, not found. Please, try again!");
            contactID.Name = contact.Name;
            contactID.LastName = contact.LastName;
            contactID.Email = contact.Email;
            contactID.Phone = contact.Phone;
            _controleDeContactos.Contacts.Update(contactID);
            await _controleDeContactos.SaveChangesAsync();

            return contactID;
        }
    }
}