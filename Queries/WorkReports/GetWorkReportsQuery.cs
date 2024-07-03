using MediatR;
using WorkTimeTracking.Models;
using WorkTimeTracking.Queries.Users;

namespace WorkTimeTracking.Queries.WorkReports
{
    public record GetWorkReportsQuery : IRequest<List<WorkReport>>;
}
