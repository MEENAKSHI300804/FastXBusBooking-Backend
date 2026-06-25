using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.DTOs.UserDTOs
{
    public class RegisterUserDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }
    }
}