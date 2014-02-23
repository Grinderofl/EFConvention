﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using EFConvention;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        private DbContext _context;
        public HomeController(DbContext context)
        {
            _context = context;
            /*_autoContextFactory = new AutoContextFactory();
            //_autoContextFactory.Configuration.AutoMigrateToLatestVersionEnabled = true;
            _autoContextFactory.Configuration.AutoGeneratedMigrationsEnabled = true;
            _autoContextFactory.Configuration.AutoMigrateGeneratedMigrationsEnabled = true;
            _autoContextFactory.Configuration.MigrationsDirectory =
                @"C:\Users\Nero\Documents\visual studio 2013\Projects\EFAutomation\WebTest\Migrations";
            _autoContextFactory.Configuration.MigrationsAssemblyAsFile = true;
            _autoContextFactory.Configuration.MigrationsAssemblyFileLocation =
                @"C:\Users\Nero\Documents\visual studio 2013\Projects\EFAutomation\WebTest\Migrations\Migrations.dll";
            _autoContextFactory.AddEntitiesBasedOn<BaseEntity>().AddAssemblyContaining<BaseEntity>();
            _autoContextFactory.Seeding += (sender, context) =>
            {
                context.Context.Set<Item>().AddOrUpdate(a => a.Data, new Item() {Data = "hello" + 3, Created = DateTime.Now});
            };*/
            //_autoContextFactory = new AutoContextFactory();
            //_autoContextFactory.AddEntitiesBasedOn<BaseEntity>().AddAssemblyContaining<BaseEntity>();
            /*_autoContextFactory.Seeding += (sender, context) => context.Context.Set<Item>()
                .AddOrUpdate(a => a.Data, new Item() {Data = "Hello world", Created = DateTime.Now});*/
        }

        public ActionResult Index()
        {
            /*var context = _autoContextFactory.Context();
            context.SavingChanges += (sender, args) =>
            {
                var saveTime = DateTime.Now;
                foreach (var entry in args.Context.ChangeTracker.Entries().Where(x => x.State == EntityState.Added))
                {
                    var type = entry.Entity.GetType();

                    if (type.GetProperty("Created") == null) continue;

                    /*if (entry.Property("Created") != null)
                        entry.Property("Created").CurrentValue = saveTime;
                }
            };*/
            _context.Set<Item>().Add(new Item());
            _context.SaveChanges();
            
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