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
      // return _context.TripDbSet.Include(t => t.Groups).ToList();
      return _context.TripDbSet.ToList();
    }

    public Trip GetTrip(int tripId)
    {
      //return _context.TripDbSet.Include(t => t.Groups).First(t => t.Id == tripId);
      var trip = _context.TripDbSet.Find(tripId);
      return trip;
    }

    public void RemoveTrip(int tripId)
    {
      var trip = _context.TripDbSet.Find(tripId);
      foreach (var group in GetAllGroups())
      {
        if(group.TripId == tripId) RemoveGroup(group.Id); 
      }
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
      //group.Trip = GetTrip(group.TripId);
      _context.GroupDbSet.Add(group);
      _context.SaveChanges();
    }

    public IEnumerable<Group> GetAllGroups()
    {
      return _context.GroupDbSet.ToList();
    }

    public Group GetGroup(int groupId)
    {
      return _context.GroupDbSet.First(g => g.Id == groupId);
    }

    public IEnumerable<Group> GetGroupsForTrip(int tripId)
    {
      return _context.GroupDbSet.Where(g => g.TripId == tripId);
    }

    public void RemoveGroup(int groupId)
    {
      var group = GetGroup(groupId);
      foreach (var person in GetAllPeople())
      {
        if (person.GroupId == groupId) RemovePerson(person.Id);
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
      _context.PersonDbSet.Add(person);
      _context.SaveChanges();
    }

    public IEnumerable<Person> GetAllPeople()
    {
      return _context.PersonDbSet.ToList();
    }

    public Person GetPerson(int personId)
    {
      return _context.PersonDbSet.First(p => p.Id == personId);
    }

    public void RemovePerson(int personId)
    {
      var person = GetPerson(personId);
      foreach (var payment in GetAllPayments())
      {
        if (payment.PersonId == personId) RemovePayment(payment.Id);
      }
      _context.PersonDbSet.Remove(person);
      _context.SaveChanges();
    }

    public void UpdatePerson(Person updatedPerson)
    {
      _context.Entry(updatedPerson).State = EntityState.Modified;
      _context.SaveChanges();
    }

    public IEnumerable<Person> GetGroupMembers(int groupId)
    {
      return _context.PersonDbSet.Where(p => p.GroupId == groupId);
    }

    public void AddPayment(Payment payment)
    {
      _context.PaymentDbSet.Add(payment);
      _context.SaveChanges();
    }

    public IEnumerable<Payment> GetAllPayments()
    {
      return _context.PaymentDbSet.ToList();
    }

    public IEnumerable<Payment> GetPaymentsForPerson(int personId)
    {
      return _context.PaymentDbSet.Where(p => p.PersonId == personId);
    }

    public IEnumerable<Payment> GetPaymentsForGroup(int groupId)
    {
      var people = GetGroupMembers(groupId);
      var payments = new List<Payment>();

      foreach (var personId in people.Select(p => p.Id))
      {
        payments.AddRange(GetPaymentsForPerson(personId));
      }

      return payments;
    }

    public Payment GetPayment(int paymentId)
    {
      return _context.PaymentDbSet.First(p => p.Id == paymentId);
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