using Application.Dto;
using Domain;

namespace Application.Repositories
{
    public interface IKorisniciRepository
    {
        Task<List<UserGetDto>> GetUsers();
        Task<AppUser> GetUser(string id);
        Task AdminDeleteUser(string id);
    }
}
