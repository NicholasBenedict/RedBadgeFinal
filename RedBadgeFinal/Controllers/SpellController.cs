using RedBadgeFinal.Models;
using RedBadgeFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinal.Controllers
{
    public class SpellController : Controller
    {
        // GET: Spell
        public ActionResult Index()
        {
            var service = new SpellService();
            var model = service.GetSpells();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpellCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new SpellService();
            service.CreateSpell(model);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var service = new SpellService();
            var model = service.GetSpellById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new SpellService();
            var detail = service.GetSpellById(id);

            var model =
                new SpellEdit
                {
                    SpellId = detail.SpellId,
                    SpellName = detail.SpellName,
                    SpellDescription = detail.SpellDescription
                };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SpellEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.SpellId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new SpellService();

            if (service.UpdateSpell(model))
            {
                TempData["SaveResult"] = "The Spell was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The spell could not be updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new SpellService();
            var model = service.GetSpellById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new SpellService();

            service.DeleteSpell(id);

            TempData["SaveResult"] = "The Spell was deleted";

            return RedirectToAction("Index");
        }
    }
}