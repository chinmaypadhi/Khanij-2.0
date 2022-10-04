// ***********************************************************************
//  Class Name               : SR_Assesment_Master
//  Desciption               : Starrating Assessment
//  Created By               : Lingaraj Dalai
//  Created On               : 30 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace StarratingEF
{
    public class SR_Assesment_Master
    {
        public int Assesment_Id { get; set; }
        public int? User_Id { get; set; }
        public string Lessee_Code { get; set; }
        public string Khasra_No { get; set; }
        public int State_Id { get; set; }
        public int District_Id { get; set; }
        public int Tehsil_Id { get; set; }
        public int Village_Id { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int TehsilID { get; set; }
        public int VillageID { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public string TehsilName { get; set; }
        public string VillageName { get; set; }
        public string MineralName { get; set; }
        public string Lease_Period_From { get; set; } //Datetime
        public string Lease_Period_To { get; set; } //Datetime
        public string Lessee_Type_Id { get; set; }
        public string Address { get; set; }
        public string Mobile_No { get; set; }
        public string Email_Id { get; set; }
        public int? Mineral_Id { get; set; }
        public string Mining_Method_Id { get; set; }
        public string Lease_Status_Id { get; set; }
        public int? Working_Days { get; set; }
        public int? Discontunuance_Days { get; set; }
        public int? Suspension_Days { get; set; }
        public string Contact_Person { get; set; }
        public string Contact_No { get; set; }
        public string Contact_Mail { get; set; }
        public string Contact_Address { get; set; }
        public string Approved_Plan_Validity_From { get; set; } //Datetime
        public string Approved_Plan_Validity_To { get; set; } //Datetime
        public int? Approved_Plan_Quantity { get; set; }
        public string Environment_Clearance_Validity_From { get; set; } //Datetime
        public string Environment_Clearance_Validity_To { get; set; } //Datetime
        public int? Environment_Clearance_Quantity { get; set; }
        public string SPCB_Validity_Upto { get; set; } //Datetime
        public int? SPCB_Quantity { get; set; }
        public string Forest_Clearance_Validity_Upto { get; set; } //Datetime ?
        public double? Royalty_Paid { get; set; }
        public double? Dead_Rent_Paid { get; set; }
        public double? Contribution_To_DMF { get; set; }
        public double? Contribution_To_State_Exploration_Trust { get; set; }
        public string Reporting_Year { get; set; }
        public string Company_Name { get; set; }
        public string Director_Name { get; set; }
        public int LeaseArea_TypeID { get; set; }
        public string LeaseArea_Type { get; set; }
    }
}
