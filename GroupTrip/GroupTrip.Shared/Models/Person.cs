using System.Collections.Generic;

namespace GroupTrip.Shared.Models
{
    public class Person
    {
        public Person()
        {
            Payments = new List<Payment>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public List<Payment> Payments { get; set; }
    }
}