using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.DTOs.AdminDTOs
{
    public class CreateAdminDto
    {
        [Required]
        public string AdminName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string PasswordHash { get; set; }
    }
}