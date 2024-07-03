using WorkTimeTracking.Models;

namespace WorkTimeTracking.Persistence.Interfaces
{
    public interface IWorkReportRepository
    {
        Task<WorkReport?> GetByIdAsync(int id);
        Task<int> CreateAsync(WorkReport workReport);
        Task RemoveAsync(WorkReport workReport);
        Task UpdateAsync(WorkReport workReport);
        Task<List<WorkReport>> GetAllAsync();
        Task<List<WorkReport>> GetByMonthAsync(int userId, int year, int month);
    } 
}
