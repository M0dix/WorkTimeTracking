using MediatR;
using WorkTimeTracking.Models;
using WorkTimeTracking.Persistence.Interfaces;

namespace WorkTimeTracking.Queries.Users
{
    public class GetUserQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
