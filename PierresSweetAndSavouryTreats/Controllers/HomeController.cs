using Microsoft.AspNetCore.Mvc;

namespace PierresSweetAndSavouryTreats.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}