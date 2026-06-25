using FastXBusBooking.Models.Entities;

namespace FastXBusBooking.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> RegisterUser(User user);

        Task<User> GetUserById(int id);

        Task<List<User>> GetAllUsers();

        Task<User> UpdateUser(User user);

        Task<bool> DeleteUser(int id);

        Task<User> GetUserByEmail(string email);
    }
}