using RedBadgeFinal.Models.ItemModels;
using RedBadgeFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadgeFinal.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            var service = new ItemService();
            var model = service.GetItems();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new ItemService();
            service.CreateItem(model);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var service = new ItemService();
            var model = service.GetItemById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new ItemService();
            var detail = service.GetItemById(id);

            var model =
                new ItemEdit
                {
                    ItemId = detail.ItemId,
                    ItemName = detail.ItemName,
                    ItemDescription = detail.ItemDescription,
                    ItemValue = detail.ItemValue,
                    ItemWeight = detail.ItemWeight,
                    Item = detail.Item
                };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.ItemId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new ItemService();

            if (service.UpdateItem(model))
            {
                TempData["SaveResult"] = "The item was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The item could not be updated");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new ItemService();
            var model = service.GetItemById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new ItemService();

            service.DeleteItem(id);

            TempData["SaveResult"] = "The Item was deleted";

            return RedirectToAction("Index");
        }
    }
}