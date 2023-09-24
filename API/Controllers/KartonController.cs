using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Kartoni;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class KartonController:BaseApiController
    {
             private readonly IMediator _mediator;

        public KartonController(IMediator mediator)
        {
            _mediator = mediator;
        }
      [HttpGet("{idO}/{idP}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetKartoniOdeljenja(Guid idO,Guid idP)
        {
            return HandleResult(await _mediator.Send(new ListKartoni.Query{IdO=idO,IdP=idP}));
            
        }




    }
}