using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCore_GigHub.Controllers
{
    public class AppController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult More()
        {
            return new ObjectResult(new { name = "Elvis", Age = "26" });
        }
    }
}
