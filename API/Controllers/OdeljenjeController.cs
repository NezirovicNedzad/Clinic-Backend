using Application.Odeljenja;
using Domain;
using MediatR;
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
        public async Task<ActionResult<List<Odeljenje>>> GetOdeljenja()
        {



            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Odeljenje>> GetOdeljenje(Guid id)
        {



            return await _mediator.Send(new Details.Query { Id = id });
        }



        [HttpPost]




        public async Task<IActionResult> CreateOdeljenje(Odeljenje odeljenje)
        {


            return Ok(await _mediator.Send(new Create.Command { Odeljenje = odeljenje }));

        }
        [HttpPut("{id}")]



        public async Task<IActionResult> EditOdeljenje(Guid id, Odeljenje odeljenje)
        {
            odeljenje.Id = id;

            return Ok(await _mediator.Send(new Edit.Command { Odeljenje = odeljenje }));

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOdeljenje(Guid id)
        {
          

            return Ok(await _mediator.Send(new Delete.Command {Id=id}));

        }



    }
}
