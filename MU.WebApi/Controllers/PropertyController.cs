using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MU.Application.UseCases.Properties.Commands.AddImage;
using MU.Application.UseCases.Properties.Commands.ChangeAddress;
using MU.Application.UseCases.Properties.Commands.Create;
using MU.Application.UseCases.Properties.Commands.Update;
using MU.Application.UseCases.Properties.Commands.UpdatePrice;
using MU.Application.UseCases.Properties.Queries.List;
using MU.Application.UseCases.Properties.Queries.SearchPropertiesByFilters;
using MU.Application.UseCases.Properties.Queries.SearchPropertyById;
using MU.WebApi.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace MU.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PropertyController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IConfiguration _configuration;
        public PropertyController(ISender mediator, IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        #region GET
        /// <summary>
        /// Return all list of properties exists in the database.
        /// </summary>
        [HttpGet]
        [SwaggerOperation("ListAll")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> ListAll()
        {
            var listPropertiesResult = await _mediator.Send(new ListPropertiesQuery());
            return listPropertiesResult.Match(
                properties => Ok(properties),
                errors => Problem(errors)
            );
        }

        /// <summary>
        /// Return a property than match with the id getted.
        /// </summary>
        [ProducesResponseType(200)]
        [SwaggerOperation("GetById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var propertyresult = await _mediator.Send(new SearchPropertyByIdQuery(id));
            return propertyresult.Match(
                property => Ok(property),
                errors => Problem(errors)
            );
        }

        /// <summary>
        /// Return all items than match with filters getted, returns items for pagination.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetByFilters([FromQuery] SearchPropertiesByFiltersQuery request)
        {
            var propertyesresult = await _mediator.Send(request);
            return propertyesresult.Match(
                property => Ok(propertyesresult.Value),
                errors => Problem(errors)
            );
        }
        #endregion GET

        #region POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePropertyCommand request)
        {
            var createPropertyResult = await _mediator.Send(request);
            return createPropertyResult.Match(
                propertyId => Ok(propertyId),
                errors => Problem(errors)
            );
        }        
        #endregion POST

        #region PATCH
        [HttpPatch("{id}")]
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
                propertyId => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeAddress(Guid id, [FromBody] ChangeAddressPropertyCommand request)
        {
            if (request.IdProperty != id)
            {
                List<Error> errors = new()
                {
                    Error.Validation("Property.UpdateInvalid", "The request Id does not match with the url Id.")
                };
                return Problem(errors);
            }

            var updateAddressPropertyResult = await _mediator.Send(request);
            return updateAddressPropertyResult.Match(
                propertyId => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpPatch("idProperty")]
        public async Task<IActionResult> AddImage(IFormFile file, [FromQuery] Guid idProperty)
        {
            byte[] bytesFile = new byte[file.Length];
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                bytesFile = memoryStream.ToArray();
            }
            string PathFolder = _configuration.GetValue<string>("PathFilesProperties").ToString();
            var addImagePropertyResult = await _mediator.Send(new AddImagePropertyCommand(
                idProperty,
                PathFolder,
                bytesFile,
                file.FileName,
                file.Length
            ));
            return addImagePropertyResult.Match(
                propertyId => Ok(propertyId),
                errors => Problem(errors)
            );
        }
        #endregion PATCH

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePropertyCommand request)
        {
            if (request.IdProperty != id)
            {
                List<Error> errors = new()
                {
                    Error.Validation("Property.UpdateInvalid", "The request Id does not match with the url Id.")
                };
                return Problem(errors);
            }

            var updatePropertyResult = await _mediator.Send(request);
            return updatePropertyResult.Match(
                propertyId => NoContent(),
                errors => Problem(errors)
            );
        }
        #endregion PUT
    }
}
