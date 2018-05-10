using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
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
        private readonly ContextGigHub _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;


        public ManagerSecurity(
            JwtSettings jwtSettings,
            ContextGigHub context,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _context = context;
            _jwtSettings = jwtSettings;
            _signInManager = signInManager;
            _userManager = userManager;
        }


        internal Task<IdentityResult> CreateUserAsync(string userName, string email, string password)
        {
            var user = new User
            {
                UserName = userName,
                Email = email
            };
            return _userManager.CreateAsync(user, password);
        }

        internal async Task<AuthUser> ValidateUser(ViewModelLogin viewModel)
        {
            var authObject = new AuthUser();

            var user = await _userManager.FindByNameAsync(viewModel.Username);
            if (user != null)
                authObject = _BuildUserAuth(user);

            return authObject;
        }

        internal async Task<bool> AuthorizeJwtAsync(HttpContext context)
        {
            return (await AuthenticationHttpContextExtensions.AuthenticateAsync(
                context, JwtBearerDefaults.AuthenticationScheme)).Succeeded;
        }

        private AuthUser _BuildUserAuth(User user)
        {
            var claimsUser = _context.Claims
                .Where(c => c.UserId == user.Id)
                .ToList();

            var bearerToken = _BuildJwtBearer(user.Id, claimsUser);

            return new AuthUser
            {
                UserName = user.UserName,
                BearerToken = bearerToken,
                IsAuthenticated = true,
                Claims = claimsUser
            };
        }


        private string _BuildJwtBearer(int userId, List<ClaimUser> claimsUser)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var claimsJwt = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, $"{userId}"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claimsUser.ForEach(c =>
                claimsJwt.Add(new Claim(c.ClaimType, c.ClaimValue)));

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
