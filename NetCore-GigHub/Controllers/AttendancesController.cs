using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_GigHub.Data;
using NetCore_GigHub.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetCore_GigHub.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    public class AttendancesController : BaseController
    {
        private readonly ContextGigHub _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AttendancesController(ContextGigHub context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public ActionResult Attend([FromBody]int gigId)
        {
            var errors = new List<string>();

            var userId = _userManager.GetUserId(User);

            if (userId != null)
            {
                if (_context.Attendances.Any(a => a.UserId == int.Parse(userId) && a.GigId == gigId))
                {
                    errors.Add("The attendance already exists!");
                }
                else
                {
                    var entity = new Attendance
                    {
                        GigId = gigId,
                        UserId = int.Parse(userId)
                    };

                    _context.Attendances.Add(entity);
                    _context.SaveChanges();
                }
            }
            else
            {
                // 401 Unauthorized...
                errors.Add("You have to login first");
            }


            if (errors.Count == 0)
                return StatusCode(StatusCodes.Status201Created);
            else
                return StatusCode(StatusCodes.Status409Conflict, new { values = errors });
        }
    }
}
