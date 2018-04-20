using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_GigHub.Entities;
using System;
using System.Threading.Tasks;

namespace NetCore_GigHub.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody]ViewModelRegister viewModel, string urlReturn)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = viewModel.Username,
                    Email = viewModel.Email
                };

                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                    return Ok(viewModel);
                else
                    return BadRequest(new { message = "CreateAsync Errors!", errors = result.Errors });
            }
            else
            {
                return BadRequest(new { message = "ModelState Errors!", errors = ModelState.Values });
            }
        }


        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(_CONST.Index, _CONST.App);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(ViewModelLogin viewModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(_CONST.Index, _CONST.App);
            }
            else
            {
                return View();
            }

            // TODO
        }

        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            throw new NotImplementedException();
        }
    }
}
