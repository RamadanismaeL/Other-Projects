using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace controleDeContactos.Data.Maps
{
    /*
    *@author Ramadan ismael
    */
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            try
            {
                builder.HasKey(u => u.Id);
                builder.Property(u => u.FirstName).HasMaxLength(30);
                builder.Property(u => u.LastName).HasMaxLength(30);
                builder.Property(u => u.Email).HasMaxLength(45);
                builder.Property(u => u.UserName).HasMaxLength(21);
            }
            catch(Exception error)
            {
                throw new Exception($"Connection mapuser error : {error.Message}");
            }
        }
    }
}