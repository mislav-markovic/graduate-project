using System.Collections.Generic;

namespace GroupTrip.Shared.Models
{
  public class Group
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int TripId { get; set; }
  }
}