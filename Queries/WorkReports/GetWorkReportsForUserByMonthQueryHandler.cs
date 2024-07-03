using MediatR;
using WorkTimeTracking.Models;
using WorkTimeTracking.Persistence.Interfaces;

namespace WorkTimeTracking.Queries.WorkReports
{
    public class GetWorkReportsForUserByMonthQueryHandler : IRequestHandler<GetWorkReportsForUserByMonthQuery, List<WorkReport>>
    {
        private readonly IWorkReportRepository _workReportRepository;

        public GetWorkReportsForUserByMonthQueryHandler(IWorkReportRepository workReportRepository)
        {
            _workReportRepository = workReportRepository;
        }

        public async Task<List<WorkReport>> Handle(GetWorkReportsForUserByMonthQuery query, CancellationToken cancellationToken)
        {
            var workReports = await _workReportRepository.GetByMonthAsync(query.UserId, query.Year, query.Month);
            
            if (workReports == null) { throw new Exception("Work reports not found"); }
            
            return workReports; 
        }
    }
}
