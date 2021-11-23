using RedBadgeFinal.Models;
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
            var service = new AddSpellToCharacter();
            ViewBag.Spells = service.GetSpells();
            ViewBag.Characters = service.GetCharacters();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterSpellCreate model, int characterId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            PopulateSpells();
            var service = new AddSpellToCharacter();
            service.CreateCharacterSpell(model, characterId);
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

        private void PopulateSpells()
        {
            ViewBag.SpellList = new SelectList(new SpellService().GetSpells());
        }

    }
}