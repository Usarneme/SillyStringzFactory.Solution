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

    [HttpGet("/engineers/edit/{id}")]
    public ActionResult Edit(int id)
    {
      return View();
    }

    [HttpGet("/engineers/delete/{id}")]
    public ActionResult Delete(int id)
    {
      return View();
    }

  }
}
