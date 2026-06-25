using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.DTOs.UserDTOs
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}