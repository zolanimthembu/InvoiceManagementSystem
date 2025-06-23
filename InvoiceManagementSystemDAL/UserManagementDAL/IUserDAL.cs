using InvoiceManagementSystemBO.DTO;
using InvoiceManagementSystemBO.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBL.UserManagementDAL
{
    public interface IUserDAL
    {
        Task<IdentityResult> AddUser(UserRequestDTO user);
        Task<LoginResponseDTO> LoginUser(LoginDTO login);
    }
}
