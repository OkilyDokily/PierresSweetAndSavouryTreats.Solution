using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PierresSweetAndSavouryTreats.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PierresSweetAndSavouryTreats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly PierresSweetAndSavouryTreatsContext _db;
    public TreatsController(PierresSweetAndSavouryTreatsContext db)
    {
      _db = db;
    }
    public ActionResult Create()
    {
      return View();
    }

    public ActionResult Index()
    {

      return View(_db.Treats.ToList());
    }
    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      return View(_db.Treats.Include(x => x.Flavors).ThenInclude(x=>x.Flavor).FirstOrDefault(x => x.Id == id));
    }

    public ActionResult Add(int id)
    {
      
      ViewBag.FlavorId = new SelectList(_db.Flavors.Select(x => new { FlavorId = x.Id, Name = x.Name }).ToList(),"FlavorId","Name");
      return View();
    }

    [HttpPost]
    public ActionResult Add(int id,int flavorid)
    {
      _db.FlavorTreats.Add(new FlavorTreat{TreatId = id, FlavorId = flavorid});
      _db.SaveChanges();
      return RedirectToAction("Details",new {id = id});
    }
  }
}