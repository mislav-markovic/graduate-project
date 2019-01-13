using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupTrip.Server.DataAccess;
using GroupTrip.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroupTrip.Server.Controllers
{
    public class TripsController : Controller
    {
        private readonly GroupTripDAL _db;

        public TripsController(GroupTripDAL db)
        {
            _db = db;
        }

        // GET: Trips/Index
        [HttpGet]
        [Route("api/Trips/Index")]
        public IEnumerable<Trip> Index()
        {
            return _db.GetAllTrips();
        }

        // GET: Trips/Details/5
        [HttpGet]
        [Route("api/Trips/Details/{id}")]
        public Trip Details(int id)
        {
            return _db.GetTrip(id);
        }

        // POST: Trips/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("api/Trips/Create")]
        public void Create([FromBody]Trip newTrip)
        {
            _db.AddTrip(newTrip);
        }

        // PUT: Trips/Edit
        [HttpPut]
        [Route("api/Trips/Edit")]
        public void Edit([FromBody]Trip updatedTrip)
        {
            _db.UpdateTrip(updatedTrip);
        }

        // DELETE: Trips/Delete/5
        [HttpDelete]
        [Route("api/Trips/Delete/{id}")]
        public void Delete(int id)
        {
            _db.RemoveTrip(id);
        }
    }
}