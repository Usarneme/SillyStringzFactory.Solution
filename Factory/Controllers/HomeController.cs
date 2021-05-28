using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    private readonly FactoryContext _db;
    public HomeController(FactoryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.Engineers = _db.Engineers.ToList();
      ViewBag.Machines = _db.Machines.ToList();
      return View();
    }

    [HttpPost("/remove_license/{EngineerMachineId}")]
    public ActionResult RemoveAssociation(int EngineerMachineId)
    {
      EngineerMachine enMa = _db.EngineerMachines.FirstOrDefault(enMa => enMa.EngineerMachineId == EngineerMachineId);
      _db.EngineerMachines.Remove(enMa);
      _db.SaveChanges();
      return Content("ok", "application/json");
    }
  }
}
