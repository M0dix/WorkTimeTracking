using WorkTimeTracking.Models;

namespace WorkTimeTracking.Persistence.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<int> CreateAsync(User user);
        Task RemoveAsync(User user);
        Task UpdateAsync(User user);
        Task<List<User>> GetAllAsync();
    }
}
