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
  }
}