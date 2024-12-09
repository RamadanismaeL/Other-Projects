using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeContatos
{
    /*
    *@author Ramadan ismaeL
    */
    public class ContatoMap : IEntityTypeConfiguration<ContactoModel>
    {
        public void Configure(EntityTypeBuilder<ContactoModel> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Nome).HasMaxLength(100).isRequered;
            builder.HasOne(x => x.Usuario);
        }
    }
}