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

                if (Event != null)
                {
                    if (!String.IsNullOrEmpty(Event.Title))
                    {
                        query = query.Where(w => w.Title.Contains(Event.Title));
                    }
                }

                return query.OrderBy(o => o.Title).ToList();
            }
        }
    }
}