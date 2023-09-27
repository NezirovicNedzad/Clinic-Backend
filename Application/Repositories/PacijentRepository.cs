using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Application.Dto;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repositories
{
    public class PacijentRepository : IPacijentRepository
    {


       private readonly DataContext _context;
       private readonly UserManager<AppUser> _userManager;
       
        private readonly IMapper _mapper;

        public PacijentRepository(DataContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async void CreatePacijent(Pacijent pacijent)
        {
          
await _context.Pacijenti.AddAsync(pacijent);
        }

        public async Task DeletePacijentAsync(Guid id)
        {
                      var pacijent = await  _context.Pacijenti.FindAsync(id);
                    List <Karton> kartoni=await _context.Kartoni.Where(x=>x.Pacijent==pacijent).ToListAsync();
                      Odeljenje odeljenje=await _context.Odeljenja.Where(x=>x.Pacijenti.Contains(pacijent)).FirstAsync();
                        odeljenje.BrojPacijenata=odeljenje.BrojPacijenata-1;
           _context.RemoveRange(kartoni);
            _context.Remove(pacijent);
        }

        public async Task<PacijentDto2> GetPacijent(Guid id)
        {
            
             
          Pacijent p=   await _context.Pacijenti.Where(p=>p.Id==id).Include(l=>l.Lekar).FirstAsync();
        
        Odeljenje o=await _context.Odeljenja.Where(o=>o.Pacijenti.Contains(p)).FirstAsync();
        PacijentDto2 pacijentDto2=new PacijentDto2{
            Id=p.Id,
            Ime=p.Ime,
            Prezime=p.Prezime,
            BrojGodina=p.BrojGodina,
            Pol=p.Pol,
            Lekar=p.Lekar,
            IdOdeljenja=o.Id
        };

        return pacijentDto2;
        
        
        }

        public async Task<List<Pacijent>> GetPacijentiPoOdeljenju(Odeljenje odeljenje)
        {

            
       return await _context.Pacijenti.Where((p)=>p.Kartoni.Any(k=>k.Odeljenje==odeljenje)).ToListAsync();
      
      
        }

        public async Task<List<Pacijent>> GetPacijents()
        {
            
            return await _context.Pacijenti.ToListAsync();
        }

        public async Task PrebaciPacijenta(Guid idP, Pacijent pacijent)
        {
             var pacijent2 = await _context.Pacijenti.FindAsync(idP);
            _mapper.Map(pacijent,pacijent2);
        }
    }
}