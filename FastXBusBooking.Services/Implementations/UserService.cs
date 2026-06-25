using FastXBusBooking.DTOs.AuthDTOs;
using FastXBusBooking.DTOs.UserDTOs;
using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Interfaces;
using FastXBusBooking.Services.Helpers;
using FastXBusBooking.Services.Interfaces;

namespace FastXBusBooking.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public UserService(IUserRepository repository, JwtTokenGenerator jwtTokenGenerator)
        {
            _repository = repository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<UserResponseDto> RegisterUser(RegisterUserDto dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.Gender,
                Address = dto.Address
            };

            var result = await _repository.RegisterUser(user);

            return new UserResponseDto
            {
                UserId = result.UserId,
                FullName = result.FullName,
                Email = result.Email,
                PhoneNumber = result.PhoneNumber,
                Gender = result.Gender,
                Address = result.Address
            };
        }

        public async Task<LoginResponseDto> LoginUser(LoginUserDto dto)
        {
            var user = await _repository.GetUserByEmail(dto.Email);

            if (user == null)
                return null;

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isPasswordValid)
                return null;

            var token = _jwtTokenGenerator.GenerateToken(user.Email, "User");

            return new LoginResponseDto
            {
                Token = token,
                User = new UserResponseDto
                {
                    UserId = user.UserId,
                    FullName = user.FullName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Gender = user.Gender,
                    Address = user.Address
                }
            };
        }

        public async Task<UserResponseDto> GetUserById(int id)
        {
            var user = await _repository.GetUserById(id);

            if (user == null)
                return null;

            return new UserResponseDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                Address = user.Address
            };
        }

        public async Task<List<UserResponseDto>> GetAllUsers()
        {
            var users = await _repository.GetAllUsers();

            return users.Select(user => new UserResponseDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                Address = user.Address
            }).ToList();
        }

        public async Task<UserResponseDto> UpdateUser(int id, RegisterUserDto dto)
        {
            var existingUser = await _repository.GetUserById(id);

            if (existingUser == null)
                return null;

            existingUser.FullName = dto.FullName;
            existingUser.Email = dto.Email;
            existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            existingUser.PhoneNumber = dto.PhoneNumber;
            existingUser.Gender = dto.Gender;
            existingUser.Address = dto.Address;

            var updated = await _repository.UpdateUser(existingUser);

            return new UserResponseDto
            {
                UserId = updated.UserId,
                FullName = updated.FullName,
                Email = updated.Email,
                PhoneNumber = updated.PhoneNumber,
                Gender = updated.Gender,
                Address = updated.Address
            };
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _repository.DeleteUser(id);
        }
    }
}