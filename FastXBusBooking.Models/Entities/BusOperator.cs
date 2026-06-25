using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.Models.Entities
{
    public class BusOperator
    {
        [Key]
        public int OperatorId { get; set; }

        public string OperatorName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public string CompanyName { get; set; }
    }
}