using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.DTOs.PaymentDTOs
{
    public class CreatePaymentDto
    {
        [Required]
        public int BookingId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentStatus { get; set; }
    }
}