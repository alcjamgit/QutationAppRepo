using QuotationApp.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using System.Text;
using System.Threading.Tasks;

namespace QuotationApp.Infrastructure.BusinessLayer
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IIdentity identity)
        {
            IsAuthenticated = identity.IsAuthenticated;
            UserName = identity.Name;
            UserID = identity.GetUserId();
        }
        //for mocking
        public CurrentUserService() { }

        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
        public virtual string UserID { get; set; }
    }
}
