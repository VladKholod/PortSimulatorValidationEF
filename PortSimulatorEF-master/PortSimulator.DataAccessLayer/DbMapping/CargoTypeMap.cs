﻿using System.Data.Entity.ModelConfiguration;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.DbMapping
{
    public class CargoTypeMap : EntityTypeConfiguration<CargoType>
    {
        public CargoTypeMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            this.ToTable("CargoType");
        }
    }
}
