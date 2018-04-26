using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EventProject.Models;
using EventProject.ViewModels.Events;

namespace EventProject.Services
{
    public class Queries
    {
        static public IQueryable<Event> EventQueryParse(IQueryable<Event> Query, GetEvent ParseData)
        {
            if (ParseData != null)
            {
                if (!String.IsNullOrEmpty(ParseData.Title))
                {
                    Query = Query.Where(w => w.Title.Contains(ParseData.Title));
                }
            }

            return Query;
        }
    }
}