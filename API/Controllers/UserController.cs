using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{

    public class UserController :BaseApiController
    {

        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]


        public async Task CreateUser(User user)
        {

            await _dataContext.Korsinici.AddAsync(user);

 await    _dataContext.SaveChangesAsync();
        
        }
    }
}
