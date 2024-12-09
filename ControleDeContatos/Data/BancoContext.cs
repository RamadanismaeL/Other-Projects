using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
         public BancoContext(DbContextOptions<BancoContext> options) : base(options)
         {}

         public DbSet<ContactoModel> Contactos { get; set; }
         public DbSet<UsuarioModel> Usuarios { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(modelBuilder);
         }
    }
}