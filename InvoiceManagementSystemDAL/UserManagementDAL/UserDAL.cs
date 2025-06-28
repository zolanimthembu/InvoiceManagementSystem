using InvoiceManagementSystemBO.Data;
using InvoiceManagementSystemBO.DTO;
using InvoiceManagementSystemBO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystemBL.UserManagementDAL
{
    public class UserDAL : IUserDAL
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public UserDAL(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _context = context;
        }
        public async Task<IdentityResult> AddUser(UserRequestDTO registerUser)
        {
            var user = new ApplicationUser { UserName = registerUser.Email, Email = registerUser.Email, FirstName = registerUser.FirstName, LastName = registerUser.LastName };
            var result = await _userManager.CreateAsync(user, registerUser.Password);
            await _userManager.AddToRoleAsync(user, registerUser.Role);
            return result;
        }

        public async Task<List<UserResponseDTO>> GetUsers()
        {
            return await (from user in _context.Users
                                  join userRole in _context.UserRoles on user.Id equals userRole.UserId
                                  join role in _context.Roles on userRole.RoleId equals role.Id
                                  select new UserResponseDTO
                                  {
                                      Email = user.Email,
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                      UserId = user.Id,
                                      Role = role.Name
                                  }).ToListAsync();
        }

        public async Task<LoginResponseDTO> LoginUser(LoginDTO login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
                return null!;

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = GetToken(authClaims);

            return new LoginResponseDTO
            {
                User = user,
                Expiration = token.ValidTo,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            };
        }

        public async Task<string> UpdateUser(UserResponseDTO user)
        {
            try
            {
                var updateUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.UserId);
                if (updateUser == null) return "User not found";

                updateUser.FirstName = user.FirstName;
                updateUser.LastName = user.LastName;

                // Remove existing role
                var currentRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.UserId);
                if (currentRole != null)
                    _context.UserRoles.Remove(currentRole);

                // Get new role
                var newRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name!.ToLower() == user.Role.ToLower());
                if (newRole == null) return "New role not found";

                // Add new role
                _context.UserRoles.Add(new IdentityUserRole<string>
                {
                    UserId = user.UserId,
                    RoleId = newRole.Id
                });

                await _context.SaveChangesAsync();
                return "success";
            }
            catch (Exception ex)
            {
                return $"error {ex.Message}";
            }

        }

        private JwtSecurityToken GetToken(List<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            return new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
        }
    }
}
