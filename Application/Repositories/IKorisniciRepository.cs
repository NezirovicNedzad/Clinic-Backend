using Domain;

namespace Application.Repositories
{
    public interface IKorisniciRepository
    {
        Task<List<AppUser>> GetUsers();
        Task<AppUser> GetUser(string id);
        void AdminDeleteUser(string id);
    }
}
