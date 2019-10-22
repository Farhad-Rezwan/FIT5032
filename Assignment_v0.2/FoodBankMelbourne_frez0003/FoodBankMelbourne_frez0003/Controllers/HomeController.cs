using FoodBankMelbourne_frez0003.Models;
using FoodBankMelbourne_frez0003.Services;
using System;
using System.Collections.Generic;
using System.IO;
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

        [Authorize(Roles = "Administrator")]
        public ActionResult SendEmail()
        {
            return View(new EmailSenderViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
        public ActionResult SendEmailWithAttachment()
        {
            return View(new EmailWithAttachmmentViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult SendEmailWithAttachment(EmailWithAttachmmentViewModel model)
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

                return View(new EmailWithAttachmmentViewModel());
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}