using WorkTimeTracking.Persistence.Data;
using WorkTimeTracking.Persistence.Interfaces;
using WorkTimeTracking.Persistence.Repositories;

namespace WorkTimeTracking.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IUserRepository _users;
        private IWorkReportRepository _workReports;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IWorkReportRepository WorkReports => _workReports ??= new WorkReportRepository(_context);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync();
        }
    }
}
