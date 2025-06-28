using InvoiceManagementSystemBL.UserManagementDAL;
using InvoiceManagementSystemBO.DTO;
using InvoiceManagementSystemBO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBL.UserManagement
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL _userDAL;
        public UserBL(IUserDAL userDAL)
        {
           _userDAL = userDAL;
        }
        public Task<IdentityResult> AddUser(UserRequestDTO user)
        {
            return _userDAL.AddUser(user);
        }

        public async Task<List<UserResponseDTO>> GetUsers()
        {
            return await _userDAL.GetUsers();
        }

        public async Task<LoginResponseDTO> LoginUser(LoginDTO login)
        {
            return await _userDAL.LoginUser(login);
        }

        public async Task<string> UpdateUser(UserResponseDTO user)
        {
            return await _userDAL.UpdateUser(user);
        }
    }
}
