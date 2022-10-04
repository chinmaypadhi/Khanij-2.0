using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeologyEF
{

public class GeologyMainData
    {
        public int hdnUpdateStatus { get; set; }
        public int geologyId { get; set; }
        public int GeologyInspectionReportId { get; set; }
        public int FPO_id { get; set; }
        public int? UserID { get; set; }
        public string DateOfInspection { get; set; }
        public string TehsilName { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public  int ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public int? UserLoginId { get; set; }
        public string Name { get; set; }
        public int Designation { get; set; }
        public int  Village { get; set; }
        public string CampInspectionDate { get; set; }
        public string Post { get; set; }
        public int District { get; set; }
        public string NameofRegionalWork { get; set; }
        public string VillageName { get; set; }
        public int Tehsil { get; set; }
        public string StatusofBV { get; set; }
        public  string BoreHolePointPosition { get; set; }
        public string CateringworkandRLinformation { get; set; }
        public string BriefNoteonallheworkinthecamp { get; set; }
        public string TotalTopoGraphicalSurveyworktillinspectionDate { get; set; }
        public string WorkAreaStatus { get; set; }
        public string vehicleregrecordedornot { get; set; }
        public string Totaladvancedemandedbythecampofficer { get; set; }
        public string Advanceamountreceived { get; set; }
        public string AmountSpentPOL { get; set; }
        public string AmountSpentLabour { get; set; }
        public string MonthlyStatusCertificate { get; set; }
        public string AmountSpentImprovementWork { get; set; }
        public string AmountSpentExpenditureonotheritems { get; set; }
        public string LastExpendituresheetsubmittedbycampofficer { get; set; }
        public string Statusofregistrationmaintainedinthecamp { get; set; }
        public string WaterSupplyPumpStatus { get; set; }
        public int? DistrictID { get; set; }
        public int? BlockId { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string Frodate { get; set; }
        public string Todate { get; set; }
        public DateTime FrodateDt { get; set; }
        public DateTime TodateDt { get; set; }
        public List<CampOfficeStaffDetails> CampOfficeStaffDetails { get; set; }
        public List<InformationAboutDrillingMachines> InformationAboutDrillingMachines { get; set; }
        public List<NumberAndTypeOfVehicles> NumberAndTypeOfVehicles { get; set; }
        public List<SurveyEquipment> SurveyEquipment { get; set; }
        public List<InformationOnProgressOfRegionalWork> InformationOnProgressOfRegionalWork { get; set; }
        public List<StatusAndProgressOfDrilling> StatusAndProgressOfDrilling { get; set; }
        public List<TotalSupplyVehiclesAndTheirTypes> TotalSupplyVehiclesAndTheirTypes { get; set; }
        public List<TotalExpeditureAfter1stExpediture> TotalExpeditureAfter1stExpediture { get; set; }
        public List<FuelConsumptionAverageOfTheVehicle> FuelConsumptionAverageOfTheVehicle { get; set; }

        //for dropdown
        public int ? RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class CampOfficeStaffDetails
    {
      public string CampOfcStaff { get; set; }
      public string Name { get; set; }      
    }
    public class InformationAboutDrillingMachines
    {
        public string DrillingMachineName { get; set; }
        public string DrillingNo { get; set; }
    }

    public class NumberAndTypeOfVehicles
    {
        public string VehicleNo { get; set; }
        public string TypeofVehicles { get; set; }
    }


    public class SurveyEquipment
    {
        public string EquipmentName { get; set; }
    }

    public class InformationOnProgressOfRegionalWork
    {
        public string Description { get; set; }
        public string Target { get; set; }
        public string TillLastMonthprogress { get; set; }
        public string Updatesprogress { get; set; }
        public string type { get; set; }
    }

    public class StatusAndProgressOfDrilling
    {
    public string Description { get; set; }
    public string TillLastMonthprogress { get; set; }
    public string Updatesprogress { get; set; }
    public string Accusation { get; set; }
    }

    public class TotalSupplyVehiclesAndTheirTypes
    {
        public string TotalSupplyVehicles { get; set; }
        public string CampType { get; set; }
     }

    public class TotalExpeditureAfter1stExpediture
    {
        public string VehiclesType { get; set; }
        public string  TotalExpediture { get; set; }    
    }


    public class FuelConsumptionAverageOfTheVehicle
    {
        public string VehiclesType { get; set; }
        public string FuelUsed { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }       
    }
public class SelectQueryMultiple
    {
        public List<GeologyMainData> GeologyMainData { get; set; }
        public List<InformationOnProgressOfRegionalWork> InformationOnProgressOfRegionalWork { get; set; }
    }
   
}
