using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Data.Maps;
using controleDeContactos.Models;
using Microsoft.EntityFrameworkCore;

namespace controleDeContactos.Data
{
    /*
    *@author Ramadan ismaeL
    */
    public class ControleDeContactos : DbContext
    {
        public ControleDeContactos(DbContextOptions<ControleDeContactos> options) : base(options)
        {}

        public DbSet<UserModel>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            try
            {
                model.ApplyConfiguration(new UserMap());
                base.OnModelCreating(model);
            }
            catch(Exception error)
            {
                throw new Exception($"Connection error : {error.Message}");
            }
        }
    }
}