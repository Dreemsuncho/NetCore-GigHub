using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCore_GigHub.Data;
using NetCore_GigHub.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetCore_GigHub.Controllers
{
    public class FollowingsController : BaseController
    {
        private readonly ContextGigHub _context;
        private readonly UserManager<User> _userManager;

        public FollowingsController(ContextGigHub context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public ActionResult Follow([FromBody]int followeeId)
        {
            var errors = new List<string>();

            var followerId = _userManager.GetUserId(User);

            if (followerId != null)
            {
                if (followeeId == int.Parse(followerId))
                {
                    errors.Add("The user cannot follow himself!");
                }
                else if (_context.Followings.Any(f => f.FolloweeId == followeeId && f.FollowerId == int.Parse(followerId)))
                {
                    errors.Add("Following already exist!");
                }
                else
                {
                    var entity = new Following
                    {
                        FolloweeId = followeeId,
                        FollowerId = int.Parse(followerId)
                    };

                    _context.Followings.Add(entity);
                    _context.SaveChanges();
                }
            }
            else
            {
                errors.Add("Follower does not exist!");
            }

            if (errors.Count == 0)
                return StatusCode(StatusCodes.Status201Created);
            else
                return StatusCode(StatusCodes.Status409Conflict, new { values = errors });
        }
    }
}
