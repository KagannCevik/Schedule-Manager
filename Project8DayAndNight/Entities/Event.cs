using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project8DayAndNight.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public int CategoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Category Category { get; set; }
    }
}