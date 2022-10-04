// ***********************************************************************
//  Class Name               : LesseeListForDGMModel
//  Description              : View Lessee User details by User,Role type
//  Created By               : Lingaraj Dalai
//  Created On               : 25 April 2022
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEF
{
    public class LesseeListForDGMModel
    {
        public int? SrNo { get; set; }
        public int? LesseId { get; set; }
        public int? StateId { get; set; }
        public int? DistrictId { get; set; }
        public int? UserId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string RoleTypeName { get; set; }
        public string UserType { get; set; }
        public string ApplicantName { get; set; }
        public string LeaseCode { get; set; }
        public string lesseeType { get; set; }
        public string MineName { get; set; }
        public string Address { get; set; }
        public string EMailId { get; set; }
        public string MOBILENO { get; set; }
        public string TotalLeaseArea { get; set; }
        public string LeasePeriod { get; set; }
        public string MineralDealswith { get; set; }
        public string GradeDealswith { get; set; }
        public string FormDealswith { get; set; }
        public string IsInterNetConnectionAtDistpatch { get; set; }
        public string StatusOfLessee { get; set; }
        public string DistrictName { get; set; }
        public string GrantOrderDate { get; set; }
        public string RequestSubmissionDate { get; set; }
        public string RequestApprovalDate { get; set; }
        public string StatusOfLesseeLicensee { get; set; }
        public string MineralType { get; set; }
    }
}
