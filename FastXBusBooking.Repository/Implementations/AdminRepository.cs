using Microsoft.EntityFrameworkCore;
using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Data;
using FastXBusBooking.Repository.Interfaces;

namespace FastXBusBooking.Repository.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> CreateAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin> UpdateAsync(Admin admin)
        {
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
                return false;

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();

            return true;
        }
public async Task<Admin> GetAdminByEmail(string email)
{
    return await _context.Admins
        .FirstOrDefaultAsync(a => a.Email == email);
}

    }
}