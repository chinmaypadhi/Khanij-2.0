using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnEF
{
    public class AnnualReturnH1ViewModel
    {
        public MineDetailsModel objMineDetails { get; set; }
        public MineOther_DetailsModel objOtherDetails { get; set; }
        public ParticularsofArea objParticular { get; set; }
        public LeaseArea objLeaseArea { get; set; } 
        public int? UserId { get; set; }
        public AnnualReturnH1ViewModel()
        {
            objMineDetails = new MineDetailsModel();
            objOtherDetails = new MineOther_DetailsModel();
            objParticular = new ParticularsofArea();
            objLeaseArea = new LeaseArea();
        }
    }

    public class MineDetailsModel
    {
        //------------Mine Details ----------------------------------
        public string Registrationnumber { get; set; }
        public string MINE_CODE { get; set; }
        public int? MineralID { get; set; }
        public string MineralName { get; set; }
        public string OtherMineral { get; set; }
        public string MineName { get; set; }
        public string MineAddress { get; set; }
        public string MineVillage { get; set; }
        public string MineDistrict { get; set; }
        public string MineState { get; set; }
        public string MineTehsil { get; set; }
        public string MinePinCode { get; set; }
        public string MinePostOffice { get; set; }
        public string MineFaxNo { get; set; }
        public string MineEmailID { get; set; }
        public string MineMobileNo { get; set; }
        public string MinePhoneNo { get; set; }
        public string LesseeName { get; set; }
        public string LesseeAddress { get; set; }
        public string LesseeVillageName { get; set; }
        public string LesseeDistrictName { get; set; }

        public string LesseePostOffice { get; set; }
        public string LesseeStateName { get; set; }
        public string LesseeTehsilName { get; set; }
        public string LesseePinCode { get; set; }
        public string LesseeFaxNo { get; set; }
        public string LesseeEmailID { get; set; }
        public string LesseeMobileNo { get; set; }
        public string LesseePhoneNo { get; set; }
    }

    public class MineOther_DetailsModel
    {
        public int? OtherDetails_Id { get; set; }
        public string RegisteredOffice { get; set; }
        public string Director_in_charge { get; set; }
        public string Agent { get; set; }
        public string Manager { get; set; }
        public string MiningEngineer_in_charge { get; set; }
        public string Geologist_in_charge { get; set; }
        public string Transferor { get; set; }
        public string Dateof_Transfer { get; set; }
        public string Year { get; set; }
        public string MinePostOffice { get; set; }
        public string MineFaxNo { get; set; }
        public string LesseeFaxNo { get; set; }
        public int? Flag1 { get; set; }
        public string SubmitDate { get; set; }
        public string DSCFilePath { get; set; }
    }

    public class ParticularsofArea
    {

        //------------Particulars of area operated/Lease ----------------------------
        public List<int> Particular_Id { get; set; }
        public List<string> Lease_number { get; set; }
        public List<string> underlease_UnderForest { get; set; }
        public List<string> underlease_OutsideForest { get; set; }
        public List<string> underlease_Total { get; set; }
        public List<string> Date_of_execution { get; set; }
        public List<string> Date_of_execution_str { get; set; }
        public List<string> Periodoflease { get; set; }
        public List<string> Surfacerights_UnderForest { get; set; }
        public List<string> Surfacerights_OutsideForest { get; set; }
        public List<string> Surfacerights_Total { get; set; }
        public List<string> RenewalDate { get; set; }
        public List<string> RenewalDate_str { get; set; }
        public List<string> RenewalPeriod { get; set; }
        public string More_mine_details { get; set; }
        public string Mineral_produced { get; set; }
        public string Year { get; set; }
        public int? Flag2 { get; set; }
        public int? UserId { get; set; }
        public ParticularsofArea()
        {
            this.Particular_Id = new List<int>();
            this.Lease_number = new List<string>();
            this.underlease_UnderForest = new List<string>();
            this.underlease_OutsideForest = new List<string>();
            this.underlease_Total = new List<string>();
            this.Date_of_execution = new List<string>();
            this.Date_of_execution_str = new List<string>();
            this.Periodoflease = new List<string>();
            this.Surfacerights_UnderForest = new List<string>();
            this.Surfacerights_OutsideForest = new List<string>();
            this.Surfacerights_Total = new List<string>();
            this.RenewalDate = new List<string>();
            this.RenewalDate_str = new List<string>();
            this.RenewalPeriod = new List<string>();
        }
    }

    public class LeaseArea
    {
        //------------Lease area (surface area) utilisation----------------------------
        public int? Lease_Area_Id { get; set; } 
        public string UnderForest1 { get; set; } 
        public string UnderForest2 { get; set; } 
        public string UnderForest3 { get; set; } 
        public string UnderForest4 { get; set; } 
        public string UnderForest5 { get; set; } 
        public string UnderForest6 { get; set; } 
        public string UnderForest7 { get; set; } 
        public string Outsideforest1 { get; set;} 
        public string Outsideforest2 { get; set; } 
        public string Outsideforest3 { get; set; } 
        public string Outsideforest4 { get; set; } 
        public string Outsideforest5 { get; set; } 
        public string Outsideforest6 { get; set; } 
        public string Outsideforest7 { get; set; } 
        public string Total1 { get; set; } 
        public string Total2 { get; set; } 
        public string Total3 { get; set; } 
        public string Total4 { get; set; } 
        public string Total5 { get; set; } 
        public string Total6 { get; set; } 
        public string Total7 { get; set; } 
        public string AgencyofMine { get; set; }
        public string Year { get; set; }
        public int? Flag3 { get; set; }
        public int? UserId { get; set; }
    }
}
