using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.DTOs.BusOperatorDTOs
{
    public class LoginBusOperatorDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}