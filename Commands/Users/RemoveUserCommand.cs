using MediatR;

namespace WorkTimeTracking.Commands.Users
{
    public record RemoveUserCommand(int id) : IRequest;
}
