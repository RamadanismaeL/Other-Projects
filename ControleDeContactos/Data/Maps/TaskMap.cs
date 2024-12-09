using ControleDeContactos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleDeContactos.Data.Maps
{
    /*
    *@authro Ramadan ismaeL
    */
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            try
            {
                builder.HasKey(t => t.Id);
                builder.Property(t => t.Name).HasMaxLength(50);
                builder.Property(t => t.Description).HasMaxLength(200);
                builder.Property(t => t.Status).IsRequired();
                builder.HasOne(t => t.User);
            }
            catch(Exception error)
            {
                throw new Exception($"_ControleDeContactos error : {error.Message}");
            }
        }
    }
}