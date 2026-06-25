using Microsoft.EntityFrameworkCore;
using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Data;
using FastXBusBooking.Repository.Interfaces;

namespace FastXBusBooking.Repository.Implementations
{
    public class BusRepository : IBusRepository
    {
        private readonly AppDbContext _context;

        public BusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Bus> CreateAsync(Bus bus)
        {
            _context.Buses.Add(bus);
            await _context.SaveChangesAsync();
            return bus;
        }

        public async Task<Bus> GetByIdAsync(int id)
        {
            return await _context.Buses.FindAsync(id);
        }

        public async Task<IEnumerable<Bus>> GetAllAsync()
        {
            return await _context.Buses.ToListAsync();
        }

        public async Task<Bus> UpdateAsync(Bus bus)
        {
            _context.Buses.Update(bus);
            await _context.SaveChangesAsync();
            return bus;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bus = await _context.Buses.FindAsync(id);

            if (bus == null)
                return false;

            _context.Buses.Remove(bus);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<IEnumerable<Bus>> GetAllPagedAsync(int page, int pageSize)
{
    return await _context.Buses
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
}
    }
}