using Microsoft.EntityFrameworkCore;
using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Data;
using FastXBusBooking.Repository.Interfaces;

namespace FastXBusBooking.Repository.Implementations
{
    public class BusOperatorRepository : IBusOperatorRepository
    {
        private readonly AppDbContext _context;

        public BusOperatorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BusOperator> RegisterAsync(BusOperator busOperator)
        {
            _context.BusOperators.Add(busOperator);
            await _context.SaveChangesAsync();
            return busOperator;
        }

        public async Task<BusOperator> GetByEmailAsync(string email)
{
    return await _context.BusOperators
        .FirstOrDefaultAsync(x => x.Email == email);
}
        public async Task<BusOperator> GetByIdAsync(int id)
        {
            return await _context.BusOperators.FindAsync(id);
        }

        public async Task<IEnumerable<BusOperator>> GetAllAsync()
        {
            return await _context.BusOperators.ToListAsync();
        }

        public async Task<BusOperator> UpdateAsync(BusOperator busOperator)
        {
            _context.BusOperators.Update(busOperator);
            await _context.SaveChangesAsync();
            return busOperator;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var busOperator = await _context.BusOperators.FindAsync(id);

            if (busOperator == null)
                return false;

            _context.BusOperators.Remove(busOperator);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}