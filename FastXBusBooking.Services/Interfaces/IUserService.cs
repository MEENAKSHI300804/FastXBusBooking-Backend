using FastXBusBooking.DTOs.AuthDTOs;
using FastXBusBooking.DTOs.UserDTOs;

namespace FastXBusBooking.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> RegisterUser(RegisterUserDto dto);

        Task<LoginResponseDto> LoginUser(LoginUserDto dto);

        Task<UserResponseDto> GetUserById(int id);

        Task<List<UserResponseDto>> GetAllUsers();

        Task<UserResponseDto> UpdateUser(int id, RegisterUserDto dto);

        Task<bool> DeleteUser(int id);
    }
}