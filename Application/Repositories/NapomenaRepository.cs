using Application.Dto;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class NapomenaRepository : INapomenaRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public NapomenaRepository(DataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async void CreateNapomena(Napomena napomena)
        {
            await _context.Napomene.AddAsync(napomena);
        }

        public async Task<List<NapomenaDto>> GetNapomene(Guid idKartona)
        {
            var napomene = await _context.Napomene.Where(p => p.Karton.Id == idKartona).Include(s => s.Sestra).ToListAsync();

            List<NapomenaDto> napomena = napomene.Select(p => new NapomenaDto { Id = p.Id, NezeljenoDejstvo = p.NezeljenoDejstvo, Primedba = p.Primedba, Sestra = new SestraDto { Id = p.Sestra.Id, Ime = p.Sestra.Ime, Prezime = p.Sestra.Prezime } }).ToList();

            return napomena;
        }
    }
}
