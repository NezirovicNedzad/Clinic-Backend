

using Application.Dto;
using Application.Pacijenti;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{

    [AllowAnonymous]
    public class PacijentController :BaseApiController
    {
    private readonly IMapper _mapper;
     private readonly UserManager<AppUser> _userManager;

         private readonly IMediator _mediator;
private readonly DataContext _context;
        public PacijentController(IMediator mediator, DataContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            _mediator = mediator;
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }





        [HttpGet]
        

        public async Task<IActionResult> GetPacijenti()
        {

            return HandleResult(await _mediator.Send(new List.Query()));
        }


  [HttpGet("/api/Pacijent/odeljenja/{id}")]
        

        public async Task<IActionResult> GetPacijentiPoOdeljenju(Guid id)
        {

            Odeljenje odeljenje=await _context.Odeljenja.FindAsync(id);


            return Ok(await _context.Pacijenti.Where(p=>p.Odeljenje.Equals(odeljenje)).Select(n=>new{Ime=n.Ime,Prezime=n.Prezime,Jmbg=n.JMBG,Id=n.Id,Pol=n.Pol,BrojGodina=n.BrojGodina}).ToListAsync());
        }



        [HttpGet("{id}")]
          public async Task<IActionResult> GetPacijent(Guid id)
        {
            return HandleResult(await _mediator.Send(new DetailsPacijent.Query { Id = id }));
        }
      

    [HttpPost]


    public async Task<IActionResult>CreatePacijent(PacijentDto pacijentDto)
    {
          Odeljenje Odeljenje=await _context.Odeljenja.FindAsync(pacijentDto.IdOdeljenja);
            var Lekar=await _userManager.FindByIdAsync(pacijentDto.IdLekara);
            var Karton=new Karton{

 Dijagnoza="",
 Terapija="",
 Odeljenje=Odeljenje,
 Lekar=Lekar            };

Odeljenje odeljenje2= new Odeljenje{Id=Odeljenje.Id,Naziv=Odeljenje.Naziv,BrojKreveta=Odeljenje.BrojKreveta,BrojPacijenata=Odeljenje.BrojPacijenata+1,Osoblje=Odeljenje.Osoblje};
List<Karton> icollection = new List<Karton>();
icollection.Add(Karton);

      Pacijent pacijent=new Pacijent{
 Id=pacijentDto.Id,
 Ime=pacijentDto.Ime,
 Prezime=pacijentDto.Prezime,
 JMBG=pacijentDto.JMBG,
 Pol=pacijentDto.Pol,
 BrojGodina=pacijentDto.BrojGodina,
 Odeljenje=Odeljenje,
 Kartoni=icollection,
 

      };
 
_mapper.Map(odeljenje2,Odeljenje);
await _context.SaveChangesAsync();
        return HandleResult(await _mediator.Send( new CreatePacijent.Command{  Pacijent=pacijent    }));
    }


  [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeletePacijent(Guid id)
        {
            return HandleResult(await _mediator.Send(new DeletePacijent.Command { Id = id }));
        }


    }
}