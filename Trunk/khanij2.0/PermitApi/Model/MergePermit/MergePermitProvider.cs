using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;

namespace PermitApi.Model.MergePermit
{
    public class MergePermitProvider : RepositoryBase, IMergePermitProvider
    {
        public MergePermitProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Get the merge permit list
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GetMergePermitList(ePermitModel objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                    MineralGradeID=objUser.MineralGradeId,
                    FromDate=objUser.FromDATE,
                    ToDate=objUser.ToDATE,
                    Check = 1,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("GetMergePermitMineralGrade", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    ObjUserTypeList = result.ToList();
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;

        }
        /// <summary>
        /// Merge permit mineral grade list
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetMergePermitMineralGrade(ePermitModel objLease)
        
{

            ePermitResult ObjResult = new ePermitResult();

            DataTable ObjDt = new DataTable();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            ePermitModel LeaseEF = new ePermitModel();

            try
            {
                var paramList = new
                {
                    UserId = objLease.UserID,
                    Check = 0,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("GetMergePermitMineralGrade", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            MineralGradeId = Convert.ToInt32(dr.MineralGradeID.ToString()),
                            MineralGrade = dr.MineralGrade.ToString(),


                        });
                    }
                    ObjResult.MineralGradeLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Print and close RTP permit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> ClosePermit(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                
                p.Add("CreatedBy", model.UserID);              //model.LeaseInfoId
                p.Add("MineralId", model.MineralId);
                p.Add("MineralGradeId", model.MineralGradeId);
                p.Add("MineralNatureId", model.MineralNatureId);
                p.Add("DispatchedQty", model.PendingQty);
                p.Add("RPTPBulkPermitId", model.BulkPermitId);
                p.Add("SubUserID", model.SubUserID);
               
                var result =await Connection.ExecuteScalarAsync<string>("uspLicenseeStopRPTP", p, commandType: CommandType.StoredProcedure);
                // int response = p.Get<int>("RESULT");

                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();

                }
                else
                {
                    objMessage.Satus = string.Empty;
                }
            }
            catch (Exception ex)
            {
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Save and Generate Permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<MessageEF> SaveAndGenerateEpermit(ePermitModel objUser)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,
                    BulkPermitID = objUser.BulkPermitId,
                    Check = 4,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("uspEPermitOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();

                }
                else
                {
                    objMessage.Satus = string.Empty;
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// Get Mineral Name for CoalMerge permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetMineralName(ePermitModel objUser)
        {
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                    MineralId = objUser.MineralId,
                    MineralNatureID=objUser.MineralNatureId,
                    MineralGradeId=objUser.MineralGradeId,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("uspGetMineralNatureName", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo.MineralNatureLst = result.ToList(); ;
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// check for merge permit data
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> CheckMergePermitDetails(ePermitModel objUser)
        {
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                if (objUser.UserType.ToUpper() == "TAILING DAM")
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,
                    };
                    DynamicParameters param = new DynamicParameters();

                    var result = await Connection.QueryAsync<ePermitModel>("getDetailsByTailingDamUserID", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {

                        UserInfo.PermitOperationLst = result.ToList(); ;
                    }

                }
                else
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,
                    };
                    DynamicParameters param = new DynamicParameters();

                    var result = await Connection.QueryAsync<ePermitModel>("getDetailsByUserID", paramList, commandType: System.Data.CommandType.StoredProcedure);

                    if (result.Count() > 0)
                    {

                        UserInfo.PermitOperationLst = result.ToList(); ;
                    }
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get the details of Mergepermit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetMergePermitTransDetails(ePermitModel objUser)
        {
            ePermitResult UserInfo = new ePermitResult();
            try
            {

                var paramList = new
                {
                    UserID = objUser.UserID,
                    Check = 1,
                    BulkPermitID = objUser.BulkPermitId,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryMultipleAsync("uspEPermitOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);

                var ApplDetails = result.Read<ePermitModel>().ToList();
                var PaymentDetails = result.Read<ePaymentData>().ToList();
                UserInfo.DetailsPermitLstByUserID = ApplDetails;
                UserInfo.PermitPaymentLst = PaymentDetails;


            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }

    }
}
