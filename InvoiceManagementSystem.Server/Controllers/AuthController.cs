using InvoiceManagementSystemBL.UserManagement;
using InvoiceManagementSystemBO.DTO;
using InvoiceManagementSystemBO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace InvoiceManagementSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserBL _userBL;
        public AuthController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRequestDTO user)
        {
            var result = await _userBL.AddUser(user);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var user = await _userBL.LoginUser(login);
            if(user == null)
                return Unauthorized();
            return Ok(user);
        }
    }
}
