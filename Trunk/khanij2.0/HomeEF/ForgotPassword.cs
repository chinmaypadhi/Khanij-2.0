using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
   public class ForgotPassword
    {
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string OTP { get; set; }
        public string PasswordChange { get; set; }
        public int? UserId { get; set; }
        public string EMAIL_SENT { get; set; }
    }
}
