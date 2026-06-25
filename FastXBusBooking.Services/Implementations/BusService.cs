using FastXBusBooking.DTOs.BusDTOs;
using FastXBusBooking.Models.Entities;
using FastXBusBooking.Repository.Interfaces;
using FastXBusBooking.Services.Interfaces;

namespace FastXBusBooking.Services.Implementations
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _repository;

        public BusService(IBusRepository repository)
        {
            _repository = repository;
        }

        public async Task<BusResponseDto> CreateAsync(CreateBusDto dto)
        {
            var bus = new Bus
            {
                BusName = dto.BusName,
                BusNumber = dto.BusNumber,
                BusType = dto.BusType,
                TotalSeats = dto.TotalSeats,
                Fare = dto.Fare,
                Amenities = dto.Amenities,
                OperatorId = dto.OperatorId
            };

            var result = await _repository.CreateAsync(bus);

            return new BusResponseDto
            {
                BusId = result.BusId,
                BusName = result.BusName,
                BusNumber = result.BusNumber,
                BusType = result.BusType,
                TotalSeats = result.TotalSeats,
                Fare = result.Fare,
                Amenities = result.Amenities,
                OperatorId = result.OperatorId
            };
        }

        public async Task<BusResponseDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            if (result == null)
                return null;

            return new BusResponseDto
            {
                BusId = result.BusId,
                BusName = result.BusName,
                BusNumber = result.BusNumber,
                BusType = result.BusType,
                TotalSeats = result.TotalSeats,
                Fare = result.Fare,
                Amenities = result.Amenities,
                OperatorId = result.OperatorId
            };
        }

        public async Task<List<BusResponseDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            return result.Select(x => new BusResponseDto
            {
                BusId = x.BusId,
                BusName = x.BusName,
                BusNumber = x.BusNumber,
                BusType = x.BusType,
                TotalSeats = x.TotalSeats,
                Fare = x.Fare,
                Amenities = x.Amenities,
                OperatorId = x.OperatorId
            }).ToList();
        }

        public async Task<BusResponseDto> UpdateAsync(int id, CreateBusDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
                return null;

            existing.BusName = dto.BusName;
            existing.BusNumber = dto.BusNumber;
            existing.BusType = dto.BusType;
            existing.TotalSeats = dto.TotalSeats;
            existing.Fare = dto.Fare;
            existing.Amenities = dto.Amenities;
            existing.OperatorId = dto.OperatorId;

            var result = await _repository.UpdateAsync(existing);

            return new BusResponseDto
            {
                BusId = result.BusId,
                BusName = result.BusName,
                BusNumber = result.BusNumber,
                BusType = result.BusType,
                TotalSeats = result.TotalSeats,
                Fare = result.Fare,
                Amenities = result.Amenities,
                OperatorId = result.OperatorId
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
        public async Task<List<BusResponseDto>> GetAllPagedAsync(int page, int pageSize)
{
    var result = await _repository.GetAllPagedAsync(page, pageSize);

    return result.Select(x => new BusResponseDto
    {
        BusId = x.BusId,
        BusName = x.BusName,
        BusNumber = x.BusNumber,
        BusType = x.BusType,
        TotalSeats = x.TotalSeats,
        Fare = x.Fare,
        Amenities = x.Amenities,
        OperatorId = x.OperatorId
    }).ToList();
}
    }
}