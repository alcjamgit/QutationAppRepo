using QuotationApp.Core.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QuotationApp.Core.Entities
{
    public class Product: IAuditable
    {
        [StringLength(128)]
        public string Id { get; set; }
        public string Description { get; set; }
        public int UnitOfMeasure { get; set; }
        public bool Discontinued { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        
    }
}
