using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_GigHub.Data;
using NetCore_GigHub.Entities;
using NetCore_GigHub.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace NetCore_GigHub.Controllers
{
    //[Authorize]
    public class GigsController : BaseController
    {
        private ContextGigHub _context;

        public GigsController(ContextGigHub context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            var genres = _context.Genres.ToList();
            return StatusCode(StatusCodes.Status200OK, genres);
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
                return StatusCode(StatusCodes.Status400BadRequest, errors);
        }
    }
}
