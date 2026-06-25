using FastXBusBooking.DTOs.BookingDTOs;

namespace FastXBusBooking.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingResponseDto> CreateAsync(CreateBookingDto dto);
        Task<BookingResponseDto> GetByIdAsync(int id);
        Task<List<BookingResponseDto>> GetAllAsync();
        Task<List<BookingResponseDto>> GetAllPagedAsync(int page, int pageSize);
        Task<List<BookingResponseDto>> GetByUserIdAsync(int userId);
        Task<BookingResponseDto> UpdateAsync(int id, CreateBookingDto dto);
        Task<bool> DeleteAsync(int id);
    }
}