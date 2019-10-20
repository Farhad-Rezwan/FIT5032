using FoodBankMelbourne_frez0003.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FoodBankMelbourne_frez0003.Services
{
    public class EmailWithAttachmentSender
    {
        private const String api_k = "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";

        public void Sender(EmailWithAttachmmentViewModel model, string pathFull)
        {
            string attachmentName = Path.GetFileName(model.Attachment.FileName);
            var byts = System.IO.File.ReadAllBytes(pathFull);
            var file = Convert.ToBase64String(byts);
            var client = new SendGridClient(api_k);

            var from = new EmailAddress("noreply@localhost.com", "FoodBank Melbourne B-Email With Attachment");

            var to = new List<EmailAddress>
            {
                new EmailAddress (model.EmailTo, "User A")
            };


            var message = new SendGridMessage();
            message.SetFrom("noreply@localhost.com", "Lab Assessment 3 Email with Attachment");
            message.PlainTextContent = model.EmailContent;
            message.Subject = model.Sub;
            message.AddAttachment(model.Attachment.FileName, file);
            message.AddTos(to);
            var respond = client.SendEmailAsync(message);


        }
    }
}