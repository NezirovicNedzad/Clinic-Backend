using Application.Odeljenja;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Diagnostics;

namespace API.Controllers
{
    public class OdeljenjeController : BaseApiController
    {
        private readonly IMediator _mediator;
        public OdeljenjeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
       
        public async Task<IActionResult> GetOdeljenja()
        {
            return HandleResult(await _mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
       
        public async Task<IActionResult> GetOdeljenje(Guid id)
        {
            return HandleResult(await _mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        [Authorize(Policy ="AdminOnly")]
        public async Task<IActionResult> CreateOdeljenje(Odeljenje odeljenje)
        {
            return HandleResult(await _mediator.Send(new Create.Command { Odeljenje = odeljenje }));
        }

        [HttpPut("{id}")]
         [Authorize(Policy ="AdminOnly")]
        public async Task<IActionResult> EditOdeljenje(Guid id, Odeljenje odeljenje)
        {
            odeljenje.Id = id;

            return HandleResult(await _mediator.Send(new Edit.Command { Odeljenje = odeljenje }));
        }

        [HttpDelete("{id}")]
         [Authorize(Policy ="AdminOnly")]
        public async Task<IActionResult> DeleteOdeljenje(Guid id)
        {
            return HandleResult(await _mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
