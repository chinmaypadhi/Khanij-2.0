using Dapper;
using MasterApi.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.WeighBridge
{
    public class WeighBridgeTagProvider : RepositoryBase, IWeighBridgeTagProvider
    {
        public WeighBridgeTagProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// All district dropdown load
        /// </summary>
        /// <returns></returns>
        public async Task<List<ViewWeighBridgeTagModel>> ViewDistrict(ViewWeighBridgeTagModel obj)
        {
            List<ViewWeighBridgeTagModel> objviewlist = new List<ViewWeighBridgeTagModel>();
            try
            {
                var paramList = new
                {
                    UserTypeID = obj.UserTypeID,
                    UserID = obj.UserID,
                    ACTION = "VIEWDISTRICT"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeTagModel>("WeighBridgeTagView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// All User dropdown fill by selecting district dropdown
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<List<ViewWeighBridgeTagModel>> ViewUserByDistrict(ViewWeighBridgeTagModel obj)
        {
            List<ViewWeighBridgeTagModel> objviewlist = new List<ViewWeighBridgeTagModel>();
            try
            {
                var paramList = new
                {
                    UserTypeID = obj.UserTypeID,
                    DistrictID = obj.DistrictID,
                    UserID = obj.UserID,
                    ACTION = "VIEWUSERBYDISTRICT"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeTagModel>("WeighBridgeTagView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// All user type dropdown fill
        /// </summary>
        /// <returns></returns>
        public async Task<List<ViewWeighBridgeTagModel>> ViewUserType()
        {
            List<ViewWeighBridgeTagModel> objviewlist = new List<ViewWeighBridgeTagModel>();
            try
            {
                var paramList = new
                {
                    //WeighBridgeID = obj.WeighBridgeID,
                    ACTION = "VIEWUSERTYPE"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeTagModel>("WeighBridgeTagView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// All weighbridge dropdown fill by user dropdown on change
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeByUser(ViewWeighBridgeTagModel obj)
        {
            List<ViewWeighBridgeTagModel> objviewlist = new List<ViewWeighBridgeTagModel>();
            try
            {
                var paramList = new
                {
                    TagUserID = obj.TagUserID,
                    ACTION = "VIEWWEIGHBRIDGEBYUSER"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeTagModel>("WeighBridgeTagView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// All weighbridge tag by logged user
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTag(ViewWeighBridgeTagModel obj)
        {
            List<ViewWeighBridgeTagModel> objviewlist = new List<ViewWeighBridgeTagModel>();
            try
            {
                var paramList = new
                {
                    UserID = obj.UserID,
                    ACTION = "VIEWWEIGHBRIDGETAG"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeTagModel>("WeighBridgeTagView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// loading of all weighbridgetag to be approved by district wise
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTagApproval(ViewWeighBridgeTagModel obj)
        {
            List<ViewWeighBridgeTagModel> objviewlist = new List<ViewWeighBridgeTagModel>();
            try
            {
                var paramList = new
                {
                    DistrictName = obj.DistrictName,
                    ACTION = "VIEWWEIGHBRIDGETAGAPPROVAL"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeTagModel>("WeighBridgeTagView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// loading of all weighbridgetag requests for consent before forwarding to approvals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTagRequest(ViewWeighBridgeTagModel obj)
        {
            List<ViewWeighBridgeTagModel> objviewlist = new List<ViewWeighBridgeTagModel>();
            try
            {
                var paramList = new
                {
                    UserID = obj.UserID,
                    ACTION = "VIEWWEIGHBRIDGETAGREQUEST"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeTagModel>("WeighBridgeTagView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<AddWeighBridgeTagModel> WBTagByTagID(ViewWeighBridgeTagModel obj)
        {
            AddWeighBridgeTagModel objaddmodel = new AddWeighBridgeTagModel();
            try
            {
                var paramList = new
                {
                    WeighBridgeTagID = obj.WeighBridgeTagID,
                    ACTION = "WBTAGBYTAGID"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryFirstAsync<AddWeighBridgeTagModel>("WeighBridgeTagView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objaddmodel = Output;
                return objaddmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Saving of weighbridge tag approval
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<MessageEF> WBTagApprove(ViewWeighBridgeTagModel obj)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeTagID", obj.WeighBridgeTagID);
                p.Add("@UserID", obj.ApprovedBy);
                p.Add("@ApproveRemarks", obj.ApproveRemarks);
                p.Add("@ACTION", "APPROVE");
                p.Add("@msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeTagInsert", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("msg");
                if (result == "1")
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// saving of weighbridge edit
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public async Task<MessageEF> WBTagEdit(AddWeighBridgeTagModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeTagID", objmodel.WeighBridgeTagID);
                p.Add("@WeighBridgeID", objmodel.WeighBridgeID);
                p.Add("@UserID", objmodel.UserID);
                p.Add("@ACTION", "EDIT");
                p.Add("@msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeTagInsert", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("msg");
                if (result == "1")
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// saving of weighbridge tag forward
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<MessageEF> WBTagForward(ViewWeighBridgeTagModel obj)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeTagID", obj.WeighBridgeTagID);
                p.Add("@ACTION", "FORWARD");
                p.Add("@msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeTagInsert", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("msg");
                if (result == "1")
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        public async Task<MessageEF> WBTagReject(ViewWeighBridgeTagModel obj)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeTagID", obj.WeighBridgeTagID);
                p.Add("@UserID", obj.ApprovedBy);
                p.Add("@ApproveRemarks", obj.ApproveRemarks);
                p.Add("@ACTION", "REJECT");
                p.Add("@msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeTagInsert", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("msg");
                if (result == "1")
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        public async Task<MessageEF> WBTagCheck(AddWeighBridgeTagModel obj)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeID", obj.WeighBridgeID);
                p.Add("@UserID", obj.UserID);
                p.Add("@ACTION", "CHECK");
                p.Add("@msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeTagInsert", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("msg");
                if (result == "1")
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTagHistory(ViewWeighBridgeTagModel obj)
        {
            List<ViewWeighBridgeTagModel> objviewlist = new List<ViewWeighBridgeTagModel>();
            try
            {
                var paramList = new
                {
                    WeighBridgeTagID = obj.WeighBridgeTagID,
                    ACTION = "VIEWWEIGHBRIDGETAGHISTORY"
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeTagModel>("WeighBridgeTagView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MessageEF> WBTagSave(AddWeighBridgeTagModel obj)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeID", obj.WeighBridgeID);
                p.Add("@UserID", obj.UserID);
                p.Add("@ACTION", "INSERT");
                p.Add("@msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeTagInsert", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("msg");
                if (result == "1")
                {
                    objMessage.Satus = result.ToString();
                }
                else if (result == "2")
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public async Task<MessageEF> WBTagRequest(ViewWeighBridgeTagModel obj)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeTagID", obj.WeighBridgeTagID);
                p.Add("@UserID", obj.ApprovedBy);
                p.Add("@ApproveType", obj.ApproveType);
                p.Add("@ApproveRemarks", obj.ApproveRemarks);
                p.Add("@ACTION", "REQUEST");
                p.Add("@ActionId", obj.ApproveType);
                p.Add("@msg", dbType: DbType.String, direction: ParameterDirection.Output, size: 300);
                var rr = await Connection.ExecuteScalarAsync("WeighBridgeTagInsert", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("msg");
                if (result == "1")
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "0";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeActionList(ViewWeighBridgeTagModel obj)
        {
            List<ViewWeighBridgeTagModel> objviewlist = new List<ViewWeighBridgeTagModel>();
            try
            {
                var paramList = new
                {
                    ACTION = "ViewActionList",
                    ActivityId = obj.ActivityId
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<ViewWeighBridgeTagModel>("WeighBridgeTagView", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objviewlist = Output.ToList();
                }
                return objviewlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
