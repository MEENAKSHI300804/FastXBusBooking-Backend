using FastXBusBooking.DTOs.BusDTOs;

namespace FastXBusBooking.Services.Interfaces
{
    public interface IBusService
    {
        Task<BusResponseDto> CreateAsync(CreateBusDto dto);
        Task<BusResponseDto> GetByIdAsync(int id);
        Task<List<BusResponseDto>> GetAllAsync();
        Task<List<BusResponseDto>> GetAllPagedAsync(int page, int pageSize);
        Task<BusResponseDto> UpdateAsync(int id, CreateBusDto dto);
        Task<bool> DeleteAsync(int id);
    }
}