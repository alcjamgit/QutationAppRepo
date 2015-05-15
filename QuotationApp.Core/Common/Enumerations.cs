using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotationApp.Core.Common
{
    public static class Enumerations
    {
        public enum QuotationStatus
        {
            [Description("Created")]
            Created = 0,
            [Description("In-Progress")]
            InProgress = 1,
            [Description("For Approval")]
            ForManagementApproval =2 ,
            [Description("Sent")]
            SentToCustomer = 3,

        }

        public enum UnitOfMeasure
        {
            [Description("PCS")]
            Pieces = 0,
            [Description("BOXES")]
            Boxes = 1,
            [Description("KGS")]
            Kilos = 2,

        }
    }
}
