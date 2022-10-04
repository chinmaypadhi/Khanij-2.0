using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeologyEF
{
    public class GeologyMail
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
        public string EmailIdCC { get; set; }
        public string FPO { get; set; }
        public string MineralName { get; set; }
        public string ReportType { get; set; }
        public string ReportStatus { get; set; }
    }
}
