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
using System.Data.Entity;
using System.Security.Principal;

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
            _curUserService = new CurrentUserService(System.Web.HttpContext.Current.User.Identity);
            
        }


        public ActionResult Index()
        {
            
            IQueryable<QuotationIndexVm2> model = from q in _db.Quotations
                                                 orderby q.Id
                                                 select new QuotationIndexVm2
                                                 {
                                                    Id = q.Id,
                                                    Product_Id = q.Product_Id,
                                                    Product_Description = q.Product_Description,
                                                    MinOrderQty = q.MinOrderQty,
                                                    QuotedPrice = q.QuotedPrice,
                                                    CustomerName = q.Customer.Name,
                                                    CustomerReference = q.CustomerReference,
                                                    
                                                    Status = q.Status,
                                                    CreateDate = DbFunctions.TruncateTime(q.CreateDate),
                                                    CreatedBy = q.CreatedBy,
                                                 };
            ViewBag.PageSize = 10;
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = (from q in _db.Quotations
                         where q.Id == id
                         select new QuotationDeleteVm()
                         {
                             Id = q.Id,
                             Product_Id = q.Product_Id,
                             Product_Description = q.Product_Description,
                             QuotedPrice = q.QuotedPrice,
                             CreatedBy = q.CreatedBy,
                             CreatedDate = q.CreateDate,
                         }).FirstOrDefault();

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = _db.Quotations.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            _db.Quotations.Remove(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = (from q in _db.Quotations
                        where q.Id == id
                        select new QuotationEditVm()
                        {
                            Id = q.Id,
                            Product_Id = q.Product_Id,
                            Product_Description = q.Product_Description,
                            QuotedPrice = q.QuotedPrice,
                            MinOrderQty = q.MinOrderQty,
                            UnitOfMeasure = (QuotationApp.Core.Common.Enumerations.UnitOfMeasure)q.UnitOfMeasure,
                            Customer_Id = q.Customer_Id,
                            CustomerReference = q.CustomerReference,
                            Comments = q.Comments,
                            AttachmentFileName = q.AttachmentFileName,
                            CreatedBy = q.CreatedBy,
                            CreatedDate = q.CreateDate,
                        }).FirstOrDefault();

            model.CustomerSelectList = new SelectList(_db.Customers.AsQueryable(), "Id", "Name");     
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(QuotationEditVm quoteVm)
        {
            //we'll move this mess to a service
            //AmazonS3FileService fileService = new AmazonS3FileService(_curUserService);
            if (ModelState.IsValid)
            {
                var model = new Quotation()
                {
                    Id = quoteVm.Id,
                    Product_Id = quoteVm.Product_Id,
                    Product_Description = quoteVm.Product_Description,
                    QuotedPrice = quoteVm.QuotedPrice,
                    Customer_Id = quoteVm.Customer_Id,
                    MinOrderQty = quoteVm.MinOrderQty,
                    UnitOfMeasure = (int)quoteVm.UnitOfMeasure,
                    CustomerReference = quoteVm.CustomerReference,
                    Comments = quoteVm.Comments,
                    Status = quoteVm.Status.GetDescription(),
                    AttachmentFileName = quoteVm.AttachmentFileName,
                    CreateDate = quoteVm.CreatedDate,
                    CreatedBy = quoteVm.CreatedBy
                };
                //model.AttachmentFileName = fileService.UploadFile(quoteVm.PostedFile.InputStream, null,
                //    quoteVm.PostedFile.FileName, quoteVm.PostedFile.ContentLength);

                _db.Entry(model).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            //invalid model lets return the View Model
            quoteVm.ProductList = new SelectList(_db.Products.AsQueryable(), "Id", "Description");
            quoteVm.CustomerSelectList = new SelectList(_db.Customers.AsQueryable(), "Id", "Name");
            return View(quoteVm);
        }
        public ActionResult Create() 
        {

            var model = new QuotationCreateVm();
            model.CustomerSelectList = new SelectList(_db.Customers.AsQueryable(), "Id", "Name");
            //model.ProductList = new SelectList(_db.Products.AsQueryable(), "Id", "Description");
            model.UnitOfMeasure = Enumerations.UnitOfMeasure.Pieces;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(QuotationCreateVm quoteVm)
        {
            //we'll move this mess to a service
            AmazonS3FileService fileService = new AmazonS3FileService(_curUserService);
            if (ModelState.IsValid)
            {
                var model = new Quotation()
                {
                    Product_Id = quoteVm.Product_Id,
                    Product_Description = quoteVm.Product_Description,
                    QuotedPrice = quoteVm.QuotedPrice,
                    MinOrderQty = quoteVm.MinOrderQty,
                    UnitOfMeasure = (int)quoteVm.UnitOfMeasure,
                    Customer_Id = quoteVm.Customer_Id,
                    CustomerReference = quoteVm.CustomerReference,
                    Comments = quoteVm.Comments,
                    Status = Enumerations.QuotationStatus.Created.GetDescription()
                };

                if (!string.IsNullOrEmpty(model.AttachmentFileName))
                {
                    model.AttachmentFileName = fileService.UploadFile(quoteVm.PostedFile.InputStream, null,
                        quoteVm.PostedFile.FileName, quoteVm.PostedFile.ContentLength);
                }


                _db.Quotations.Add(model);
                _db.SaveChanges();
                return Redirect("Index");
            }

            //invalid model lets return the View Model
            quoteVm.ProductList = new SelectList(_db.Products.AsQueryable(), "Id", "Description");
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