using FastXBusBooking.DTOs.UserDTOs;

namespace FastXBusBooking.DTOs.AuthDTOs
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public UserResponseDto User { get; set; }
    }
}