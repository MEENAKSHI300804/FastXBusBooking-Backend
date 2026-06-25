using FastXBusBooking.DTOs.BookingDTOs;
using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Interfaces;
using FastXBusBooking.Services.Interfaces;

namespace FastXBusBooking.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookingResponseDto> CreateAsync(CreateBookingDto dto)
        {
            var booking = new Booking
            {
                UserId = dto.UserId,
                RouteId = dto.RouteId,
                NumberOfSeats = dto.NumberOfSeats,
                TotalAmount = dto.TotalAmount,
                BookingDate = dto.BookingDate == DateTime.MinValue ? DateTime.Now : dto.BookingDate,
                BookingStatus = dto.BookingStatus
            };

            var result = await _repository.CreateAsync(booking);

            return MapToDto(result);
        }

        public async Task<BookingResponseDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;

            return MapToDto(result);
        }

        public async Task<List<BookingResponseDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return result.Select(MapToDto).ToList();
        }

        public async Task<List<BookingResponseDto>> GetAllPagedAsync(int page, int pageSize)
        {
            var result = await _repository.GetAllPagedAsync(page, pageSize);

            return result.Select(MapToDto).ToList();
        }

        public async Task<List<BookingResponseDto>> GetByUserIdAsync(int userId)
        {
            var result = await _repository.GetByUserIdAsync(userId);

            return result.Select(MapToDto).ToList();
        }

        public async Task<BookingResponseDto> UpdateAsync(int id, CreateBookingDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return null;

            existing.UserId = dto.UserId;
            existing.RouteId = dto.RouteId;
            existing.NumberOfSeats = dto.NumberOfSeats;
            existing.TotalAmount = dto.TotalAmount;
            existing.BookingDate = dto.BookingDate;
            existing.BookingStatus = dto.BookingStatus;

            var result = await _repository.UpdateAsync(existing);

            return MapToDto(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private BookingResponseDto MapToDto(Booking booking)
        {
            return new BookingResponseDto
            {
                BookingId = booking.BookingId,
                UserId = booking.UserId,
                RouteId = booking.RouteId,
                NumberOfSeats = booking.NumberOfSeats,
                TotalAmount = booking.TotalAmount,
                BookingDate = booking.BookingDate,
                BookingStatus = booking.BookingStatus
            };
        }
    }
}