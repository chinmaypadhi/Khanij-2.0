using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationEF
{
    public class TransporterMail
    {
        public int? UserId { get; set; }
        public string EmailId { get; set; }
        public string TransporterName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserCode { get; set; }
        public string EMAIL_SENT { get; set; }
        public string MobileNo { get; set; }
        public string Type { get; set; }
        public string RegistrationNo { get; set; }
        public string TotalVehiclesPayment { get; set; }
        public int? VehicleCount { get; set; }
        public string CLNT_TXN_REF { get; set; }
    }
}
