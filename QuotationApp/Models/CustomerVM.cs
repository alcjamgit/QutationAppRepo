using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuotationApp.Web.Models
{
    public class CustomerIndexVm
    {
        [Display(Name = "Company Name"), Required]
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class CustomerCreateVm
    {
        [Display(Name = "Company Name"), Required]
        public string Name { get; set; }
        public string Email { get; set; }
    }

}