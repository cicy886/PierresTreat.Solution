using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PierresTreat.Models;

namespace PierresTreat.Controllers
{
    public class TreatsController : Controller
    {
        private readonly PierresTreatContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TreatsController(UserManager<ApplicationUser> userManager, PierresTreatContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Treat> model = _db.Treats.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(Treat treat)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            treat.User = currentUser;
            _db.Treats.Add (treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var thisTreat =
                _db
                    .Treats
                    .Include(treat => treat.JoinEntities)
                    .ThenInclude(join => join.Flavor)
                    .FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var thisTreat =
                _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var thisTreat =
                _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisTreat =
                _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove (thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
