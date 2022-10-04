// ***********************************************************************
//  Class Name               : AllModel
//  Desciption               : Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 April 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StarratingEF
{
    public class AllModel
    {    
        public int? User_Id { get; set; }      
        public int? LeaseArea_TypeID { get; set; }
        public string LeaseArea_Type { get; set; }
        public int CountAssesment { get; set; }
        public string UserName { get; set; }
        public string tableText { get; set; }
        public string Mode { get; set; }
        public SR_Assesment_Master SR_AM { get; set; }
        public SR_Coordinate_Master SR_CM { get; set; }
        public SR_Lease_Area_Master SR_LAM { get; set; }
        public SR_Mineral_Resource_Master SR_MRM { get; set; }
        public SR_Lease_Area_Mineral SR_LAMM { get; set; }
        public string Reporting_Year { get; set; }
        #region FileUpload
        public int FileMasterID { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int Assessment_ID { get; set; }
        public string SPName { get; set; }
        public string mFile { get; set; }
        public string HasObtainOther { get; set; }
        public DataTable dtSystSust { get; set; }
        #endregion
        #region SYSTAMATIC AND SUSTAINABLE MINING
        public SR_Systematic_Sustainable SR_SS { get; set; }
        public SR_Systematic_Sustainable SR_SS1 { get; set; }
        public SR_Systematic_Sustainable SR_SS2 { get; set; }
        public SR_Systematic_Sustainable SR_SS3 { get; set; }
        public SR_Systematic_Sustainable SR_SS4 { get; set; }
        public SR_Systematic_Sustainable SR_SS5 { get; set; }
        public SR_Systematic_Sustainable SR_SS6 { get; set; }
        public SR_Systematic_Sustainable SR_SS7 { get; set; }
        #endregion
        #region  PROTECTION OF ENVIRONMENT AND CONSERVATION OF WATER
        public SR_Protection_Environment SR_PE { get; set; }
        public SR_Protection_Environment SR_PE1 { get; set; }
        public SR_Protection_Environment SR_PE2 { get; set; }
        public SR_Protection_Environment SR_PE3 { get; set; }
        public SR_Protection_Environment SR_PE4 { get; set; }
        public SR_Protection_Environment SR_PE5 { get; set; }
        #endregion
        #region Health Saftery and Welfare of Workers
        public SR_Health_Saftey SR_HS { get; set; }
        public SR_Health_Saftey SR_HS1 { get; set; }
        public SR_Health_Saftey SR_HS2 { get; set; }
        public SR_Health_Saftey SR_HS3 { get; set; }
        public SR_Health_Saftey SR_HS4 { get; set; }
        public SR_Health_Saftey SR_HS5 { get; set; }
        public SR_Health_Saftey SR_HS6 { get; set; }
        public SR_Health_Saftey SR_HS7 { get; set; }
        public SR_Health_Saftey SR_HS8 { get; set; }
        #endregion
        #region Statutory Compliance
        public SR_Statutory_Compliance SR_SC { get; set; }
        public SR_Statutory_Compliance SR_SC1 { get; set; }
        public SR_Statutory_Compliance SR_SC2 { get; set; }
        public SR_Statutory_Compliance SR_SC3 { get; set; }
        public SR_Statutory_Compliance SR_SC4 { get; set; }
        public SR_Statutory_Compliance SR_SC5 { get; set; }
        public SR_Statutory_Compliance SR_SC6 { get; set; }
        public SR_Statutory_Compliance SR_SC7 { get; set; }
        public SR_Statutory_Compliance SR_SC8 { get; set; }
        #endregion
        #region Non Usable
        public SR_Conservation_Renewal SR_CR { get; set; }
        public SR_Conservation_Renewal SR_CR1 { get; set; }
        public SR_Conservation_Renewal SR_CR2 { get; set; }
        public SR_Welfare_Community SR_WC { get; set; }
        public SR_Welfare_Community SR_WC1 { get; set; }
        public SR_Welfare_Community SR_WC2 { get; set; }
        #endregion     
    }
   
}
