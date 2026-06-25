using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FastXBusBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatBookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeatBookingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("bus/{busId}")]
        public IActionResult GetBookedSeats(int busId)
        {
            var bookedSeats = _context.SeatBookings
                .Where(s => s.BusId == busId)
                .Select(s => s.SeatNumber)
                .ToList();

            return Ok(bookedSeats);
        }
[HttpGet("bus/{busId}/date/{journeyDate}")]
public async Task<IActionResult> GetBookedSeats(
    int busId,
    DateTime journeyDate)
{
    var seats = await _context.SeatBookings
        .Where(x =>
            x.BusId == busId &&
            x.JourneyDate.Date == journeyDate.Date)
        .Select(x => x.SeatNumber)
        .ToListAsync();

    return Ok(seats);
}

        [HttpPost]
        public IActionResult BookSeats([FromBody] List<SeatBooking> seatBookings)
        {
            if (seatBookings == null || seatBookings.Count == 0)
            {
                return BadRequest("No seats selected");
            }

            _context.SeatBookings.AddRange(seatBookings);
            _context.SaveChanges();

            return Ok("Seats booked successfully");
        }
    }
}