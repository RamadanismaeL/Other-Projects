using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Maps;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
/*
*@author Ramadan ismaeL
*/
    public class SistemaDeTarefasDB(DbContextOptions<SistemaDeTarefasDB> options) : DbContext(options)
    {
    public DbSet<UserModel> Users { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}