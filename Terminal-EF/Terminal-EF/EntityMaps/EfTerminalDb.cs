
using Microsoft.EntityFrameworkCore;
using Terminal_EF.Entities;

namespace BusTerminal.EntityMaps
{
    public class EfTerminalDb : DbContext
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Chair> Chairs { get; set; }    
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TerminlaDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfTerminalDb).Assembly);
        }

    }
}
