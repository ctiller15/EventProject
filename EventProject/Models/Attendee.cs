using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventProject.Models
{
    public class Attendee
    {
        public int ID { get; set; }
        public string Email { get; set; }

        public ICollection<Event> Event { get; set; } = new HashSet<Event>();
    }
}