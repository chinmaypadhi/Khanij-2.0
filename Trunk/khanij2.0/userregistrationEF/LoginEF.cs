using System;
using System.Collections.Generic;
using System.Text;

namespace userregistrationEF
{
    public class LoginEF
    {
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int UserID { get; set; }
        public string MobileNo { get; set; }
        public string Remoteid { get; set; }
        public string Localip { get; set; }
        public string Browserinfo { get; set; }
    }
}
