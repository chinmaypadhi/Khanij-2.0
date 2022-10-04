// ***********************************************************************
//  Class Name               : LabReportsProvider
//  Desciption               : CRUD,Forward,Get Status,Get sample of Lab Reports
//  Created By               : Lingaraj Dalai
//  Created On               : 24 Feb 2021
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

namespace GeologyApi.Model.LabReports
{
    public class LabReportsProvider: RepositoryBase,ILabReportsProvider
    {
        #region Submit New Samples
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LabReportsProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To Add the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddLabReportsmaster(LabReportmaster objLabReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FPO_Id", objLabReportmaster.FPO_Id);
                p.Add("Location", objLabReportmaster.Location);
                p.Add("ToposheetNo", objLabReportmaster.ToposheetNo);
                p.Add("RegionalID", objLabReportmaster.RegionalID);
                p.Add("DistrictID", objLabReportmaster.DistrictID);
                p.Add("TehsilID", objLabReportmaster.TehsilID);
                p.Add("VillageID", objLabReportmaster.VillageID);
                p.Add("Type_Of_Sample", objLabReportmaster.Type_Of_Sample);
                p.Add("No_Of_Sample", objLabReportmaster.No_Of_Sample);
                p.Add("Type_Id", objLabReportmaster.StudyAnalysisID);
                p.Add("Elements_analysed", objLabReportmaster.Elements_analysed);
                p.Add("Date_of_Submission", objLabReportmaster.Date_of_Submission);
                p.Add("App_Id", objLabReportmaster.App_Id);
                p.Add("RegionalOffice", objLabReportmaster.RegionalOfficeId);
                p.Add("GeologistName", objLabReportmaster.GeologistName);
                p.Add("Designation", objLabReportmaster.Designation);
                p.Add("Block", objLabReportmaster.Block);
                p.Add("MineralId", objLabReportmaster.MineralID);
                p.Add("UserId", objLabReportmaster.UserId);
                p.Add("UserLoginId", objLabReportmaster.UserLoginId);
                p.Add("AttechmentName", objLabReportmaster.AttechmentName);
                p.Add("Attechment", objLabReportmaster.Attechment);
                p.Add("Report_MY", objLabReportmaster.Report_MY);
                p.Add("chk", "INSERT");
                string response = await Connection.QueryFirstAsync<string>("upsLab_ReportsOperation", p, commandType: CommandType.StoredProcedure);
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
        /// To View the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<List<LabReportmaster>> ViewLabReportsmaster(LabReportmaster objLabReportmaster)
        {
            List<LabReportmaster> ListFPOMaster = new List<LabReportmaster>();
            try
            {
                var paramList = new
                {
                    LabReport_Id = objLabReportmaster.LabReport_Id,
                    Type=objLabReportmaster.Type
                };
                var Output = await Connection.QueryAsync<LabReportmaster>("Sp_LabReport", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Edit the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<LabReportmaster> EditLabReportsmaster(LabReportmaster objLabReportmaster)
        {
            LabReportmaster LobjLabReportmaster = new LabReportmaster();
            try
            {
                var paramList = new
                {
                    LabReport_Id = objLabReportmaster.LabReport_Id,
                    Type = objLabReportmaster.Type
                };
                DynamicParameters param = new DynamicParameters();

                var Output = await Connection.QueryAsync<LabReportmaster>("Sp_LabReport", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    LobjLabReportmaster = Output.FirstOrDefault();
                }

                return LobjLabReportmaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjLabReportmaster = null;
            }
        }
        /// <summary>
        /// To Delete the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteLabReportsmaster(LabReportmaster objLabReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("LabReport_Id", objLabReportmaster.LabReport_Id);
                p.Add("chk", "DELETE");
                string response = await Connection.QueryFirstAsync<string>("upsLab_ReportsOperation", p, commandType: CommandType.StoredProcedure);
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
        /// To Update the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateLabReportsmaster(LabReportmaster objLabReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FPO_Id", objLabReportmaster.FPO_Id);
                p.Add("Location", objLabReportmaster.Location);
                p.Add("ToposheetNo", objLabReportmaster.ToposheetNo);
                p.Add("RegionalID", objLabReportmaster.RegionalID);
                p.Add("DistrictID", objLabReportmaster.DistrictID);
                p.Add("TehsilID", objLabReportmaster.TehsilID);
                p.Add("VillageID", objLabReportmaster.VillageID);
                p.Add("Type_Of_Sample", objLabReportmaster.Type_Of_Sample);
                p.Add("No_Of_Sample", objLabReportmaster.No_Of_Sample);
                p.Add("Type_Id", objLabReportmaster.StudyAnalysisID);
                p.Add("Elements_analysed", objLabReportmaster.Elements_analysed);
                p.Add("Date_of_Submission", objLabReportmaster.Date_of_Submission);
                p.Add("App_Id", objLabReportmaster.App_Id);
                p.Add("UserId", objLabReportmaster.UserId);
                p.Add("UserLoginId", objLabReportmaster.UserLoginId);
                p.Add("RegionalOffice", objLabReportmaster.RegionalOfficeId);
                p.Add("GeologistName", objLabReportmaster.GeologistName);
                p.Add("Designation", objLabReportmaster.Designation);
                p.Add("LabReport_Id", objLabReportmaster.LabReport_Id);
                p.Add("Block", objLabReportmaster.Block);
                p.Add("MineralId", objLabReportmaster.MineralID);
                p.Add("AttechmentName", objLabReportmaster.AttechmentName);
                p.Add("Attechment", objLabReportmaster.Attechment);
                p.Add("Report_MY", objLabReportmaster.Report_MY);
                p.Add("chk", "UPDATE");
                string response = await Connection.QueryFirstAsync<string>("upsLab_ReportsOperation", p, commandType: CommandType.StoredProcedure);
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
        /// To Forward the Lab Report master details data
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> SendForForward(LabReportmaster objLabReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("chk", "SEND_FOR_FORWARD");
                p.Add("LabReport_Id", objLabReportmaster.LabReport_Id);
                p.Add("UserId", objLabReportmaster.UserId);
                p.Add("UserLoginId", objLabReportmaster.UserLoginId);
                string response = await Connection.QueryFirstAsync<string>("upsLab_ReportsOperation", p, commandType: CommandType.StoredProcedure);
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
        #region Dropdowns
        /// <summary>
        /// To Get the MPR code list Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<LabReportmaster>> GetMPRCodeList(LabReportmaster objLabReportmaster)
        {
            List<LabReportmaster> ObjMPRCodeList = new List<LabReportmaster>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<LabReportmaster>("uspGetFpoDropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Bind the Mineral list Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<LabReportmaster>> GetMineralList(LabReportmaster objLabReportmaster)
        {
            List<LabReportmaster> ObjMineralNameList = new List<LabReportmaster>();
            try
            {
                var paramList = new
                {
                    chk = "5"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<LabReportmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Bind the Division list Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<LabReportmaster>> GetDivisionList(LabReportmaster objLabReportmaster)
        {
            List<LabReportmaster> ObjDivisionList = new List<LabReportmaster>();
            try
            {
                var paramList = new
                {
                    chk = "6"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<LabReportmaster>("MPR_Procedure", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Bind the Regional office list Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<LabReportmaster>> GetRegionalOfficeList(LabReportmaster objLabReportmaster)
        {
            List<LabReportmaster> ObjRegionalOfficeList = new List<LabReportmaster>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync <LabReportmaster>("uspGetRegoinalOffice", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// <summary>
        /// To Get the Study analysis Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<LabReportmaster>> GetTypeOfStudyAnalysis(LabReportmaster objLabReportmaster)
        {
            List<LabReportmaster> ObjStudyAnalysisList = new List<LabReportmaster>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<LabReportmaster>("uspTypeOfStudyAnalysis", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjStudyAnalysisList = Output.ToList();
                }
                return ObjStudyAnalysisList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        /// <summary>
        /// To get Office details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public async Task<LabReportmaster> GetOfficerNameAndDesignation(LabReportmaster objMPRMaster)
        {
            LabReportmaster LobjMPRMaster = new LabReportmaster();
            try
            {
                var paramList = new
                {
                    UserId = objMPRMaster.UserId,
                    chk = "GET_OFFICER_NAME_AND_DESIGNATION"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<LabReportmaster>("Geology_FPO_OrderOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        #endregion
        #region Lab Report Forward
        /// <summary>
        /// To View the Lab Report details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<List<LabReportmaster>> ViewLabReportForward(LabReportmaster objLabReportmaster)
        {
            List<LabReportmaster> ListLabReport = new List<LabReportmaster>();
            try
            {
                var paramList = new
                {
                    UserId = objLabReportmaster.UserId,
                    chk = "GET_FORWARD_DATA"
                };
                var Output = await Connection.QueryAsync<LabReportmaster>("upsLab_ReportsOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ListLabReport = Output.ToList();
                }
                return ListLabReport;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListLabReport = null;
            }
        }
        /// <summary>
        /// To Add the Lab Report details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> SendForApproval(LabReportmaster objLabReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("chk", "SEND_FOR_APPROVAL");
                p.Add("LabReport_Id", objLabReportmaster.LabReport_Id);
                p.Add("UserId", objLabReportmaster.UserId);
                p.Add("UserLoginId", objLabReportmaster.UserLoginId);
                string response = await Connection.QueryFirstAsync<string>("upsLab_ReportsOperation", p, commandType: CommandType.StoredProcedure);
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
        #endregion
        #region StatusofLabReport
        /// <summary>
        /// To View the Lab Report status Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<List<LabReportmaster>> ViewStatusOfLabReport(LabReportmaster objLabReportmaster)
        {
            List<LabReportmaster> ListLabReport = new List<LabReportmaster>();
            try
            {
                var paramList = new
                {
                    UserId = objLabReportmaster.UserId,
                    UserType = objLabReportmaster.UserType,
                    chk = "GET_FOR_APPROVE_DATA"
                };
                var Output = await Connection.QueryAsync<LabReportmaster>("upsLab_ReportsOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ListLabReport = Output.ToList();
                }
                return ListLabReport;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Upload result in Lab report
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UploadResult(LabReportmaster objLabReportmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("UserId", objLabReportmaster.UserId);
                if (objLabReportmaster.dtUpload != null)
                {
                    DataTable _dt = new DataTable("MultipleFileUpload");
                    _dt = (DataTable)objLabReportmaster.dtUpload;
                    if (_dt.Rows.Count > 0)
                    {
                        p.Add("BulkInseration", _dt, DbType.Object);
                    }
                }            
                string response = await Connection.QueryFirstAsync<string>("upsAnaLysedLabReportOperaion", p, commandType: CommandType.StoredProcedure);
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
        #endregion
        #region GetAnalysedSamples
        /// <summary>
        /// To View the Analysed samples Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<List<LabReportmaster>> ViewAnalysedSamples(LabReportmaster objLabReportmaster)
        {
            List<LabReportmaster> ListLabReport = new List<LabReportmaster>();
            try
            {
                var paramList = new
                {
                    LabReport_Id = objLabReportmaster.LabReport_Id,
                    Type =objLabReportmaster.Type
                };
                var Output = await Connection.QueryAsync<LabReportmaster>("Sp_LabReport", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ListLabReport = Output.ToList();
                }
                return ListLabReport;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListLabReport = null;
            }
        }
        /// <summary>
        /// To View the Files list Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public async Task<List<LabReportmaster>> ViewFilesList(LabReportmaster objLabReportmaster)
        {
            List<LabReportmaster> ListLabReport = new List<LabReportmaster>();
            try
            {
                var paramList = new
                {
                    LabReport_Id = objLabReportmaster.LabReport_Id,
                };
                var Output = await Connection.QueryAsync<LabReportmaster>("Sp_GatAnalysedReport", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ListLabReport = Output.ToList();
                }
                return ListLabReport;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListLabReport = null;
            }
        }
        #endregion
    }
}
