using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore_GigHub.Data;
using NetCore_GigHub.Entities;
using NetCore_GigHub.ViewModels;
using System.Linq;

namespace NetCore_GigHub.Controllers
{
    [Authorize]
    public class GigsController : Controller
    {
        private ContextGigHub _context;

        public GigsController(ContextGigHub context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var genres = _context.Genres.AsEnumerable();
            return View(genres);
        }

        [HttpPost]
        public ActionResult Create([FromBody]ViewModelGig model)
        {
            if (ModelState.IsValid)
            {
                _context.Gigs.Add(new Gig
                {
                    Venue = model.Venue,
                    DateTime = model.GetDateTime(),
                    GenreId = model.Genre,
                    //ArtistId = User.Identity.Name
                });

                _context.SaveChanges();
                return Created(HttpContext.Request.Path, model);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}
