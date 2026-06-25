using FastXBusBooking.Models.Entities;

namespace FastXBusBooking.Repository.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin> CreateAsync(Admin admin);

        Task<Admin> GetByIdAsync(int id);

        Task<IEnumerable<Admin>> GetAllAsync();

        Task<Admin> UpdateAsync(Admin admin);

        Task<bool> DeleteAsync(int id);
        Task<Admin> GetAdminByEmail(string email);
    }
}