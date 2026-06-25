using FastXBusBooking.DTOs.PaymentDTOs;
using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Interfaces;
using FastXBusBooking.Services.Interfaces;

namespace FastXBusBooking.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaymentResponseDto> CreateAsync(CreatePaymentDto dto)
        {
            var payment = new Payment
            {
                BookingId = dto.BookingId,
                Amount = dto.Amount,
                PaymentMethod = dto.PaymentMethod,
                PaymentDate = dto.PaymentDate == DateTime.MinValue ? DateTime.Now : dto.PaymentDate,
                PaymentStatus = dto.PaymentStatus
            };

            var result = await _repository.CreateAsync(payment);
            return MapToDto(result);
        }

        public async Task<PaymentResponseDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;

            return MapToDto(result);
        }

        public async Task<List<PaymentResponseDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return result.Select(MapToDto).ToList();
        }

        public async Task<List<PaymentResponseDto>> GetAllPagedAsync(int page, int pageSize)
        {
            var result = await _repository.GetAllPagedAsync(page, pageSize);
            return result.Select(MapToDto).ToList();
        }

        public async Task<PaymentResponseDto> UpdateAsync(int id, CreatePaymentDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return null;

            existing.BookingId = dto.BookingId;
            existing.Amount = dto.Amount;
            existing.PaymentMethod = dto.PaymentMethod;
            existing.PaymentDate = dto.PaymentDate;
            existing.PaymentStatus = dto.PaymentStatus;

            var result = await _repository.UpdateAsync(existing);
            return MapToDto(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private PaymentResponseDto MapToDto(Payment payment)
        {
            return new PaymentResponseDto
            {
                PaymentId = payment.PaymentId,
                BookingId = payment.BookingId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentDate = payment.PaymentDate,
                PaymentStatus = payment.PaymentStatus
            };
        }
    }
}