using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationEF
{
    public class VehiclePayment
    {
        public string PaymentVehicleID { get; set; }
        public int? UserId { get; set; }
        public string total { get; set; }
        public string UserName { get; set; }
        public string uniqueCustomerID { get; set; }
        public string PaymentBank { get; set; }
        public string ReturnID { get; set; }
    }
}
