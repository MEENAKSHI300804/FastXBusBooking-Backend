using Microsoft.EntityFrameworkCore;
using FastXBusBooking.Models.Entities;

namespace FastXBusBooking.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<BusOperator> BusOperators { get; set; }

        public DbSet<Bus> Buses { get; set; }

        public DbSet<BusRoute> BusRoutes { get; set; }

        public DbSet<Booking> Bookings { get; set; }
public DbSet<SeatBooking> SeatBookings { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}