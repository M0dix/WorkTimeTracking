using MediatR;

namespace WorkTimeTracking.Commands.WorkReports
{
    public record UpdateWorkReportCommand(
        int id,
        string Note,
        int Hours,
        DateTime Date,
        int UserId
        ) : IRequest;

}
