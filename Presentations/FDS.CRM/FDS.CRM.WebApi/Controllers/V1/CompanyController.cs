using FDS.CRM.Application.Contact.Commands;
using FDS.CRM.Application.Contact.DTOs;
using FDS.CRM.Application.Contact.Queries;
using FDS.CRM.Application.Common.DTOs;
using FDS.CRM.Application.Position.Queries;
using FDS.CRM.Application.Queries;
using FDS.CRM.Application.CommonSetting.Queries;

namespace FDS.CRM.WebApi.Controllers.V1
{

    [EnableRateLimiting(RateLimiterPolicyNames.DefaultPolicy)]
    // [Authorize]
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/[controller]/")]
    public class CompanyController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;
        private readonly ILogger _logger;

        public CompanyController(Dispatcher dispatcher, ILogger<CompanyController> logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        [HttpGet("CompaniesByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetCompanys([FromQuery] string? name, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _dispatcher.DispatchAsync(new GetCompanyQuery { name = name }, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception($"error: {ex.Message}");
            }
           
        }
    }
}
