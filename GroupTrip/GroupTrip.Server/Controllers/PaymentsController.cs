using System.Collections.Generic;
using System.Linq;
using GroupTrip.Server.DataAccess;
using GroupTrip.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroupTrip.Server.Controllers
{
  public class PaymentsController : Controller
  {
    private readonly GroupTripDAL _db;

    public PaymentsController(GroupTripDAL db)
    {
      _db = db;
    }

    // POST: Payments/Create
    [HttpPost]
    [Route("api/Payments/Create")]
    public void Create([FromBody] Payment newPayment)
    {
      _db.AddPayment(newPayment);
    }

    [HttpGet]
    [Route("api/Payments/Person/{personId}")]
    public IEnumerable<Payment> PaymentsForPerson(int personId)
    {
      return _db.GetPaymentsForPerson(personId);
    }

    [HttpGet]
    [Route("api/Payments/GroupTotal/{groupId}")]
    public double GroupTotal(int groupId)
    {
      var total = _db.GetPaymentsForGroup(groupId).Select(p => p.Value).Sum();
      return total;
    }
    }
}