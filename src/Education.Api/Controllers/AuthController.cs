using Education.Application.UseCases.AuthServise;
using Education.Domain.DTOS;
using Education.Domain.Entities.Auth;
using Education.Domain.Entities.DemoModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase 
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IAuthServise _authService;

        public AuthController(UserManager<UserModel> userManager, IAuthServise authService)
        {
            _userManager = userManager;
            _authService = authService;
        }
        [HttpPost]

        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var user = new UserModel()
            {
                FullName = register.FullName,
                Country = register.Country,
                UserName = register.Username,
                Email = register.Email,
                
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
                throw new Exception();

            await _userManager.AddToRoleAsync(user, "User");

            return Ok(new ResponseModel()
            {
                IsSuccess = true,
                Message = "Successfully Created",
                StatusCode = 201
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return BadRequest(new TokenDTO()
                {
                    Message = "User  not found",
                    IsSucceed = false,
                    Token = ""
                });
            }

            var checker = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!checker)
            {
                return BadRequest(new TokenDTO()
                {
                    Message = "Password not match",
                    IsSucceed = false,
                    Token = ""
                });
            }

            var token = await _authService.GenerateToken(user);

            return Ok(new TokenDTO()
            {
                Token = token,
                IsSucceed = true,
                Message = "Success"
            });

        }
    }
}

