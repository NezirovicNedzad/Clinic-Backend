using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Kartoni;
using Application.Pregledi;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    public class PregledController :BaseApiController
    {

private readonly UserManager<AppUser> _userManager;

         private readonly IMediator _mediator;
private readonly DataContext _context;

        public PregledController(IMediator mediator, DataContext context, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _context = context;
            _userManager = userManager;
        }


       [HttpGet]
          [Authorize(Policy ="LekarOrSestra")]

        public async Task<IActionResult> GetPreglediNaKartonu(Guid idk)
        {

            return HandleResult(await _mediator.Send(new ListPregledi.Query{IdK=idk}));
        }


        [HttpPost]
        [Authorize(Policy ="LekarOnly")]



          public async Task<IActionResult> CreatePregled(PregledDto pregledDto)
        {


             Karton karton=await _context.Kartoni.FindAsync(pregledDto.IdKarton);

           AppUser lekar=await _userManager.FindByIdAsync(pregledDto.IdLekar);


           Pregled p= new Pregled{

            Id=pregledDto.Id,
            Dijagnoza=pregledDto.Dijagnoza,
            Terapija=pregledDto.Terapija,
            Anamneza=pregledDto.Anamneza,
            VremePregleda=DateTime.Now,   
            Lekar=lekar,
            Karton=karton
           };
            return HandleResult(await _mediator.Send(new CreatePregled.Command { Pregled = p }));
        }
    }
}