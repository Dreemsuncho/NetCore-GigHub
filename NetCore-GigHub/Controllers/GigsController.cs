using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_GigHub.Data;
using NetCore_GigHub.Entities;
using NetCore_GigHub.Managers;
using NetCore_GigHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GigHub.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GigsController : BaseController
    {
        private readonly ManagerSecurity _managerSecurity;
        private readonly ContextGigHub _context;


        public GigsController(
            ManagerSecurity managerSecurity,
            ContextGigHub context)
        {
            _managerSecurity = managerSecurity;
            _context = context;
        }


        [HttpGet]
        public ActionResult Genres()
        {
            var genres = _context.Genres.ToList();
            return StatusCode(StatusCodes.Status200OK, genres);
        }


        [HttpGet]
        public async Task<ActionResult> Upcoming()
        {
            var gigs = _context.Gigs
                .Where(g => g.DateTime > DateTime.Now)
                .Include(x => x.Genre)
                .Include(x => x.Artist)
                .ToList();

            bool isAuthenticated = await _managerSecurity.AuthorizeJwtAsync(context: HttpContext);

            return StatusCode(StatusCodes.Status200OK, new { gigs, isAuthenticated });
        }


        [HttpPost]
        public ActionResult Create([FromBody]ViewModelGig viewModel)
        {
            var errors = new List<string>();

            if (ModelState.IsValid)
            {
                _context.Gigs.Add(new Gig
                {
                    Venue = viewModel.Venue,
                    DateTime = viewModel.GetDateTime(),
                    GenreId = viewModel.GenreId,
                    ArtistId = viewModel.ArtistId
                });

                _context.SaveChanges();
            }
            else
            {
                errors.AddRange(_GetModelStateErrors());
            }

            if (errors.Count == 0)
                return StatusCode(StatusCodes.Status200OK);
            else
                return StatusCode(StatusCodes.Status400BadRequest, new { values = errors });
        }
    }
}
