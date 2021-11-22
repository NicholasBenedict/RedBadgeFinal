using RedBadgeFinal.Models.InventoryModels;
using RedBadgeFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinal.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            var service = new InventoryService();
            var model = service.GetCharacterInventory();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventoryCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new InventoryService();
            service.CreateCharacterInventory(model);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var service = new InventoryService();
            var model = service.GetCharacterInventoryById(id);

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new InventoryService();
            var model = service.GetCharacterInventoryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new InventoryService();

            service.DeleteItemFromInventory(id);

            TempData["SaveResult"] = "Your Characters item was removed";

            return RedirectToAction("Index");
        }
    }
}