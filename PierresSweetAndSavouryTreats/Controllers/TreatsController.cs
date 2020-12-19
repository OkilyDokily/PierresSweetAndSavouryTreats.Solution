using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PierresSweetAndSavouryTreats.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;


namespace PierresSweetAndSavouryTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierresSweetAndSavouryTreatsContext _db;
    public TreatsController(PierresSweetAndSavouryTreatsContext db)
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
      return View(_db.Treats.ToList());
    }
    [HttpPost,Authorize]
    public ActionResult Create(Treat treat)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public ActionResult Details(int id)
    {
      return View(_db.Treats.Include(x => x.Flavors).ThenInclude(x=>x.Flavor).FirstOrDefault(x => x.Id == id));
    }
    [Authorize]

    public ActionResult Add(int id)
    {
      Treat treat = _db.Treats.Include(x => x.Flavors).ThenInclude(x => x.Flavor).FirstOrDefault(x => x.Id == id);
      List<Flavor> flavors = treat.Flavors.Select(x => x.Flavor).ToList();
      ViewBag.FlavorId = new SelectList(_db.Flavors.Where(x => !(flavors.Any(f => f == x))).Select(x => new { FlavorId = x.Id, Name = x.Name }).ToList(),"FlavorId","Name");
      return View();
    }

    [HttpPost, Authorize]
    public ActionResult Add(int id,int flavorid)
    {
      _db.FlavorTreats.Add(new FlavorTreat{TreatId = id, FlavorId = flavorid});
      _db.SaveChanges();
      return RedirectToAction("Details",new {id = id});
    }

    [HttpPost, Authorize]
    public ActionResult Delete(int id)
    {
      Treat treat = _db.Treats.FirstOrDefault(x => x.Id == id);
      _db.Treats.Remove(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [Authorize]

    public ActionResult Edit(int id)
    {
      Treat treat = _db.Treats.FirstOrDefault(x=>x.Id == id);
      return View(treat);
    }

    [HttpPost, Authorize]
    public ActionResult Edit(Treat treat)
    {
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new{id = treat.Id});
    }
  }
}