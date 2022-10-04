// ***********************************************************************
//  Class Name               : InspectionReportProvider
//  Desciption               : Add,View,Edit,Update,Delete Inspection Report
//  Created By               : Lingaraj Dalai
//  Created On               : 01 March 2021
// ***********************************************************************
using Dapper;
using GeologyApi.Factory;
using GeologyApi.Repository;
using GeologyEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GeologyApi.Model.InspectionReport
{
    public class InspectionReportProvider: RepositoryBase, IInspectionReportProvider
    {
        #region Submit Inspection Report
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public InspectionReportProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To Add the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddInspectionReportsmaster(InspectionReportmaster objInspectionReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FPO_id", objInspectionReportmaster.FPO_Id);
                p.Add("DateOfInspection", objInspectionReportmaster.SubmissionDate);
                p.Add("FileName", objInspectionReportmaster.FileName);
                p.Add("FilePath", objInspectionReportmaster.FilePath);              
                p.Add("USER_ID", objInspectionReportmaster.UserId);
                p.Add("LOGIN_ID", objInspectionReportmaster.UserLoginId);
                p.Add("SP_MODE", "INSERT_DATA");
                string response = await Connection.QueryFirstAsync<string>("USP_GeologyInspectionReport", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else if (response == "0")
                {
                    objMessage.Satus = "3";
                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To View the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        public async Task<List<InspectionReportmaster>> ViewInspectionReportsmaster(InspectionReportmaster objInspectionReportmaster)
        {
            List<InspectionReportmaster> ListFPOMaster = new List<InspectionReportmaster>();
            try
            {
                var paramList = new
                {
                    USER_ID =objInspectionReportmaster.UserId,
                    LOGIN_ID = objInspectionReportmaster.UserLoginId,
                    SP_MODE = "GET_DATA"
                };
                var Output = await Connection.QueryAsync<InspectionReportmaster>("USP_GeologyInspectionReport", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ListFPOMaster = Output.ToList();
                }
                return ListFPOMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Edit the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        public async Task<InspectionReportmaster> EditInspectionReportsmaster(InspectionReportmaster objInspectionReportmaster)
        {
            InspectionReportmaster LobjInspectionReportmaster = new InspectionReportmaster();
            try
            {
                var paramList = new
                {
                    GeologyInspectionReportId = objInspectionReportmaster.MPR_ID,
                    SP_MODE = "SELECT_ID"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<InspectionReportmaster>("USP_GeologyInspectionReport", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    LobjInspectionReportmaster = Output.FirstOrDefault();
                }
                return LobjInspectionReportmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjInspectionReportmaster = null;
            }
        }
        /// <summary>
        /// To Delete the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteInspectionReportsmaster(InspectionReportmaster objInspectionReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("GeologyInspectionReportId", objInspectionReportmaster.MPR_ID);
                p.Add("SP_MODE", "DELETE_DATA");
                string response = await Connection.QueryFirstAsync<string>("USP_GeologyInspectionReport", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Update the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateInspectionReportsmaster(InspectionReportmaster objInspectionReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("GeologyInspectionReportId", objInspectionReportmaster.MPR_ID);
                p.Add("FPO_id", objInspectionReportmaster.FPO_Id);
                p.Add("DateOfInspection", objInspectionReportmaster.SubmissionDate);
                p.Add("FileName", objInspectionReportmaster.FileName);
                p.Add("FilePath", objInspectionReportmaster.FilePath);
                p.Add("USER_ID", objInspectionReportmaster.UserId);
                p.Add("LOGIN_ID", objInspectionReportmaster.UserLoginId);
                p.Add("SP_MODE", "UPDATE_DATA");
                string response = await Connection.QueryFirstAsync<string>("USP_GeologyInspectionReport", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "4";
                }
                else if (response == "0")
                {
                    objMessage.Satus = "3";
                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// To Get the MPR code list details data in view
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        public async Task<List<InspectionReportmaster>> GetMPRCodeList(InspectionReportmaster objLabReportmaster)
        {
            List<InspectionReportmaster> ObjMPRCodeList = new List<InspectionReportmaster>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<InspectionReportmaster>("uspGetFpoDropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjMPRCodeList = Output.ToList();
                }
                return ObjMPRCodeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Get the Officer list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public async Task<InspectionReportmaster> GetOfficerNameAndDesignation(InspectionReportmaster objMPRMaster)
        {
            InspectionReportmaster LobjMPRMaster = new InspectionReportmaster();
            try
            {
                var paramList = new
                {
                    UserId = objMPRMaster.UserId,
                    chk = "GET_OFFICER_NAME_AND_DESIGNATION"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<InspectionReportmaster>("Geology_FPO_OrderOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    LobjMPRMaster = Output.FirstOrDefault();
                }
                return LobjMPRMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MessageEF> AddGeologyNew(GeologyMainData objInspectionReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Action","A");

                p.Add("@DateOfInspection", objInspectionReportmaster.DateOfInspection);
                p.Add("@CreatedBy", objInspectionReportmaster.UserID);
                //p.Add("@CreatedOn", objInspectionReportmaster.CreatedOn);
                p.Add("@ModifiedBy", objInspectionReportmaster.UserID);
                //p.Add("@ModifiedOn", objInspectionReportmaster.ModifiedOn);
                p.Add("@UserLoginId", objInspectionReportmaster.UserLoginId);
                p.Add("@Name", objInspectionReportmaster.Name);
                p.Add("@Designation", objInspectionReportmaster.Designation);
                p.Add("@Village", objInspectionReportmaster.Village);
                p.Add("@CampInspectionDate", objInspectionReportmaster.CampInspectionDate);
                p.Add("@District", objInspectionReportmaster.District);
                p.Add("@NameofRegionalWork", objInspectionReportmaster.NameofRegionalWork);
                p.Add("@Tehsil", objInspectionReportmaster.Tehsil);
                p.Add("@BoreHolePointPosition", objInspectionReportmaster.BoreHolePointPosition);
                p.Add("@StatusofBV", objInspectionReportmaster.StatusofBV);
                p.Add("@CateringworkandRLinformation", objInspectionReportmaster.CateringworkandRLinformation);
                p.Add("@BriefNoteonallheworkinthecamp", objInspectionReportmaster.BriefNoteonallheworkinthecamp);
                p.Add("@TotalTopoGraphicalSurveyworktillinspectionDate", objInspectionReportmaster.TotalTopoGraphicalSurveyworktillinspectionDate);
                p.Add("@WorkAreaStatus", objInspectionReportmaster.WorkAreaStatus);
                p.Add("@vehicleregrecordedornot", objInspectionReportmaster.MonthlyStatusCertificate);
                p.Add("@Totaladvancedemandedbythecampofficer", objInspectionReportmaster.Totaladvancedemandedbythecampofficer);
                p.Add("@Advanceamountreceived", objInspectionReportmaster.Advanceamountreceived);
                p.Add("@AmountSpentPOL", objInspectionReportmaster.AmountSpentPOL);
                p.Add("@AmountSpentImprovementWork", objInspectionReportmaster.AmountSpentImprovementWork);
                p.Add("@AmountSpentExpenditureonotheritems", objInspectionReportmaster.AmountSpentExpenditureonotheritems);
                p.Add("@LastExpendituresheetsubmittedbycampofficer", objInspectionReportmaster.LastExpendituresheetsubmittedbycampofficer);
                p.Add("@Statusofregistrationmaintainedinthecamp", objInspectionReportmaster.Statusofregistrationmaintainedinthecamp);
                p.Add("@WaterSupplyPumpStatus", objInspectionReportmaster.WaterSupplyPumpStatus);
                p.Add("@AmountSpentLabour", objInspectionReportmaster.AmountSpentLabour);
                p.Add("@CampOfficeStaffDetails", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.CampOfficeStaffDetails).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@InformationAboutDrillingMachines", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.InformationAboutDrillingMachines).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@NumberAndTypeOfVehicles", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.NumberAndTypeOfVehicles).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@SurveyEquipment", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.SurveyEquipment).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@InformationOnProgressOfRegionalWork", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.InformationOnProgressOfRegionalWork).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@StatusAndProgressOfDrilling", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.StatusAndProgressOfDrilling).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@TotalSupplyVehiclesAndTheirTypes", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.TotalSupplyVehiclesAndTheirTypes).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@TotalExpeditureAfter1stExpediture", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.TotalExpeditureAfter1stExpediture).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@FuelConsumptionAverageOfTheVehicle", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.FuelConsumptionAverageOfTheVehicle).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));               
                string response = await Connection.QueryFirstAsync<string>("USP_GEOLOGY_INSERT", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "true";
                    objMessage.Msg = "Data saved Successfully";
                }
                
                else
                {
                    objMessage.Satus = "false";
                    objMessage.Msg = "something went wrong";

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion
        public async Task<List<GeologyMainData>> GetDistrict(GeologyMainData objLabReportmaster)
        {
            List<GeologyMainData> ObjMPRCodeList = new List<GeologyMainData>();
            try
            {
                var paramList = new
                {
                    P_Acction= "District",
                    P_StateID = 7
                };
                var Output = await Connection.QueryAsync<GeologyMainData>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjMPRCodeList = Output.ToList();
                }
                return ObjMPRCodeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GeologyMainData>> GetTahasil(GeologyMainData objLabReportmaster)
        {
            List<GeologyMainData> ObjMPRCodeList = new List<GeologyMainData>();
            try
            {
                var paramList = new
                {
                    P_Acction = "Tehsil",
                    P_DistrictId = objLabReportmaster.DistrictID,
                    P_StateId = 7
                };
                var Output = await Connection.QueryAsync<GeologyMainData>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjMPRCodeList = Output.ToList();
                }
                return ObjMPRCodeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GeologyMainData>> GetVillage(GeologyMainData objLabReportmaster)
        {
            List<GeologyMainData> ObjMPRCodeList = new List<GeologyMainData>();
            try
            {
                var paramList = new
                {
                    P_Acction = "GetVlg",
                    P_DistrictId = objLabReportmaster.DistrictID,
                    TahasilId = objLabReportmaster.Tehsil,
                    P_StateId = 7
                };
                var Output = await Connection.QueryAsync<GeologyMainData>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjMPRCodeList = Output.ToList();
                }
                return ObjMPRCodeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GeologyMainData>> GetDesig(GeologyMainData objLabReportmaster)
        {
            List<GeologyMainData> ObjMPRCodeList = new List<GeologyMainData>();
            try
            {
                var paramList = new
                {
                    operation=4
               };
                
                var Output = await Connection.QueryAsync<GeologyMainData>("uspRoleMasterOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjMPRCodeList = Output.ToList();
                }
                return ObjMPRCodeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<GeologyMainData>> GetVehicle(GeologyMainData objLabReportmaster)
        {
            List<GeologyMainData> ObjMPRCodeList = new List<GeologyMainData>();
            try
            {
                var paramList = new
                {
                    P_Acction = "GetVehicle",
                };
                var Output = await Connection.QueryAsync<GeologyMainData>("UspBindDropDownsandstone", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjMPRCodeList = Output.ToList();
                }
                return ObjMPRCodeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<SelectQueryMultiple> GetAllRecord(GeologyMainData objLabReportmaster)
        {
            SelectQueryMultiple ObjSelectQueryMultiple = new SelectQueryMultiple ();
            GeologyMainData obj = new GeologyMainData();
            try
            {
                var paramList = new
                {
                    @Action = "R"
                    ,@FromDate = objLabReportmaster.Frodate
                    ,@Todate = objLabReportmaster.Todate
                };

                var result = await Connection.QueryMultipleAsync("USP_GEOLOGY_INSERT", paramList, commandType: System.Data.CommandType.StoredProcedure);
                ObjSelectQueryMultiple.GeologyMainData = result.Read<GeologyMainData>().ToList();
                ObjSelectQueryMultiple.InformationOnProgressOfRegionalWork = result.Read<InformationOnProgressOfRegionalWork>().ToList();            
                return ObjSelectQueryMultiple;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MessageEF> DeleteInspection(GeologyMainData objInspectionReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Action", "D");

                p.Add("@GeologyInspectionReportId", objInspectionReportmaster.GeologyInspectionReportId);
                string response = await Connection.QueryFirstAsync<string>("USP_GEOLOGY_INSERT", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "true";
                    objMessage.Msg = "Data Deleted Successfully";
                }
                else
                {
                    objMessage.Satus = "false";
                    objMessage.Msg = "something went wrong";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        public async Task<SelectQueryMultiple> SelectDataForUpdate(GeologyMainData objLabReportmaster)
        {
            SelectQueryMultiple ObjSelectQueryMultiple = new SelectQueryMultiple();
            GeologyMainData obj = new GeologyMainData();
            try
            {
                var paramList = new
                {
                    @Action = "Ev",
                    @GeologyInspectionReportId= objLabReportmaster.GeologyInspectionReportId
                };

                var result = await Connection.QueryMultipleAsync("USP_GEOLOGY_INSERT", paramList, commandType: System.Data.CommandType.StoredProcedure);
                ObjSelectQueryMultiple.GeologyMainData = result.Read<GeologyMainData>().ToList();
                ObjSelectQueryMultiple.InformationOnProgressOfRegionalWork = result.Read<InformationOnProgressOfRegionalWork>().ToList();
                return ObjSelectQueryMultiple;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MessageEF> UpdateGeologyNew(GeologyMainData objInspectionReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Action", "U");

                p.Add("@DateOfInspection", objInspectionReportmaster.DateOfInspection);
                p.Add("@CreatedBy", objInspectionReportmaster.UserID);
                //p.Add("@CreatedOn", objInspectionReportmaster.CreatedOn);
                p.Add("@ModifiedBy", objInspectionReportmaster.UserID);
                //p.Add("@ModifiedOn", objInspectionReportmaster.ModifiedOn);
                p.Add("@UserLoginId", objInspectionReportmaster.UserLoginId);
                p.Add("@Name", objInspectionReportmaster.Name);
                p.Add("@Designation", objInspectionReportmaster.Designation);
                p.Add("@Village", objInspectionReportmaster.Village);
                p.Add("@CampInspectionDate", objInspectionReportmaster.CampInspectionDate);
                p.Add("@District", objInspectionReportmaster.District);
                p.Add("@NameofRegionalWork", objInspectionReportmaster.NameofRegionalWork);
                p.Add("@Tehsil", objInspectionReportmaster.Tehsil);
                p.Add("@BoreHolePointPosition", objInspectionReportmaster.BoreHolePointPosition);
                p.Add("@StatusofBV", objInspectionReportmaster.StatusofBV);
                p.Add("@CateringworkandRLinformation", objInspectionReportmaster.CateringworkandRLinformation);
                p.Add("@BriefNoteonallheworkinthecamp", objInspectionReportmaster.BriefNoteonallheworkinthecamp);
                p.Add("@TotalTopoGraphicalSurveyworktillinspectionDate", objInspectionReportmaster.TotalTopoGraphicalSurveyworktillinspectionDate);
                p.Add("@WorkAreaStatus", objInspectionReportmaster.WorkAreaStatus);
                p.Add("@vehicleregrecordedornot", objInspectionReportmaster.MonthlyStatusCertificate);
                p.Add("@Totaladvancedemandedbythecampofficer", objInspectionReportmaster.Totaladvancedemandedbythecampofficer);
                p.Add("@Advanceamountreceived", objInspectionReportmaster.Advanceamountreceived);
                p.Add("@AmountSpentPOL", objInspectionReportmaster.AmountSpentPOL);
                p.Add("@AmountSpentImprovementWork", objInspectionReportmaster.AmountSpentImprovementWork);
                p.Add("@AmountSpentExpenditureonotheritems", objInspectionReportmaster.AmountSpentExpenditureonotheritems);
                p.Add("@LastExpendituresheetsubmittedbycampofficer", objInspectionReportmaster.LastExpendituresheetsubmittedbycampofficer);
                p.Add("@Statusofregistrationmaintainedinthecamp", objInspectionReportmaster.Statusofregistrationmaintainedinthecamp);
                p.Add("@WaterSupplyPumpStatus", objInspectionReportmaster.WaterSupplyPumpStatus);
                p.Add("@AmountSpentLabour", objInspectionReportmaster.AmountSpentLabour);
                p.Add("@GeologyInspectionReportId", objInspectionReportmaster.geologyId);
                p.Add("@Post", objInspectionReportmaster.Post);
                p.Add("@CampOfficeStaffDetails", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.CampOfficeStaffDetails).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@InformationAboutDrillingMachines", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.InformationAboutDrillingMachines).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@NumberAndTypeOfVehicles", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.NumberAndTypeOfVehicles).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@SurveyEquipment", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.SurveyEquipment).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@InformationOnProgressOfRegionalWork", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.InformationOnProgressOfRegionalWork).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@StatusAndProgressOfDrilling", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.StatusAndProgressOfDrilling).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@TotalSupplyVehiclesAndTheirTypes", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.TotalSupplyVehiclesAndTheirTypes).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@TotalExpeditureAfter1stExpediture", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.TotalExpeditureAfter1stExpediture).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                p.Add("@FuelConsumptionAverageOfTheVehicle", Newtonsoft.Json.JsonConvert.SerializeObject(objInspectionReportmaster.FuelConsumptionAverageOfTheVehicle).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' }));
                string response = await Connection.QueryFirstAsync<string>("USP_GEOLOGY_INSERT", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "true";
                    objMessage.Msg = "Data Updated Successfully";
                }

                else
                {
                    objMessage.Satus = "false";
                    objMessage.Msg = "something went wrong";

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

    }
}
