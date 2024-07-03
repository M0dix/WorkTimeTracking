
using MediatR;
using WorkTimeTracking.Models;

namespace WorkTimeTracking.Commands.WorkReports
{
    public record CreateWorkReportCommand(
        string Note,
        int Hours,
        DateTime Date,
        int UserId
        ) : IRequest<int>;
}