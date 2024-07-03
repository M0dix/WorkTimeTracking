using MediatR;
using WorkTimeTracking.Models;

namespace WorkTimeTracking.Queries.WorkReports
{
    public record GetWorkReportByIdQuery(int Id) : IRequest<WorkReport>;
}
