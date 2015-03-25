using SnoZen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SnoZen.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            MailMessage mail = new MailMessage();
    
            // Insert your Smtp settings
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Credentials = new System.Net.NetworkCredential("youremail", "password");
            smtpClient.Port = 465;
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 100;

            mail.From = new MailAddress(contact.Email);
            mail.To.Add("youremail");
            mail.Subject = "Inquiry From: " + contact.Name;
            mail.Body = contact.Message;

            // Uncomment when Smtp has been implemented
            //smtpClient.Send(mail);

            return View();
        }
    }
}