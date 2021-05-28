using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;
    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    [HttpGet("/machines")]
    public ActionResult Index()
    {
      List<Machine> machines = _db.Machines.ToList();
      return View(machines);
    }

    [HttpGet("/machines/create")]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost("/machines/create")]
    public ActionResult Create(Machine mach)
    {
      _db.Machines.Add(mach);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/machines/edit/{id}")]
    public ActionResult Edit(int id)
    {
      return View();
    }

    [HttpGet("/machines/delete/{id}")]
    public ActionResult Delete(int id)
    {
      return View();
    }
  }
}
