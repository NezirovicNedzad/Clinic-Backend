using Application.Dto;
using Application.Napomene;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    public class NapomenaController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public NapomenaController(IMediator mediator, DataContext context, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetNapomeneNaKartonu(Guid idk)
        {
            return HandleResult(await _mediator.Send(new ListNapomene.Query { IdK = idk }));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateNapomea(NapomenaDto2 napomenaDto)
        {
            Karton karton = await _context.Kartoni.FindAsync(napomenaDto.IdKarton);

            AppUser sestra = await _userManager.FindByIdAsync(napomenaDto.IdSestra);

            Napomena n = new Napomena
            {
                Id = napomenaDto.Id,
                Primedba = napomenaDto.Primedba,
                NezeljenoDejstvo = napomenaDto.NezeljenoDejstvo,
                Sestra = sestra,
                Karton = karton
            };
            return HandleResult(await _mediator.Send(new CreateNapomene.Command { Napomena = n }));
        }
    }
}
