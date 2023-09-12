﻿using AutoMapper;
using Domain;
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

        public async void CreateOdeljenje(Odeljenje odeljenje)
        {
            await _context.Odeljenja.AddAsync(odeljenje);
        }

        public async Task DeleteOdeljenjeAsync(Guid id)
        {
            var odeljenje = await  _context.Odeljenja.FindAsync(id);

            _context.Remove(odeljenje);
        }

        public async void EditOdeljenje(Guid id,Odeljenje Odeljenje)
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
 
Odeljenje odeljenje=await _context.Odeljenja.FindAsync(id);

            return  odeljenje;
        }
    }
}
