using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.DTOs.AdminDTOs
{
    public class LoginAdminDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}