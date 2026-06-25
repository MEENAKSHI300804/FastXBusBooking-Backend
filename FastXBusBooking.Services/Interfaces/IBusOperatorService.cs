using FastXBusBooking.DTOs.BusOperatorDTOs;

namespace FastXBusBooking.Services.Interfaces
{
    public interface IBusOperatorService
    {
        Task<BusOperatorResponseDto> RegisterAsync(RegisterBusOperatorDto dto);

        Task<BusOperatorLoginResponseDto> LoginAsync(LoginBusOperatorDto dto);

        Task<BusOperatorResponseDto> GetByIdAsync(int id);

        Task<List<BusOperatorResponseDto>> GetAllAsync();

        Task<BusOperatorResponseDto> UpdateAsync(int id, RegisterBusOperatorDto dto);

        Task<bool> DeleteAsync(int id);
    }
}