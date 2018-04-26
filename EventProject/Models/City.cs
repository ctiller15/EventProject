using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventProject.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int? EventID { get; set; }
        public Event Event { get; set; }
    }
}