// ***********************************************************************
//  Class Name               : LeaseAreaViewModel
//  Description              : Lessee Lease Area Model Details class
//  Created By               : Lingaraj Dalai
//  Created On               : 21 July 2021
// ***********************************************************************
using System;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace MasterEF
{
    public class LeaseAreaViewModel
    {
        public int? LICENSE_AREA_ID { get; set; }
        public string BLOCK_FOREST_RANGE { get; set; }
        public int? TehsilID { get; set; }
        public string TehsilName { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public int? VillageID { get; set; } 
        public string VillageName { get; set; }
        public string PIN_CODE { get; set; }
        public string TYPE_OF_LAND { get; set; }
        public string Remarks { get; set; }
        public decimal AREA_IN_HECT { get; set; }
        public string TOPOSHEET_NO { get; set; }
        public string COORDINATES { get; set; }
        public IFormFile DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES { get; set; }
        public string DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME { get; set; }
        public string DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH { get; set; }
        public string WORKING_PERMISSION_DATE { get; set; }
        public IFormFile WORKING_PERMISSION_COPY { get; set; }
        public string WORKING_PERMISSION_COPY_NAME { get; set; }
        public string WORKING_PERMISSION_COPY_PATH { get; set; }
        public DateTime? COMMENCEMENT_OF_MINING_DATE { get; set; }
        public IFormFile COMMENCEMENT_OF_MINING_COPY { get; set; }
        public string COMMENCEMENT_OF_MINING_COPY_NAME { get; set; }
        public string COMMENCEMENT_OF_MINING_PATH { get; set; }
        public int? STATUS { get; set; }
        public int? CREATED_BY { get; set; }
        public string DATE_OF_EXECUTION { get; set; }
        public string POLICE_STATION { get; set; }
        public string GRAM_PANCHAYAT { get; set; }
        public decimal Forest { get; set; }
        public decimal RevenueForest { get; set; }
        public decimal RevenueGovernmentLand { get; set; }
        public decimal PrivateTribal { get; set; }
        public decimal PrivateNonTribal { get; set; }
        public decimal Nistar { get; set; }
        public string LandUnderVidhansabhakshetra { get; set; }
        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }
        public IFormFile COORDINATES_PILLARS { get; set; }
        public string PATH_COORDINATES_PILLARS { get; set; }
        public string FILE_COORDINATES_PILLARS { get; set; }
        public IFormFile LEASE_AREA_MAP { get; set; }
        public string PATH_LEASE_AREA_MAP { get; set; }
        public string FILE_LEASE_AREA_MAP { get; set; }
        public int? LEASELAND_DISRICT_ID { get; set; }
        public string LEASELAND_DISRICT_NAME { get; set; }
        public string LEASELAND_GP { get; set; }
        public int? LEASELAND_VILLAGE_ID { get; set; }
        public string LEASELAND_VILLAGE_NAME { get; set; }
        public string LEASELAND_KHASRA_NO { get; set; }
        public string LEASELAND_BASRA_NO { get; set; }
        public string LEASELAND_DHARANADIKAR { get; set; }
        public string LEASELAND_AREA_TYPE { get; set; }
        public string LEASELAND_AREA_SUB_TYPE { get; set; }
        public string LEASELAND_AREA_NF_SUB_TYPE { get; set; }
        public string LEASELAND_AREA { get; set; }
        public string LEASELAND_SURFACE_RIGHT_AREA { get; set; }
        public string LEASELAND_MAP { get; set; }
        public int LokSabhaId { get; set; }
        public string LokSabha { get; set; }
        public int VidhanSabhaId { get; set; }
        public string VidhanSabha { get; set; }
        public int? UserId { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
        public int? BlockId { get; set; }
        public string BlockName { get; set; }
        public int LAND_ID { get; set; }
        public int? LEASELAND_BLOCK_ID { get; set; }
        public string LEASELAND_BLOCK_NAME { get; set; }
        public string MineralTypeName { get; set; }
        public string FOREST_RANGE { get; set; }
        public string COMPARTMENT_NUMBER { get; set; }
        public decimal LandForest { get; set; }
        public decimal LandRevenueForest { get; set; }
        public decimal LandRevenueGovernmentLand { get; set; }
        public decimal LandPrivateTribal { get; set; }
        public decimal LandPrivateNonTribal { get; set; }
        public decimal ForestRangeProtected { get; set; }
        public decimal ForestRangeRevenue { get; set; }
        public bool IsForestRangeProtected { get; set; }
        public bool IsForestRangeRevenue { get; set; }
        public DataTable dtCoordinatePillars { get; set; }
        public string DATA_LEASE_AREA_MAP { get; set; }
    }
}
