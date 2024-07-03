using MediatR;

namespace WorkTimeTracking.Commands.Users
{
    public record CreateUserCommand(
        string Email,
        string FirstName,
        string LastName,
        string Patronymic
        ) : IRequest<int>;
    
}
