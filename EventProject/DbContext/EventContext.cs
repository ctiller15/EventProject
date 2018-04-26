using EventProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventProject.Data
{
    public class EventContext :DbContext
    {
        public EventContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
    }
}