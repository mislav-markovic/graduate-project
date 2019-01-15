using GroupTrip.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupTrip.Server.DataAccess
{
    public class GroupTripContext : DbContext
    {
        public virtual DbSet<Person> PersonDbSet { get; set; }
        public virtual DbSet<Group> GroupDbSet { get; set; }
        public virtual DbSet<Trip> TripDbSet { get; set; }
        public virtual DbSet<Payment> PaymentDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Group>().HasKey(p => p.Id);
            modelBuilder.Entity<Payment>().HasKey(p => p.Id);
            modelBuilder.Entity<Trip>().HasKey(p => p.Id);

            modelBuilder.Entity<Person>().HasOne<Group>().WithMany(g => g.Persons).HasForeignKey(g=> g.GroupId);
            modelBuilder.Entity<Group>().HasOne(g => g.Trip).WithMany(t => t.Groups).HasForeignKey(g => g.TripId);
            modelBuilder.Entity<Payment>().HasOne(p => p.Person).WithMany(p => p.Payments).HasForeignKey(g => g.PersonId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection =
                    @"Server=(localdb)\mssqllocaldb;Database=GroupTrip.Db;Trusted_Connection=True;ConnectRetryCount=0";
                optionsBuilder.UseSqlServer(connection);
            }
        }
    }
}