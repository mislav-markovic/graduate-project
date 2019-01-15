using System.Collections.Generic;
using GroupTrip.Server.DataAccess;
using GroupTrip.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroupTrip.Server.Controllers
{
  public class PersonsController : Controller
  {
    private readonly GroupTripDAL _db;

    public PersonsController(GroupTripDAL db)
    {
      _db = db;
    }

    // GET: Persons/Index
    [HttpGet]
    [Route("api/Persons/Index")]
    public IEnumerable<Person> Index()
    {
      return _db.GetAllPeople();
    }

    // GET: Persons/Details/5
    [HttpGet]
    [Route("api/Persons/Details/{id}")]
    public Person Details(int id)
    {
      return _db.GetPerson(id);
    }

    // POST: Persons/Create
    [HttpPost]
    [Route("api/Persons/Create")]
    public void Create([FromBody] Person newPerson)
    {
      _db.AddPersonToGroup(newPerson);
    }

    // PUT: Persons/Edit
    [HttpPut]
    [Route("api/Persons/Edit")]
    public void Edit([FromBody] Person updatedPerson)
    {
      _db.UpdatePerson(updatedPerson);
    }

    // DELETE: Persons/Delete/5
    [HttpDelete]
    [Route("api/Persons/Delete/{id}")]
    public void Delete(int id)
    {
      _db.RemovePerson(id);
    }
  }
}