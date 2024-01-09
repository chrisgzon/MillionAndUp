using MediatR;
using Microsoft.AspNetCore.Mvc;
using MU.Application.UseCases.Owners.Commands.Create;
using MU.Application.UseCases.Owners.Queries.GetAll;
using MU.Application.UseCases.Owners.Queries.GetById;
using MU.WebApi.Common;
using Swashbuckle.AspNetCore.Annotations;

namespace MU.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OwnerController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IConfiguration _configuration;
        public OwnerController(ISender mediator, IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        #region GET
        /// <summary>
        /// Return all list of owners exists in the database.
        /// </summary>
        [HttpGet]
        [SwaggerOperation("GetAll")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
        {
            var listOwnersResult = await _mediator.Send(new GetAllOwnersQuery());
            return listOwnersResult.Match(
                owners => Ok(owners),
                errors => Problem(errors)
            );
        }

        /// <summary>
        /// Return a owner than match with the id getted.
        /// </summary>
        [ProducesResponseType(200)]
        [SwaggerOperation("GetById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ownerresult = await _mediator.Send(new GetByIdOwnerQuery(id));
            return ownerresult.Match(
                owner => Ok(owner),
                errors => Problem(errors)
            );
        }
        #endregion GET

        #region POST
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOwnerCommand request)
        {
            var createOwnerResult = await _mediator.Send(request);
            return createOwnerResult.Match(
                ownerId => Ok(ownerId),
                errors => Problem(errors)
            );
        }
        #endregion POST
    }
}
