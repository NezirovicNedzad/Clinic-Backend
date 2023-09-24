using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Application.Dto;
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
       
       
       
        public PacijentRepository(DataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async void CreatePacijent(Pacijent pacijent)
        {
          
await _context.Pacijenti.AddAsync(pacijent);
        }

        public async Task DeletePacijentAsync(Guid id)
        {
                      var pacijent = await  _context.Pacijenti.FindAsync(id);
                      Odeljenje odeljenje=await _context.Odeljenja.Where(x=>x.Pacijenti.Contains(pacijent)).FirstAsync();
                        odeljenje.BrojPacijenata=odeljenje.BrojPacijenata-1;
           
            _context.Remove(pacijent);
        }

        public async Task<Pacijent> GetPacijent(Guid id)
        {
             return await _context.Pacijenti.Where(p=>p.Id==id).Include(l=>l.Lekar).FirstAsync();
        }

        public async Task<List<Pacijent>> GetPacijentiPoOdeljenju(Odeljenje odeljenje)
        {

            
       return await _context.Pacijenti.Where((p)=>p.Kartoni.Any(k=>k.Odeljenje==odeljenje)).ToListAsync();
      
      
        }

        public async Task<List<Pacijent>> GetPacijents()
        {
            
            return await _context.Pacijenti.ToListAsync();
        }
    }
}