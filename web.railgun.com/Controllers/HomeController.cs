using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            
            var projects = id!=0 ? db.Projects.Where(x => x.CategoryId == id).Where(x => x.InProgress != true).ToList().OrderByDescending(x => x.DateInitiated) : db.Projects.Where(x => x.InProgress != true).ToList().OrderByDescending(x => x.DateInitiated);             
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



    }
}