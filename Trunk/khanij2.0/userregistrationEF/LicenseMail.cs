using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class LicenseMail
    {
        public string MOBILENO { get; set; }
        public string EMAILADDRESS { get; set; }
        public string APPLICANTNAME { get; set; }
        public string LICENSE_APP_CODE { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string application_tyep { get; set; }
        public string EMAIL_SENT { get; set; }
        public int? UserId { get; set; }
    }
}
