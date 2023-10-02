using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repositories
{
    public class OdeljenjeRepository : IOdeljenjeRepository
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OdeljenjeRepository(DataContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task CreateOdeljenje(Odeljenje odeljenje)
        {
            await _context.Odeljenja.AddAsync(odeljenje);
        }

        public async Task DeleteOdeljenjeAsync(Guid id)
        {
            var odeljenje = await _context.Odeljenja.FindAsync(id);

            List<Pacijent> pacijenti = await _context.Pacijenti.Where(p => p.Odeljenje == odeljenje).ToListAsync();
            List<AppUser> users = await _userManager.Users.Where(u => u.Odeljenje == odeljenje).ToListAsync();
            List<Karton> kartoni = await _context.Kartoni.Where(k => pacijenti.Contains(k.Pacijent)).ToListAsync();

            _context.RemoveRange(kartoni);
            _context.RemoveRange(pacijenti);
            _context.RemoveRange(users);
            _context.Remove(odeljenje);
        }

        public async Task EditOdeljenje(Guid id, Odeljenje Odeljenje)
        {
            var odeljenje = await _context.Odeljenja.FindAsync(id);
            _mapper.Map(Odeljenje, odeljenje);

        }

        public async Task<List<Odeljenje>> GetOdeljenja()
        {
            return await _context.Odeljenja.ToListAsync();
        }

        public async Task<Odeljenje> GetOdeljenje(Guid id)
        {

            Odeljenje odeljenje = await _context.Odeljenja.FindAsync(id);

            return odeljenje;
        }
    }
}
