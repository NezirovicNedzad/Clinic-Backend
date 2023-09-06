using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repositories
{
    public class KorisniciRepository : IKorisniciRepository
    {
        private readonly DataContext _context;

        public KorisniciRepository(DataContext context)
        {
            _context = context;
        }

        public async void AdminDeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);

            _context.Remove(user);
        }

        public async Task<AppUser> GetUser(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<AppUser>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
