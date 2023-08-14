using AutoMapper;
using Azure.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class OdeljenjeRepository : IOdeljenjeRepository
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OdeljenjeRepository(DataContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateOdeljenje(Odeljenje odeljenje)
        {
            _context.Odeljenja.Add(odeljenje);
        }

        public async void DeleteOdeljenje(Guid id)
        {
            var odeljenje = await _context.Odeljenja.FindAsync(id);


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
            return await _context.Odeljenja.FindAsync(id);
        }
    }
}
