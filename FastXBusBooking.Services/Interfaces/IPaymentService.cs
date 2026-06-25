using FastXBusBooking.DTOs.PaymentDTOs;

namespace FastXBusBooking.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> CreateAsync(CreatePaymentDto dto);
        Task<PaymentResponseDto> GetByIdAsync(int id);
        Task<List<PaymentResponseDto>> GetAllAsync();
        Task<List<PaymentResponseDto>> GetAllPagedAsync(int page, int pageSize);
        Task<PaymentResponseDto> UpdateAsync(int id, CreatePaymentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}