﻿using System;
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

    // POST: Groups/Create
    [HttpPost]
    [Route("api/Groups/Create/{tripId}")]
    public void Create([FromBody] Group newGroup, int tripId)
    {
      _db.AddGroupToTrip(newGroup, tripId);
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