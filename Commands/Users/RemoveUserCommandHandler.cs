using MediatR;
using WorkTimeTracking.Persistence.Interfaces;
using WorkTimeTracking.Queries.Users;

namespace WorkTimeTracking.Commands.Users
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveUserCommandHandler(IMediator mediator, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveUserCommand command, CancellationToken cancellationToken)
        {
            var currUserSearchResult = await _mediator.Send(new GetUserByIdQuery(command.id), cancellationToken);

            if (currUserSearchResult == null)
            {
                throw new Exception("User not found");
            }

            await _userRepository.RemoveAsync(currUserSearchResult);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
