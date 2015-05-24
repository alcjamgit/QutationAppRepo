using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuotationApp.Core.Common;

namespace QuotationApp.Web.Models
{
    public class QuotationIndexVm
    {
        [DisplayName("Quote ID")]
        public int Id { get; set; }
        [DisplayName("Customer")]
        public string CustomerName { get; set; }
        [DisplayName("Customer Reference")]
        [StringLength(128)]
        public string CustomerReference { get; set; }
        [StringLength(64)]
        public string Status { get; set; }



        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
        [DisplayName("Create Date")]
        public DateTime CreateDate { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }

    }

    public class QuotationIndexVm2
    {
        [DisplayName("Quote ID")]
        public int Id { get; set; }

        [DisplayName("Part Number"), Required]
        public string Product_Id { get; set; }
        [DisplayName("Part Description"), Required]
        public string Product_Description { get; set; }

        [DisplayName("Min Order"), Required]
        public int MinOrderQty { get; set; }
        [DisplayName("Unit of Measure"), Required]
        public string UnitOfMeasure { get; set; }
        public decimal QuotedPrice { get; set; }

        [DisplayName("Customer")]
        public string CustomerName { get; set; }
        [DisplayName("Customer Reference")]
        [StringLength(128)]
        public string CustomerReference { get; set; }
        [StringLength(64)]
        public string Status { get; set; }
        [StringLength(128)]
        public string AttachmentFileName { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
        [DisplayName("Create Date")]
        public DateTime? CreateDate { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }

    }


    public class QuotationCreateVm
    {
        [DisplayName("Part Number"), Required] 
        public string Product_Id { get; set; }
        [DisplayName("Part Description")]
        public string Product_Description { get; set; }
        [DisplayName("Min Order"), Required]
        public int MinOrderQty { get; set; }
        [DisplayName("Unit of Measure"), Required]
        public Enumerations.UnitOfMeasure UnitOfMeasure { get; set; }
        [DisplayName("Quoted Price"), Required]
        public decimal QuotedPrice { get; set; }

        [DisplayName("Customer"), Required]
        public int Customer_Id { get; set; }
        [DisplayName("Customer Reference")]
        [StringLength(128)]
        public string CustomerReference { get; set; }
        public HttpPostedFileBase PostedFile { get; set; }

        [StringLength(128)]
        public string Comments { get; set; }

        public IEnumerable<SelectListItem> CustomerSelectList { get; set; }
        public IEnumerable<SelectListItem> ProductList { get; set; }  

    }

    public class QuotationEditVm
    {
        [HiddenInput]
        public int Id { get; set; }
        [DisplayName("Part Number"), Required]
        public string Product_Id { get; set; }
        [DisplayName("Part Description")]
        public string Product_Description { get; set; }
        [DisplayName("Min Order"), Required]
        public int MinOrderQty { get; set; }
        [DisplayName("Unit of Measure"), Required]
        public Enumerations.UnitOfMeasure UnitOfMeasure { get; set; }
        [DisplayName("Quoted Price"), Required]
        public decimal QuotedPrice { get; set; }

        [DisplayName("Customer"), Required]
        public int Customer_Id { get; set; }
        [DisplayName("Customer Reference")]
        [StringLength(128)]
        public string CustomerReference { get; set; }
        [DisplayName("Status"), Required]
        public Enumerations.QuotationStatus Status { get; set; }
        [StringLength(128)]
        public string Comments { get; set; }

        [StringLength(128)]
        public string AttachmentFileName { get; set; }
        [StringLength(128)]
        [HiddenInput]
        public string CreatedBy { get; set; }
        [HiddenInput]
        public DateTime CreatedDate { get; set; }

        public IEnumerable<SelectListItem> CustomerSelectList { get; set; }
        public IEnumerable<SelectListItem> ProductList { get; set; }

    }

    public class QuotationDeleteVm
    {
        [DisplayName("Quote Id")]
        public int Id { get; set; }
        [DisplayName("Part Number"), Required]
        public string Product_Id { get; set; }
        [DisplayName("Part Description")]
        public string Product_Description { get; set; }

        [DisplayName("Quoted Price"), Required]
        public decimal QuotedPrice { get; set; }

        [DisplayName("Unit of Measure"), Required]
        public Enumerations.QuotationStatus Status { get; set; }

        [StringLength(128)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }


    }
    public class QuotationEditLineItemsVm
    {
        [DisplayName("Quote ID")]
        public int Id { get; set; }
        [DisplayName("Customer"), Required]
        public string CustomerName { get; set; }
        [DisplayName("Customer Reference")]
        [StringLength(128)]
        public string CustomerReference { get; set; }
        public string Status {get; set;}

        public IQueryable<QuotationLinesVm> LineItems { get; set; }
    }
    
    public class QuotationLinesVm
    {
        
        [DisplayName("Item Number")]
        public int SortOrder { get; set; }
        [DisplayName("Part Number"), Required]
        public string Product_Id { get; set; }
        public int MinOrderQty { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal QuotedPrice { get; set; }
        
    }
}