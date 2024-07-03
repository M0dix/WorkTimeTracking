using MediatR;
using WorkTimeTracking.Models;
using WorkTimeTracking.Persistence.Interfaces;

namespace WorkTimeTracking.Queries.WorkReports
{
    public class GetWorkReportsQueryHandler : IRequestHandler<GetWorkReportsQuery, List<WorkReport>>
    { 
        private readonly IWorkReportRepository _workReportRepository;

        public GetWorkReportsQueryHandler(IWorkReportRepository workReportRepository)
        {
            _workReportRepository = workReportRepository;
        }

        public async Task<List<WorkReport>> Handle(GetWorkReportsQuery request, CancellationToken cancellationToken)
        {
            return await _workReportRepository.GetAllAsync();
        }
    }
}
