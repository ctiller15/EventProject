using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventProject.ViewModels.Events
{
    public class GetEvent
    {
        public string Title { get; set; }
        public string TagLine { get; set; }
        public string Long_Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int? Age_Limit { get; set; }
        // Nullable on the viewmodel, not nullable on the actual model.
        public decimal? Price { get; set; }
        public DateTime? DateHappening { get; set; }
    }
}