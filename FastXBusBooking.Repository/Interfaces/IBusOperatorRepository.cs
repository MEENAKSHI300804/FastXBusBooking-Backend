using FastXBusBooking.Models.Entities;

namespace FastXBusBooking.Repository.Interfaces
{
    public interface IBusOperatorRepository
    {
        Task<BusOperator> RegisterAsync(BusOperator busOperator);

        Task<BusOperator> GetByEmailAsync(string email);

        Task<BusOperator> GetByIdAsync(int id);

        Task<IEnumerable<BusOperator>> GetAllAsync();

        Task<BusOperator> UpdateAsync(BusOperator busOperator);

        Task<bool> DeleteAsync(int id);
    }
}