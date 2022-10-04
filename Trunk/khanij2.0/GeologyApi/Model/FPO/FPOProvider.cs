// ***********************************************************************
//  Class Name               : FPOProvider
//  Desciption               : CRUD,Create,Approve,Generate Field Program Order
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Feb 2021
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

namespace GeologyApi.Model.FPO
{
    public class FPOProvider: RepositoryBase,IFPOProvider
    {
        #region FPO Order
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public FPOProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To Add Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddFPOMaster(FPOOrdermaster objFPOMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FPO_Code", objFPOMaster.FPO_Code);
                p.Add("FPO_Name", objFPOMaster.FPO_Name);
                p.Add("DateOfIssuance", objFPOMaster.DateOfIssuance);
                p.Add("ExplorationSeason", objFPOMaster.Year);
                p.Add("FPO_File", objFPOMaster.FPO_Creater_File);
                p.Add("FPO_Path", objFPOMaster.FPO_Creater_Path);
                p.Add("UserId", objFPOMaster.CreatedBy);
                p.Add("UserLoginId",objFPOMaster.UserLoginId);
                p.Add("chk", "Insert");              
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Geology_FPO_OrderOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
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
        /// To View Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<FPOOrdermaster>> ViewFPOMaster(FPOOrdermaster objFPOMaster)
        {
            List<FPOOrdermaster> ListFPOMaster = new List<FPOOrdermaster>();
            try
            {
                var paramList = new
                {
                    chk = "SELECT",
                    FPO_Id = objFPOMaster.FPO_Id
                };
                var Output = await Connection.QueryAsync<FPOOrdermaster>("Geology_FPO_OrderOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Edit Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<FPOOrdermaster> EditFPOMaster(FPOOrdermaster objFPOMaster)
        {
            FPOOrdermaster LobjFPOMaster = new FPOOrdermaster();
            try
            {
                var paramList = new
                {
                    chk = "SELECT",
                    FPO_Id=objFPOMaster.FPO_Id
                };
                DynamicParameters param = new DynamicParameters();

                var Output = await Connection.QueryAsync<FPOOrdermaster>("Geology_FPO_OrderOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    LobjFPOMaster = Output.FirstOrDefault();
                }
                return LobjFPOMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteFPOMaster(FPOOrdermaster objFPOMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FPO_Id", objFPOMaster.FPO_Id);
                p.Add("UserId", objFPOMaster.CreatedBy);
                p.Add("chk", "DELETE");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Geology_FPO_OrderOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
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
        /// To Update Field Program Order Status Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateFPOMaster(FPOOrdermaster objFPOMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FPO_Id", objFPOMaster.FPO_Id);
                p.Add("FPO_Code", objFPOMaster.FPO_Code);
                p.Add("FPO_Name", objFPOMaster.FPO_Name);
                p.Add("DateOfIssuance", objFPOMaster.DateOfIssuance);
                p.Add("ExplorationSeason", objFPOMaster.Year);
                p.Add("FPO_File", objFPOMaster.FPO_Creater_File);
                p.Add("FPO_Path", objFPOMaster.FPO_Creater_Path);
                p.Add("IsActive", objFPOMaster.IsActive);
                p.Add("UserId",objFPOMaster.CreatedBy);
                p.Add("UserLoginId", objFPOMaster.UserLoginId);
                p.Add("chk", "UPDATE");              
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Geology_FPO_OrderOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
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
        /// To Bind the Field Season list Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<FPOOrdermaster>> GetFieldSeasonList(FPOOrdermaster objFPOMaster)
        {
            List<FPOOrdermaster> ObjPolicyTypeList = new List<FPOOrdermaster>();
            try
            {
                var paramList = new
                {
                    SP_MODE="GET_MINING_PLAN_YEAR"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<FPOOrdermaster>("LESSEE_MININGPLAN", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        #endregion
        #region FPO Creator
        /// <summary>
        /// To Bind the Field Program Order Creator Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<FPOOrdermaster>> ViewFPOCreator(FPOOrdermaster objFPOMaster)
        {
            List<FPOOrdermaster> ListFPOMaster = new List<FPOOrdermaster>();
            try
            {
                var paramList = new
                {
                    chk = "FPOCreatorGrid",
                };
                var Output = await Connection.QueryAsync<FPOOrdermaster>("Geology_FPO_OrderOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
            finally
            {
                ListFPOMaster = null;
            }
        }
        /// <summary>
        /// To Add the Field Program Order Creator Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddFPOCreator(FPOOrdermaster objFPOMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FPO_Id",objFPOMaster.FPO_Id);
                p.Add("UserId",objFPOMaster.CreatedBy);
                p.Add("chk", "FPODSCUpdation");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Geology_FPO_OrderOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
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
        #region FPO Approver
        /// <summary>
        /// To Bind Field Program Order Approver details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<FPOOrdermaster>> ViewFPOApprover(FPOOrdermaster objFPOMaster)
        {
            List<FPOOrdermaster> ListFPOMaster = new List<FPOOrdermaster>();
            try
            {
                var paramList = new
                {
                    chk = "FPOApproverGrid",
                };
                var Output = await Connection.QueryAsync<FPOOrdermaster>("Geology_FPO_OrderOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Add Field Program Order Approver details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddFPOApprover(FPOOrdermaster objFPOMaster)
        {
           MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("FPO_Id", objFPOMaster.FPO_Id);
                p.Add("IsApproved", objFPOMaster.IsApproved);
                p.Add("Remarks", objFPOMaster.Remarks);
                p.Add("UserId", objFPOMaster.CreatedBy);
                p.Add("chk", "FPOApprovalUpdation");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("Geology_FPO_OrderOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
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
        #region Generated FPO
        /// <summary>
        /// To View Generated Field Program Order details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public async Task<List<FPOOrdermaster>> ViewGeneratedFPO(FPOOrdermaster objFPOMaster)
        {
            List<FPOOrdermaster> ListFPOMaster = new List<FPOOrdermaster>();
            try
            {
                var paramList = new
                {
                    chk = "Generated",
                };
                var Output = await Connection.QueryAsync<FPOOrdermaster>("Geology_FPO_OrderOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        #endregion
    }
}
