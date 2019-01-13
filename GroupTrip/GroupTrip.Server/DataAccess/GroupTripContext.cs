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


    }
}