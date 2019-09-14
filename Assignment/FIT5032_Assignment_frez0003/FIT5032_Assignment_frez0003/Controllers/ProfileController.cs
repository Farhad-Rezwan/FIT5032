using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment_frez0003.Models;
using System.Web.Security;

namespace FIT5032_Assignment_frez0003.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Reg_Customer member)
        {
            using (var context = new FIT5032_Assignment_DatabaseFirstEntities())
            {
                bool isValid = context.Reg_Customer.Any(x => x.C_Email == member.C_Email && x.C_Password == member.C_Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(member.C_Email, false);
                    return RedirectToAction("Index", "Reg_Customer");
                }

                ModelState.AddModelError("", "Invalid User email and Password");
                return View();
            }
            
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Reg_Customer cust)
        {
            using (var context = new FIT5032_Assignment_DatabaseFirstEntities())
            {
                context.Reg_Customer.Add(cust);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}