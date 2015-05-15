using QuotationApp.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuotationApp.Web.Models
{
    public class ProductIndexVm
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public Enumerations.UnitOfMeasure UnitOfMeasureInt { get; set; }
        public string UnitOfMeasure {
            get { return UnitOfMeasureInt.GetDescription(); }
        }
        public bool Discontinued { get; set; }
    }

    public class ProductCreateVm
    {
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public Enumerations.UnitOfMeasure UnitOfMeasure { get; set; }

    }
}