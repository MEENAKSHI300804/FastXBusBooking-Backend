using System.ComponentModel.DataAnnotations;

namespace FastXBusBooking.Models.Entities
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }

        public string BusName { get; set; }

        public string BusNumber { get; set; }

        public string BusType { get; set; }

        public int TotalSeats { get; set; }

        public decimal Fare { get; set; }

        public string Amenities { get; set; }

        public int OperatorId { get; set; }
    }
}