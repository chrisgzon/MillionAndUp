﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MU.Application.UseCases.Properties.Commands.Create;

namespace MU.WebApi.Controllers
{
    [Route("Property")]
    [ApiController]
    public class PropertyController : ControllerBase
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
            return Ok(createPropertyResult);
        }
    }
}
