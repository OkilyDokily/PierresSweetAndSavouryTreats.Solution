using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PierresSweetAndSavouryTreats.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PierresSweetAndSavouryTreats.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly PierresSweetAndSavouryTreatsContext _db;
    public FlavorsController(PierresSweetAndSavouryTreatsContext db)
    {
      _db = db;
    }
    public ActionResult Create()
    {
      return View();
    }

    public ActionResult Index()
    {
      return View(_db.Flavors.ToList());
    }
    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      return View(_db.Flavors.Include(x => x.Treats).ThenInclude(x => x.Treat).FirstOrDefault(x => x.Id == id));
    }

    public ActionResult Add(int id)
    {

      ViewBag.TreatId = new SelectList(_db.Treats.Select(x => new { TreatId = x.Id, Name = x.Name }).ToList(), "TreatId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Add(int id, int treatid)
    {
      _db.FlavorTreats.Add(new FlavorTreat { FlavorId = id, TreatId = treatid });
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = id });
    }
  }
}