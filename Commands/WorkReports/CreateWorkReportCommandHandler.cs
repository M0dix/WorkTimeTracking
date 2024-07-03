using MediatR;
using WorkTimeTracking.Models;
using WorkTimeTracking.Persistence.Interfaces;

namespace WorkTimeTracking.Commands.WorkReports
{
    public class CreateWorkReportCommandHandler : IRequestHandler<CreateWorkReportCommand, int>
    {
        private readonly IWorkReportRepository _workReportRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWorkReportCommandHandler(IWorkReportRepository workReportRepository, IUnitOfWork unitOfWork)
        {
            _workReportRepository = workReportRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateWorkReportCommand command, CancellationToken cancellationToken)
        {
            var workReport = new WorkReport(command.Note, 
                command.Hours, 
                command.Date, 
                command.UserId);

            await _workReportRepository.CreateAsync(workReport);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return workReport.Id;
        }
    }
}
