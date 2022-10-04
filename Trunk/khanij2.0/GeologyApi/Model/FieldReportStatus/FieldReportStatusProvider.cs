// ***********************************************************************
//  Interface Name           : IFieldReportStatusProvider
//  Desciption               : Add,View,Edit,Update,Delete Field Report Status
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

namespace GeologyApi.Model.FieldReportStatus
{
    public class FieldReportStatusProvider : RepositoryBase, IFieldReportStatusProvider
    {
        #region Field Report Status
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public FieldReportStatusProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To Add Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddFieldReportStatusMaster(FieldReportStatusmaster objFieldReportStatusMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FPO_ID", objFieldReportStatusMaster.FPO_Id);
                p.Add("ReportType", objFieldReportStatusMaster.ReportType);
                p.Add("ReportStatus", 2);
                p.Add("ReportStatus_1", objFieldReportStatusMaster.ReportStatus_1);
                p.Add("USER_ID", objFieldReportStatusMaster.UserId);
                p.Add("LOGIN_ID", objFieldReportStatusMaster.UserLoginId);
                p.Add("RegionalID", objFieldReportStatusMaster.RegionalOfficeId);
                p.Add("RegionalOffice", objFieldReportStatusMaster.RegionalOfficeId);
                p.Add("FIELD_REPORT_FILE_PATH", objFieldReportStatusMaster.FIELD_REPORT_FILE_PATH);
                p.Add("FIELD_REPORT_FILE_NAME", objFieldReportStatusMaster.FIELD_REPORT_FILE_NAME);
                p.Add("MAPS_PLATES_FILE_PATH", objFieldReportStatusMaster.MAPS_PLATES_FILE_PATH);
                p.Add("MAPS_PLATES_FILE_NAME", objFieldReportStatusMaster.MAPS_PLATES_FILE_NAME);
                p.Add("ANNEXURE_FILE_PATH", objFieldReportStatusMaster.ANNEXURE_FILE_PATH);
                p.Add("ANNEXURE_FILE_NAME", objFieldReportStatusMaster.ANNEXURE_FILE_NAME);
                p.Add("SP_MODE", "INSERT_DATA");
                string response = await Connection.QueryFirstAsync<string>("USP_GeologyFieldReportStatus", p, commandType: CommandType.StoredProcedure);
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
        /// To View Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        public async Task<List<FieldReportStatusmaster>> ViewFieldReportStatusMaster(FieldReportStatusmaster objFieldReportStatusMaster)
        {
            List<FieldReportStatusmaster> ListFieldReportStatusMaster = new List<FieldReportStatusmaster>();
            try
            {
                var paramList = new
                {
                    SP_MODE = "LIST_DATA",
                    USER_ID = objFieldReportStatusMaster.UserId,
                };
                var Output = await Connection.QueryAsync<FieldReportStatusmaster>("USP_GeologyFieldReportStatus", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {
                    ListFieldReportStatusMaster = Output.ToList();
                }
                return ListFieldReportStatusMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Edit Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        public async Task<FieldReportStatusmaster> EditFieldReportStatusMaster(FieldReportStatusmaster objFieldReportStatusMaster)
        {
            FieldReportStatusmaster LobjFieldReportStatusMaster = new FieldReportStatusmaster();
            try
            {
                var paramList = new
                {
                    SP_MODE = "GETDATAFIELDREPORT",
                    GeologyFieldReportStatusId = objFieldReportStatusMaster.MPR_ID
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<FieldReportStatusmaster>("USP_GeologyFieldReportStatus", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    LobjFieldReportStatusMaster = Output.FirstOrDefault();
                }
                return LobjFieldReportStatusMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteFieldReportStatusMaster(FieldReportStatusmaster objFieldReportStatusMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("GeologyFieldReportStatusId", objFieldReportStatusMaster.MPR_ID);
                p.Add("FPO_ID", objFieldReportStatusMaster.FPO_Id);
                p.Add("ReportType", objFieldReportStatusMaster.ReportType);
                p.Add("ReportStatus", objFieldReportStatusMaster.ReportStatus);
                p.Add("USER_ID", objFieldReportStatusMaster.UserId);
                p.Add("LOGIN_ID", objFieldReportStatusMaster.UserLoginId);
                p.Add("SP_MODE", "DELETE_DATA");
                string response = await Connection.QueryFirstAsync<string>("USP_GeologyFieldReportStatus", p, commandType: CommandType.StoredProcedure);
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
        /// To Update Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateFieldReportStatusMaster(FieldReportStatusmaster objFieldReportStatusMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("GeologyFieldReportStatusId", objFieldReportStatusMaster.MPR_ID);
                p.Add("FPO_ID", objFieldReportStatusMaster.FPO_Id);
                p.Add("ReportType", objFieldReportStatusMaster.ReportType);
                p.Add("ReportStatus_1", objFieldReportStatusMaster.ReportStatus_1);
                p.Add("UserId", objFieldReportStatusMaster.UserId);
                p.Add("LOGIN_ID", objFieldReportStatusMaster.UserLoginId);
                p.Add("RegionalID", objFieldReportStatusMaster.RegionalOfficeId);
                p.Add("RegionalOffice", objFieldReportStatusMaster.RegionalOfficeId);
                p.Add("FIELD_REPORT_FILE_PATH", objFieldReportStatusMaster.FIELD_REPORT_FILE_PATH);
                p.Add("FIELD_REPORT_FILE_NAME", objFieldReportStatusMaster.FIELD_REPORT_FILE_NAME);
                p.Add("MAPS_PLATES_FILE_PATH", objFieldReportStatusMaster.MAPS_PLATES_FILE_PATH);
                p.Add("MAPS_PLATES_FILE_NAME", objFieldReportStatusMaster.MAPS_PLATES_FILE_NAME);
                p.Add("ANNEXURE_FILE_PATH", objFieldReportStatusMaster.ANNEXURE_FILE_PATH);
                p.Add("ANNEXURE_FILE_NAME", objFieldReportStatusMaster.ANNEXURE_FILE_NAME);
                p.Add("SP_MODE", "UPDATE_DATA");
                string response = await Connection.QueryFirstAsync<string>("USP_GeologyFieldReportStatus", p, commandType: CommandType.StoredProcedure);
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
        /// To Bind the Regional Office Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        public async Task<List<FieldReportStatusmaster>> GetRegionalOfficeList(FieldReportStatusmaster objFieldReportStatusMaster)
        {
            List<FieldReportStatusmaster> ObjPolicyTypeList = new List<FieldReportStatusmaster>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<FieldReportStatusmaster>("uspGetRegoinalOffice", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjPolicyTypeList = Output.ToList();
                }
                return ObjPolicyTypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Submit Field Report to Regional Office
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateStatusOfReport_STOREGIONALOFFICE(FieldReportStatusmaster objFieldReportStatusMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("GeologyFieldReportStatusId", objFieldReportStatusMaster.MPR_ID);
                p.Add("ReportStatus", "3");
                p.Add("UserId", objFieldReportStatusMaster.UserId);
                p.Add("LOGIN_ID", objFieldReportStatusMaster.UserLoginId);
                p.Add("SP_MODE", "STATUS_REPORT_FORWARDER");
                string response = await Connection.QueryFirstAsync<string>("USP_GeologyFieldReportStatus", p, commandType: CommandType.StoredProcedure);
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
        /// To Fetch Email Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        public async Task<FieldReportStatusmaster> ViewEmailDetails(FieldReportStatusmaster objFieldReportStatusMaster)
        {
            FieldReportStatusmaster FieldReportStatusMaster = new FieldReportStatusmaster();
            try
            {
                var paramList = new DynamicParameters();
                paramList.Add("SP_MODE", "FETCH_DATA");
                paramList.Add("GeologyFieldReportStatusId", objFieldReportStatusMaster.MPR_ID);
                paramList.Add("USER_ID", objFieldReportStatusMaster.UserId);
                var Output = await Connection.QueryAsync<FieldReportStatusmaster>("USP_GeologyFieldReportStatus", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    FieldReportStatusMaster = Output.FirstOrDefault();
                }
                return FieldReportStatusMaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
