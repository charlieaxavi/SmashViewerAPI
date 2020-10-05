using EntitiesLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Mapping
{
    public class ArticuloMap : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.ToTable("Articulo").HasKey(x=> x.ID);
        }
    }
}
