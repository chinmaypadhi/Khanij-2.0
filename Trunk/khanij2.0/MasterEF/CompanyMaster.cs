using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
   public class CompanyMaster
    {
        public int? CompanyId { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive{ get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Status { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? UserLoginId { get; set; }
        public string ActiveStatus { get; set; }
    }
}
