using InvoiceManagementSystemBL.UserManagement;
using InvoiceManagementSystemBO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagementSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBL _userBL;
        public UsersController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userBL.GetUsers();
            if (users == null)
                return NotFound();
            return Ok(users);
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserResponseDTO userUpdate)
        {
            var response = await _userBL.UpdateUser(userUpdate);
            if (response == null)
                return Content("Error Updating");
            return Ok(response);
        }
    }
}
