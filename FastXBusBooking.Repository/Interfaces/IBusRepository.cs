using FastXBusBooking.Models.Entities;

namespace FastXBusBooking.Repository.Interfaces
{
    public interface IBusRepository
    {
        Task<Bus> CreateAsync(Bus bus);
        Task<Bus> GetByIdAsync(int id);
        Task<IEnumerable<Bus>> GetAllAsync();
        Task<IEnumerable<Bus>> GetAllPagedAsync(int page, int pageSize);
        Task<Bus> UpdateAsync(Bus bus);
        Task<bool> DeleteAsync(int id);
    }
}