using FastXBusBooking.DTOs.AdminDTOs;

namespace FastXBusBooking.Services.Interfaces
{
    public interface IAdminService
    {
        // Create Admin
        Task<AdminResponseDto> CreateAsync(CreateAdminDto dto);

        // Get Admin by ID
        Task<AdminResponseDto> GetByIdAsync(int id);

        // Get all Admins
        Task<List<AdminResponseDto>> GetAllAsync();

        // Update Admin
        Task<AdminResponseDto> UpdateAsync(int id, CreateAdminDto dto);

        // Delete Admin
        Task<bool> DeleteAsync(int id);

        // Admin Login + JWT Token
        Task<AdminLoginResponseDto> LoginAdmin(LoginAdminDto dto);
    }
}