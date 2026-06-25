using FastXBusBooking.DTOs.BusOperatorDTOs;
using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Interfaces;
using FastXBusBooking.Services.Interfaces;
using FastXBusBooking.Services.Helpers;

namespace FastXBusBooking.Services.Implementations
{
    public class BusOperatorService : IBusOperatorService
    {
        private readonly IBusOperatorRepository _repository;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public BusOperatorService(
            IBusOperatorRepository repository,
            JwtTokenGenerator jwtTokenGenerator
        )
        {
            _repository = repository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<BusOperatorResponseDto> RegisterAsync(RegisterBusOperatorDto dto)
        {
            var busOperator = new BusOperator
            {
                OperatorName = dto.OperatorName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                PhoneNumber = dto.PhoneNumber,
                CompanyName = dto.CompanyName
            };

            var result = await _repository.RegisterAsync(busOperator);

            return new BusOperatorResponseDto
            {
                OperatorId = result.OperatorId,
                OperatorName = result.OperatorName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                CompanyName = result.CompanyName
            };
        }

       public async Task<BusOperatorLoginResponseDto> LoginAsync(LoginBusOperatorDto dto)
{
    var result = await _repository.GetByEmailAsync(dto.Email);

    if (result == null)
        return null;

    var isPasswordValid = BCrypt.Net.BCrypt.Verify(
        dto.Password,
        result.PasswordHash
    );

    if (!isPasswordValid)
        return null;

    var token = _jwtTokenGenerator.GenerateToken(
        result.Email,
        "BusOperator"
    );

    return new BusOperatorLoginResponseDto
    {
        Token = token,

        BusOperator = new BusOperatorResponseDto
        {
            OperatorId = result.OperatorId,
            OperatorName = result.OperatorName,
            Email = result.Email,
            PhoneNumber = result.PhoneNumber,
            CompanyName = result.CompanyName
        }
    };
}
        public async Task<BusOperatorResponseDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;

            return new BusOperatorResponseDto
            {
                OperatorId = result.OperatorId,
                OperatorName = result.OperatorName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                CompanyName = result.CompanyName
            };
        }

        public async Task<List<BusOperatorResponseDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return result.Select(x => new BusOperatorResponseDto
            {
                OperatorId = x.OperatorId,
                OperatorName = x.OperatorName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                CompanyName = x.CompanyName
            }).ToList();
        }

        public async Task<BusOperatorResponseDto> UpdateAsync(int id, RegisterBusOperatorDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return null;

            existing.OperatorName = dto.OperatorName;
            existing.Email = dto.Email;
            existing.PasswordHash =
    BCrypt.Net.BCrypt.HashPassword(dto.Password);
            existing.PhoneNumber = dto.PhoneNumber;
            existing.CompanyName = dto.CompanyName;

            var result = await _repository.UpdateAsync(existing);

            return new BusOperatorResponseDto
            {
                OperatorId = result.OperatorId,
                OperatorName = result.OperatorName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                CompanyName = result.CompanyName
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}