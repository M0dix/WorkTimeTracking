using MediatR;
using WorkTimeTracking.Models;
using WorkTimeTracking.Persistence.Interfaces;

namespace WorkTimeTracking.Queries.WorkReports
{
    public class GetWorkReportByIdQueryHandler : IRequestHandler<GetWorkReportByIdQuery, WorkReport>
    {
        private readonly IWorkReportRepository _workReportRepository;

        public GetWorkReportByIdQueryHandler(IWorkReportRepository workReportRepository)
        {
            _workReportRepository = workReportRepository;
        }

        public async Task<WorkReport> Handle(GetWorkReportByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _workReportRepository.GetByIdAsync(query.Id);

            if (user == null) { throw new Exception("Work Report not found");  }

            return user;
        }
    }
}
