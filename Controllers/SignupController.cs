using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using zero_hunger.Models;
using zero_hunger.Models.DB;
using zero_hunger.Models.Repository;

namespace WebApplication1.Controllers
{
    public class SignupController : Controller
    {
        private Iuser iuser;
        public SignupController()
        {
            this.iuser = new RepositoryUserClass(new zero_hungerEntities());
        }
        [HttpGet]
        public ActionResult Index()
        {
            if (Session != null && Session["User"] != null)
            {
                return Redirect("Dashboard");
            }
            else
            {
                return View(new Signup());
            }
            
        }

        [HttpPost]
        public ActionResult Index(Signup signup)
        {
            try
            {
                var check = iuser.GetUserByEmail(signup.Email);
                //if error send massage
                if (check != null)
                {
                    TempData["Email"]="Email Email already exist";
                    return View(signup);
                }
                else
                {
                    DateTime date_of_birth = DateTime.Parse(signup.DOB.ToString());
                    user newuser = new user();
                    newuser.role = "Resturent";
                    newuser.resturent_name = signup.ResturentName;
                    newuser.name = signup.Name;
                    newuser.email = signup.Email;
                    newuser.phone = signup.Phone;
                    newuser.dob = date_of_birth.Date;
                    newuser.address = signup.Address;
                    newuser.gender = signup.Gender;
                    newuser.password = signup.Password;
                    newuser.created_at = DateTime.Now;
                    iuser.InsertUserRecord(newuser);
                    Session["User"] = newuser;
                    return Redirect("Dashboard");
                }                
            }
            catch
            {
                return View(signup);
            }
            
        }

        private DateTime Date(string dOB)
        {
            throw new NotImplementedException();
        }
    }
}
