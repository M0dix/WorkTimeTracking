using MediatR;
using WorkTimeTracking.Persistence.Interfaces;
using WorkTimeTracking.Queries.WorkReports;

namespace WorkTimeTracking.Commands.WorkReports
{
    public class RemoveWorkReportCommandHandler : IRequestHandler<RemoveWorkReportCommand>
    {
        private readonly IMediator _mediator;
        private readonly IWorkReportRepository _workReportRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveWorkReportCommandHandler(IMediator mediator, IWorkReportRepository workReportRepository, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _workReportRepository = workReportRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveWorkReportCommand command, CancellationToken cancellationToken)
        {
            var workReport= await _mediator.Send(new GetWorkReportByIdQuery(command.id), cancellationToken);

            if (workReport == null) throw new Exception("Work report not found");

            await _workReportRepository.RemoveAsync(workReport);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
