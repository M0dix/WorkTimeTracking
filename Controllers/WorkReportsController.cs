using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WorkTimeTracking.Commands.WorkReports;
using WorkTimeTracking.Models;
using WorkTimeTracking.Queries.Users;
using WorkTimeTracking.Queries.WorkReports;

namespace WorkTimeTracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkReportsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public WorkReportsController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        // GET: api/WorkReports/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkReport>>> GetWorkReports()
        {
            const string workReportsListCacheKey = "WorkReports";

            if (!_memoryCache.TryGetValue(workReportsListCacheKey, out List<WorkReport>? workReports))
            {
                workReports = await _mediator.Send(new GetWorkReportsQuery());

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

                _memoryCache.Set(workReportsListCacheKey, workReports, cacheOptions);
            }

            return Ok(workReports);
        }

        // GET: api/WorkReports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkReport>> GetWorkReport(int id)
        {
            var workReport = await _mediator.Send(new GetWorkReportByIdQuery(id));

            if (workReport == null)
            {
                return NotFound();
            }

            return Ok(workReport);
        }

        // GET: api/{userId}/month/{year}/{month}
        [HttpGet("user/{userId}/month/{year}/{month}")]
        public async Task<IActionResult> GetWorkReportsForUserByMonth(int userId, int year, int month)
        { 
            var workReports = await _mediator.Send(new GetWorkReportsForUserByMonthQuery(userId, year, month));
            return Ok(workReports);
        }

        // POST: api/WorkReports
        [HttpPost]
        public async Task<IActionResult> CreateWorkReport([FromBody] CreateWorkReportCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetWorkReportsForUserByMonth), new { userId = command.UserId, year = command.Date.Year, month = command.Date.Month }, result);
        }

        // PUT: api/WorkReports/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkReport(int id, [FromBody] UpdateWorkReportCommand command)
        {
            if (command == null || id != command.id )
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/WorkReports/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkReport(int id)
        {
            await _mediator.Send(new RemoveWorkReportCommand(id));
            return NoContent();
        }
    }
}
