using FDS.CRM.Application.Category.Commands;
using FDS.CRM.Application.Category.DTOs;
using FDS.CRM.Application.Supplier.Commands;
using FDS.CRM.Application.Supplier.DTOs;
using FDS.CRM.Application.Supplier.Queries;

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
    
    // api/v1/product/supplier/id
    [HttpGet("supplier/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<Product>> GetSupplierById(Guid id)
    {
        ValidationException.Requires(id != Guid.Empty, "Invalid Id");

        var supplier = await _dispatcher.DispatchAsync(new GetSupplierQuery { Id = id });
        //   var model = product.ToModel();
        return Ok(supplier);
    }

    [HttpPost("category")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<Product>> HandleCreateCategoryAsync([FromBody] CategoryDto dto)
    {
        // Dispatcher hiểu nôm na là 1 người vận chuyển, nó sẽ chuyển các luồng dữ liệu tới đúng command hoặc query handler 
        await _dispatcher.DispatchAsync(new AddUpdateCategoryCommand { CategoryDto = dto });
        //   var model = product.ToModel();
        return Ok();
    }

    // api/v1/product/suppiler
    [HttpPost("supplier")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<SupplierDto>> HandleCreateSupplierAsync([FromBody] SupplierDto dto)
    {
        // Dispatcher hiểu nôm na là 1 người vận chuyển, nó sẽ chuyển các luồng dữ liệu tới đúng command hoặc query handler 
        await _dispatcher.DispatchAsync(new AddSupplierCommand { SupplierDto = dto });
        //   var model = product.ToModel();
        return Ok();
    }
}
