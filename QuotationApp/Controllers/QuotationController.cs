﻿using QuotationApp.Core.Common;
using QuotationApp.Core.Entities;
using QuotationApp.Core.Specifications;
using QuotationApp.Infrastructure.BusinessLayer;
using QuotationApp.Infrastructure.DataLayer;
using QuotationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuotationApp.Web.Controllers
{
    [Authorize]
    public class QuotationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUserService _curUserService;
        public QuotationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public QuotationController()
        {
            //poor man's IOC for now
            _db = new ApplicationDbContext(System.Web.HttpContext.Current.User.Identity.Name);
            _curUserService = new CurrentUserService();
        }

        public ActionResult Index()
        {
            IQueryable<QuotationIndexVm> model = from q in _db.Quotations
                                                 join c in _db.Customers on
                                                 q.Customer_Id equals c.Id
                                                 orderby q.Id
                                                 select new QuotationIndexVm
                                                 {
                                                    Id = q.Id,
                                                    CustomerName = c.Name,
                                                    CustomerReference = q.CustomerReference,
                                                    Status = q.Status,
                                                    CreateDate = q.CreateDate,
                                                    CreatedBy = q.CreatedBy,
                                                 };
            ViewBag.PageSize = 2;
            
            return View(model);
        }
        public ActionResult IndexJson()
        {
            IQueryable<QuotationIndexVm> model = from q in _db.Quotations
                                                 join c in _db.Customers on
                                                 q.Customer_Id equals c.Id
                                                 orderby q.Id
                                                 select new QuotationIndexVm
                                                 {
                                                     Id = q.Id,
                                                     CustomerName = c.Name,
                                                     CustomerReference = q.CustomerReference,
                                                     Status = q.Status,
                                                     CreateDate = q.CreateDate,
                                                     CreatedBy = q.CreatedBy,
                                                 };
            

            return View(model);
        }

        public ActionResult Edit(int id)
        {


            return View();
        }

        public ActionResult Create() 
        {

            var model = new QuotationCreateVm();
            model.CustomerSelectList = new SelectList(_db.Customers.AsQueryable(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(QuotationCreateVm quoteVm)
        {
            //we'll move this mess to a service

            if (ModelState.IsValid)
            {
                var model = new Quotation()
                {
                    Customer_Id = quoteVm.Customer_Id,
                    CustomerReference = quoteVm.CustomerReference,
                    Comments = quoteVm.Comments,
                    Status = Enumerations.QuotationStatus.Created.GetDescription()
                };
                _db.Quotations.Add(model);
                _db.SaveChanges();
                return Redirect("Index");
            }

            //invalid model lets return the View Model
            quoteVm.CustomerSelectList = new SelectList(_db.Customers.AsQueryable(), "Id", "Name");
            return View(quoteVm);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}