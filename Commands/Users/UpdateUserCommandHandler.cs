using MediatR;
using WorkTimeTracking.Models;
using WorkTimeTracking.Persistence.Interfaces;
using WorkTimeTracking.Queries.Users;

namespace WorkTimeTracking.Commands.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IMediator mediator, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(command.id), cancellationToken);
        
            if (user == null) { throw new Exception("User not found"); }

            user.UpdateDetails(
                command.Email,
                command.FirstName,
                command.LastName,
                command.Patronymic
            );

            await _userRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
