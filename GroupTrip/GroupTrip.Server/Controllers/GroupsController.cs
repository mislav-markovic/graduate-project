using System;
using System.Collections.Generic;
using System.Linq;
using GroupTrip.Server.DataAccess;
using GroupTrip.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroupTrip.Server.Controllers
{
  public class GroupsController : Controller
  {
    private readonly GroupTripDAL _db;

    public GroupsController(GroupTripDAL db)
    {
      _db = db;
    }

    // GET: Groups/Index
    [HttpGet]
    [Route("api/Groups/Index")]
    public IEnumerable<Group> Index()
    {
      return _db.GetAllGroups();
    }

    // GET: Groups/Details/5
    [HttpGet]
    [Route("api/Groups/Details/{id}")]
    public Group Details(int id)
    {
      return _db.GetGroup(id);
    }

    //returns groups for one trip
    [HttpGet]
    [Route("api/Groups/Index/{tripId}")]
    public IEnumerable<Group> GroupsForTrip(int tripId)
    {
      return _db.GetGroupsForTrip(tripId);
    }

    //returns members of one group
    [HttpGet]
    [Route("api/Groups/Members/{groupId}")]
    public IEnumerable<Person> GetGroupMembers(int groupId)
    {
      return _db.GetGroupMembers(groupId);
    }

    //returns members of one group
    [HttpGet]
    [Route("api/Groups/NonMembers/{groupId}")]
    public IEnumerable<Person> GetGroupNonMembers(int groupId)
    {
      return _db.GetPeopleNotInGroup(groupId);
    }

        //returns payments for one group
        [HttpGet]
    [Route("api/Groups/Payments/{groupId}")]
    public IEnumerable<Payment> GetGroupExpenses(int groupId)
    {
      return _db.GetPaymentsForGroup(groupId);
    }

    // POST: Groups/Create
    [HttpPost]
    [Route("api/Groups/Create")]
    public void Create([FromBody] Group newGroup)
    {
      _db.AddGroupToTrip(newGroup);
    }

    // PUT: Groups/Edit
    [HttpPut]
    [Route("api/Groups/Edit")]
    public void Edit([FromBody] Group updatedGroup)
    {
      _db.UpdateGroup(updatedGroup);
    }

    // PUT: Groups/Edit
    [HttpPut]
    [Route("api/Groups/AddMember/{groupId}")]
    public void AddMember(int groupId, [FromBody] int personId)
    {
      var person = _db.GetPerson(personId);
      _db.AddPersonToGroup(person, groupId);
    }
        
    // DELETE: Groups/Delete/5
    [HttpDelete]
    [Route("api/Groups/Delete/{id}")]
    public void Delete(int id)
    {
      _db.RemoveGroup(id);
    }

    // DELETE: Groups/Delete/5
    [HttpDelete]
    [Route("api/Groups/RemoveFromGroup/{groupId}")]
    public void Delete(int groupId, [FromBody] int personId)
    {
      _db.RemovePersonFromGroup(groupId, personId);
    }
    }
}