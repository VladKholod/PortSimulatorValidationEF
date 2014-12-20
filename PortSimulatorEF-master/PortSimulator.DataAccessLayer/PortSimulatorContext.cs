using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.DbConfiguration;
using PortSimulator.DataAccessLayer.DbInitializers;
using PortSimulator.DataAccessLayer.DbMapping;

namespace PortSimulator.DataAccessLayer
{
    public class PortSimulatorContext : DbContext
    {
        public PortSimulatorContext()
            : base(Parameters.ConnectionString)
        {
            Database.SetInitializer(new DropCreateIfModelChangesPortDbInitializer());

            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Captain> Captains { get; set; }
        public DbSet<Cargo> Cargos{ get; set; }
        public DbSet<CargoType> CargoTypes { get; set; }
        public DbSet<City> Cities{ get; set; }
        public DbSet<Port> Ports{ get; set; }
        public DbSet<Ship> Ships{ get; set; }
        public DbSet<Trip> Trips{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CaptainMap());
            modelBuilder.Configurations.Add(new CargoMap());
            modelBuilder.Configurations.Add(new CargoTypeMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new PortMap());
            modelBuilder.Configurations.Add(new ShipMap());
            modelBuilder.Configurations.Add(new TripMap());
        }
    }
}
