using QuotationApp.Core.Common;
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
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ICurrentUserService _curUserService;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ProductController()
        {
            //poor man's IOC for now
            _db = new ApplicationDbContext(System.Web.HttpContext.Current.User.Identity.Name);
            _curUserService = new CurrentUserService();
        }

        // GET: Product
        public ActionResult Index()
        {
            IQueryable<ProductIndexVm> model = from p in _db.Products
                                                 orderby p.Id
                                                 select new ProductIndexVm
                                                 {
                                                     Id = p.Id,
                                                     Description = p.Description,
                                                     UnitOfMeasureInt = (Enumerations.UnitOfMeasure)p.UnitOfMeasure,
                                                     Discontinued = p.Discontinued
                                                 };
            ViewBag.PageSize = 10;

            return View(model);
        }
        
        public ActionResult Create()
        {
            var model = new ProductCreateVm();
            model.PartNumber = Guid.NewGuid().ToString("N");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProductCreateVm productVm)
        {
            //we'll move this mess to a service

            if (ModelState.IsValid)
            {
                var model = new Product()
                {
                    Id = productVm.PartNumber,
                    UnitOfMeasure = (int)productVm.UnitOfMeasure,
                    Description = productVm.Description,
                    Discontinued = false
                };
                _db.Products.Add(model);
                _db.SaveChanges();
                return Redirect("Index");
            }

            //invalid model lets return the View Model
 
            return View(productVm);
        }
    }
}