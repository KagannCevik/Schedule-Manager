using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project8DayAndNight.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}