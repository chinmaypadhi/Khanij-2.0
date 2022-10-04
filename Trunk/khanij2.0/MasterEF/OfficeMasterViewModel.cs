// ***********************************************************************
//  Class Name               : OfficeMasterViewModel
//  Description              : Lessee Office Master View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 13 July 2021
// ***********************************************************************
using System;
using Microsoft.AspNetCore.Http;

namespace MasterEF
{
    public class OfficeMasterViewModel
    {
        #region CORPORATE
        public int? CORPORATE_OFFICE_ID { get; set; }
        public string CORPORATE_NAME_PREFIX { get; set; }
        public string CORPORATE_NAME { get; set; }
        public string CORPORATE_ADDRESS { get; set; }
        public string CORPORATE_CONTACT_DETAILS { get; set; }
        public string CORPORATE_LANDLINE_NO { get; set; }
        public string CORPORATE_DESIGNATION { get; set; }
        public int? INT_CREATED_BY { get; set; }
        public string CORPORATE_MAIL_ID { get; set; }
        public int? CORPORATE_STATUS { get; set; }
        public string CategoryOfLicensee { get; set; }
        public string Firm { get; set; }
        public string Company { get; set; }
        public string Remarks { get; set; }
        public int? CompanyId { get; set; }
        #endregion
        #region BRANCH
        public int? BRANCH_OFFICE_ID { get; set; }
        public string BRANCH_NAME_PREFIX { get; set; }
        public string BRANCH_NAME { get; set; }
        public string BRANCH_ADDRESS { get; set; }
        public string BRANCH_CONTACT_DETAILS { get; set; }
        public string BRANCH_LANDLINE_NO { get; set; }
        public string BRANCH_DESIGNATION { get; set; }
        public string BRANCH_MAIL_ID { get; set; }
        public int? BRANCH_STATUS { get; set; }
        #endregion
        #region SITE Primary
        public int? SITE_OFFICE_ID { get; set; }
        public string SITE_NAME_PREFIX { get; set; }
        public string SITE_NAME { get; set; }
        public string SITE_ADDRESS { get; set; }
        public string SITE_CONTACT_DETAILS { get; set; }
        public string SITE_LANDLINE_NO { get; set; }
        public string SITE_DESIGNATION { get; set; }
        public string SITE_MAIL_ID { get; set; }
        public int? SITE_STATUS { get; set; }
        #endregion
        #region SITE Secondary
        public string SECONDARY_SITE_NAME_PREFIX { get; set; }
        public string SECONDARY_SITE_NAME { get; set; }
        public string SECONDARY_SITE_ADDRESS { get; set; }
        public string SECONDARY_SITE_CONTACT_DETAILS { get; set; }
        public string SECONDARY_SITE_LANDLINE_NO { get; set; }
        public string SECONDARY_SITE_DESIGNATION { get; set; }
        public string SECONDARY_SITE_MAIL_ID { get; set; }
        #endregion
        #region AGENT
        public int? AGENT_OFFICE_ID { get; set; }
        public string AGENT_NAME_PREFIX { get; set; }
        public string AGENT_NAME { get; set; }
        public string AGENT_ADDRESS { get; set; }
        public string AGENT_CONTACT_DETAILS { get; set; }
        public string AGENT_LANDLINE_NO { get; set; }
        public string AGENT_DESIGNATION { get; set; }
        public string AGENT_MAIL_ID { get; set; }
        public int? AGENT_STATUS { get; set; }
        public string CategoryOfLessee { get; set; }
        public IFormFile LETTER_OF_APPOINTMENT_OF_AGENT { get; set; }
        public String LETTER_OF_APPOINTMENT_OF_AGENT_FILE_NAME { get; set; }
        public string LETTER_OF_APPOINTMENT_OF_AGENT_FILE_PATH { get; set; }
        public ProfileStatusModel objProfileStatus { get; set; }
        public OfficeMasterViewModel()
        {
            objProfileStatus = new ProfileStatusModel();
        }
        #endregion
        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }
        public int? User_Id { get; set; }
        public string CompanyName { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
        public string CollieryCode { get; set; }
        public string GSTNo { get; set; }
        public string MinesType { get; set; }
        public string MineralTypeName { get; set; }
        public string MineralName { get; set; }
    }
}
