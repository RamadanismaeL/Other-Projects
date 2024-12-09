using ControleDeContactos.Data.Maps;
using ControleDeContactos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContactos.Data
{
/*
*@author Ramadan ismaeL
*/
    public class _ControleDeContactos : DbContext
    {
        public _ControleDeContactos(DbContextOptions<_ControleDeContactos> options) : base(options)
        {}

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.ApplyConfiguration(new ContactMap());
                modelBuilder.ApplyConfiguration(new TaskMap());
                modelBuilder.ApplyConfiguration(new UserMap());
                base.OnModelCreating(modelBuilder);
            }
            catch(Exception error)
            {
                throw new Exception($"_ControleDeContactos error : {error.Message}");
            }
        }
    }
}