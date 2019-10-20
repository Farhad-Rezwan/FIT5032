using FoodBankMelbourne_frez0003.Models;
using FoodBankMelbourne_frez0003.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodBankMelbourne_frez0003.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendEmail()
        {
            return View(new EmailSenderViewModel());
        }

        [HttpPost]
        public ActionResult SendEmail(EmailSenderViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    EmailSendingOption eso = new EmailSendingOption();
                    eso.Send(toEmail, subject, contents);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new EmailSenderViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }
    }
}