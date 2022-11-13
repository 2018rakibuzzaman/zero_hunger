using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zero_hunger.Models;
using zero_hunger.Models.DB;
using zero_hunger.Models.Repository;
using zero_hunger.Models.Annotation;

namespace zero_hunger.Controllers
{
    [Logdin]
    public class UserController : Controller
    {
        private Iuser iuser;
        private Irole irole;
        public UserController()
        {            
            this.iuser = new RepositoryUserClass(new zero_hungerEntities());
            this.irole = new RepositoryRoleClass(new zero_hungerEntities());
        }
        // GET: User        
        public ActionResult Index()
        {            
            var userlist = iuser.GetUsers().ToList();
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = iuser.GetUserById(id);
            return View(user);
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            var getrole = irole.GetRole();
            var allrole = "";
            foreach (var role in getrole)
            {
                if (allrole == "")
                {
                    allrole = role.role_name;
                }
                else
                {
                    allrole=allrole+"," + role.role_name;
                }                
            }
            ViewBag.allrole = allrole.Split(',');
           return View(new user());
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,user userisert)
        {
            try
            {
                // TODO: Add insert logic here
                //var adduser = new user();
                iuser.InsertUserRecord(userisert);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {

            var user = iuser.GetUserById(id);
            var getrole = irole.GetRole();
            var allrole = "";
            foreach (var role in getrole)
            {
                if (allrole == "")
                {
                    allrole = role.role_name;
                }
                else
                {
                    allrole = allrole + "," + role.role_name;
                }
            }
            ViewBag.allrole = allrole.Split(',');
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(user userupdate, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                iuser.UpdateUserRecord(userupdate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var userdel = iuser.GetUserById(id);
            return View(userdel);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                iuser.DeleteUserRecord(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
