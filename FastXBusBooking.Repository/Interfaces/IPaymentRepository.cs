using FastXBusBooking.Models.Entities;

namespace FastXBusBooking.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> CreateAsync(Payment payment);
        Task<Payment> GetByIdAsync(int id);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<IEnumerable<Payment>> GetAllPagedAsync(int page, int pageSize);
        Task<Payment> UpdateAsync(Payment payment);
        Task<bool> DeleteAsync(int id);
    }
}