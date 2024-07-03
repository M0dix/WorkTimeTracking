using MediatR;
using WorkTimeTracking.Models;
using WorkTimeTracking.Persistence.Interfaces;
using WorkTimeTracking.Queries.WorkReports;

namespace WorkTimeTracking.Commands.WorkReports
{
    public class UpdateWorkReportCommandHandler : IRequestHandler<UpdateWorkReportCommand>
    {
        private readonly IMediator _mediator;
        private readonly IWorkReportRepository _workReportRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWorkReportCommandHandler(IMediator mediator, IWorkReportRepository workReportRepository, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _workReportRepository = workReportRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateWorkReportCommand command, CancellationToken cancellationToken)
        {
            var workReport = await _mediator.Send(new GetWorkReportByIdQuery(command.id), cancellationToken);

            if (workReport == null) { throw new Exception("Work report not found"); }

            workReport.UpdateDetails(
                command.Note,
                command.Hours,
                command.Date,
                command.UserId
                );

            await _workReportRepository.UpdateAsync(workReport);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
