using FDS.CRM.Application.Contact.Queries;
using FDS.CRM.Application.Deal.Queries;

namespace FDS.CRM.WebApi.Controllers.V1;


[EnableRateLimiting(RateLimiterPolicyNames.DefaultPolicy)]
// [Authorize]
[Produces("application/json")]
[ApiController]
[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/[controller]/")]
public class DealController : ControllerBase
{
    private readonly Dispatcher _dispatcher;
    private readonly ILogger _logger;

    public DealController(Dispatcher dispatcher, ILogger<DealController> logger)
    {
        _dispatcher = dispatcher;
        _logger = logger;
    }

    [HttpGet("DealByName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> GetDeals(string? name, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.DispatchAsync(new GetDealQuery { name = name}, cancellationToken);
        return Ok(result);
    }
}
