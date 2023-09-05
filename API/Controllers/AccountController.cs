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
        private readonly IMediator _mediator;

        public AccountController(UserManager<AppUser> userManager, TokenService tokenService, IMediator mediator)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {


            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            var roles = await _userManager.GetRolesAsync(user);

            var role = roles.FirstOrDefault();

            if (result)
            {
                if (role == "Admin")
                {
                    return CreateUserObject(user, role);
                }
                else
                {
                    return Unauthorized("Samo administratori mogu da izvrše ovu akciju.");
                }
            }

            return Unauthorized();
        }

        [HttpPost("AdminCreateUser")]
        [Authorize(Policy = "AdminOnly")]
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

            var user = new AppUser
            {
                Ime = registerDto.Ime,
                Email = registerDto.Email,
                Prezime = registerDto.Prezime,
                UserName = registerDto.Username
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, registerDto.Role);

                return CreateUserObject(user, registerDto.Role);
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
            return HandleResult(await _mediator.Send(new Details.Query { Id = id }));
        }

        [HttpDelete("AdminDeleteUser")]
        [Authorize(Policy = "AdminOnly")]
        [AllowAnonymous]
        public async Task<IActionResult> AdminDeleteUser(string id)
        {
            return HandleResult(await _mediator.Send(new Delete.Command { Id = id }));
        }

        private UserDto CreateUserObject(AppUser user, string role)
        {
            return new UserDto
            {
                Image = null,
                Ime = user.Ime,
                Prezime = user.Prezime,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName,
                Role = role,
                Email = user.Email
            };
        }
    }
}
