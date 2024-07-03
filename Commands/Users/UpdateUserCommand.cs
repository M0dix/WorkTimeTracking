using MediatR;

namespace WorkTimeTracking.Commands.Users
{
    public record UpdateUserCommand(
        int id,
        string Email,
        string FirstName,
        string LastName,
        string Patronymic
    ) : IRequest;

}
