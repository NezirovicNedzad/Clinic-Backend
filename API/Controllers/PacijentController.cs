

using Application.Dto;
using Application.Pacijenti;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API.Controllers
{

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

Pacijent pacijent= await _context.Pacijenti.Where(p=>p.Id==id).Include(l=>l.Lekar).FirstAsync(); 
          Odeljenje odeljenje=await _context.Odeljenja.Where(o=>o.Pacijenti.Contains(pacijent)).FirstAsync();

          AppUser lekar=await _userManager.FindByIdAsync(pacijent.Lekar.Id);

        PacijentDto2 pacijentDto2=new PacijentDto2{
            Id=pacijent.Id,
            Ime=pacijent.Ime,
            Prezime=pacijent.Prezime,
            BrojGodina=pacijent.BrojGodina,
            Pol=pacijent.Pol,
            ImeLekara=lekar.Ime,
            PrezimeLekara=lekar.Prezime,
            UsernameLekara=lekar.UserName,
            IdLekara=lekar.Id,
            IdOdeljenja=odeljenje.Id
        };

return Ok(pacijentDto2);
           // return HandleResult(await _mediator.Send(new DetailsPacijent.Query { Id = id }));
        }
      

    [HttpPost]
    [Authorize(Policy ="SestraOnly")]

    public async Task<IActionResult>CreatePacijent(PacijentDto pacijentDto)
    {
          Odeljenje Odeljenje=await _context.Odeljenja.FindAsync(pacijentDto.IdOdeljenja);
            AppUser Lekar=await _userManager.FindByIdAsync(pacijentDto.IdLekara.ToString());
            Karton Karton=new Karton{

 Dijagnoza="",
 Terapija="",
 Odeljenje=Odeljenje,
 Lekar=Lekar            };

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
 Lekar=Lekar

      };
 
Odeljenje.BrojPacijenata=Odeljenje.BrojPacijenata+1;
await _context.SaveChangesAsync();
        return HandleResult(await _mediator.Send( new CreatePacijent.Command{  Pacijent=pacijent    }));
    }


  [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeletePacijent(Guid id)
        {
            return HandleResult(await _mediator.Send(new DeletePacijent.Command { Id = id }));
        }
[HttpPost("prebaci/{idP}/{idO}/{idL}")]
 [AllowAnonymous]
  public async Task<IActionResult>PrebaciPacijenta(Guid idP,Guid idO,string idL)
  {

    AppUser Lekar=await _userManager.FindByIdAsync(idL);

    Odeljenje odeljenje=await _context.Odeljenja.FindAsync(idO);

    Pacijent p=await _context.Pacijenti.Where(p=>p.Id==idP).Include(l=>l.Lekar).FirstAsync();
    Odeljenje odeljenjePacijentTrenutno=await _context.Odeljenja.Where(x=>x.Pacijenti.Contains(p)).FirstAsync();

AppUser LekarPacijent=p.Lekar;  
 
  Pacijent noviP=new Pacijent{
    Id=p.Id,
    JMBG=p.JMBG,
    Ime=p.Ime,
    Prezime=p.Prezime,
    BrojGodina=p.BrojGodina,
    Pol=p.Pol,
    Odeljenje=odeljenje,
    Lekar=p.Lekar
  };
   Karton karton= new Karton{

    Id=Guid.NewGuid(),
    Pacijent=noviP,
    Odeljenje=odeljenje,
    Lekar=Lekar,
    Pregledi={},
    Dijagnoza="",
    Terapija=""
  };




  _context.Remove(p);
 

_context.Kartoni.Add(karton); 

odeljenjePacijentTrenutno.BrojPacijenata=odeljenjePacijentTrenutno.BrojPacijenata-1;
odeljenje.BrojPacijenata=odeljenje.BrojPacijenata+1;
            return HandleResult(await _mediator.Send(new CreatePacijent.Command { Pacijent = noviP, }));
  

  }


  [HttpGet("/api/Pacijent/IzabraniLekar/{idL}")]


public async Task<IActionResult>GetPacijenteIzabranogLekara(string idL)
{

  AppUser Lekar=await _userManager.FindByIdAsync(idL);
        return HandleResult(await _mediator.Send(new ListIzabraniLekar.Query { lekar = Lekar, }));


}









  

    }




}