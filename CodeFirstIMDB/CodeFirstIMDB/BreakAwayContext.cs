using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIMDB
{
    class BreakAwayContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DestinationConfiguration());
            modelBuilder.Configurations.Add(new LodgingConfiguration());
            modelBuilder.Entity<Trip>().HasKey(t => t.Identifier);

            modelBuilder.Entity<Person>().Property(p => p.RowVersion).IsRowVersion();
            modelBuilder.Entity<Destination>()
            .HasMany(d => d.Lodgings)
            .WithOptional(l => l.Destination);
        }
    }
}
