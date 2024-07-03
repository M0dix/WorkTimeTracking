using MediatR;

namespace WorkTimeTracking.Commands.WorkReports
{
    public record RemoveWorkReportCommand(int id) : IRequest;
}
