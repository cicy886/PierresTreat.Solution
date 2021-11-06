using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PierresTreat.Models;

namespace PierresTreat.Controller
{
  public class TreatsController: Controller
  {
    private readonly PierresTreatContext _db;

    public TreatsController(PierresContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Treat> model = _db.Treats.ToList();
      return View(model);
    }
  }
}
