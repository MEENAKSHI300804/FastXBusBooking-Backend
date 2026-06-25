namespace FastXBusBooking.DTOs.RouteDTOs
{
    public class RouteResponseDto
    {
        public int RouteId { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime JourneyDate { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public TimeSpan ArrivalTime { get; set; }

        public int BusId { get; set; }
    }
}