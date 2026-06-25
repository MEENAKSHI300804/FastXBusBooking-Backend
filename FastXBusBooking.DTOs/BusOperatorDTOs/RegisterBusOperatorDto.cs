using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.DTOs.BusOperatorDTOs
{
    public class RegisterBusOperatorDto
    {
        [Required]
        public string OperatorName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string CompanyName { get; set; }
    }
}