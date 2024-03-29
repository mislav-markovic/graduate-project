﻿using System;
using System.Collections.Generic;

namespace GroupTrip.Shared.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}