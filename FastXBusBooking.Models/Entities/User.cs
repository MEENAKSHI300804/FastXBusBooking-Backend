using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.Models.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }
    }
}