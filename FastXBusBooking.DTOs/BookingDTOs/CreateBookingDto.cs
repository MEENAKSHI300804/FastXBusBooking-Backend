using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.DTOs.BookingDTOs
{
    public class CreateBookingDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RouteId { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public string BookingStatus { get; set; }
    }
}