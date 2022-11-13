using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zero_hunger.Models.Annotation;
using zero_hunger.Models.DB;
using zero_hunger.Models.Repository;

namespace zero_hunger.Controllers
{
    [Logdin]
    public class FoodController : Controller
    {
        private Ifood ifood;
        public FoodController()
        {
            this.ifood = new RepositoryFoodClass(new zero_hungerEntities());
        }

        // GET: Food
        public ActionResult Index()
        {
            var foodlist = ifood.GetFood().ToList();
            return View(foodlist);
        }

        // GET: Food/Details/5
        public ActionResult Details(int id)
        {
            var food = ifood.GetFoodById(id);
            return View(food);
        }

        // GET: Food/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new food());
        }

        // POST: Food/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,food food)
        {
            try
            {
                // TODO: Add insert logic here
                food.created_at = DateTime.Now;
                food.updated_at = DateTime.Now;
                ifood.InsertFoodRecord(food);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Food/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var food = ifood.GetFoodById(id);
            return View(food);
        }

        // POST: Food/Edit/5
        [HttpPost]
        public ActionResult Edit(food food, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                food.updated_at = DateTime.Now;
                ifood.UpdateFoodRecord(food);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Food/Delete/5
        public ActionResult Delete(int id)
        {
            var food = ifood.GetFoodById(id);
            return View(food);
        }

        // POST: Food/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ifood.DeleteFoodRecord(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
