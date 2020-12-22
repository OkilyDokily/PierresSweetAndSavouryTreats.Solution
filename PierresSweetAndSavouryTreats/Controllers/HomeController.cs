using Microsoft.AspNetCore.Mvc;
using PierresSweetAndSavouryTreats.Models;
using System.Collections.Generic;
using System.Linq;

namespace PierresSweetAndSavouryTreats.Controllers
{
    public class HomeController : Controller
    {

        private readonly PierresSweetAndSavouryTreatsContext _db;
        public HomeController(PierresSweetAndSavouryTreatsContext db)
        {
           _db = db;
        }
        public ActionResult Index()
        {
            List<Flavor> flavors = _db.Flavors.ToList();
            List<Treat> treats = _db.Treats.ToList();
            return View((treats,flavors));
        }
    }
}