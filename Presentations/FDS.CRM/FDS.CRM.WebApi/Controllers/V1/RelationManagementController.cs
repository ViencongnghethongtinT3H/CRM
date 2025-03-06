using FDS.CRM.Application.RelationManager.Commands;
using FDS.CRM.Application.RelationManager.DTOs;
using FDS.CRM.Application.RelationManager.Queries;
using FDS.CRM.Domain.Enums;
using static FDS.CRM.Application.RelationManager.Commands.DeleteRalationCommand;

namespace FDS.CRM.WebApi.Controllers.V1;

[EnableRateLimiting(RateLimiterPolicyNames.DefaultPolicy)]
// [Authorize]
[Produces("application/json")]
[ApiController]
[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/[controller]/")]
public class RelationManagementController : ControllerBase
{
    private readonly Dispatcher _dispatcher;
    private readonly ILogger _logger;
    public RelationManagementController(Dispatcher dispatcher,
       ILogger<RelationManagementController> logger)
    {
        _dispatcher = dispatcher;
        _logger = logger;

    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<IEnumerable<Paged<ProductEntryDto>>>> Search(
    [FromQuery] RelationshipType? type,
    [FromQuery] Guid? Id)
    {
        _logger.LogInformation("search all relation");
        var relation = await _dispatcher.DispatchAsync(new GetPagedRelationQuery
        {
            Id = Id.Value,
        });
        return Ok(relation);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<Product>> Get(Guid id, RelationshipType type)
    {
        ValidationException.Requires(id != Guid.Empty, "Invalid Id");

        var product = await _dispatcher.DispatchAsync(new GetManagerRealtionQuery { Id = id, RelationshipType = type });
        //   var model = product.ToModel();
        return Ok(product);
    }

    [HttpPost("Relation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<Product>> HandleCreateCategoryAsync([FromBody] ManagerRelationDto dto)
    {
        _logger.LogInformation("add relations");
        await _dispatcher.DispatchAsync(new AddUpdateRelationCommand { ManagerRelationDto = dto });
        //   var model = product.ToModel();
        return Ok();
    }

    [HttpDelete("DeleteById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<Product>> HandleCreateCategoryAsync([FromBody] DeleteRalationRequest request)
    {
        _logger.LogInformation("Delete");
        await _dispatcher.DispatchAsync(new DeleteRalationCommand { query = request });
        //   var model = product.ToModel();
        return Ok();
    }

}
