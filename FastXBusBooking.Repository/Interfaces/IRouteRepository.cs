using FastXBusBooking.Models.Entities;

namespace FastXBusBooking.Repository.Interfaces
{
    public interface IRouteRepository
    {
        Task<BusRoute> CreateAsync(BusRoute route);
        Task<BusRoute> GetByIdAsync(int id);
        Task<IEnumerable<BusRoute>> GetAllAsync();
        Task<IEnumerable<BusRoute>> GetAllPagedAsync(int page, int pageSize);
        Task<IEnumerable<BusRoute>> SearchAsync(string origin, string destination);
        Task<BusRoute> UpdateAsync(BusRoute route);
        Task<bool> DeleteAsync(int id);
    }
}