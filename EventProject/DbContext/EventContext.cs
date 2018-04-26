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
    }
}