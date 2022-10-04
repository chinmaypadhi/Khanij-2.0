using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class ForceFullDataVTDUser
    {
        public int VTDVendorId { get; set; }
        public string SrNo { get; set; }
        public string UserName { get; set; }  
        public string DistrictName { get; set; }
        public string RegistrationNo { get; set; }

        public string DistrictId { get; set; }
        public string ApplicantName { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationType { get; set; }
        public string UserType { get; set; }
        public string IsExisting { get; set; }
        public string ApprovalStatus { get; set; }
        public string UserRemarks { get; set; }
        public string ApproverRemarks { get; set; }
        public string AddedBy { get; set; }
        public string AddedOn { get; set; }
        public string ActionTakenBy { get; set; }
        public string ActionTakenOn { get; set; }
        public string StateId { get; set; }
        public string IsCompleted { get; set; }
        public string StateName { get; set; }
    }
}
