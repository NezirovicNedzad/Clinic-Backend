using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

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

        public async void CreateOdeljenje(Odeljenje odeljenje)
        {
            await _context.Odeljenja.AddAsync(odeljenje);
        }

        public void DeleteOdeljenje(Guid id)
        {
            var odeljenje =  _context.Odeljenja.Find(id);

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
