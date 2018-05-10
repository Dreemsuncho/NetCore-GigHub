using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_GigHub.Data;
using NetCore_GigHub.Entities;
using NetCore_GigHub.Managers;
using System.Collections.Generic;
using System.Linq;

namespace NetCore_GigHub.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    public class AttendancesController : BaseController
    {
        private readonly ContextGigHub _context;
        private readonly ManagerSecurity _managerSecurity;


        public AttendancesController(ContextGigHub context, ManagerSecurity managerSecurity)
        {
            _context = context;
            _managerSecurity = managerSecurity;
        }


        [HttpPost]
        public ActionResult Attend([FromBody]int gigId)
        {
            var errors = new List<string>();

            var userId = _managerSecurity.GetUserId(User);

            if (_context.Attendances.Any(a => a.UserId == userId && a.GigId == gigId))
            {
                errors.Add("The attendance already exists!");
            }
            else
            {
                var entity = new Attendance
                {
                    GigId = gigId,
                    UserId = userId
                };

                _context.Attendances.Add(entity);
                _context.SaveChanges();
            }

            if (errors.Count == 0)
                return StatusCode(StatusCodes.Status201Created);
            else
                return StatusCode(StatusCodes.Status409Conflict, new { values = errors });
        }
    }
}
