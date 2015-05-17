using QuotationApp.Core.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotationApp.Core.Entities
{
    public class QuotationLineItem: IAuditable
    {
        [Index(IsClustered = false)]
        public Guid Id { get; set; }

        [StringLength(128)]
        public string Product_Id { get; set; }
        public int MinOrderQty { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal QuotedPrice { get; set; }
        public int SortOrder { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }


    }
}
