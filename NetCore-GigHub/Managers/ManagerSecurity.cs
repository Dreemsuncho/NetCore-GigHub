using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NetCore_GigHub.Data;
using NetCore_GigHub.Entities;
using NetCore_GigHub.Models;
using NetCore_GigHub.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetCore_GigHub.Managers
{
    public class ManagerSecurity
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ContextGigHub _context;


        public ManagerSecurity(
            JwtSettings jwtSettings,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            ContextGigHub context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _jwtSettings = jwtSettings;
        }


        public Task<IdentityResult> CreateUserAsync(string userName, string email, string password)
        {
            var user = new User
            {
                UserName = userName,
                Email = email
            };
            return _userManager.CreateAsync(user, password);
        }


        public Task<SignInResult> SignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }


        public async Task<AuthUser> ValidateUser(ViewModelLogin viewModel)
        {
            var authObject = new AuthUser();

            var result = await SignInAsync(
                userName: viewModel.Username,
                password: viewModel.Password,
                isPersistent: true,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(viewModel.Username);
                authObject = _BuildUserAuth(user);
            }

            return authObject;
        }

        private AuthUser _BuildUserAuth(User user)
        {
            var claimsUser = _context.Claims
                .Where(c => c.UserId == user.Id)
                .ToList();

            var bearerToken = _BuildJwtBearer(user.UserName, claimsUser);

            return new AuthUser
            {
                UserId = user.Id,
                UserName = user.UserName,
                BearerToken = bearerToken,
                IsAuthenticated = true,
                Claims = claimsUser
            };
        }


        private string _BuildJwtBearer(string username, List<ClaimUser> claimsUser)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var claimsJwt = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claimsUser.ForEach(c => claimsJwt.Add(new Claim(c.ClaimType, c.ClaimValue)));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claimsJwt,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.MinutesToExpiration),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
