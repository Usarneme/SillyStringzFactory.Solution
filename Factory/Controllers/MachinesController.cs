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
    [HttpGet("/machines")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/machines/create")]
    public ActionResult Create()
    {
      return View();
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
