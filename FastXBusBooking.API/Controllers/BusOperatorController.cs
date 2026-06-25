using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FastXBusBooking.DTOs.BusOperatorDTOs;
using FastXBusBooking.Services.Interfaces;

namespace FastXBusBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusOperatorController : ControllerBase
    {
        private readonly IBusOperatorService _service;

        public BusOperatorController(IBusOperatorService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterBusOperatorDto dto)
        {
            var result = await _service.RegisterAsync(dto);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginBusOperatorDto dto)
        {
            var result = await _service.LoginAsync(dto);

            if (result == null)
                return BadRequest("Invalid credentials");

            return Ok(result);
        }

        [Authorize(Roles = "BusOperator,Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [Authorize(Roles = "BusOperator,Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RegisterBusOperatorDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Bus Operator deleted successfully");
        }
    }
}
