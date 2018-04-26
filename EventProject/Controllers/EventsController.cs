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
                var SingleEvent = db.Events.SingleOrDefault(s => s.ID == eventID);
                if (SingleEvent == null)
                {
                    return NotFound();
                } else
                {
                    return Ok(SingleEvent);
                }
            }
        }
    }
}