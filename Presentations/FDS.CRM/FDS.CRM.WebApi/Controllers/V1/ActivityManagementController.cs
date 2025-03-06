using FDS.CRM.Application.ActivityManager.Queries;
namespace FDS.CRM.WebApi.Controllers.V1;

[EnableRateLimiting(RateLimiterPolicyNames.DefaultPolicy)]
// [Authorize]
[Produces("application/json")]
[ApiController]
[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/[controller]/")]
public class ActivityManagementController : ControllerBase
{
    private readonly Dispatcher _dispatcher;
    private readonly ILogger _logger;
    public ActivityManagementController(Dispatcher dispatcher,
       ILogger<ActivityManagementController> logger)
    {
        _dispatcher = dispatcher;
        _logger = logger;

    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<Activity>> Search(
    [FromQuery] RelationshipType RelationshipType,
    [FromQuery] Guid? Id)
    {
        _logger.LogInformation("search all Activity");
        try
        {
            var activities = await _dispatcher.DispatchAsync(new GetActivityQuery
            {
                Id = Id.GetValueOrDefault(),
                RelationshipType = RelationshipType
            });
            return Ok(activities);
        }
        catch (Exception ex)
        {

            throw new Exception($"error: {ex.Message}");
        }
      
        
    }
}
