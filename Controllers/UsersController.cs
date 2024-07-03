using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net.WebSockets;
using WorkTimeTracking.Commands.Users;
using WorkTimeTracking.Models;
using WorkTimeTracking.Queries.Users;

namespace WorkTimeTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator, IMemoryCache cache)
        {
            _mediator = mediator;
            _memoryCache = cache;
        }

        // GET: api/Users/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            const string usersListCacheKey = "UsersList";

            if (!_memoryCache.TryGetValue(usersListCacheKey, out List<User>? users))
            {
                users = await _mediator.Send(new GetUsersQuery());

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

                _memoryCache.Set(usersListCacheKey, users, cacheOptions);
            }

            return Ok(users);
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var userId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUser), new {id = userId}, userId);
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserCommand command)
        {
            if (command == null || id != command.id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteUser(int id)
        {
            var command = new RemoveUserCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
