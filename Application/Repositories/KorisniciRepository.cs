using Application.Dto;
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

        public async Task<List<UserGetDto>> GetUsers()
        {

            List<AppUser> listK=await _context.Users.ToListAsync();

         List<UserGetDto> listaUD=listK.Select(d=>new UserGetDto{Id=d.Id,Ime=d.Ime,Prezime=d.Prezime,Specijalizacija=d.Specijalizacija,Email=d.Email,OdeljenjeId=_context.Odeljenja.Where(o=>o.Osoblje.Contains(d)).First().Id.ToString(),Role=d.Role,Username=d.UserName}).ToList();
            return  listaUD;
        }
    }
}
