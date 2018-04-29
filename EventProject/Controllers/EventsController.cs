using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EventProject.Data;
using EventProject.Models;
using EventProject.ViewModels.Events;
using EventProject.Services;

namespace EventProject.Controllers
{
    public class EventsController : ApiController
    {
        // GET: Find all events in the city.
        [Route("api/events")]
        [HttpGet]
        public IEnumerable<Event> GetEvents([FromUri]GetEvent Event)
        {
            using (var db = new EventContext())
            {
                var query = db.Events.Include(i => i.City);

                query = Queries.EventQueryParse(query, Event);

                return query.OrderBy(o => o.Title).ToList();
            }
        }

        // GET: One event.
        [Route("api/events/{eventID}")]
        [HttpGet]
        public IHttpActionResult GetOneEvent(int eventID)
        {
            using (var db = new EventContext())
            {
                var SingleEvent = db.Events.Include(i => i.Attendee).Include(i => i.City).SingleOrDefault(s => s.ID == eventID);
                if (SingleEvent == null)
                {
                    return NotFound();
                } else
                {

                    return Ok(SingleEvent);
                }
            }
        }

        // POST: Have user enter an event.
        [Route("api/events/{eventID}")]
        [HttpPost]
        public IHttpActionResult SignUpForEvent(int eventID, [FromBody]EnterEvent EventInfo)
        {
            using (var db = new EventContext())
            {
                var AllUsers = db.Attendees.Include(i => i.Event);
                // If the user exists, great!
                // If not, create them.
                var user = AllUsers.SingleOrDefault(s => s.Email == EventInfo.Email);
                var CurrentEvent = db.Events.Single(w => w.ID == eventID);

                if(user == null)
                {
                    user = new Attendee
                    {
                        Email = EventInfo.Email
                    };
                    db.Attendees.Add(user);
                    db.SaveChanges();
                }

                user.Event.Add(CurrentEvent);

                db.SaveChanges();
                return Ok(EventInfo);
            }
        }
    }
}