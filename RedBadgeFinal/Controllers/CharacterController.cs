using RedBadgeFinal.Models;
using RedBadgeFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinal.Controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        // GET: Character
        public ActionResult Index()
        {
            var service = new CharacterService();
            var model = service.GetCharacters();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new CharacterService();
            service.CreateCharacter(model);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var service = new CharacterService();
            var model = service.GetCharacterById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new CharacterService();
            var detail = service.GetCharacterById(id);

            var model =
                new CharacterEdit
                {
                    CharacterId = detail.CharaterId,
                    CharacterName = detail.CharacterName,
                    CharacterRace = detail.CharacterRace,
                    CharacterBackground = detail.CharacterBackground,
                    CharacterClass = detail.CharacterClass,
                    Level = detail.Level,
                    HitPoints = detail.HitPoints,
                    Strength = detail.Str,
                    Dexterity = detail.Dex, 
                    Constitution = detail.Con,
                    Intelligence = detail.Int,
                    Wisdom = detail.Wis,
                    Charisma = detail.Cha
                };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CharacterEdit model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.CharacterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new CharacterService();

            if(service.UpdateCharacter(model))
            {
                TempData["SaveResult"] = "Your Character was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your character could not be updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new CharacterService();
            var model = service.GetCharacterById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new CharacterService();

            service.DeleteCharacter(id);

            TempData["SaveResult"] = "Your character was deleted";

            return RedirectToAction("Index");
        }
    }
}