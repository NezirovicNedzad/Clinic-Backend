using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repositories
{
    public class PregledRepository : IPregledRepository
    {
        private readonly DataContext _context;
         private readonly UserManager<AppUser> _userManager;

        public PregledRepository(DataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async void CreatePregled(Pregled pregled)
        {

          

           await _context.Pregledi.AddAsync(pregled);

        }

        public async Task<List<PregledDto2>> GetPregledi(Guid idKartona)
        {
        var pregledi=await _context.Pregledi.Where(p=>p.Karton.Id==idKartona).Include(n=>n.Lekar).ToListAsync();


        List<PregledDto2> Pregledi2=pregledi.Select(p=>new PregledDto2{Id=p.Id,VremePregleda=p.VremePregleda,Anamneza=p.Anamneza,Dijagnoza=p.Dijagnoza,Terapija=p.Terapija,Lekar=new LekarDto{Id=p.Lekar.Id,Ime=p.Lekar.Ime,Prezime=p.Lekar.Prezime}}).ToList();


return Pregledi2;
        }
    }
}