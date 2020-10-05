using DataLibrary.Mapping;
using EntitiesLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary
{
    public class DBContextSV : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DBContextSV(DbContextOptions<DBContextSV> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ArticuloMap());
        }
    }
}
