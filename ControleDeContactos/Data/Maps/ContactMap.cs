using ControleDeContactos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeContactos.Data.Maps
{
    /*
    *@author Ramadan ismaeL
    */
    public class ContactMap : IEntityTypeConfiguration<ContactModel>
    {
        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {
            try
            {
                builder.HasKey(c => c.Id);
                builder.Property(c => c.Name).HasMaxLength(50);
                builder.Property(c => c.LastName).HasMaxLength(30);
                builder.Property(c => c.Email).HasMaxLength(75);
                builder.Property(c => c.Phone).HasMaxLength(20);
                builder.HasOne(c => c.User);
            }
            catch(Exception error)
            {
                throw new Exception($"_ControleDeContactos error : {error.Message}");
            }
        }
    }
}