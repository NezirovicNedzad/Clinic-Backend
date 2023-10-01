using Application.Dto;
using Domain;

namespace Application.Repositories
{
    public interface IKorisniciRepository
    {
        Task<List<UserGetDto>> GetUsers();
        Task<AppUser> GetUser(string id);
        void AdminDeleteUser(string id);
    }
}
