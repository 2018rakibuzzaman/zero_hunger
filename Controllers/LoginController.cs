using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zero_hunger.Models;
using zero_hunger.Models.DB;
using zero_hunger.Models.Repository;

namespace zero_hunger.Controllers
{
    public class LoginController : Controller
    {
        private Iuser iuser;
        public LoginController()
        {
            this.iuser = new RepositoryUserClass(new zero_hungerEntities());
        }
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            if(Session!=null && Session["User"] != null)
            {
                return Redirect("/Dashboard");
            }
            else
            {
                return View(new Login());
            }            
        }

        // POST: Login
        [HttpPost]
        public ActionResult Index(Login data)
        {
            try
            {
                user user = new user();
                user = iuser.GetUserByEmail(data.Email);
                if(user == null)
                {
                    if (data.Email != null)
                    {
                        TempData["Email"] = "Email dos not exist";
                    }                    
                    return View();
                }
                else
                {
                    if (data.Password == user.password)
                    {
                        Session["User"] = user;
                        return Redirect("/Dashboard");
                    }
                    else
                    {
                        if (data.Password != null)
                        {
                            TempData["Password"] = "Wrong password";
                        }
                        return View();
                    }
                }                
            }
            catch
            {
                return View();
            }            
        }
    }
}