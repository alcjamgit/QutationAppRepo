using QuotationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuotationApp.Web.Controllers
{
    public class KnockoutGridController : Controller
    {
        // GET: KnockoutGrid
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index2(IEnumerable<QuotationIndexVm> quos)
        {
            return View();
        }
    }
}