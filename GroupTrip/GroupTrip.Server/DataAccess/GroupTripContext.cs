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
            modelBuilder.Entity<Person>().HasOne<Group>().WithMany(g => g.People);
            modelBuilder.Entity<Group>().HasOne(g => g.Trip).WithMany(t => t.Groups);
            modelBuilder.Entity<Payment>().HasOne(p => p.Person).WithMany(p => p.Payments);
        }
    }
}