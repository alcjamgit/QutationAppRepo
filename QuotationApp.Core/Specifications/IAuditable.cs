using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotationApp.Core.Specifications
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTime CreateDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
