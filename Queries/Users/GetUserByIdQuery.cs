using MediatR;
using WorkTimeTracking.Models;

namespace WorkTimeTracking.Queries.Users
{
    public record GetUserByIdQuery(int Id) : IRequest<User>;
}
