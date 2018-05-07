using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ManagerSecurity _managerSecurity;


        public AccountController(ManagerSecurity managerSecurity)
        {
            _managerSecurity = managerSecurity;
        }


        [HttpPost]
        public async Task<ActionResult> Register([FromBody]ViewModelRegister viewModel, string urlReturn)
        {
            var errors = new List<string>();

            if (ModelState.IsValid)
            {
                var result = await _managerSecurity.CreateUserAsync(
                    userName: viewModel.Username,
                    password: viewModel.Password,
                    email: viewModel.Email);

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
                    errors.Add("Username or password incorrect!");
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
