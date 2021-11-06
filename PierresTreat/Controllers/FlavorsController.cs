using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PierresTreat.Models;

namespace PierresTreat.Controllers
{
    public class FlavorsController : Controller
    {
        private readonly PierresTreatContext _db;

        public FlavorsController(PierresTreatContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Flavors.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Flavor flavor, int TreatId)
        {
            _db.Flavors.Add (flavor);
            _db.SaveChanges();
            if (TreatId != 0)
            {
                _db
                    .FlavorTreat
                    .Add(new FlavorTreat()
                    { TreatId = TreatId, FlavorId = flavor.FlavorId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
