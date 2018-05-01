using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_GigHub.Data;
using NetCore_GigHub.Entities;
using NetCore_GigHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore_GigHub.Controllers
{
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

        [HttpGet]
        public ActionResult GetUpcoming()
        {
            var res = _context.Gigs
                .Where(g => g.DateTime > DateTime.Now)
                .Include(x => x.Genre)
                .Include(x => x.Artist)
                .ToList();

            return StatusCode(StatusCodes.Status200OK, res);
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
