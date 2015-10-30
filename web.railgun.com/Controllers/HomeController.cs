using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Aspose.Email.Mail;
using web.railgun.com.Models;

namespace web.railgun.com.Controllers
{
    public class HomeController : Controller
    {

        railgunContext db = new railgunContext();


        [ChildActionOnly]
        public ActionResult RenderMenu(int CategoryId)
        {
            var model = db.Projects.Where(x => x.CategoryId == CategoryId).ToList();
            return PartialView(model);
        }

        public ActionResult Contact()
        {

            return View();
        }

        public async Task<string> PostContactForm()
        {



            return "Okay thanks";

            return "Sorry that failed";

        }


        public ActionResult Index()
        {
            var model = db.Categories.ToList();
            ViewBag.Pricings = db.PricingTiers.ToList();
            ViewBag.Features = db.Features.ToList();
            ViewBag.Services = db.Values.ToList();
            ViewBag.Testimonials = db.Testimonials.ToList();

            return View(model);
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }


        public ActionResult Project(int ProjectId = 4)
        {
            ViewBag.Projects = db.Projects.Where(x => x.InProgress != true).ToList().OrderByDescending(x => x.DateInitiated);

            var model = db.Projects.Find(ProjectId);
            return View(model);
        }




        [HttpGet]
        public ActionResult Projects(int id = 0)
        {

            var projects = id != 0 ? db.Projects.Where(x => x.CategoryId == id).Where(x => x.InProgress != true).ToList().OrderByDescending(x => x.DateInitiated) : db.Projects.Where(x => x.InProgress != true).ToList().OrderByDescending(x => x.DateInitiated);
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.LastId = id;

            return View(projects);
        }

        public ActionResult ProjectsInProgress()
        {
            var projects = db.Projects.Where(x => x.InProgress == true).ToList();
            ViewBag.Categories = db.Categories.ToList();

            return View("Projects", projects);
        }




        public ActionResult WhatWeDo()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        public ActionResult LetTalkBusiness()
        {
            return View();
        }

        public ActionResult LetTalkTech()
        {
            return View();
        }

        public ActionResult RailFare()
        {
            return View();
        }

        public ActionResult Team()
        {
            var team = db.TeamMembers.ToList();
            return View(team);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmailUs([Bind(Include = "Id,Name,Email,Request,Phone")] ContactRequest contactRequest)
        {
            contactRequest.CreatedDate = DateTime.Now;
            
            var result = "We have receieved your request and will be in touch! Thanks for choosing Railgun.it!";
            try
            {
                MailMessage theAsposeMessage;
                SmtpClient theSMTPClient = new SmtpClient();
                //set some defaults so i always get copied in

                //create the message
                theAsposeMessage = new MailMessage();
                theSMTPClient.Host = "smtp.gmail.com";
                theSMTPClient.Username = "railgunit.maintenance@gmail.com";
                theSMTPClient.Password = "Diagonal23";
                theSMTPClient.Port = 587;
                theSMTPClient.EnableSsl = true;
                theSMTPClient.SecurityMode = SmtpSslSecurityMode.Explicit;

                //ADDRESSING
                theAsposeMessage.From = theSMTPClient.Username;
                theAsposeMessage.To = @"info@railgunit.com";
                theAsposeMessage.Subject = "You got RailMail, fucko! A new client has something to tell you:";
                var bodyMessage = "<h1>From:" + contactRequest.Email + " " + contactRequest.Name + " " + contactRequest.Phone + "</h1><br/>" + "<p>" + contactRequest.Request + "</p>";
                theAsposeMessage.HtmlBody = bodyMessage;

                theSMTPClient.Send(theAsposeMessage);

                db.ContactRequests.Add(contactRequest);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                result = "Sorry that... didn't work. Try again later, or send us an email at info@railgunit.com";

            }




            return Json(new { result = result });
        }



    }
}