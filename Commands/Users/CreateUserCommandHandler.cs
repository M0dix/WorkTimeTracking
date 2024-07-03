using MediatR;
using WorkTimeTracking.Models;
using WorkTimeTracking.Persistence.Interfaces;

namespace WorkTimeTracking.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(command.Email)) throw new ArgumentException("Email is required");

            if (string.IsNullOrEmpty(command.FirstName)) throw new ArgumentException("First name is required");
            
            if (string.IsNullOrEmpty(command.LastName)) throw new ArgumentException("Last Name is required");
            
            if (string.IsNullOrEmpty(command.Patronymic)) throw new ArgumentException("Patronymic is required");

            var user = new User(command.Email,
                command.FirstName,
                command.LastName,
                command.Patronymic);

            await _userRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }

}
