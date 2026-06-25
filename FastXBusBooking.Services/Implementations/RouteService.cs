using FastXBusBooking.DTOs.RouteDTOs;
using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Interfaces;
using FastXBusBooking.Services.Interfaces;

namespace FastXBusBooking.Services.Implementations
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _repository;

        public RouteService(IRouteRepository repository)
        {
            _repository = repository;
        }

        public async Task<RouteResponseDto> CreateAsync(CreateRouteDto dto)
        {
            var route = new BusRoute
            {
                Origin = dto.Origin,
                Destination = dto.Destination,
                JourneyDate = dto.JourneyDate,
                DepartureTime = dto.DepartureTime,
                ArrivalTime = dto.ArrivalTime,
                BusId = dto.BusId
            };

            var result = await _repository.CreateAsync(route);

            return MapToDto(result);
        }

        public async Task<RouteResponseDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;

            return MapToDto(result);
        }

        public async Task<List<RouteResponseDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return result.Select(MapToDto).ToList();
        }

        public async Task<List<RouteResponseDto>> GetAllPagedAsync(int page, int pageSize)
        {
            var result = await _repository.GetAllPagedAsync(page, pageSize);

            return result.Select(MapToDto).ToList();
        }

        public async Task<List<RouteResponseDto>> SearchAsync(string origin, string destination)
        {
            var result = await _repository.SearchAsync(origin, destination);

            return result.Select(MapToDto).ToList();
        }

        public async Task<RouteResponseDto> UpdateAsync(int id, CreateRouteDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return null;

            existing.Origin = dto.Origin;
            existing.Destination = dto.Destination;
            existing.JourneyDate = dto.JourneyDate;
            existing.DepartureTime = dto.DepartureTime;
            existing.ArrivalTime = dto.ArrivalTime;
            existing.BusId = dto.BusId;

            var result = await _repository.UpdateAsync(existing);

            return MapToDto(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private RouteResponseDto MapToDto(BusRoute route)
        {
            return new RouteResponseDto
            {
                RouteId = route.RouteId,
                Origin = route.Origin,
                Destination = route.Destination,
                JourneyDate = route.JourneyDate,
                DepartureTime = route.DepartureTime,
                ArrivalTime = route.ArrivalTime,
                BusId = route.BusId
            };
        }
    }
}