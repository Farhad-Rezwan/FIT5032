using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBankMelbourne_frez0003.Services
{
    public class EmailSendingOption
    {
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }
    }
}