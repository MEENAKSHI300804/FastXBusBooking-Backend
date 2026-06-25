namespace FastXBusBooking.DTOs.PaymentDTOs
{
    public class PaymentResponseDto
    {
        public int PaymentId { get; set; }

        public int BookingId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentStatus { get; set; }
    }
}