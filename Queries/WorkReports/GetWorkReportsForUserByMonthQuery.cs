using MediatR;
using WorkTimeTracking.Models;

namespace WorkTimeTracking.Queries.WorkReports
{
    public record GetWorkReportsForUserByMonthQuery(
        int UserId,
        int Year,
        int Month) : IRequest<List<WorkReport>>;
}
