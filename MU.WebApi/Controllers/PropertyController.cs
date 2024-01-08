using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MU.Application.UseCases.Properties.Commands.Create;
using MU.Application.UseCases.Properties.Commands.UpdatePrice;
using MU.Application.UseCases.Properties.Queries.List;
using MU.Application.UseCases.Properties.Queries.SearchPropertyById;
using MU.WebApi.Common;

namespace MU.WebApi.Controllers
{
    [Route("[controller]/[action]")]
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

        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            var listPropertiesResult = await _mediator.Send(new ListPropertiesQuery());
            return listPropertiesResult.Match(
                customers => Ok(customers),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var propertyresult = await _mediator.Send(new SearchPropertyByIdQuery(id));
            return propertyresult.Match(
                customers => Ok(customers),
                errors => Problem(errors)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangePrice(Guid id, [FromBody] ChangePricePropertyCommand request)
        {
            if (request.IdProperty != id)
            {
                List<Error> errors = new()
                {
                    Error.Validation("Property.UpdateInvalid", "The request Id does not match with the url Id.")
                };
                return Problem(errors);
            }

            var updatePricePropertyResult = await _mediator.Send(request);
            return updatePricePropertyResult.Match(
                customerId => NoContent(),
                errors => Problem(errors)
            );
        }
    }
}
