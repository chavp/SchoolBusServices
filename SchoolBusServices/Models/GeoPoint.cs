using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolBusServices.Models
{
    public class GeoPoint
    {
        public int ID { get; set; }
        public string TrackingName { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}