using FastXBusBooking.Models.Entities;

namespace FastXBusBooking.Repository.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> CreateAsync(Booking booking);
        Task<Booking> GetByIdAsync(int id);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<IEnumerable<Booking>> GetAllPagedAsync(int page, int pageSize);
        Task<IEnumerable<Booking>> GetByUserIdAsync(int userId);
        Task<Booking> UpdateAsync(Booking booking);
        Task<bool> DeleteAsync(int id);
    }
}