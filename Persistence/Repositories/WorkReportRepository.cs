using Microsoft.EntityFrameworkCore;
using WorkTimeTracking.Models;
using WorkTimeTracking.Persistence.Data;
using WorkTimeTracking.Persistence.Interfaces;

namespace WorkTimeTracking.Persistence.Repositories
{
    public class WorkReportRepository : IWorkReportRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkReport>> GetAllAsync()
        {
            return await _context.WorkReports.ToListAsync();
        }

        public async Task<int> CreateAsync(WorkReport workReport)
        {
            await _context.WorkReports.AddAsync(workReport);
            await _context.SaveChangesAsync();

            return workReport.Id;
        }

        public async Task<WorkReport?> GetByIdAsync(int id)
        {
            return await _context.WorkReports.FindAsync(id);
        }

        public async Task<List<WorkReport>> GetByMonthAsync(int userId, int year, int month)
        {
            return await _context.WorkReports
                .Where(wr => wr.UserId == userId && 
                             wr.Date.Year == year && 
                             wr.Date.Month == month)
                .ToListAsync();
        }

        public async Task RemoveAsync(WorkReport workReport)
        {
            _context.WorkReports.Remove(workReport);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkReport workReport)
        {
            _context.WorkReports.Update(workReport);
            await _context.SaveChangesAsync();
        }
    }
}
