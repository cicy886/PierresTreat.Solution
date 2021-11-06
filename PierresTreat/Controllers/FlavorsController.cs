using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        public ActionResult Details(int id)
        {
            var thisFlavor =
                _db
                    .Flavors
                    .Include(Flavor => Flavor.JoinEntities)
                    .ThenInclude(join => join.Treat)
                    .FirstOrDefault(Flavor => Flavor.FlavorId == id);
            return View(thisFlavor);
        }

        public ActionResult Edit(int id)
        {
            var thisFlavor =
                _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View(thisFlavor);
        }

        [HttpPost]
        public ActionResult Edit(Flavor flavor, int TreatId)
        {
            if (TreatId != 0)
            {
                _db
                    .FlavorTreat
                    .Add(new FlavorTreat()
                    { TreatId = TreatId, FlavorId = flavor.FlavorId });
            }
            _db.Entry(flavor).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddTreat(int id)
        {
            var thisFlavor =
                _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View(thisFlavor);
        }

        [HttpPost]
        public ActionResult AddTreat(Flavor flavor, int TreatId)
        {
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

        public ActionResult Delete(int id)
        {
            var thisFlavor =
                _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            return View(thisFlavor);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisFlavor =
                _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
            _db.Flavors.Remove (thisFlavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteEngineer(int joinId)
        {
            var joinEntry =
                _db
                    .FlavorTreat
                    .FirstOrDefault(entry => entry.FlavorTreatId == joinId);
            _db.FlavorTreat.Remove (joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
