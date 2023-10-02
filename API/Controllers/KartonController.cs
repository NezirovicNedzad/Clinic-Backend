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
        [Authorize(Policy ="LekarOrSestra")]
        public async Task<IActionResult> GetKartoniOdeljenja(Guid idO,Guid idP)
        {
            return HandleResult(await _mediator.Send(new ListKartoni.Query{IdO=idO,IdP=idP}));
            
        }

        [HttpGet("{idP}")]
        [Authorize(Policy ="LekarOnly")]
        [AllowAnonymous]
        public async Task<IActionResult> GetKartonPacijenta(Guid idP)
        {
            return HandleResult(await _mediator.Send(new ListKartoniPacijent.Query{IdPacijent=idP}));
            
        }


    }
}