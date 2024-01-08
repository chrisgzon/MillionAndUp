using MediatR;
using Microsoft.AspNetCore.Mvc;
using MU.Application.UseCases.Properties.Commands.Create;
using MU.WebApi.Common;

namespace MU.WebApi.Controllers
{
    [Route("Property")]
    [ApiController]
    public class PropertyController : ApiController
    {
        private readonly ISender _mediator;

        public PropertyController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePropertyCommand request)
        {
            var createPropertyResult = await _mediator.Send(request);
            return createPropertyResult.Match(
                customers => Ok(customers),
                errors => Problem(errors)
            );
        }
    }
}
