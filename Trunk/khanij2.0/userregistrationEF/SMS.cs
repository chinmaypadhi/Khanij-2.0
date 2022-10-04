using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class SMS
    {
        public string mobileNo { get; set; }
        public string message { get; set; }
        public string templateid { get; set; }
        public string SMS_SENT { get; set; }
        public int? UserId { get; set; }
    }
}
