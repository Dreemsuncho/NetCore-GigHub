using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_GigHub.Controllers
{
    //[Authorize]
    public class GigsController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}
