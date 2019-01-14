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
            return _context.TripDbSet.ToList();
        }

        public Trip GetTrip(int tripId)
        {
            return _context.TripDbSet.Find(tripId);
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
            _context.GroupDbSet.Add(group);
            _context.SaveChanges();
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return _context.GroupDbSet.ToList();
        }

        public Group GetGroup(int groupId)
        {
            return _context.GroupDbSet.Find(groupId);
        }

        public void RemoveGroup(int groupId)
        {
            var group = _context.GroupDbSet.Find(groupId);
            _context.GroupDbSet.Remove(group);
            _context.SaveChanges();
        }

        public void UpdateGroup(Group updatedGroup)
        {
            _context.Entry(updatedGroup).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddPersonToGroup(Person person, int groupId)
        {
            person.GroupId = groupId;
            _context.PersonDbSet.Add(person);
            _context.SaveChanges();
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.PersonDbSet.ToList();
        }

        public Person GetPerson(int personID)
        {
            return _context.PersonDbSet.Find(personID);
        }

        public void RemovePerson(int personId)
        {
            var person = _context.PersonDbSet.Find(personId);
            _context.PersonDbSet.Remove(person);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person updatedPerson)
        {
            _context.Entry(updatedPerson).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddPayment(Payment payment, int personId)
        {
            payment.PersonId = personId;
            _context.PaymentDbSet.Add(payment);
            _context.SaveChanges();
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _context.PaymentDbSet.ToList();
        }

        public Payment GetPayment(int paymentId)
        {
            return _context.PaymentDbSet.Find(paymentId);
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