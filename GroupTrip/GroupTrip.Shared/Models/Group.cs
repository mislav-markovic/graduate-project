using System.Collections.Generic;

namespace GroupTrip.Shared.Models
{
  public class Group
  {
    public Group()
    {
      Persons = new List<Person>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public List<Person> Persons { get; set; }
    public int TripId { get; set; }
    public Trip Trip { get; set; }
  }
}