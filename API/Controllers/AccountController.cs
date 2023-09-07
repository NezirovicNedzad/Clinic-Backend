using API.DTOs;
using API.Services;
using Application.Korisnici;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Data;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;
  
        private readonly DataContext _context;
        private readonly IMediator _mediator;

        public AccountController(UserManager<AppUser> userManager, TokenService tokenService, DataContext context, IMediator mediator)


        {
            _userManager = userManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {


            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();


            var Odeljenje=await _context.Odeljenja.Where(s=>s.Osoblje.Contains(user)).FirstOrDefaultAsync();  

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            var roles = await _userManager.GetRolesAsync(user);

            
          
            var role = roles[0];

            if (result)
            {
                 return new UserDto{
                Image = null,
                Ime = user.Ime,
                Token = _tokenService.CreateToken(user),
                Username =user.UserName,
                Role=role,
                Prezime=user.Prezime,
                OdeljenjeId=Odeljenje.Id.ToString(),    
                
               

                };
            }

            return Unauthorized();
        }

        [HttpPost("AdminCreateUser")]
            [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            

            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
            {
                return BadRequest("Username is already taken");
            }

            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email is already taken");
            }


            Guid g=new Guid(registerDto.OdeljenjeId);
            var Odeljenje= await _context.Odeljenja.FindAsync(g);

            var user = new AppUser
            {
                Ime = registerDto.Ime,
                Odeljenje=Odeljenje,     
                Email=registerDto.Email,
                Prezime = registerDto.Prezime,
                UserName = registerDto.Username
                
            
            };

            
            IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);
            await _userManager.AddToRoleAsync(user, registerDto.Role);
            if (result.Succeeded)
            {
                return new UserDto{
                Image = null,
                Ime = registerDto.Ime,
                Token = _tokenService.CreateToken(user),
                Username = registerDto.Username,
                Role=registerDto.Role,
                Prezime=registerDto.Prezime,
                OdeljenjeId=registerDto.OdeljenjeId
               

                };
            }

            foreach (IdentityError error in result.Errors)
                Console.WriteLine($"Opps! {error.Description}");
            return BadRequest(result.Errors);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return new UserDto
            {
                Image = null,
                Ime = user.Ime,
                Email= user.Email,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName,
            };
        }

      [HttpDelete("AdminDeleteUser")]
      [AllowAnonymous]



      public async Task<IActionResult> AdminDelteUser(string id)
     {

        return HandleResult(await _mediator.Send(new Delete.Command{Id=id}));

     }



       [HttpGet("GetAllUsers")]
       [AllowAnonymous]
        public async Task<IActionResult> GetUsers()
     {

        return HandleResult(await _mediator.Send(new List.Query()));

     }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser(string id)
     {

        return HandleResult(await _mediator.Send(new Details.Query{Id=id}));    

     }


    }
}
