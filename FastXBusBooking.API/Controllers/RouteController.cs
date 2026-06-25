using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FastXBusBooking.DTOs.RouteDTOs;
using FastXBusBooking.Services.Interfaces;

namespace FastXBusBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _service;

        public RouteController(IRouteService service)
        {
            _service = service;
        }

        [Authorize(Roles = "BusOperator,Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateRouteDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            if (page <= 0)
                page = 1;

            if (pageSize <= 0)
                pageSize = 10;

            var result = await _service.GetAllPagedAsync(page, pageSize);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> Search(string origin, string destination)
        {
            var result = await _service.SearchAsync(origin, destination);
            return Ok(result);
        }

        [Authorize(Roles = "BusOperator,Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateRouteDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Authorize(Roles = "BusOperator,Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Route deleted successfully");
        }
    }
}