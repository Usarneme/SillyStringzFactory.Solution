using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

    [HttpGet("/machines/details/{id}")]
    public ActionResult Details(int id)
    {
      var mach = _db.Machines
        .Include(mach => mach.JoinEntities)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(mach => mach.MachineId == id);
      return View(mach);
    }

    [HttpGet("/machines/edit/{id}")]
    public ActionResult Edit(int id)
    {
      Machine mach = _db.Machines.FirstOrDefault(mach => mach.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(mach);
    }

    [HttpPost]
    public ActionResult Edit(Machine mach, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = EngineerId, MachineId = mach.MachineId});
      }
      _db.Entry(mach).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/machines/delete/{id}")]
    public ActionResult Delete(int id)
    {
      Machine mach = _db.Machines.FirstOrDefault(mach => mach.MachineId == id);
      return View(mach);
    }

        [HttpPost("/machines/delete/{id}")]
    public ActionResult DeleteConfirmed(int id)
    {
      Machine mach = _db.Machines.FirstOrDefault(mach => mach.MachineId == id);
      _db.Machines.Remove(mach);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
