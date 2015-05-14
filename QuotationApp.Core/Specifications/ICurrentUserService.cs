using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotationApp.Core.Specifications
{
    public interface ICurrentUserService
    {
        string UserID { get; set; }
        string UserName { get; set; }
        bool IsAuthenticated { get; set; }
    }

}
