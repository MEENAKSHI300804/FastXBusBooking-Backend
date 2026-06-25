using Microsoft.EntityFrameworkCore;
using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Data;
using FastXBusBooking.Repository.Interfaces;

namespace FastXBusBooking.Repository.Implementations
{
    public class RouteRepository : IRouteRepository
    {
        private readonly AppDbContext _context;

        public RouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BusRoute> CreateAsync(BusRoute route)
        {
            _context.BusRoutes.Add(route);
            await _context.SaveChangesAsync();
            return route;
        }

        public async Task<BusRoute> GetByIdAsync(int id)
        {
            return await _context.BusRoutes.FindAsync(id);
        }

        public async Task<IEnumerable<BusRoute>> GetAllAsync()
        {
            return await _context.BusRoutes.ToListAsync();
        }

        public async Task<IEnumerable<BusRoute>> GetAllPagedAsync(int page, int pageSize)
        {
            return await _context.BusRoutes
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<BusRoute>> SearchAsync(string origin, string destination)
        {
            return await _context.BusRoutes
                .Where(r => r.Origin.Contains(origin) &&
                            r.Destination.Contains(destination))
                .ToListAsync();
        }

        public async Task<BusRoute> UpdateAsync(BusRoute route)
        {
            _context.BusRoutes.Update(route);
            await _context.SaveChangesAsync();
            return route;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var route = await _context.BusRoutes.FindAsync(id);

            if (route == null)
                return false;

            _context.BusRoutes.Remove(route);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}