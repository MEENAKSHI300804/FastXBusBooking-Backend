using FastXBusBooking.DTOs.AdminDTOs;
using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Interfaces;
using FastXBusBooking.Services.Interfaces;
using FastXBusBooking.Services.Helpers;

namespace FastXBusBooking.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AdminService(
            IAdminRepository repository,
            JwtTokenGenerator jwtTokenGenerator
        )
        {
            _repository = repository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AdminResponseDto> CreateAsync(CreateAdminDto dto)
        {
            var admin = new Admin
            {
                AdminName = dto.AdminName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash)
            };

            var result = await _repository.CreateAsync(admin);

            return new AdminResponseDto
            {
                AdminId = result.AdminId,
                AdminName = result.AdminName,
                Email = result.Email,
                
            };
        }

        public async Task<AdminResponseDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;

            return new AdminResponseDto
            {
                AdminId = result.AdminId,
                AdminName = result.AdminName,
                Email = result.Email,
                
            };
        }

        public async Task<List<AdminResponseDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return result.Select(x => new AdminResponseDto
            {
                AdminId = x.AdminId,
                AdminName = x.AdminName,
                Email = x.Email,
                
            }).ToList();
        }

        public async Task<AdminResponseDto> UpdateAsync(int id, CreateAdminDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return null;

            existing.AdminName = dto.AdminName;
            existing.Email = dto.Email;
            existing.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash);

            var result = await _repository.UpdateAsync(existing);

            return new AdminResponseDto
            {
                AdminId = result.AdminId,
                AdminName = result.AdminName,
                Email = result.Email,
                
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        // ADMIN LOGIN + JWT
        public async Task<AdminLoginResponseDto> LoginAdmin(LoginAdminDto dto)
        {
            var admin = await _repository.GetAdminByEmail(dto.Email);

if (admin == null)
    return null;

var isPasswordValid = BCrypt.Net.BCrypt.Verify(
    dto.Password,
    admin.PasswordHash
);

if (!isPasswordValid)
    return null;

            if (admin == null)
                return null;

            var token = _jwtTokenGenerator.GenerateToken(
                admin.Email,
                "Admin"
            );

            return new AdminLoginResponseDto
            {
                Token = token,

                Admin = new AdminResponseDto
                {
                    AdminId = admin.AdminId,
                    AdminName = admin.AdminName,
                    Email = admin.Email,
                    
                }
            };
        }
    }
}