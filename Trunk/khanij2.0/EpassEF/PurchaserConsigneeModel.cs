using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EpassEF
{
    public class TPVehicleModel
    {
        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public string MaxNetWeight { get; set; }
        public string CarryingCapacity { get; set; }
        public string VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public string VehicleOwner { get; set; }
        public string CompanyName { get; set; }
        public string VehicleOwnerId { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string GrossWeight { get; set; }
        public string TransporterAddress { get; set; }
        public string TransporterMobile { get; set; }
    }
    public class PurchaserConsigneeModel
    {
       
        public string Usertype { get; set; }
        public string Iscoal { get; set; }
        public int? PCId { get; set; }
        //[Required(ErrorMessage = "Select Purchaser Consignee")]
        public int? PurchaserConsigneeId { get; set; }
        public int? Other_PurchaserConsigneeId { get; set; }

        public int? Other_PurchaserConsigneeEnduserId { get; set; }
        public string PurchaserConsigneeName { get; set; }
        public int? BulkPermitId { get; set; }
        public string BulkPermitNo { get; set; }

        
        public string Destination { get; set; }

        
        public int? TransportationModeId { get; set; }
        public string TransportationMode { get; set; }
        public string UserType { get; set; }

        public int? Route { get; set; }
        public int? RouteId { get; set; }
        public int? Other_Route { get; set; }
        public int? Other_RouteEndUser { get; set; }

        public string RouteName { get; set; }
        //public List<ChekpostAssignment> CheckPostCount { get; set; }
        public int? CheckPostId { get; set; }

        public int CheckPostCount { get; set; }

      

        public string CheckPostName { get; set; }
        public int? ActiveStatus { get; set; }
        public int? AddedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string MineralName { get; set; }
        public string MineralGrade { get; set; }
       
        public decimal? ApprovedQty { get; set; }
      
        public decimal? RemainingQty { get; set; }
        public int? LicenseeId { get; set; }
        public String LicenseeName { get; set; }
        public string DispatchType { get; set; }
        public string PartyCode { get; set; }

       
        public int? StateId { get; set; }
        public int? Other_StateId { get; set; }
      
        public int? DistrictId { get; set; }

        public int? LicenseeTypeId { get; set; }

        public int? Other_LicenseeTypeId { get; set; }

        public int? LicenseeDistrictId { get; set; }
        public int? PurchaserConsigneeDistrictId { get; set; }
        public int? Other_PurchaserConsigneeDistrictId { get; set; }

        public int? Other_PurchaserConsigneeEndUserDistrictId { get; set; }

        public int? Route1 { get; set; }

        public int? CoalWashryId { get; set; }
        public string CoalWashryName { get; set; }
        public string CoalWashryAddress { get; set; }

        public string MineralNature { get; set; }

        public string IsOtherParty { get; set; }
        public string Yes_No { get; set; }
        public string IsRegistredPurchaser { get; set; }
        public string PartyName { get; set; }
        public string PartyMobile { get; set; }
        public string OtherOption { get; set; }

        public string ThroughIsCoalWashery { get; set; }
        public int? ThroughCoalWasheryDistrictId { get; set; }
        public int? ThroughCoalWasheryId { get; set; }
        public string ThroughCoalWasheryName { get; set; }
        public string ThroughCoalWasheryAddress { get; set; }
        public int? ThroughCoalWasheryLicenseeTypeId { get; set; }
        public string MineralType { get; set; }

        public string RCR_RTP_BY { get; set; }


        public int? UserId { get; set; }
        public class ChekpostAssignment
        {
            public ChekpostAssignment() { }
            //public string Text { get; set; }
            public int? Value { get; set; }
        }
    }

    public class PurchaserConsigneeModelView
    {
        public PurchaserConsigneeModelView() { }

        public int PCId { get; set; }
        public int? PurchaserConsigneeId { get; set; }
        public int? Other_PurchaserConsigneeId { get; set; }
        public int? Other_PurchaserConsigneeEnduserId { get; set; }
        public string PurchaserConsigneeName { get; set; }
        public int? BulkPermitId { get; set; }
        public string BulkPermitNo { get; set; }
        public string Destination { get; set; }
        public int? TransportationModeId { get; set; }
        public string TransportationMode { get; set; }
        public string UserType { get; set; }
        public int? Route { get; set; }
        public int? Other_Route { get; set; }
        public int? Other_RouteEndUser { get; set; }
        public string RouteName { get; set; }
        public int CheckPostId { get; set; }
        public List<ChekpostAssignment> CheckPostCount { get; set; }
        public string CheckPostName { get; set; }
        public int? ActiveStatus { get; set; }
        public int? AddedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string MineralName { get; set; }
        public string MineralGrade { get; set; }
        public decimal? ApprovedQty { get; set; }
        public decimal? RemainingQty { get; set; }
        public int? LicenseeId { get; set; }
        public String LicenseeName { get; set; }
        public string DispatchType { get; set; }
        public string PartyCode { get; set; }
        public int? StateId { get; set; }
        public int? Other_StateId { get; set; }
        public int? DistrictId { get; set; }
        public int? LicenseeTypeId { get; set; }
        public int? Other_LicenseeTypeId { get; set; }
        public int? LicenseeDistrictId { get; set; }
        public int? PurchaserConsigneeDistrictId { get; set; }
        public int? Other_PurchaserConsigneeDistrictId { get; set; }
        public int? Other_PurchaserConsigneeEndUserDistrictId { get; set; }
        public int? Route1 { get; set; }
        public int? RouteId { get; set; }
        public int? CoalWashryId { get; set; }
        public string CoalWashryName { get; set; }
        public string CoalWashryAddress { get; set; }
        public string MineralNature { get; set; }
        public string IsOtherParty { get; set; }
        public string Yes_No { get; set; }
        public string IsRegistredPurchaser { get; set; }
        public string PartyName { get; set; }
        public string PartyMobile { get; set; }
        public string OthersOption { get; set; }
        public string ThroughIsCoalWashery { get; set; }
        public int? ThroughCoalWasheryDistrictId { get; set; }
        public int? ThroughCoalWasheryId { get; set; }
        public string ThroughCoalWasheryName { get; set; }
        public string ThroughCoalWasheryAddress { get; set; }
        public int? ThroughCoalWasheryLicenseeTypeId { get; set; }
        public string MineralType { get; set; }
        public string RCR_RTP_BY { get; set; }
        public int UserId { get; set; }
        public string ActionCode { get; set; }
        public string Type { get; set; }
        public int IsCoal { get; set; }
        public decimal Total { get; set; }
        public string PurchaserType { get; set; }
        public string OtherYes_No { get; set; }

        public string OtherOption { get; set; }//----added 

        public class ChekpostAssignment
        {
            public ChekpostAssignment() { }
            //public string Text { get; set; }
            public int? Value { get; set; }
        }
    }
    

    public class PurchaserConsigneeOpenEpermitModel
    {
        public PurchaserConsigneeOpenEpermitModel()
        {
            this.BULKPERMITID = String.Empty;
            this.BULKPERMITNO = String.Empty;
            this.PAYABLEROYALTY = String.Empty;
            this.TCS = String.Empty;
            this.CESS = String.Empty;
            this.ECESS = String.Empty;
            this.DMF = String.Empty;
            this.NMET = String.Empty;
            this.TOTALPAYABLEAMOUNT = String.Empty;
            this.APPROVEDDATE = String.Empty;
            this.PAYMENTMODE = String.Empty;
            this.CHALLANNUMBER = String.Empty;
            this.CHALLANDATE = String.Empty;
            this.MineralGradeId = String.Empty;
            this.MINERALGRADE = String.Empty;
            this.MINERALNAME = String.Empty;
            this.PAYMENTREFERENCENO = string.Empty;
            this.MINERALNATURE = string.Empty;
            this.TOTALQTY = string.Empty;
            this.UNIT = string.Empty;
            this.RPTPBulkPermitId = string.Empty;

        }
        public String RPTPBulkPermitId { get; set; }
        public String BULKPERMITID { get; set; }
        public String BULKPERMITNO { get; set; }
        public String PAYABLEROYALTY { get; set; }
        public String TCS { get; set; }
        public String CESS { get; set; }
        public String ECESS { get; set; }
        public String DMF { get; set; }
        public String NMET { get; set; }
        public String TOTALPAYABLEAMOUNT { get; set; }
        public String APPROVEDDATE { get; set; }
        public String PAYMENTMODE { get; set; }
        public String CHALLANNUMBER { get; set; }
        public String CHALLANDATE { get; set; }
        public String MineralGradeId { get; set; }
        public String MINERALGRADE { get; set; }
        public String MINERALNAME { get; set; }
        public String PAYMENTREFERENCENO { get; set; }
        public String MINERALNATURE { get; set; }
        public String TOTALQTY { get; set; }
        public String UNIT { get; set; }
        public String MineralType { get; set; }

        public String PENDINGQTY { get; set; }
        public String RoyaltyChangedQty { get; set; }
        public String DISPATCHEDQTY { get; set; }
        public String BlockedQty { get; set; }

        public String PermitAdjustedQty { get; set; }
        public String MINERAL_TYPE { get; set; }
        public int UserWiseId { get; set; }
        public int UserId { get; set; }
        public string ActionCode { get; set; }
    }

    public class PurchaserConsigneePermitModel
    {
        public int? CheckPostId { get; set; }

        //public List<int> CheckPostCount { get; set; }



        public string CheckPostName { get; set; }
        public PurchaserConsigneePermitModel() { }
        public int PCId { get; set; }
        public int? Other_Route { get; set; }
        public int BulkPermitId { get; set; }
        public int Districtid { get; set; }
        public int Applicationid { get; set; }
        public string lesseecompstatus { get; set; } 
        public int UserId { get; set; }
        public int RPTPBulkPermitId { get; set; }
        public string BulkPermitNo { get; set; }
        public string MineralName { get; set; }
        public string MineralGrade { get; set; }

        public decimal? RemainingQty { get; set; }
        public decimal? ApprovedQty { get; set; }
        public int? MineralId { get; set; }
        public int? PurchaserConsigneeId { get; set; }
        public string PurchaserConsigneeName { get; set; }

        public int? MineralGradeId { get; set; }

        public int? MineralTypeID { get; set; }

        public string MineralType { get; set; }
        public decimal? AverageSalePrice { get; set; }

        public int? RoyaltyRateTypeId { get; set; }

        public string MineralNature { get; set; }
        public string IsOtherParty { get; set; }

        public string PartyName { get; set; }
        public string PartyCode { get; set; }

        public string PartyMobile { get; set; }

        public string PurchaserType { get; set; }
        public string Destination { get; set; }

        public string OthersOption { get; set; }

        public string ThroughIsCoalWashery { get; set; }

        public string ThroughCoalWasheryId { get; set; }

        public string ThroughCoalWasheryLicenseeTypeId { get; set; }


        public int StateId { get; set; }
        public int? PurchaserConsigneeDistrictId { get; set; }
        public int? LicenseeDistrictId { get; set; }

        public int? LicenseeTypeId { get; set; }
        public int? LicenseeId { get; set; }
        public int? Route { get; set; }
        public int? Route1 { get; set; }
        public string Yes_No { get; set; }
        public int? Other_PurchaserConsigneeDistrictId { get; set; }

        public int? Other_PurchaserConsigneeEndUserDistrictId { get; set; }
        public int? Other_StateId { get; set; }
        public int? Other_LicenseeTypeId { get; set; }
        public int? Other_PurchaserConsigneeId { get; set; }
        public int? Other_PurchaserConsigneeEnduserId { get; set; }


        public int? ThroughCoalWasheryDistrictId { get; set; }

        public string ThroughCoalWasheryName { get; set; }
        public string ThroughCoalWasheryAddress { get; set; }


        public string RCR_RTP_BY { get; set; }
        //[Required(ErrorMessage = "Select Transportation Mode")]
        public int? TransportationModeId { get; set; }
        public int? Check { get; set; }

        public int? BindedLicensee { get; set; }
        public int? BindedEnduser { get; set; }
        public int? BindedLicenseeType { get; set; }
        public int? EndUserType { get; set; }
        public string Address { get; set; }

        public int? RouteId { get; set; }

      

        public string TransportationMode { get; set; }
          public string OtherOption { get; set; }
    }
    public class EmpDropDown
    {
        public string Action { get; set; }
        public string Text { get; set; }
        public string value { get; set; }
        public int? Stateid { get; set; }

        public int? DistrictID { get; set; }

        public string DistrictName { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
    }
    public class PurchaseConsignee
    {
       public string Other_user { get; set; }
        public int PurchaserConsigneeId { get; set; }
        public string PurchaserConsigneeName { get; set; }
        public string Address { get; set; }
        public int? LoginUserId { get; set; }
        public int? LicenseeDistrictId { get; set; }
        public int? ApplicationType_Id { get; set; }
        public int? BulkPermitId { get; set; }
        public string LesseeCaptiveMineStatus { get; set; }

        public int? EndUserId { get; set; }
        public string EndUserName { get; set; }
        public int? DistrictID { get; set; }

        public int? chk { get; set; }
    }
   
}
