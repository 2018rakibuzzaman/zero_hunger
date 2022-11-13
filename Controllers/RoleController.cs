using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zero_hunger.Models.DB;
using zero_hunger.Models.Repository;

namespace zero_hunger.Controllers
{
    public class RoleController : Controller
    {
        private Irole irole;
        public RoleController()
        {
            this.irole = new RepositoryRoleClass(new zero_hungerEntities());
        }

        // GET: Role
        public ActionResult Index()
        {
            var rolelist = irole.GetRole().ToList();
            return View(rolelist);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            var role = irole.GetRoleById(id);
            return View(role);
        }

        // GET: Role/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new role());
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(role role,FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                role.created_at = DateTime.Now;
                role.updated_at = DateTime.Now;
                irole.InsertRoleRecord(role);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var role = irole.GetRoleById(id);
            return View(role);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(role role, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                role.updated_at = DateTime.Now;
                irole.UpdateRoleRecord(role);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var role = irole.GetRoleById(id);
            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                irole.DeleteRoleRecord(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
