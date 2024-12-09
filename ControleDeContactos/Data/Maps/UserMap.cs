using ControleDeContactos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeContactos.Data.Maps
{
    /*
    *@author Ramadan ismaeL
    */
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            try
            {
                builder.HasKey(u => u.Id);
                builder.Property(c => c.Name).HasMaxLength(50);
                builder.Property(c => c.LastName).HasMaxLength(30);
                builder.Property(u => u.Email).HasMaxLength(75);
                builder.Property(u => u.UserName).HasMaxLength(25);
            }
            catch(Exception error)
            {
                throw new Exception($"_ControleDeContactos error : {error.Message}");
            }
        }
    }
}