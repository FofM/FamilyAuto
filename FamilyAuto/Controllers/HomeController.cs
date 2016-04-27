using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyAuto.Models;
using System.Web.Helpers;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace FamilyAuto.Controllers
{
    public class HomeController : Controller
    {
        private FamilyAutoEntities db = new FamilyAutoEntities();

        public ActionResult Index()
        {
            var topNews = (from n in db.Articles
                           where n.ArticleType == 0
                           orderby n.DateUploaded descending
                           select n).Take(3);
            //topNews.Take(3).ToList();
            return View("Index", topNews);
        }

        public ActionResult News()
        {
            var topNews = from n in db.Articles
                          where n.ArticleType == 0
                          orderby n.DateUploaded descending
                          select n;
            return View("News", topNews);
        }

        public ActionResult Services()
        {
            var topNews = from n in db.Articles
                          where (int)n.ArticleType == 1
                          orderby n.DateUploaded descending
                          select n;
            return View("Services", topNews);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Family Auto contact page.";

            return View("Contact");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailForm model)
        {
            if (ModelState.IsValid)
            {
                string subject = "General Inquiry";
                //if (!String.IsNullOrEmpty(ViewBag.vID))
                //{
                //    subject = "Inquiry for Vehicle ID " + ViewBag.vID;
                //}
                if (model.vID != null)
                {
                    subject = "Inquiry for Vehicle ID: " + model.vID;
                }
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("infofamilyauto@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("infofamilyauto@gmail.com");  // replace with valid value
                message.Subject = subject;
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                //using (var smtp = new SmtpClient())
                //{
                //    var credential = new NetworkCredential
                //    {
                //        UserName = "infofamilyauto@gmail.com",  // replace with valid value
                //        Password = "throwAwayAccount"  // replace with valid value
                //    };
                //    smtp.Credentials = credential;
                //    smtp.Host = "smtp.gmail.com";
                //    smtp.Port = 587;
                //    smtp.EnableSsl = true;
                //    await smtp.SendMailAsync(message);
                    await SMTPsend(message);

                    return RedirectToAction("Sent");
                }
            //}
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }

        public async Task SMTPsend(MailMessage message)
        {
            var smtp = new SmtpClient();

            var credential = new NetworkCredential
            {
                UserName = "infofamilyauto@gmail.com",  // replace with valid value
                Password = "throwAwayAccount"  // replace with valid value
            };
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = credential;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 456; // 587;
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(message);
        }
    }
}