using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PierresSweetAndSavouryTreats.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace PierresSweetAndSavouryTreats.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly PierresSweetAndSavouryTreatsContext _db;
    public FlavorsController(PierresSweetAndSavouryTreatsContext db)
    {
      _db = db;
    }
    [Authorize]

    public ActionResult Create()
    {
      return View();
    }

    public ActionResult Index()
    {
      return View(_db.Flavors.ToList());
    }
    [HttpPost, Authorize]
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
    [Authorize]
    public ActionResult Add(int id)
    {
      Flavor flavor = _db.Flavors.Include(x => x.Treats).ThenInclude(x => x.Treat).FirstOrDefault(x => x.Id == id);
      List<Treat> treats = flavor.Treats.Select(x => x.Treat).ToList();
      ViewBag.TreatId = new SelectList(_db.Treats.Where(x => !(treats.Any(t => t == x))).Select(x => new { TreatId = x.Id, Name = x.Name }).ToList(), "TreatId", "Name");
      return View();
    }

    [HttpPost, Authorize]
    public ActionResult Add(int id, int treatid)
    {
      _db.FlavorTreats.Add(new FlavorTreat { FlavorId = id, TreatId = treatid });
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = id });
    }

    [HttpPost, Authorize]
    public ActionResult Delete(int id)
    {
      Flavor flavor = _db.Flavors.FirstOrDefault(x => x.Id == id);
      _db.Flavors.Remove(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [Authorize]

    public ActionResult Edit(int id)
    {
      Flavor flavor = _db.Flavors.FirstOrDefault(x => x.Id == id);
      return View(flavor);
    }

    [HttpPost,Authorize]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.Id });
    }
  }
}