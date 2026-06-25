using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.Models.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int UserId { get; set; }

        public int RouteId { get; set; }

        public int NumberOfSeats { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime BookingDate { get; set; }

        public string BookingStatus { get; set; }
    }
}