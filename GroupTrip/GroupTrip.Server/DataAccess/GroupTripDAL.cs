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
        if (group.TripId == tripId)
          RemoveGroup(group.Id);
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
    public IEnumerable<Group> GetGroupsForPerson(int personId)
    {
      var groups = _context.PersonGroupDbSet.Where(pg => pg.PersonId == personId).Select(pg => pg.GroupId);
      return _context.GroupDbSet.Where(g => groups.Contains(g.Id));
    }
        public void RemoveGroup(int groupId)
    {
      var group = GetGroup(groupId);
      RemovePersonGroupByGroup(groupId);
      _context.GroupDbSet.Remove(group);
      _context.SaveChanges();
    }

    public void RemovePersonFromGroup(int groupId, int personId)
    {
      var pgs = _context.PersonGroupDbSet.Where(pg => pg.GroupId == groupId && pg.PersonId == personId);

      foreach (var pg in pgs) _context.Remove(pg);

      _context.SaveChanges();
    }

    public void RemovePersonGroupByGroup(int groupId)
    {
      var pgs = _context.PersonGroupDbSet.Where(pg => pg.GroupId == groupId);

      foreach (var pg in pgs) _context.Remove(pg);

      _context.SaveChanges();
    }

    public void RemovePersonGroupByPerson(int personId)
    {
      var pgs = _context.PersonGroupDbSet.Where(pg => pg.GroupId == personId);

      foreach (var pg in pgs) _context.Remove(pg);

      _context.SaveChanges();
    }

    public void UpdateGroup(Group updatedGroup)
    {
      _context.Entry(updatedGroup).State = EntityState.Modified;
      _context.SaveChanges();
    }

    public void AddPersonToGroup(Person person, int groupId)
    {
      var find = _context.PersonDbSet.Find(person.Id);

      if (find == null)
      {
        _context.PersonDbSet.Add(person);
        _context.SaveChanges();
      }

      var personGroup = new PersonGroup {GroupId = groupId, PersonId = person.Id};
      _context.PersonGroupDbSet.Add(personGroup);
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

    public IEnumerable<Person> GetPeopleNotInGroup(int groupId)
    {
      var members = _context.PersonGroupDbSet.Where(pg => pg.GroupId == groupId).Select(pg => pg.PersonId).ToList();

      return _context.PersonDbSet.Where(p => !members.Contains(p.Id));
    }

    public void RemovePerson(int personId)
    {
      var person = GetPerson(personId);
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
      var members = _context.PersonGroupDbSet.Where(pg => pg.GroupId == groupId).Select(pg => pg.PersonId);
      return _context.PersonDbSet.Where(p => members.Contains(p.Id));
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
      return _context.PaymentDbSet.Where(p => p.GroupId == groupId);
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