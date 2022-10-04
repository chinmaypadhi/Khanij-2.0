using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class SandStoneModels
    {
        public int ApplicationID { get; set; }
        public string ApplicationNo { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }        
        public string EmailID { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
        public int StateId { get; set; }
        public int DistrictID { get; set; }
        public int BlockId { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public int MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public int MineralId { get; set; }         
        public string MineralName { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public int LesseeLicenseeId { get; set; }
        public string LesseeLicenseeName { get; set; }
        public decimal MineralQty { get; set; }
        public string Purpose { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SSBR_OTP { get; set; }
        public string SSBR_Captcha { get; set; }
        public int Dist { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

