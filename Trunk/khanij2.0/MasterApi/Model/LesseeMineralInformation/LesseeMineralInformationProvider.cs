// ***********************************************************************
//  Class Name               : LesseeMineralInformationProvider
//  Description              : Lessee Mineral Information Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 04 August 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.LesseeMineralInformation
{
    public class LesseeMineralInformationProvider: RepositoryBase,ILesseeMineralInformationProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeMineralInformationProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        #region Binddropdowns
        /// <summary>
        /// To bind Mineral Category details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralCategoryDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            List<LesseeMineralInformationModel> ObjMineralTypeDetails = new List<LesseeMineralInformationModel>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMineralInformationModel>("[USP_GET_MINERALTYPE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralTypeDetails = result.ToList();
                }
                return ObjMineralTypeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Name details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralNameDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            List<LesseeMineralInformationModel> ObjMineralNameDetails = new List<LesseeMineralInformationModel>();
            try
            {
                var paramList = new
                {
                    UserId=objLesseeMineralInformationModel.CREATED_BY,
                    MineralTypeId=objLesseeMineralInformationModel.MINERAL_CATEGORY_ID
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMineralInformationModel>("[uspGetMineralNameFromMineralType]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralNameDetails = result.ToList();
                }
                return ObjMineralNameDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Form details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralFormDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            List<LesseeMineralInformationModel> ObjMineralNameDetails = new List<LesseeMineralInformationModel>();
            try
            {
                var paramList = new
                {
                    UserId = objLesseeMineralInformationModel.CREATED_BY,
                    MineralIdList = objLesseeMineralInformationModel.MineralIdList,
                    Check=2
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMineralInformationModel>("[uspGetMineralNature_GradeFromMineral]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralNameDetails = result.ToList();
                }
                return ObjMineralNameDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Grade details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralGradeDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            List<LesseeMineralInformationModel> ObjMineralNameDetails = new List<LesseeMineralInformationModel>();
            try
            {
                var paramList = new
                {
                    UserId = objLesseeMineralInformationModel.CREATED_BY,
                    MineralIdList = objLesseeMineralInformationModel.MineralIdList,
                    MineralNatureId = objLesseeMineralInformationModel.MineralNatureId,
                    CHECK=3
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMineralInformationModel>("[uspGetMineralNature_GradeFromMineral]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralNameDetails = result.ToList();
                }
                return ObjMineralNameDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        /// <summary>
        /// To bind Lessee Mineral Information details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<LesseeMineralInformationModel> GetMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            LesseeMineralInformationModel ObjMineralInformationDetails = new LesseeMineralInformationModel();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeMineralInformationModel.CREATED_BY,
                    CHECK = "1"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMineralInformationModel>("[USP_LESSEE_MINERAL_INFORMATION_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralInformationDetails = result.FirstOrDefault();
                }
                return ObjMineralInformationDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Information Log History details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralInformationLogDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            List<LesseeMineralInformationModel> ObjGrantOrderLogDetails = new List<LesseeMineralInformationModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeMineralInformationModel.CREATED_BY,
                    CHECK = "5"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMineralInformationModel>("[USP_LESSEE_MINERAL_INFORMATION_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjGrantOrderLogDetails = result.ToList();
                }
                return ObjGrantOrderLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Information Compare details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralInformationCompareDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            List<LesseeMineralInformationModel> ObjGrantOrderLogDetails = new List<LesseeMineralInformationModel>();
            try
            {
                var paramList = new
                {
                    CREATED_BY = objLesseeMineralInformationModel.CREATED_BY,
                    CHECK = "6"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<LesseeMineralInformationModel>("[USP_LESSEE_MINERAL_INFORMATION_OFFICE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjGrantOrderLogDetails = result.ToList();
                }
                return ObjGrantOrderLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Mineral Information details
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public MessageEF UpdateMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "2");
                p.Add("CREATED_BY", objLesseeMineralInformationModel.CREATED_BY);
                p.Add("USER_LOGIN_ID", objLesseeMineralInformationModel.UserLoginId);
                p.Add("LESSEE_MINERAL_INFORMATION_ID", objLesseeMineralInformationModel.LESSEE_MINERAL_INFORMATION_ID); 
                p.Add("MINERAL_CATEGORY_ID", objLesseeMineralInformationModel.MINERAL_CATEGORY_ID);
                p.Add("MINERAL_ID", objLesseeMineralInformationModel.MineralID);
                p.Add("MINERAL_GRADE_ID", objLesseeMineralInformationModel.MINERAL_GRADE_ID);
                p.Add("ESTIMATED_RESERVE", objLesseeMineralInformationModel.ESTIMATED_RESERVE);
                p.Add("MINABLE_RESERVE", objLesseeMineralInformationModel.MINABLE_RESERVE);
                p.Add("STATUS", objLesseeMineralInformationModel.STATUS);
                p.Add("COPY_OF_MP_SOM_ESTIMATION_FILE_PATH", objLesseeMineralInformationModel.COPY_OF_MP_SOM_ESTIMATION_FILE_PATH);
                p.Add("COPY_OF_MP_SOM_ESTIMATION_FILE_NAME", objLesseeMineralInformationModel.COPY_OF_MP_SOM_ESTIMATION_FILE_NAME);
                string mineralid = "";
                string mineralFormId = "";
                string mineralGradeId = "";

                if (objLesseeMineralInformationModel.MineralCount != null)
                {
                    if (objLesseeMineralInformationModel.MineralCount.Count > 0)
                    {
                        for (int i = 0; i < objLesseeMineralInformationModel.MineralCount.Count; i++)
                        {
                            mineralid += objLesseeMineralInformationModel.MineralCount[i].ToString();
                            mineralid += ",";
                        }
                    }
                }
                if (objLesseeMineralInformationModel.MineralFormCount != null)
                {
                    if (objLesseeMineralInformationModel.MineralFormCount.Count > 0)
                    {
                        for (int i = 0; i < objLesseeMineralInformationModel.MineralFormCount.Count; i++)
                        {
                            mineralFormId += objLesseeMineralInformationModel.MineralFormCount[i].ToString();
                            mineralFormId += ",";
                        }
                    }
                }
                if (objLesseeMineralInformationModel.MineralGradeCount != null)
                {
                    if (objLesseeMineralInformationModel.MineralGradeCount.Count > 0)
                    {
                        for (int i = 0; i < objLesseeMineralInformationModel.MineralGradeCount.Count; i++)
                        {
                            mineralGradeId += objLesseeMineralInformationModel.MineralGradeCount[i].ToString();
                            mineralGradeId += ",";
                        }
                    }
                }
                p.Add("MINERAL_ID_LIST", mineralid);
                p.Add("MINERAL_FORMID_LIST", mineralFormId);
                p.Add("MINERAL_GRADEID_LIST", mineralGradeId);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_MINERAL_INFORMATION_OFFICE]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Approve Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "3");
                p.Add("APPROVED_BY", objLesseeMineralInformationModel.UserLoginId);
                p.Add("LESSEE_MINERAL_INFORMATION_ID", objLesseeMineralInformationModel.LESSEE_MINERAL_INFORMATION_ID);
                p.Add("Remarks", objLesseeMineralInformationModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_MINERAL_INFORMATION_OFFICE]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// To Reject Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "4");
                p.Add("REJECTED_BY", objLesseeMineralInformationModel.UserLoginId);
                p.Add("LESSEE_MINERAL_INFORMATION_ID", objLesseeMineralInformationModel.LESSEE_MINERAL_INFORMATION_ID);
                p.Add("Remarks", objLesseeMineralInformationModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_MINERAL_INFORMATION_OFFICE]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
        /// <summary>
        /// To Delete Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("CHECK", "7");
                p.Add("USER_LOGIN_ID", objLesseeMineralInformationModel.CREATED_BY);
                p.Add("LESSEE_MINERAL_INFORMATION_ID", objLesseeMineralInformationModel.LESSEE_MINERAL_INFORMATION_ID);
                p.Add("CREATED_BY", objLesseeMineralInformationModel.CREATED_BY);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_MINERAL_INFORMATION_OFFICE]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
    }
}
