using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager,TokenService tokenService)
        {
            _userManager= userManager;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
       public async Task<ActionResult<UserDto>>Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            var roles = await _userManager.GetRolesAsync(user);

            var role = roles[0];

            if (result)
            {
                return CreateUserObject(user, role);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        { 
        
            if(await _userManager.Users.AnyAsync(x=>x.UserName==registerDto.Username))
            {
                return BadRequest("Username is already taken");
            }

            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email is already taken");
            }

            var user = new AppUser
            {                
                Ime = registerDto.Ime,
                Email=registerDto.Email,
                Prezime = registerDto.Prezime,
                UserName = registerDto.Username
            
            };

            
            IdentityResult result = await _userManager.CreateAsync(user, "Pas$word123");
            await _userManager.AddToRoleAsync(user, registerDto.Role);
            if (result.Succeeded)
            {
                return CreateUserObject(user,registerDto.Role);
            }

            foreach (IdentityError error in result.Errors)
                Console.WriteLine($"Opps!{error.Description}");
            return BadRequest(result.Errors);
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>>GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

             return new UserDto
            {
                Image = null,
                Ime = user.Ime,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName,
               
            };
        }

        private UserDto CreateUserObject(AppUser user,string role)
        {
            return new UserDto
            {
                Image = null,
                Ime = user.Ime,
                Prezime=user.Prezime,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName,
                Role = role
            };
        }
    }
}
