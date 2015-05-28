using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuotationApp.Infrastructure;
using QuotationApp.Infrastructure.DataLayer;
using QuotationApp.Web.Models;
using QuotationApp.Core.Entities;

namespace QuotationApp.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private readonly ApplicationDbContext _db;
        public CustomerController()
        {
            _db = new ApplicationDbContext(System.Web.HttpContext.Current.User.Identity.Name);
        }

        public ActionResult Index()
        {
            var customers = from c in _db.Customers.AsQueryable()
                            select new CustomerIndexVm
                            {
                                Name = c.Name,
                                Email = c.Email
                            };
            return View(customers);
        }

        public ActionResult Create() 
        {
            var customer = new CustomerCreateVm();
            return View(customer);
        }

        [HttpPost]
        public ActionResult Create(CustomerCreateVm model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer() { Name = model.Name, Email = model.Email};
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return Redirect("Index");
            }
            
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}