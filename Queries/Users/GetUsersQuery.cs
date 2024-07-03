using MediatR;
using WorkTimeTracking.Models;

namespace WorkTimeTracking.Queries.Users
{
    public record GetUsersQuery : IRequest<List<User>>;
}
