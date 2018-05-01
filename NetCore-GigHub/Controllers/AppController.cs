using Microsoft.AspNetCore.Mvc;

namespace NetCore_GigHub.Controllers
{
    public class AppController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
