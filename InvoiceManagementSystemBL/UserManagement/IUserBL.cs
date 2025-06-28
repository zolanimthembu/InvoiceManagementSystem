using InvoiceManagementSystemBO.DTO;
using InvoiceManagementSystemBO.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBL.UserManagement
{
    public interface IUserBL
    {
        Task<IdentityResult> AddUser(UserRequestDTO user);
        Task<LoginResponseDTO> LoginUser(LoginDTO login);
        Task<List<UserResponseDTO>> GetUsers();
        Task<string> UpdateUser(UserResponseDTO user);



    }
}
