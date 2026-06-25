using FastXBusBooking.DTOs.RouteDTOs;

namespace FastXBusBooking.Services.Interfaces
{
    public interface IRouteService
    {
        Task<RouteResponseDto> CreateAsync(CreateRouteDto dto);
        Task<RouteResponseDto> GetByIdAsync(int id);
        Task<List<RouteResponseDto>> GetAllAsync();
        Task<List<RouteResponseDto>> GetAllPagedAsync(int page, int pageSize);
        Task<List<RouteResponseDto>> SearchAsync(string origin, string destination);
        Task<RouteResponseDto> UpdateAsync(int id, CreateRouteDto dto);
        Task<bool> DeleteAsync(int id);
    }
}