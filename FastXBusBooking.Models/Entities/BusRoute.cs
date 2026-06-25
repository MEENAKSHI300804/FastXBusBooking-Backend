using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastXBusBooking.Models.Entities
{
    [Table("Routes")]
    public class BusRoute
    {
        [Key]
        public int RouteId { get; set; }

        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime JourneyDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int BusId { get; set; }
    }
}
