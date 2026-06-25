using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.DTOs.BusDTOs
{
    public class CreateBusDto
    {
        [Required]
        public string BusName { get; set; }

        [Required]
        public string BusNumber { get; set; }

        [Required]
        public string BusType { get; set; }

        [Range(1, 100)]
        public int TotalSeats { get; set; }

        [Range(1, 10000)]
        public decimal Fare { get; set; }

        public string Amenities { get; set; }

        [Required]
        public int OperatorId { get; set; }
    }
}