using FDS.CRM.Application.Contact.Commands;
using FDS.CRM.Application.Contact.Queries;
using FDS.CRM.Application.Position.Queries;
using FDS.CRM.Application.CommonSetting.Queries;

namespace FDS.CRM.WebApi.Controllers.V1
{

    [EnableRateLimiting(RateLimiterPolicyNames.DefaultPolicy)]
    // [Authorize]
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/[controller]s/")]
    public class ContactController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;
        private readonly ILogger _logger;

        public ContactController(Dispatcher dispatcher, ILogger<ContactController> logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<ResultModel<ContactDto>>> CreateContactAsync([FromBody] ContactDto dto)
        {
            await _dispatcher.DispatchAsync(new AddContactCommand(dto));
            var contact = ResultModel<ContactDto>.Create(null, false, "Thêm KHCN thành công.");
            return Ok(contact);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContactDetailQueryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<ContactDetailQueryDto>> GetDetailContactAsync(Guid id)
        {
            var contactDto = await _dispatcher.DispatchAsync(new GetDetailContactQuery(id));
            return Ok(contactDto);
        }

        [HttpPost("search-contacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<SearchResponseModel<SearchContactDto>>> SearchContactsAsync([FromBody] SearchRequestModel searchRequest)
        {
            var query = new SearchContactQuery(searchRequest);
            var result = await _dispatcher.DispatchAsync(query);
            return Ok(result);
        }

        [HttpGet("positions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetPositions(CancellationToken cancellationToken)
        {
            var result = await _dispatcher.DispatchAsync(new GetPositionQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("industries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetIndustries(CancellationToken cancellationToken)
        {
            var result = await _dispatcher.DispatchAsync(new GetCommonSettingsByTypeQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("ContactsByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetContacts(string? name, CancellationToken cancellationToken)
        {
            var result = await _dispatcher.DispatchAsync(new GetContactQuery { Name = name}, cancellationToken);

            return Ok(result);
        }
    }
}
