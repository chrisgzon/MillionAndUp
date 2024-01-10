using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MU.Application.UseCases.Tokens.Queries;
using MU.WebApi.Common;

namespace MU.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [AllowAnonymous]
    public class TokenController : ApiController
    {
        private readonly ISender _mediator;
        public TokenController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        #region POST
        [HttpPost]
        public async Task<IActionResult> Generate([FromBody] Guid IdOwner)
        {
            var tokenResult = await _mediator.Send(new GenerateTokenQuery(IdOwner));
            
            return tokenResult.Match(
                token => Ok(token),
                errors => Problem(errors)
            );
        }
        #endregion POST
    }
}