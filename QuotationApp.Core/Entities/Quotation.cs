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
    public class Quotation: IAuditable
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        [StringLength(128)]
        public string CustomerReference { get; set; }
        [StringLength(128)]
        public string Comments { get; set; }
        [StringLength(64)]
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        

        [ForeignKey("Customer_Id")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<QuotationLineItem> QuotationLineItems { get; set; }
        
    }
}
