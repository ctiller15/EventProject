using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventProject.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Long_Description { get; set; }
        public string Address { get; set; }
        //public string City { get; set; }

        public int? CityID { get; set; }
        public City City { get; set; }

        public string State { get; set; }
        public string Zip { get; set; }
        public int? Age_Limit { get; set; }
        public decimal? Price { get; set; }
        public DateTime DateHappening { get; set; }

        public ICollection<Attendee> Attendee { get; set; } = new HashSet<Attendee>();
    }
}