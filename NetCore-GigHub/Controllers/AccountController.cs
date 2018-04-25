using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetCore_GigHub.Data;
using NetCore_GigHub.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetCore_GigHub.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ManagerSecurity _managerSecurity;

        public AccountController(
            JwtSettings jwtSettings,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            ManagerSecurity managerSecurity)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _managerSecurity = managerSecurity;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody]ViewModelRegister viewModel, string urlReturn)
        {
            var errors = new List<string>();

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = viewModel.Username,
                    Email = viewModel.Email
                };

                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (!result.Succeeded)
                    errors.AddRange(result.Errors.Select(err => err.Description));
            }
            else
            {
                errors.AddRange(_GetModelStateErrors());
            }

            if (errors.Count == 0)
                return StatusCode(StatusCodes.Status201Created);
            else
                return StatusCode(StatusCodes.Status400BadRequest, errors);
        }

        private IEnumerable<string> _GetModelStateErrors()
        {
            var errors = new List<string>();

            ModelState.Values.ToList()
                .ForEach(v => errors.AddRange(v.Errors.Select(e => e.ErrorMessage)));

            return errors;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]ViewModelLogin viewModel)
        {
            AuthUser authObject = null;
            var errors = new List<string>();

            if (ModelState.IsValid)
            {
                authObject = await _managerSecurity.ValidateUser(viewModel);

                if (!authObject.IsAuthenticated)
                    errors.Add("Username or password incorrect!");
            }
            else
            {
                errors.AddRange(_GetModelStateErrors());
            }

            if (errors.Count == 0)
                return StatusCode(StatusCodes.Status200OK, authObject);
            else
                return StatusCode(StatusCodes.Status400BadRequest, errors);
        }
    }

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

        public async Task<AuthUser> ValidateUser(ViewModelLogin viewModel)
        {
            var authObject = new AuthUser();

            var user = await _userManager.FindByNameAsync(viewModel.Username);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, viewModel.Password, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    authObject = _BuildUserAuth(user);
                }
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


    public class AuthUser
    {
        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }

        public List<ClaimUser> Claims { get; set; }
    }
}
