using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;
    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    [HttpGet("/engineers")]
    public ActionResult Index()
    {
      List<Engineer> engineers = _db.Engineers.ToList();
      return View(engineers);
    }

    [HttpGet("/engineers/create")]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost("/engineers/create")]
    public ActionResult Create(Engineer eng)
    {
      _db.Engineers.Add(eng);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/engineers/details/{id}")]
    public ActionResult Details(int id)
    {
      Engineer eng = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      return View(eng);
    }

    [HttpGet("/engineers/edit/{id}")]
    public ActionResult Edit(int id)
    {
      return View();
    }

    [HttpGet("/engineers/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Engineer eng = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      return View(eng);
    }

    [HttpPost("/engineers/delete/{id}")]
    public ActionResult DeleteConfirmed(int id)
    {
      Engineer eng = _db.Engineers.FirstOrDefault(eng => eng.EngineerId == id);
      _db.Engineers.Remove(eng);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
