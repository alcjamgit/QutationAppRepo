﻿using QuotationApp.Core.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotationApp.Core.Entities
{
    public class Quotation: IAuditable
    {
        [Index(IsClustered = false)]
        public Guid Id { get; set; }
        public int Customer_Id { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        

        [ForeignKey("Customer_Id")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<QuotationLineItem> QuotationLineItems { get; set; }
        
    }
}
