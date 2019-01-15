using System.Collections.Generic;
using System.Linq;
using GroupTrip.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupTrip.Server.DataAccess
{
    public class GroupTripDAL
    {
        private readonly GroupTripContext _context;

        public GroupTripDAL()
        {
            _context = new GroupTripContext();
        }

        public void AddTrip(Trip trip)
        {
            _context.TripDbSet.Add(trip);
            _context.SaveChanges();
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return _context.TripDbSet.Include(t => t.Groups).ToList();
        }

        public Trip GetTrip(int tripId)
        {
            return _context.TripDbSet.Include(t => t.Groups).First(t => t.Id == tripId);
        }

        public void RemoveTrip(int tripId)
        {
            var trip = _context.TripDbSet.Find(tripId);
            _context.TripDbSet.Remove(trip);
            _context.SaveChanges();
        }

        public void UpdateTrip(Trip updatedTrip)
        {
            _context.Entry(updatedTrip).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddGroupToTrip(Group group)
        {
            group.Trip = GetTrip(group.TripId);
            _context.GroupDbSet.Add(group);
            _context.SaveChanges();
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return _context.GroupDbSet.Include(g => g.People).ThenInclude(p => p.Payments).ToList();
        }

        public Group GetGroup(int groupId)
        {
            return _context.GroupDbSet.Include(g => g.People).ThenInclude(p => p.Payments).First(g => g.Id == groupId);
        }

        public void RemoveGroup(int groupId)
        {
            var group = GetGroup(groupId);
            foreach (var person in group.People)
            {
                RemovePerson(person.Id);
            }

            _context.GroupDbSet.Remove(group);
            _context.SaveChanges();
        }

        public void UpdateGroup(Group updatedGroup)
        {
            _context.Entry(updatedGroup).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddPersonToGroup(Person person)
        {
            person.Group = GetGroup(person.GroupId);
            _context.PersonDbSet.Add(person);
            _context.SaveChanges();
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.PersonDbSet.Include(p => p.Payments).Include(p => p.Group).ToList();
        }

        public Person GetPerson(int personId)
        {
            return _context.PersonDbSet.Include(p => p.Payments).Include(p => p.Group).First(p => p.Id == personId);
        }

        public void RemovePerson(int personId)
        {
            var person = GetPerson(personId);
            foreach (var personPayment in person.Payments)
            {
                RemovePayment(personPayment.Id);
            }

            _context.PersonDbSet.Remove(person);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person updatedPerson)
        {
            _context.Entry(updatedPerson).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddPayment(Payment payment)
        {
            payment.Person = GetPerson(payment.PersonId);
            _context.PaymentDbSet.Add(payment);
            _context.SaveChanges();
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _context.PaymentDbSet.Include(p => p.Person).ToList();
        }

        public Payment GetPayment(int paymentId)
        {
            return _context.PaymentDbSet.Include(p => p.Person).First(p => p.Id == paymentId);
        }

        public void UpdatePayment(Payment updatedPayment)
        {
            _context.Entry(updatedPayment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemovePayment(int paymentId)
        {
            var payment = _context.PaymentDbSet.Find(paymentId);
            _context.PaymentDbSet.Remove(payment);
            _context.SaveChanges();
        }
    }
}