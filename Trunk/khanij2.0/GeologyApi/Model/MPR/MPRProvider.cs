// ***********************************************************************
//  Class Name               : MPRProvider
//  Desciption               : CRUD,Create,Approve,Forward Monthly Progress Report
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2021
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

namespace GeologyApi.Model.MPR
{
    public class MPRProvider : RepositoryBase, IMPRProvider
    {
        #region MPR Creator
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public MPRProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To Add the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddMPRMaster(MPRmaster objMPRMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FPO_Id", objMPRMaster.FPO_Id);
                p.Add("Report_MY", objMPRMaster.Report_MY);
                p.Add("UserId", objMPRMaster.UserId);
                objMPRMaster.ReportType = objMPRMaster.ReportType == "1" ? "Submission" : "Resubmission";
                p.Add("ReportType", objMPRMaster.ReportType);
                p.Add("SubmissionDate", objMPRMaster.SubmissionDate);
                p.Add("Officer_Id", objMPRMaster.UserId);
                p.Add("Officer_Designation", objMPRMaster.Designation);
                p.Add("Authority_Id", objMPRMaster.Authority_Id);
                p.Add("Authority_Designation", objMPRMaster.AuthorityDesignation);
                p.Add("MineralID", objMPRMaster.MineralID);
                p.Add("Lo_Area_Latitute", objMPRMaster.LatituteDetails);
                p.Add("Lo_Area_Longitute", objMPRMaster.LongituteDetails);
                p.Add("TopoSheetNo", objMPRMaster.TopoSheet_NoDetails);
                p.Add("RegionalID", objMPRMaster.RegionalID);
                p.Add("DistrictID", objMPRMaster.DistrictID);
                p.Add("TehsilID", objMPRMaster.TehsilID);
                p.Add("VillageID", objMPRMaster.VillageID);
                p.Add("Block", objMPRMaster.BlockName);
                p.Add("RegionalOffice", objMPRMaster.RegionalOfficeId);
                p.Add("Approve_Status", objMPRMaster.Approve_Status);
                p.Add("IsActive", objMPRMaster.IsActive);
                p.Add("UserLoginId", objMPRMaster.UserLoginId);
                p.Add("Remarks", objMPRMaster.Remarks);
                p.Add("PinCode", objMPRMaster.PinCode);
                p.Add("PostOffice", objMPRMaster.PostOffice);
                p.Add("chk", "INSERT");
                string response = await Connection.QueryFirstAsync<string>("MPR_Procedure", p, commandType: CommandType.StoredProcedure);
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
        /// To View the Monthly Progress Report list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public async Task<List<MPRmaster>> ViewMPRMaster(MPRmaster objMPRMaster)
        {
            List<MPRmaster> ListMPRMaster = new List<MPRmaster>();
            try
            {
                var paramList = new
                {
                    chk = "Select",
                };
                var Output = await Connection.QueryAsync<MPRmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ListMPRMaster = Output.ToList();
                }
                return ListMPRMaster;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// To Edit the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MPRmaster> EditMPRMaster(MPRmaster objMPRMaster)
        {
            MPRmaster LobjMPRMaster = new MPRmaster();
            try
            {
                var paramList = new
                {
                    MPR_Id = objMPRMaster.MPR_Id,
                    chk = "Select",
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<MPRmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// <summary>
        /// To Delete the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteMPRMaster(MPRmaster objMPRMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var _param = new DynamicParameters();
                _param.Add("MPR_Id", objMPRMaster.MPR_Id);
                _param.Add("chk", "DELETE");
                _param.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("MPR_Procedure", _param, commandType: CommandType.StoredProcedure);
                int newID = _param.Get<int>("Output");
                string response = newID.ToString();
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
        /// To Update the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateMPRMaster(MPRmaster objMPRMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MPR_Id", objMPRMaster.MPR_Id);
                p.Add("FPO_Id", objMPRMaster.FPO_Id);
                p.Add("Report_MY", objMPRMaster.Report_MY);
                p.Add("UserId", objMPRMaster.UserId = 1);
                if (string.IsNullOrEmpty(objMPRMaster.ReportType))
                {
                    objMPRMaster.ReportType = "Submission";
                }
                p.Add("ReportType", objMPRMaster.ReportType);
                p.Add("SubmissionDate", objMPRMaster.SubmissionDate);
                p.Add("Officer_Id", objMPRMaster.UserId);
                p.Add("Officer_Designation", objMPRMaster.Designation);
                p.Add("Authority_Id", objMPRMaster.Authority_Id);
                p.Add("Authority_Designation", objMPRMaster.AuthorityDesignation);
                p.Add("MineralID", objMPRMaster.MineralID);
                p.Add("Lo_Area_Latitute", objMPRMaster.LatituteDetails);
                p.Add("Lo_Area_Longitute", objMPRMaster.LongituteDetails);
                p.Add("TopoSheetNo", objMPRMaster.TopoSheet_NoDetails);
                p.Add("RegionalID", objMPRMaster.RegionalID);
                p.Add("DistrictID", objMPRMaster.DistrictID);
                p.Add("TehsilID", objMPRMaster.TehsilID);
                p.Add("VillageID", objMPRMaster.VillageID);
                p.Add("Block", objMPRMaster.BlockName);
                p.Add("RegionalOffice", objMPRMaster.RegionalOfficeId);
                p.Add("Approve_Status", objMPRMaster.Approve_Status = 0);
                p.Add("IsActive", objMPRMaster.IsActive);
                p.Add("UserLoginId", objMPRMaster.UserLoginId = 1);
                p.Add("Remarks", objMPRMaster.Remarks);
                p.Add("PinCode", objMPRMaster.PinCode);
                p.Add("PostOffice", objMPRMaster.PostOffice);
                p.Add("IsActive", objMPRMaster.IsActive);
                p.Add("chk", "UPDATE");
                string response = await Connection.QueryFirstAsync<string>("MPR_Procedure", p, commandType: CommandType.StoredProcedure);
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
        /// To Get the Officer details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MPRmaster> GetOfficerNameAndDesignation(MPRmaster objMPRMaster)
        {
            MPRmaster LobjMPRMaster = new MPRmaster();
            try
            {
                var paramList = new
                {
                    UserId = objMPRMaster.UserId,
                    chk = "GET_OFFICER_NAME_AND_DESIGNATION"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<MPRmaster>("Geology_FPO_OrderOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// <summary>
        /// To Get the Field Program Order details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MPRmaster> GetFPOdetailsByFPOCode(MPRmaster objMPRMaster)
        {
            MPRmaster LobjMPRMaster = new MPRmaster();
            try
            {
                var paramList = new
                {
                    FPO_Id = objMPRMaster.FPO_Id,
                    chk = "GET_FPO_DATE"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<MPRmaster>("Geology_FPO_OrderOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// <summary>
        /// To send the data for approval
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> SendForApproval(MPRmaster objMPRMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("chk", "SEND_FOR_APPROVAL");
                p.Add("Approve_Status", objMPRMaster.Approve_Status);
                p.Add("MPR_Id", objMPRMaster.MPR_Id);
                p.Add("UserId", objMPRMaster.UserId);
                p.Add("UserLoginId", objMPRMaster.UserLoginId);
                string response = await Connection.QueryFirstAsync<string>("MPR_Procedure", p, commandType: CommandType.StoredProcedure);
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
        /// To Get the Mail details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MPRmaster> GetMaildata(MPRmaster objMPRMaster)
        {
            MPRmaster LobjMPRMaster = new MPRmaster();
            try
            {
                var paramList = new
                {
                    MPR_Id = objMPRMaster.MPR_Id,
                    UserId = objMPRMaster.UserId,
                    chk = "FETCH_DATA"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<MPRmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// <summary>
        /// To Preview the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MPRmaster> PreviewMPRMaster(MPRmaster objMPRMaster)
        {
            MPRmaster ListMPRMaster = new MPRmaster();
            try
            {
                var paramList = new
                {
                    MPR_ID = objMPRMaster.MPR_Id
                };
                var Output = await Connection.QueryAsync<MPRmaster>("SP_MPR_Approval", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ListMPRMaster = Output.FirstOrDefault();
                }
                return ListMPRMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Dropdowns
        /// <summary>
        /// To bind the Monthly Progress Report code list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<MPRmaster>> GetMPRCodeList(MPRmaster objMPRMaster)
        {
            List<MPRmaster> ObjMPRCodeList = new List<MPRmaster>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<MPRmaster>("uspGetFpoDropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To bind the Mineral list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<MPRmaster>> GetMineralList(MPRmaster objMPRMaster)
        {
            List<MPRmaster> ObjMineralNameList = new List<MPRmaster>();
            try
            {
                var paramList = new
                {
                    chk = "5"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<MPRmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjMineralNameList = Output.ToList();
                }
                return ObjMineralNameList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind the Division list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<MPRmaster>> GetDivisionList(MPRmaster objMPRMaster)
        {
            List<MPRmaster> ObjDivisionList = new List<MPRmaster>();
            try
            {
                var paramList = new
                {
                    chk = "6"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<MPRmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjDivisionList = Output.ToList();
                }
                return ObjDivisionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind the District list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<MPRmaster>> GetDistrictList(MPRmaster objMPRMaster)
        {
            List<MPRmaster> ObjDistrictList = new List<MPRmaster>();
            try
            {
                var paramList = new
                {
                    RegionalId = objMPRMaster.RegionalID,
                    chk = "7"
                };
                DynamicParameters param = new DynamicParameters();

                var Output = await Connection.QueryAsync<MPRmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    ObjDistrictList = Output.ToList();
                }

                return ObjDistrictList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To bind the Tehsil list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<MPRmaster>> GetTehsilList(MPRmaster objMPRMaster)
        {
            List<MPRmaster> ObjTehsilList = new List<MPRmaster>();
            try
            {
                var paramList = new
                {
                    DistrictID = objMPRMaster.DistrictID,
                    chk = "8"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<MPRmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjTehsilList = Output.ToList();
                }
                return ObjTehsilList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind the Village list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<MPRmaster>> GetVillageList(MPRmaster objMPRMaster)
        {
            List<MPRmaster> ObjVillageList = new List<MPRmaster>();
            try
            {
                var paramList = new
                {
                    TehsilID = objMPRMaster.TehsilID,
                    chk = "9"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<MPRmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjVillageList = Output.ToList();
                }
                return ObjVillageList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind the Regional list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<MPRmaster>> GetRegionalOfficeList(MPRmaster objMPRMaster)
        {
            List<MPRmaster> ObjRegionalOfficeList = new List<MPRmaster>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<MPRmaster>("uspGetRegoinalOffice", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjRegionalOfficeList = Output.ToList();
                }
                return ObjRegionalOfficeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion
        #region MPR Approver
        /// <summary>
        /// To bind the Monthly Progress Report approver list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<MPRmaster>> ViewMPRApprover(MPRmaster objMPRMaster)
        {
            List<MPRmaster> ListMPRMaster = new List<MPRmaster>();
            try
            {
                var paramList = new
                {
                    chk = "SELECT_FOR_APPROVAL",
                };
                var Output = await Connection.QueryAsync<MPRmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ListMPRMaster = Output.ToList();
                }
                return ListMPRMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update the Monthly Progress Report status
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateMPR_Status(MPRmaster objMPRMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("chk", "APPROVE");
                p.Add("MPR_Id", objMPRMaster.MPR_Id);
                p.Add("Remarks", objMPRMaster.Remarks);
                p.Add("UserId", objMPRMaster.UserId);
                string response = await Connection.QueryFirstAsync<string>("MPR_Procedure", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Update the Monthly Progress Report refer status
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateMPR_Referback(MPRmaster objMPRMaster)
        {
           MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("chk", "APPROVER_REFER_BACK");
                p.Add("MPR_Id", objMPRMaster.MPR_Id);
                p.Add("Remarks", objMPRMaster.Remarks);
                p.Add("UserId", objMPRMaster.UserId);
                string response = await Connection.QueryFirstAsync<string>("MPR_Procedure", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        #endregion
        #region MPR Forwarder
        /// <summary>
        /// To bind the Monthly Progress Report Forwarder list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<MPRmaster>> ViewMPRForwarder(MPRmaster objMPRMaster)
        {
            List<MPRmaster> ListMPRMaster = new List<MPRmaster>();
            try
            {
                var paramList = new
                {
                    chk = "SELECT_FOR_FORWARDER",
                    UserId = objMPRMaster.UserId
                };
                var Output = await Connection.QueryAsync<MPRmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ListMPRMaster = Output.ToList();
                }
                return ListMPRMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Forward the Monthly Progress Report Forwarder list details data to DGM
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> FORWARD_TO_DGM(MPRmaster objMPRMaster)
        {
           MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("chk", "FORWARD_TO_DGM");
                p.Add("MPR_Id", objMPRMaster.MPR_Id);
                p.Add("UserId", objMPRMaster.UserId);
                string response = await Connection.QueryFirstAsync<string>("MPR_Procedure", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Forward refer back the Monthly Progress Report Forwarder list details data to DGM
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> FORWARDER_REFER_BACK(MPRmaster objMPRMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("chk", "FORWARDER_REFER_BACK");
                p.Add("MPR_Id", objMPRMaster.MPR_Id);
                p.Add("RegionalHead_Remarks", objMPRMaster.Remarks);
                p.Add("UserId", objMPRMaster.UserId);
                string response = await Connection.QueryFirstAsync<string>("MPR_Procedure", p, commandType: CommandType.StoredProcedure);
                if (response == "1")
                {
                    objMessage.Satus = "1";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion
        #region MPR Work
        /// <summary>
        /// To Add the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddMPRWorkMaster(MPRWorkmaster objMPRMaster)
        {
           MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MPR_Id", objMPRMaster.MPR_Id);
                p.Add("WorkType_Id", objMPRMaster.WorkType_Id);
                p.Add("Volume_ofWork", objMPRMaster.Volume_ofWork);
                p.Add("UnitID", objMPRMaster.UnitID);
                p.Add("Location_NewM", objMPRMaster.Location_NewM);
                p.Add("Resources", objMPRMaster.Resources);
                p.Add("No_ofEmployees", objMPRMaster.No_ofEmployees);
                p.Add("TotalExp", objMPRMaster.TotalExp);
                p.Add("Map", objMPRMaster.Map);
                p.Add("MapName", objMPRMaster.MapName);
                p.Add("BoreholeLogs", objMPRMaster.BoreholeLogs);
                p.Add("LogName", objMPRMaster.LogName);
                p.Add("Synopsis", objMPRMaster.Synopsis);
                p.Add("SynopsisName", objMPRMaster.SynopsisName);
                p.Add("Other_Info", objMPRMaster.Other_Info);
                p.Add("OtherName", objMPRMaster.OtherName);
                p.Add("Up_To_The_Last_Month", objMPRMaster.Up_To_The_Last_Month);
                p.Add("During_The_Month", objMPRMaster.During_The_Month);
                p.Add("Reconn_Area_Target", objMPRMaster.Reconn_Area_Target);
                p.Add("Reconn_Area_Last_Month", objMPRMaster.Reconn_Area_Last_Month);
                p.Add("Reconn_Area_During_Month", objMPRMaster.Reconn_Area_During_Month);
                p.Add("Reconn_Area_Current_Month", objMPRMaster.Reconn_Area_Current_Month);
                p.Add("Detailed_Area_Target", objMPRMaster.Detailed_Area_Target);
                p.Add("Detailed_Area_Last_Month", objMPRMaster.Detailed_Area_Last_Month);
                p.Add("Detailed_Area_During_Month", objMPRMaster.Detailed_Area_During_Month);
                p.Add("Detailed_Area_Current_Month", objMPRMaster.Detailed_Area_Current_Month);
                p.Add("Pitting_Nos_Target", objMPRMaster.Pitting_Nos_Target);
                p.Add("Pitting_Nos_Last_Month", objMPRMaster.Pitting_Nos_Last_Month);
                p.Add("Pitting_Nos_During_Month", objMPRMaster.Pitting_Nos_During_Month);
                p.Add("Pitting_Nos_Current_Month", objMPRMaster.Pitting_Nos_Current_Month);
                p.Add("Pitting_Volume_Target", objMPRMaster.Pitting_Volume_Target);
                p.Add("Pitting_Volume_Last_Month", objMPRMaster.Pitting_Volume_Last_Month);
                p.Add("Pitting_Volume_During_Month", objMPRMaster.Pitting_Volume_During_Month);
                p.Add("Pitting_Volume_Current_Month", objMPRMaster.Pitting_Volume_Current_Month);
                p.Add("Trenching_Nos_Target", objMPRMaster.Trenching_Nos_Target);
                p.Add("Trenching_Nos_Last_Month", objMPRMaster.Trenching_Nos_Last_Month);
                p.Add("Trenching_Nos_During_Month", objMPRMaster.Trenching_Nos_During_Month);
                p.Add("Trenching_Nos_Current_Month", objMPRMaster.Trenching_Nos_Current_Month);
                p.Add("Trenching_Volume_Target", objMPRMaster.Trenching_Volume_Target);
                p.Add("Trenching_Volume_Last_Month", objMPRMaster.Trenching_Volume_Last_Month);
                p.Add("Trenching_Volume_During_Month", objMPRMaster.Trenching_Volume_During_Month);
                p.Add("Trenching_Volume_Current_Month", objMPRMaster.Trenching_Volume_Current_Month);
                p.Add("B_H_Cpmpleted_Target", objMPRMaster.B_H_Cpmpleted_Target);
                p.Add("B_H_Cpmpleted_Last_Month", objMPRMaster.B_H_Cpmpleted_Last_Month);
                p.Add("B_H_Cpmpleted_During_Month", objMPRMaster.B_H_Cpmpleted_During_Month);
                p.Add("B_H_Cpmpleted_Current_Month", objMPRMaster.B_H_Cpmpleted_Current_Month);
                p.Add("Metrage_Target", objMPRMaster.Metrage_Target);
                p.Add("Metrage_Last_Month", objMPRMaster.Metrage_Last_Month);
                p.Add("Metrage_During_Month", objMPRMaster.Metrage_During_Month);
                p.Add("Metrage_Current_Month", objMPRMaster.Metrage_Current_Month);
                p.Add("Metrage_2_Target", objMPRMaster.Metrage_2_Target);
                p.Add("Metrage_2_Last_Month", objMPRMaster.Metrage_2_Last_Month);
                p.Add("Metrage_2_During_Month", objMPRMaster.Metrage_2_During_Month);
                p.Add("Metrage_2_Current_Month", objMPRMaster.Metrage_2_Current_Month);
                p.Add("B_H_Under_Progress_Target", objMPRMaster.B_H_Under_Progress_Target);
                p.Add("B_H_Under_Progress_Last_Month", objMPRMaster.B_H_Under_Progress_Last_Month);
                p.Add("B_H_Under_Progress_During_Month", objMPRMaster.B_H_Under_Progress_During_Month);
                p.Add("B_H_Under_Progress_Current_Month", objMPRMaster.B_H_Under_Progress_Current_Month);
                p.Add("Total_Metrage_Target", objMPRMaster.Total_Metrage_Target);
                p.Add("Total_Metrage_Last_Month", objMPRMaster.Total_Metrage_Last_Month);
                p.Add("Total_Metrage_During_Month", objMPRMaster.Total_Metrage_During_Month);
                p.Add("Total_Metrage_Current_Month", objMPRMaster.Total_Metrage_Current_Month);
                p.Add("Geochemical_Sampling_Target", objMPRMaster.Geochemical_Sampling_Target);
                p.Add("Geochemical_Sampling_Last_Month", objMPRMaster.Geochemical_Sampling_Last_Month);
                p.Add("Geochemical_Samplinge_During_Month", objMPRMaster.Geochemical_Samplinge_During_Month);
                p.Add("Geochemical_Sampling_Current_Month", objMPRMaster.Geochemical_Sampling_Current_Month);
                p.Add("Geophysical_Survey_Target", objMPRMaster.Geophysical_Survey_Target);
                p.Add("Geophysical_Survey_Last_Month", objMPRMaster.Geophysical_Survey_Last_Month);
                p.Add("Geophysical_Survey_During_Month", objMPRMaster.Geophysical_Survey_During_Month);
                p.Add("Geophysical_Survey_Current_Month", objMPRMaster.Geophysical_Survey_Current_Month);
                p.Add("Prefield_Interpretation_Target", objMPRMaster.Prefield_Interpretation_Target);
                p.Add("Prefield_Interpretation_Last_Month", objMPRMaster.Prefield_Interpretation_Last_Month);
                p.Add("Prefield_Interpretation_During_Month", objMPRMaster.Prefield_Interpretation_During_Month);
                p.Add("Prefield_Interpretation_Current_Month", objMPRMaster.Prefield_Interpretation_Current_Month);
                p.Add("Postfield_Interpretation_Target", objMPRMaster.Postfield_Interpretation_Target);
                p.Add("Postfield_Interpretation_Last_Month", objMPRMaster.Postfield_Interpretation_Last_Month);
                p.Add("Postfield_Interpretation_During_Month", objMPRMaster.Postfield_Interpretation_During_Month);
                p.Add("Postfield_Interpretation_Current_Month", objMPRMaster.Postfield_Interpretation_Current_Month);
                p.Add("Field_Check_Target", objMPRMaster.Field_Check_Target);
                p.Add("Field_Check_Last_Month", objMPRMaster.Field_Check_Last_Month);
                p.Add("Field_Check_During_Month", objMPRMaster.Field_Check_During_Month);
                p.Add("Field_Check_Current_Month", objMPRMaster.Field_Check_Current_Month);
                p.Add("Sample_Drawn_Target", objMPRMaster.Sample_Drawn_Target);
                p.Add("Sample_Drawn_Last_Month", objMPRMaster.Sample_Drawn_Last_Month);
                p.Add("Sample_Drawn_During_Month", objMPRMaster.Sample_Drawn_During_Month);
                p.Add("Sample_Drawn_Current_Month", objMPRMaster.Sample_Drawn_Current_Month);
                p.Add("Sample_Prepared_Target", objMPRMaster.Sample_Prepared_Target);
                p.Add("Sample_Prepared_Last_Month", objMPRMaster.Sample_Prepared_Last_Month);
                p.Add("Sample_Prepared_During_Month", objMPRMaster.Sample_Prepared_During_Month);
                p.Add("Sample_Prepared_Current_Month", objMPRMaster.Sample_Prepared_Current_Month);
                p.Add("Sample_Sent_For_Chemical_Analysis_Target", objMPRMaster.Sample_Sent_For_Chemical_Analysis_Target);
                p.Add("Sample_Sent_For_Chemical_Analysis_Last_Month", objMPRMaster.Sample_Sent_For_Chemical_Analysis_Last_Month);
                p.Add("Sample_Sent_For_Chemical_Analysis_During_Month", objMPRMaster.Sample_Sent_For_Chemical_Analysis_During_Month);
                p.Add("Sample_Sent_For_Chemical_Analysis_Current_Month", objMPRMaster.Sample_Sent_For_Chemical_Analysis_Current_Month);
                p.Add("Sample_Sent_For_Petrography_Target", objMPRMaster.Sample_Sent_For_Petrography_Target);
                p.Add("Sample_Sent_For_Petrography_Last_Month", objMPRMaster.Sample_Sent_For_Petrography_Last_Month);
                p.Add("Sample_Sent_For_Petrography_During_Month", objMPRMaster.Sample_Sent_For_Petrography_During_Month);
                p.Add("Sample_Sent_For_Petrography_Current_Month", objMPRMaster.Sample_Sent_For_Petrography_Current_Month);
                p.Add("Inferred_Target", objMPRMaster.Inferred_Target);
                p.Add("Inferred_Last_Month", objMPRMaster.Inferred_Last_Month);
                p.Add("Inferred_During_Month", objMPRMaster.Inferred_During_Month);
                p.Add("Inferred_Current_Month", objMPRMaster.Inferred_Current_Month);
                p.Add("Estimated_Target", objMPRMaster.Estimated_Target);
                p.Add("Estimated_Last_Month", objMPRMaster.Estimated_Last_Month);
                p.Add("Estimated_During_Month", objMPRMaster.Estimated_During_Month);
                p.Add("Estimated_Current_Month", objMPRMaster.Estimated_Current_Month);
                p.Add("Proved_Target", objMPRMaster.Proved_Target);
                p.Add("Proved_Last_Month", objMPRMaster.Proved_Last_Month);
                p.Add("Proved_During_Month", objMPRMaster.Proved_During_Month);
                p.Add("Proved_Current_Month", objMPRMaster.Proved_Current_Month);
                p.Add("Laying_Of_Base_Line_Target", objMPRMaster.Laying_Of_Base_Line_Target);
                p.Add("Laying_Of_Base_Line_Last_Month", objMPRMaster.Laying_Of_Base_Line_Last_Month);
                p.Add("Laying_Of_Base_Line_During_Month", objMPRMaster.Laying_Of_Base_Line_During_Month);
                p.Add("Laying_Of_Base_Line_Current_Month", objMPRMaster.Laying_Of_Base_Line_Current_Month);
                p.Add("Laying_Of_Grids_Target", objMPRMaster.Laying_Of_Grids_Target);
                p.Add("Laying_Of_Grids_Last_Month", objMPRMaster.Laying_Of_Grids_Last_Month);
                p.Add("Laying_Of_Grids_During_Month", objMPRMaster.Laying_Of_Grids_During_Month);
                p.Add("Laying_Of_Grids_Current_Month", objMPRMaster.Laying_Of_Grids_Current_Month);
                p.Add("No_of_Pits_Target", objMPRMaster.No_of_Pits_Target);
                p.Add("No_of_Pits_Last_Month", objMPRMaster.No_of_Pits_Last_Month);
                p.Add("No_of_Pits_During_Month", objMPRMaster.No_of_Pits_During_Month);
                p.Add("No_of_Pits_Current_Month", objMPRMaster.No_of_Pits_Current_Month);
                p.Add("Co_ordinates_Of_Pits_Target", objMPRMaster.Co_ordinates_Of_Pits_Target);
                p.Add("Co_ordinates_Of_Pits_Last_Month", objMPRMaster.Co_ordinates_Of_Pits_Last_Month);
                p.Add("Co_ordinates_Of_Pits_During_Month", objMPRMaster.Co_ordinates_Of_Pits_During_Month);
                p.Add("Co_ordinates_Of_Pits_Current_Month", objMPRMaster.Co_ordinates_Of_Pits_Current_Month);
                p.Add("Contouring_Target", objMPRMaster.Contouring_Target);
                p.Add("Contouring_Last_Month", objMPRMaster.Contouring_Last_Month);
                p.Add("Contouring_During_Month", objMPRMaster.Contouring_During_Month);
                p.Add("Contouring_Current_Month", objMPRMaster.Contouring_Current_Month);
                p.Add("Plotting_Of_Permanent_Features_Target", objMPRMaster.Plotting_Of_Permanent_Features_Target);
                p.Add("Plotting_Of_Permanent_Features_Last_Month", objMPRMaster.Plotting_Of_Permanent_Features_Last_Month);
                p.Add("Plotting_Of_Permanent_Features_During_Month", objMPRMaster.Plotting_Of_Permanent_Features_During_Month);
                p.Add("Plotting_Of_Permanent_Features_Current_Month", objMPRMaster.Plotting_Of_Permanent_Features_Current_Month);
                p.Add("Plotting_Of_Road_Nala_Target", objMPRMaster.Plotting_Of_Road_Nala_Target);
                p.Add("Plotting_Of_Road_Nala_Last_Month", objMPRMaster.Plotting_Of_Road_Nala_Last_Month);
                p.Add("Plotting_Of_Road_Nala_During_Month", objMPRMaster.Plotting_Of_Road_Nala_During_Month);
                p.Add("Plotting_Of_Road_Nala_Current_Month", objMPRMaster.Plotting_Of_Road_Nala_Current_Month);
                p.Add("Labor", objMPRMaster.Labor);
                p.Add("POL", objMPRMaster.POL);
                p.Add("Repair_And_Maintenance", objMPRMaster.Repair_And_Maintenance);
                p.Add("others", objMPRMaster.others);
                p.Add("Total", objMPRMaster.Total);
                p.Add("Camps_Name", objMPRMaster.Camps_Namedetails);
                p.Add("Camps_Designation", objMPRMaster.Camps_Designationdetails);
                p.Add("Camps_From", objMPRMaster.Camps_Fromdetails);
                p.Add("Camps_To", objMPRMaster.Camps_Todetails);
                p.Add("Camps_No_Of_Days", objMPRMaster.Camps_No_Of_Daysdetails);
                p.Add("Camps_Remarks", objMPRMaster.Camps_Remarksdetails);
                p.Add("UserId", objMPRMaster.UserId);
                p.Add("UserLoginId", objMPRMaster.UserLoginId);
                p.Add("chk", "INSERT");
                string response = await Connection.QueryFirstAsync<string>("MPR_Work_Procedure", p, commandType: CommandType.StoredProcedure);
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
        /// To View the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        public async Task<List<MPRWorkmaster>> ViewMPRWorkMaster(MPRWorkmaster objMPRMaster)
        {
            List<MPRWorkmaster> ListMPRWorkMaster = new List<MPRWorkmaster>();
            try
            {
                var paramList = new
                {
                    chk = "GET_DATA",
                    MPR_Id = objMPRMaster.MPR_Id
                };
                var Output = await Connection.QueryAsync<MPRWorkmaster>("MPR_Work_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ListMPRWorkMaster = Output.ToList();
                }
                return ListMPRWorkMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Edit the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        public async Task<MPRWorkmaster> EditMPRWorkMaster(MPRWorkmaster objMPRMaster)
        {
            MPRWorkmaster LobjMPRMaster = new MPRWorkmaster();
            try
            {
                var paramList = new
                {
                    chk = "GET_DATA",
                    MPR_Id = objMPRMaster.MPR_Id
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<MPRWorkmaster>("MPR_Work_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// <summary>
        /// To Delete the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteMPRWorkMaster(MPRWorkmaster objMPRMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Work_Id", objMPRMaster.Work_Id);
                p.Add("chk", "DELETE");
                string response = await Connection.QueryFirstAsync<string>("MPR_Work_Procedure", p, commandType: CommandType.StoredProcedure);
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
        /// To Update the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateMPRWorkMaster(MPRWorkmaster objMPRMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("MPR_Id", objMPRMaster.MPR_Id);
                p.Add("Work_Id", objMPRMaster.Work_Id);
                p.Add("WorkType_Id", objMPRMaster.WorkType_Id);
                p.Add("Volume_ofWork", objMPRMaster.Volume_ofWork);
                p.Add("UnitID", objMPRMaster.UnitID);
                p.Add("Location_NewM", objMPRMaster.Location_NewM);
                p.Add("Resources", objMPRMaster.Resources);
                p.Add("No_ofEmployees", objMPRMaster.No_ofEmployees);
                p.Add("TotalExp", objMPRMaster.TotalExp);
                p.Add("Map", objMPRMaster.Map);
                p.Add("MapName", objMPRMaster.MapName);
                p.Add("BoreholeLogs", objMPRMaster.BoreholeLogs);
                p.Add("LogName", objMPRMaster.LogName);
                p.Add("Synopsis", objMPRMaster.Synopsis);
                p.Add("SynopsisName", objMPRMaster.SynopsisName);
                p.Add("Other_Info", objMPRMaster.Other_Info);
                p.Add("OtherName", objMPRMaster.OtherName);
                p.Add("Up_To_The_Last_Month", objMPRMaster.Up_To_The_Last_Month);
                p.Add("During_The_Month", objMPRMaster.During_The_Month);
                p.Add("Reconn_Area_Target", objMPRMaster.Reconn_Area_Target);
                p.Add("Reconn_Area_Last_Month", objMPRMaster.Reconn_Area_Last_Month);
                p.Add("Reconn_Area_During_Month", objMPRMaster.Reconn_Area_During_Month);
                p.Add("Reconn_Area_Current_Month", objMPRMaster.Reconn_Area_Current_Month);
                p.Add("Detailed_Area_Target", objMPRMaster.Detailed_Area_Target);
                p.Add("Detailed_Area_Last_Month", objMPRMaster.Detailed_Area_Last_Month);
                p.Add("Detailed_Area_During_Month", objMPRMaster.Detailed_Area_During_Month);
                p.Add("Detailed_Area_Current_Month", objMPRMaster.Detailed_Area_Current_Month);
                p.Add("Pitting_Nos_Target", objMPRMaster.Pitting_Nos_Target);
                p.Add("Pitting_Nos_Last_Month", objMPRMaster.Pitting_Nos_Last_Month);
                p.Add("Pitting_Nos_During_Month", objMPRMaster.Pitting_Nos_During_Month);
                p.Add("Pitting_Nos_Current_Month", objMPRMaster.Pitting_Nos_Current_Month);
                p.Add("Pitting_Volume_Target", objMPRMaster.Pitting_Volume_Target);
                p.Add("Pitting_Volume_Last_Month", objMPRMaster.Pitting_Volume_Last_Month);
                p.Add("Pitting_Volume_During_Month", objMPRMaster.Pitting_Volume_During_Month);
                p.Add("Pitting_Volume_Current_Month", objMPRMaster.Pitting_Volume_Current_Month);
                p.Add("Trenching_Nos_Target", objMPRMaster.Trenching_Nos_Target);
                p.Add("Trenching_Nos_Last_Month", objMPRMaster.Trenching_Nos_Last_Month);
                p.Add("Trenching_Nos_During_Month", objMPRMaster.Trenching_Nos_During_Month);
                p.Add("Trenching_Nos_Current_Month", objMPRMaster.Trenching_Nos_Current_Month);
                p.Add("Trenching_Volume_Target", objMPRMaster.Trenching_Volume_Target);
                p.Add("Trenching_Volume_Last_Month", objMPRMaster.Trenching_Volume_Last_Month);
                p.Add("Trenching_Volume_During_Month", objMPRMaster.Trenching_Volume_During_Month);
                p.Add("Trenching_Volume_Current_Month", objMPRMaster.Trenching_Volume_Current_Month);
                p.Add("B_H_Cpmpleted_Target", objMPRMaster.B_H_Cpmpleted_Target);
                p.Add("B_H_Cpmpleted_Last_Month", objMPRMaster.B_H_Cpmpleted_Last_Month);
                p.Add("B_H_Cpmpleted_During_Month", objMPRMaster.B_H_Cpmpleted_During_Month);
                p.Add("B_H_Cpmpleted_Current_Month", objMPRMaster.B_H_Cpmpleted_Current_Month);
                p.Add("Metrage_Target", objMPRMaster.Metrage_Target);
                p.Add("Metrage_Last_Month", objMPRMaster.Metrage_Last_Month);
                p.Add("Metrage_During_Month", objMPRMaster.Metrage_During_Month);
                p.Add("Metrage_Current_Month", objMPRMaster.Metrage_Current_Month);
                p.Add("Metrage_2_Target", objMPRMaster.Metrage_2_Target);
                p.Add("Metrage_2_Last_Month", objMPRMaster.Metrage_2_Last_Month);
                p.Add("Metrage_2_During_Month", objMPRMaster.Metrage_2_During_Month);
                p.Add("Metrage_2_Current_Month", objMPRMaster.Metrage_2_Current_Month);
                p.Add("B_H_Under_Progress_Target", objMPRMaster.B_H_Under_Progress_Target);
                p.Add("B_H_Under_Progress_Last_Month", objMPRMaster.B_H_Under_Progress_Last_Month);
                p.Add("B_H_Under_Progress_During_Month", objMPRMaster.B_H_Under_Progress_During_Month);
                p.Add("B_H_Under_Progress_Current_Month", objMPRMaster.B_H_Under_Progress_Current_Month);
                p.Add("Total_Metrage_Target", objMPRMaster.Total_Metrage_Target);
                p.Add("Total_Metrage_Last_Month", objMPRMaster.Total_Metrage_Last_Month);
                p.Add("Total_Metrage_During_Month", objMPRMaster.Total_Metrage_During_Month);
                p.Add("Total_Metrage_Current_Month", objMPRMaster.Total_Metrage_Current_Month);
                p.Add("Geochemical_Sampling_Target", objMPRMaster.Geochemical_Sampling_Target);
                p.Add("Geochemical_Sampling_Last_Month", objMPRMaster.Geochemical_Sampling_Last_Month);
                p.Add("Geochemical_Samplinge_During_Month", objMPRMaster.Geochemical_Samplinge_During_Month);
                p.Add("Geochemical_Sampling_Current_Month", objMPRMaster.Geochemical_Sampling_Current_Month);
                p.Add("Geophysical_Survey_Target", objMPRMaster.Geophysical_Survey_Target);
                p.Add("Geophysical_Survey_Last_Month", objMPRMaster.Geophysical_Survey_Last_Month);
                p.Add("Geophysical_Survey_During_Month", objMPRMaster.Geophysical_Survey_During_Month);
                p.Add("Geophysical_Survey_Current_Month", objMPRMaster.Geophysical_Survey_Current_Month);
                p.Add("Prefield_Interpretation_Target", objMPRMaster.Prefield_Interpretation_Target);
                p.Add("Prefield_Interpretation_Last_Month", objMPRMaster.Prefield_Interpretation_Last_Month);
                p.Add("Prefield_Interpretation_During_Month", objMPRMaster.Prefield_Interpretation_During_Month);
                p.Add("Prefield_Interpretation_Current_Month", objMPRMaster.Prefield_Interpretation_Current_Month);
                p.Add("Postfield_Interpretation_Target", objMPRMaster.Postfield_Interpretation_Target);
                p.Add("Postfield_Interpretation_Last_Month", objMPRMaster.Postfield_Interpretation_Last_Month);
                p.Add("Postfield_Interpretation_During_Month", objMPRMaster.Postfield_Interpretation_During_Month);
                p.Add("Postfield_Interpretation_Current_Month", objMPRMaster.Postfield_Interpretation_Current_Month);

                p.Add("Field_Check_Target", objMPRMaster.Field_Check_Target);
                p.Add("Field_Check_Last_Month", objMPRMaster.Field_Check_Last_Month);
                p.Add("Field_Check_During_Month", objMPRMaster.Field_Check_During_Month);
                p.Add("Field_Check_Current_Month", objMPRMaster.Field_Check_Current_Month);

                p.Add("Sample_Drawn_Target", objMPRMaster.Sample_Drawn_Target);
                p.Add("Sample_Drawn_Last_Month", objMPRMaster.Sample_Drawn_Last_Month);
                p.Add("Sample_Drawn_During_Month", objMPRMaster.Sample_Drawn_During_Month);
                p.Add("Sample_Drawn_Current_Month", objMPRMaster.Sample_Drawn_Current_Month);

                p.Add("Sample_Prepared_Target", objMPRMaster.Sample_Prepared_Target);
                p.Add("Sample_Prepared_Last_Month", objMPRMaster.Sample_Prepared_Last_Month);
                p.Add("Sample_Prepared_During_Month", objMPRMaster.Sample_Prepared_During_Month);
                p.Add("Sample_Prepared_Current_Month", objMPRMaster.Sample_Prepared_Current_Month);

                p.Add("Sample_Sent_For_Chemical_Analysis_Target", objMPRMaster.Sample_Sent_For_Chemical_Analysis_Target);
                p.Add("Sample_Sent_For_Chemical_Analysis_Last_Month", objMPRMaster.Sample_Sent_For_Chemical_Analysis_Last_Month);
                p.Add("Sample_Sent_For_Chemical_Analysis_During_Month", objMPRMaster.Sample_Sent_For_Chemical_Analysis_During_Month);
                p.Add("Sample_Sent_For_Chemical_Analysis_Current_Month", objMPRMaster.Sample_Sent_For_Chemical_Analysis_Current_Month);

                p.Add("Sample_Sent_For_Petrography_Target", objMPRMaster.Sample_Sent_For_Petrography_Target);
                p.Add("Sample_Sent_For_Petrography_Last_Month", objMPRMaster.Sample_Sent_For_Petrography_Last_Month);
                p.Add("Sample_Sent_For_Petrography_During_Month", objMPRMaster.Sample_Sent_For_Petrography_During_Month);
                p.Add("Sample_Sent_For_Petrography_Current_Month", objMPRMaster.Sample_Sent_For_Petrography_Current_Month);

                p.Add("Inferred_Target", objMPRMaster.Inferred_Target);
                p.Add("Inferred_Last_Month", objMPRMaster.Inferred_Last_Month);
                p.Add("Inferred_During_Month", objMPRMaster.Inferred_During_Month);
                p.Add("Inferred_Current_Month", objMPRMaster.Inferred_Current_Month);

                p.Add("Estimated_Target", objMPRMaster.Estimated_Target);
                p.Add("Estimated_Last_Month", objMPRMaster.Estimated_Last_Month);
                p.Add("Estimated_During_Month", objMPRMaster.Estimated_During_Month);
                p.Add("Estimated_Current_Month", objMPRMaster.Estimated_Current_Month);

                p.Add("Proved_Target", objMPRMaster.Proved_Target);
                p.Add("Proved_Last_Month", objMPRMaster.Proved_Last_Month);
                p.Add("Proved_During_Month", objMPRMaster.Proved_During_Month);
                p.Add("Proved_Current_Month", objMPRMaster.Proved_Current_Month);

                p.Add("Laying_Of_Base_Line_Target", objMPRMaster.Laying_Of_Base_Line_Target);
                p.Add("Laying_Of_Base_Line_Last_Month", objMPRMaster.Laying_Of_Base_Line_Last_Month);
                p.Add("Laying_Of_Base_Line_During_Month", objMPRMaster.Laying_Of_Base_Line_During_Month);
                p.Add("Laying_Of_Base_Line_Current_Month", objMPRMaster.Laying_Of_Base_Line_Current_Month);

                p.Add("Laying_Of_Grids_Target", objMPRMaster.Laying_Of_Grids_Target);
                p.Add("Laying_Of_Grids_Last_Month", objMPRMaster.Laying_Of_Grids_Last_Month);
                p.Add("Laying_Of_Grids_During_Month", objMPRMaster.Laying_Of_Grids_During_Month);
                p.Add("Laying_Of_Grids_Current_Month", objMPRMaster.Laying_Of_Grids_Current_Month);

                p.Add("No_of_Pits_Target", objMPRMaster.No_of_Pits_Target);
                p.Add("No_of_Pits_Last_Month", objMPRMaster.No_of_Pits_Last_Month);
                p.Add("No_of_Pits_During_Month", objMPRMaster.No_of_Pits_During_Month);
                p.Add("No_of_Pits_Current_Month", objMPRMaster.No_of_Pits_Current_Month);

                p.Add("Co_ordinates_Of_Pits_Target", objMPRMaster.Co_ordinates_Of_Pits_Target);
                p.Add("Co_ordinates_Of_Pits_Last_Month", objMPRMaster.Co_ordinates_Of_Pits_Last_Month);
                p.Add("Co_ordinates_Of_Pits_During_Month", objMPRMaster.Co_ordinates_Of_Pits_During_Month);
                p.Add("Co_ordinates_Of_Pits_Current_Month", objMPRMaster.Co_ordinates_Of_Pits_Current_Month);

                p.Add("Contouring_Target", objMPRMaster.Contouring_Target);
                p.Add("Contouring_Last_Month", objMPRMaster.Contouring_Last_Month);
                p.Add("Contouring_During_Month", objMPRMaster.Contouring_During_Month);
                p.Add("Contouring_Current_Month", objMPRMaster.Contouring_Current_Month);

                p.Add("Plotting_Of_Permanent_Features_Target", objMPRMaster.Plotting_Of_Permanent_Features_Target);
                p.Add("Plotting_Of_Permanent_Features_Last_Month", objMPRMaster.Plotting_Of_Permanent_Features_Last_Month);
                p.Add("Plotting_Of_Permanent_Features_During_Month", objMPRMaster.Plotting_Of_Permanent_Features_During_Month);
                p.Add("Plotting_Of_Permanent_Features_Current_Month", objMPRMaster.Plotting_Of_Permanent_Features_Current_Month);

                p.Add("Plotting_Of_Road_Nala_Target", objMPRMaster.Plotting_Of_Road_Nala_Target);
                p.Add("Plotting_Of_Road_Nala_Last_Month", objMPRMaster.Plotting_Of_Road_Nala_Last_Month);
                p.Add("Plotting_Of_Road_Nala_During_Month", objMPRMaster.Plotting_Of_Road_Nala_During_Month);
                p.Add("Plotting_Of_Road_Nala_Current_Month", objMPRMaster.Plotting_Of_Road_Nala_Current_Month);

                p.Add("Labor", objMPRMaster.Labor);
                p.Add("POL", objMPRMaster.POL);
                p.Add("Repair_And_Maintenance", objMPRMaster.Repair_And_Maintenance);
                p.Add("others", objMPRMaster.others);
                p.Add("Total", objMPRMaster.Total);

                p.Add("Camps_Name", objMPRMaster.Camps_Namedetails);
                p.Add("Camps_Designation", objMPRMaster.Camps_Designationdetails);
                p.Add("Camps_From", objMPRMaster.Camps_Fromdetails);
                p.Add("Camps_To", objMPRMaster.Camps_Todetails);
                p.Add("Camps_No_Of_Days", objMPRMaster.Camps_No_Of_Daysdetails);
                p.Add("Camps_Remarks", objMPRMaster.Camps_Remarksdetails);

                p.Add("UserId", objMPRMaster.UserId);
                p.Add("UserLoginId", objMPRMaster.UserLoginId);
                p.Add("chk", "UPDATE");
                string response = await Connection.QueryFirstAsync<string>("MPR_Work_Procedure", p, commandType: CommandType.StoredProcedure);
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
        #endregion
    }
}
