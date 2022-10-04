using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class BreakdownRequestDetailsByMobileApp
    {
        public string TransporterName { get; set; }
        public string TransporterMobileNo { get; set; }
        public string TransporterEMailId { get; set; }
        public string EndUserName { get; set; }
        public string EndUserMobileNo { get; set; }
        public string EndUserEmailId { get; set; }
        public string LicenseeName { get; set; }
        public string LicenseeMobileNo { get; set; }
        public string LicenseeEmailId { get; set; }
        public string LesseeName { get; set; }
        public string LesseeMobileNo { get; set; }
        public string LesseeEmailId { get; set; }
        public string EMAIL_SENT { get; set; }
        public int? UserId { get; set; }
        public string TransitPassNo { get; set; }
        public string Type { get; set; }
    }
}
