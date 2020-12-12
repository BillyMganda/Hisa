using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hisa
{
    public class PurchaseRequestDetails
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string RequestedBy { get; set; }
        public string Department { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string SubGroup { get; set; }
        public string Units { get; set; }
        public int Quantity { get; set; }
        public string RequestNumber { get; set; }
    }
}
