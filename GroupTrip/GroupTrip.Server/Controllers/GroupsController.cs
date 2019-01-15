using System;
using System.Collections.Generic;
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

    [HttpGet]
    [Route("api/Groups/Index/{tripId}")]
    public IEnumerable<Group> GroupsForTrip(int tripId)
    {
      return _db.GetGroupsForTrip(tripId);
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

    // DELETE: Groups/Delete/5
    [HttpDelete]
    [Route("api/Groups/Delete/{id}")]
    public void Delete(int id)
    {
      _db.RemoveGroup(id);
    }
  }
}