using System;
using System.Collections.Generic;

namespace GroupTrip.Shared.Models
{
    public class Trip
    {
        public Trip()
        {
            Groups = new List<Group>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public List<Group> Groups { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}