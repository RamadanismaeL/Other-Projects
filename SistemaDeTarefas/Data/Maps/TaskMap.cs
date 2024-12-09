using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data.Maps
{
/*
*@author Ramadan ismaeL
*/
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {

        public void Configure(EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(75);
            builder.Property(t => t.Description).HasMaxLength(1000);
            builder.Property(t => t.Status).IsRequired();
            builder.Property(t => t.UserID);
            builder.HasOne(t => t.User);
        }
    }
}