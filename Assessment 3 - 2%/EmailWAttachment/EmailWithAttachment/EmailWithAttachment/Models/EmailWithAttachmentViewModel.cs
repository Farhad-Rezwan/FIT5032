using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmailWithAttachment.Models
{
    public class EmailWithAttachmentViewModel
    {
        [Display(Name = "E-mail address")]
        [Required(ErrorMessage = "Please enter an e-mail address")]
        [EmailAddress(ErrorMessage = "Enter valid e-mail address")]

        public string EmailTo { get; set; }

        [Required(ErrorMessage = "Please provide a subject")]
        public string Sub { get; set; }

        [Required(ErrorMessage = "Please enter content")]

        public string EmailContent { get; set; } 

        public HttpPostedFileBase Attachment { get; set; }

    }
}