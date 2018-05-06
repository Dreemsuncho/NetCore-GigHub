using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_GigHub.Entities;
using NetCore_GigHub.Managers;
using NetCore_GigHub.Models;
using NetCore_GigHub.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GigHub.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : BaseController
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
                return StatusCode(StatusCodes.Status400BadRequest, new { values = errors });
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
                {
                    errors.Add("Username or password incorrect!");
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        userName: viewModel.Username,
                        password: viewModel.Password,
                        isPersistent: true,
                        lockoutOnFailure: false);
                    
                    if (!result.Succeeded)
                        errors.Add("Something happened, cannot login with this account");
                }
            }
            else
            {
                errors.AddRange(_GetModelStateErrors());
            }

            if (errors.Count == 0)
                return StatusCode(StatusCodes.Status200OK, authObject);
            else
                return StatusCode(StatusCodes.Status400BadRequest, new { values = errors });
        }
    }
}
