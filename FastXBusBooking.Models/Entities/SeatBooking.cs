using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.Models.Entities
{
    public class SeatBooking
    {
        [Key]
        public int SeatBookingId { get; set; }

        public int BusId { get; set; }

        public int BookingId { get; set; }

        public int SeatNumber { get; set; }

        public string SeatStatus { get; set; } = "Booked";
public DateTime JourneyDate { get; set; }
    }
}