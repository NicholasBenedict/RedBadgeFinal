using RedBadgeFinal.Models.CharacterModels;
using RedBadgeFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinal.Controllers
{
    public class CharacterSpellsController : Controller
    {
        // GET: CharacterSpells
        public ActionResult Index()
        {
            var service = new AddSpellToCharacter();
            var model = service.GetCharacterSpells();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterSpellCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new AddSpellToCharacter();
            service.CreateCharacterSpell(model);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var service = new AddSpellToCharacter();
            var model = service.GetCharacterSpellById(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new AddSpellToCharacter();
            var model = service.GetCharacterSpellById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new AddSpellToCharacter();

            service.DeleteCharacterSpell(id);

            TempData["SaveResult"] = "Your Characters Spell was removed";

            return RedirectToAction("Index");
        }
    }
}