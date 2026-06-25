using FastXBusBooking.DTOs.UserDTOs;
using FastXBusBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FastXBusBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IUserService service,
            ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            try
            {
                _logger.LogInformation("User registration started");

                var result = await _service.RegisterUser(dto);

                _logger.LogInformation("User registered successfully");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration");
                throw;
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            try
            {
                _logger.LogInformation("User login started");

                var result = await _service.LoginUser(dto);

                if (result == null)
                {
                    _logger.LogWarning("Invalid login attempt");
                    return BadRequest("Invalid credentials");
                }

                _logger.LogInformation("User login successful");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                throw;
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var result = await _service.GetUserById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user");
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _service.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all users");
                throw;
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, RegisterUserDto dto)
        {
            try
            {
                var result = await _service.UpdateUser(id, dto);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user");
                throw;
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await _service.DeleteUser(id);

                if (!result)
                    return NotFound();

                return Ok("User deleted successfully");
            }
            catch (Exception ex)
{
    _logger.LogError(ex, "Error during login");
    return StatusCode(500, ex.ToString());
}
        }
    }
}