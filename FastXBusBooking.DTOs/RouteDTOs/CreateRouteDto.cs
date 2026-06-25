using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.DTOs.RouteDTOs
{
    public class CreateRouteDto
    {
        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime JourneyDate { get; set; }

        [Required]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        public TimeSpan ArrivalTime { get; set; }

        [Required]
        public int BusId { get; set; }
    }
}