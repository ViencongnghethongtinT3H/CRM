using FDS.CRM.Application.Category.Commands;
using FDS.CRM.Application.Category.DTOs;

namespace FDS.CRM.WebApi.Controllers.V1;

[EnableRateLimiting(RateLimiterPolicyNames.DefaultPolicy)]
// [Authorize]
[Produces("application/json")]
[ApiController]
[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/[controller]/")]
public class ProductController : ControllerBase
{
    private readonly Dispatcher _dispatcher;
    private readonly ILogger _logger;
    public ProductController(Dispatcher dispatcher,
       ILogger<ProductController> logger)
    {
        _dispatcher = dispatcher;
        _logger = logger;

    }


    // [Authorize(AuthorizationPolicyNames.GetProductsPolicy)]
    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<IEnumerable<Paged<ProductEntryDto>>>> Search(
    [FromQuery] string? name,
    [FromQuery] Guid? categoryId,
    [FromQuery] Guid? supplierId,
    [FromQuery] int pageIndex = 1,
    [FromQuery] int pageSize = 20)
    {
        _logger.LogInformation("search all products");
        var products = await _dispatcher.DispatchAsync(new GetPagedProductsQuery
        {
            ProductName = name,
            CategoryId = categoryId,
            SupplierId = supplierId,
            Page = pageIndex,
            PageSize = pageSize
        });
        return Ok(products);
    }

    // [Authorize(AuthorizationPolicyNames.GetProductPolicy)]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<Product>> Get(Guid id)
    {
        ValidationException.Requires(id != Guid.Empty, "Invalid Id");

        var product = await _dispatcher.DispatchAsync(new GetProductQuery { Id = id, ThrowNotFoundIfNull = true });
        //   var model = product.ToModel();
        return Ok(product);
    }

    [HttpPost("category")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<Product>> HandleCreateCategoryAsync([FromBody] CategoryDto dto)
    {        
        await _dispatcher.DispatchAsync(new AddUpdateCategoryCommand { CategoryDto = dto });
        //   var model = product.ToModel();
        return Ok();
    }
}
