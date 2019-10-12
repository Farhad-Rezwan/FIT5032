using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmailWithAttachment.Models;
using EmailWithAttachment.Utilities;

namespace EmailWithAttachment.Controllers
{
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendEmailWithAttachment()
        {
            return View(new EmailWithAttachmentViewModel());
        }

        [HttpPost]
        public ActionResult SendEmailWithAttachment(EmailWithAttachmentViewModel model)
        {
            try
            {
                string path = Server.MapPath("~/Uploads");
                string fileName = Path.GetFileName(model.Attachment.FileName);
                string fullPath = Path.Combine(path, fileName);
                model.Attachment.SaveAs(fullPath);

                EmailWithAttachmentSender emailSender = new EmailWithAttachmentSender();
                emailSender.Sender(model, fullPath);

                ViewBag.Result = "Success: E-mail sent";

                ModelState.Clear();

                return View(new EmailWithAttachmentViewModel());
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}