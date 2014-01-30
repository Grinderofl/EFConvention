using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using EFAutomation;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        private IAutoContextFactory _autoContextFactory;
        public HomeController()
        {
            _autoContextFactory = new AutoContextFactory();
            _autoContextFactory.Configuration.AutomaticMigrationsEnabled = true;
        }

        public ActionResult Index()
        {
            _autoContextFactory.AddEntity<Item>();
            var context = _autoContextFactory.Create();
            context.ModelCreating += (sender, args) => { };
            context.Set<Item>().Add(new Item());
            context.SaveChanges();
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
    }
}