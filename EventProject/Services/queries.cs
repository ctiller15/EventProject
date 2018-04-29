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
                // Checking each individual property:
                // Title
                if (!String.IsNullOrEmpty(ParseData.Title))
                {
                    Query = Query.Where(w => w.Title.Contains(ParseData.Title));
                }

                // Tagline
                if (!String.IsNullOrEmpty(ParseData.TagLine))
                {
                    Query = Query.Where(w => w.Tagline.Contains(ParseData.TagLine));
                }

                // Long Description
                if (!String.IsNullOrEmpty(ParseData.Long_Description))
                {
                    Query = Query.Where(w => w.Long_Description.Contains(ParseData.Long_Description));
                }

                // Address
                if (!String.IsNullOrEmpty(ParseData.Address))
                {
                    Query = Query.Where(w => w.Address.Contains(ParseData.Address));
                }

                //// City
                if (!String.IsNullOrEmpty(ParseData.City))
                {
                    Query = Query.Where(w => w.City.Name.Contains(ParseData.City));
                }

                // State
                if (!String.IsNullOrEmpty(ParseData.State))
                {
                    Query = Query.Where(w => w.State.Contains(ParseData.State));
                }

                // Zip
                if (!String.IsNullOrEmpty(ParseData.Zip))
                {
                    Query = Query.Where(w => w.Zip.Contains(ParseData.Zip));
                }

                // Age Limit
                if (ParseData.Age_Limit != null)
                {
                    Query = Query.Where(w => (w.Age_Limit - 1 < ParseData.Age_Limit) && (ParseData.Age_Limit < w.Age_Limit + 1));
                }

                //Price
                if (ParseData.Price != null)
                {
                    Query = Query.Where(w => w.Tagline.Contains(ParseData.TagLine));
                }

                // DateHappening
                if (ParseData.DateHappening.HasValue)
                {
                    Query = Query.Where(w => w.DateHappening.Year == ParseData.DateHappening.Value.Year
                                        || w.DateHappening.Month == ParseData.DateHappening.Value.Month
                                        || w.DateHappening.Day == ParseData.DateHappening.Value.Day);
                }
            }

            return Query;
        }
    }
}