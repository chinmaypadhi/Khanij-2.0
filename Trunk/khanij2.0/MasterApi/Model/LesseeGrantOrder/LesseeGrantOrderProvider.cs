// ***********************************************************************
//  Class Name               : LesseeGrantOrderProvider
//  Description              : Lessee Grant Order Class Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 16 July 2021
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

namespace MasterApi.Model.LesseeGrantOrder
{
    public class LesseeGrantOrderProvider: RepositoryBase,ILesseeGrantOrderProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LesseeGrantOrderProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To bind Grant order details in view
        /// </summary>
        /// <param name="objGrantOrderModel"></param>
        /// <returns></returns>
        public async Task<GrantOrderViewModel> GetGrantOrderDetails(GrantOrderViewModel objGrantOrderModel)
        {
            GrantOrderViewModel ObjGrantOrderDetails = new GrantOrderViewModel();
            try
            {
                var paramList = new
                {
                    UserId = objGrantOrderModel.UserId,
                    CHECK = 4
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<GrantOrderViewModel>("[USP_LESSEE_GRANT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjGrantOrderDetails = result.FirstOrDefault();
                }
                return ObjGrantOrderDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Grant Order details
        /// </summary>
        /// <param name="objGrantOrderModel"></param>
        public MessageEF UpdateGrantOrderDetails(GrantOrderViewModel objGrantOrderModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("GrantOrderId", objGrantOrderModel.GRANT_ORDER_ID);
                p.Add("GrantOrderNumber", objGrantOrderModel.GRANT_ORDER_NUMBER);
                if (objGrantOrderModel.GRANT_ORDER_DATE != null)
                {
                    p.Add("GrantOrderDate", objGrantOrderModel.GRANT_ORDER_DATE);
                }
                if (objGrantOrderModel.FROM_VALIDITY != null)
                {
                    p.Add("FromValidity", objGrantOrderModel.FROM_VALIDITY);
                }
                if (objGrantOrderModel.TO_VALIDITY != null)
                {
                    p.Add("ToValidity", objGrantOrderModel.TO_VALIDITY);
                }
                p.Add("ExecutionOfDeedNumber", objGrantOrderModel.EXECUTION_OF_DEED_NUMBER);
                if (objGrantOrderModel.EXECUTION_OF_DEED_DATE != null)
                {
                    p.Add("ExecutionOfDeedDate", objGrantOrderModel.EXECUTION_OF_DEED_DATE);
                }
                p.Add("GrantOrderFilePath", objGrantOrderModel.PATH_GRANT_ORDER_COPY);
                p.Add("GrantOrderFileName", objGrantOrderModel.FILE_GRANT_ORDER_COPY);
                p.Add("ExecutionOfDeedFilePath", objGrantOrderModel.PATH_EXECUTION_OF_DEED_COPY);
                p.Add("ExecutionOfDeedFileName", objGrantOrderModel.FILE_EXECUTION_OF_DEED_COPY);
                p.Add("Lease_Period", objGrantOrderModel.LEASE_PERIOD);
                p.Add("UserId", objGrantOrderModel.UserId);
                p.Add("UserLoginId", objGrantOrderModel.UserLoginId);
                p.Add("STATUS", objGrantOrderModel.STATUS);
                p.Add("MinesSection", objGrantOrderModel.MinesSection);
                p.Add("MinesAlloted", objGrantOrderModel.MinesAlloted);
                if(objGrantOrderModel.MinesAlloted!="MMDR")
                {
                    objGrantOrderModel.IsMinesSection = 0;
                    objGrantOrderModel.MinesSection = "";
                }
                p.Add("MinesType", objGrantOrderModel.MinesType);
                p.Add("MDPA_GRANT_ORDER_NUMBER", objGrantOrderModel.MDPA_GRANT_ORDER_NUMBER);
                p.Add("MDPA_GRANT_ORDER_DATE", objGrantOrderModel.MDPA_GRANT_ORDER_DATE);
                p.Add("MDPA_GRANT_AGREEMENT_DATE", objGrantOrderModel.MDPA_GRANT_AGREEMENT_DATE);
                p.Add("MDPA_PRODUCTION_QUANTITY", objGrantOrderModel.MDPA_PRODUCTION_QUANTITY);
                p.Add("PATH_MDPA_COPY", objGrantOrderModel.PATH_MDPA_COPY);
                p.Add("FILE_MDPA_COPY", objGrantOrderModel.FILE_MDPA_COPY);
                p.Add("AuctionTypeId", objGrantOrderModel.AuctionTypeId);
                if(objGrantOrderModel.AuctionTypeId==1 && objGrantOrderModel.LeaseExtender=="No")
                {
                    objGrantOrderModel.LEASEEXTENSION_FROM_VALIDITY =null;
                    objGrantOrderModel.LEASEEXTENSION_TO_VALIDITY = null;
                    objGrantOrderModel.PATH_LEASEEXTENSION = "";
                    objGrantOrderModel.FILE_LEASEEXTENSION = "";
                }
                p.Add("LeaseExtender", objGrantOrderModel.LeaseExtender);
                p.Add("LEASEEXTENSION_FROM_VALIDITY", objGrantOrderModel.LEASEEXTENSION_FROM_VALIDITY);
                p.Add("LEASEEXTENSION_TO_VALIDITY", objGrantOrderModel.LEASEEXTENSION_TO_VALIDITY);
                p.Add("PATH_LEASEEXTENSION", objGrantOrderModel.PATH_LEASEEXTENSION);
                p.Add("FILE_LEASEEXTENSION", objGrantOrderModel.FILE_LEASEEXTENSION);
                p.Add("MineralSalePercentage", objGrantOrderModel.MineralSalePercentage);
                p.Add("PATH_ALLOTTMENT", objGrantOrderModel.PATH_ALLOTTMENT);
                p.Add("FILE_ALLOTTMENT", objGrantOrderModel.FILE_ALLOTTMENT);
                p.Add("AllotmentAmount", objGrantOrderModel.AllotmentAmount);
                p.Add("FILE_DEMARCATION_COPY", objGrantOrderModel.FILE_DEMARCATION_COPY);
                p.Add("PATH_DEMARCATION_COPY", objGrantOrderModel.PATH_DEMARCATION_COPY);
                p.Add("FINALOFFER", objGrantOrderModel.FINAL_OFFER);
                p.Add("IsMinesSection", objGrantOrderModel.IsMinesSection);
                if (objGrantOrderModel.dtFYApprovedQuantity != null && objGrantOrderModel.dtFYApprovedQuantity.Rows.Count > 0)
                {
                    p.Add("BULK_PRODUCTION", objGrantOrderModel.dtFYApprovedQuantity, DbType.Object);
                }
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("CHECK", "1");
                Connection.Query<int>("[USP_LESSEE_GRANT]", p, commandType: CommandType.StoredProcedure);
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
        /// To bind Grant order Log History details in view
        /// </summary>
        /// <param name="objGrantOrderModel"></param>
        /// <returns></returns>
        public async Task<List<GrantOrderViewModel>> GetGrantOrderLogDetails(GrantOrderViewModel objGrantOrderModel)
        {
            List<GrantOrderViewModel> ObjGrantOrderLogDetails = new List<GrantOrderViewModel>();
            try
            {
                var paramList = new
                {
                    UserId = objGrantOrderModel.UserId,
                    CHECK = 8
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<GrantOrderViewModel>("[USP_LESSEE_GRANT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To bind Grant order Compare details in view
        /// </summary>
        /// <param name="objGrantOrderModel"></param>
        /// <returns></returns>
        public async Task<List<GrantOrderViewModel>> GetGrantOrderCompareDetails(GrantOrderViewModel objGrantOrderModel)
        {
            List<GrantOrderViewModel> ObjGrantOrderLogDetails = new List<GrantOrderViewModel>();
            try
            {
                var paramList = new
                {
                    UserId = objGrantOrderModel.UserId,
                    CHECK = 7
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<GrantOrderViewModel>("[USP_LESSEE_GRANT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Approve Lesse Grant Order details by DD
        /// </summary>
        /// <param name="objGrantOrderModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeGrantOrderDetails(GrantOrderViewModel objGrantOrderModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("APPROVED_BY", objGrantOrderModel.UserId);
                p.Add("Check", "5");
                p.Add("UserId", objGrantOrderModel.CREATED_BY);
                p.Add("GrantOrderId", objGrantOrderModel.GRANT_ORDER_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_GRANT]", p, commandType: CommandType.StoredProcedure);
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
        /// To Reject Lesse Grant Order details by DD
        /// </summary>
        /// <param name="objGrantOrderModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeGrantOrderDetails(GrantOrderViewModel objGrantOrderModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("REJECTED_BY", objGrantOrderModel.UserId);
                p.Add("Check", "6");
                p.Add("UserId", objGrantOrderModel.CREATED_BY);
                p.Add("GrantOrderId", objGrantOrderModel.GRANT_ORDER_ID);
                p.Add("Remarks", objGrantOrderModel.Remarks);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_LESSEE_GRANT", p, commandType: CommandType.StoredProcedure);
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
        /// To Delete Lesse Grant Order details
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeGrantOrderDetails(GrantOrderViewModel objGrantOrderModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check","9");
                p.Add("UserId", objGrantOrderModel.CREATED_BY);
                p.Add("GrantOrderId", objGrantOrderModel.GRANT_ORDER_ID);
                p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_LESSEE_GRANT]", p, commandType: CommandType.StoredProcedure);
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
        /// To Bind the Auction Type Details Data in View
        /// </summary>
        /// <param name="objGrantOrderModel"></param>
        /// <returns></returns>
        public async Task<List<GrantOrderViewModel>> GetAuctionTypeList(GrantOrderViewModel objGrantOrderModel)
        {
            List<GrantOrderViewModel> ObjAuctionypeList = new List<GrantOrderViewModel>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<GrantOrderViewModel>("[USP_GET_AUCTION_APPLICATIONTYPE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjAuctionypeList = result.ToList();
                }
                return ObjAuctionypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Grant Order Approved Quantity details in view
        /// </summary>
        /// <param name="objMiningProductionModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetApprovedQuantityDetails(MiningProductionModel objMiningProductionModel)
        {
            List<MiningProductionModel> Objlist = new List<MiningProductionModel>();
            try
            {
                var paramList = new
                {
                    UserId = objMiningProductionModel.CREATED_BY,
                    CHECK = 10
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MiningProductionModel>("[USP_LESSEE_GRANT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    Objlist = result.ToList();
                }
                return Objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Approved Quantity Log History details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<List<GrantOrderViewModel>> GetLesseeGrantOrderApprovedQuantityLogDetails(GrantOrderViewModel objGrantorderModel)
        {
            List<GrantOrderViewModel> ObjECLogDetails = new List<GrantOrderViewModel>();
            try
            {
                var paramList = new
                {
                    UserId = objGrantorderModel.UserId,
                    CHECK = 11
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<GrantOrderViewModel>("[USP_LESSEE_GRANT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjECLogDetails = result.ToList();
                }
                return ObjECLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Approved Quantity Log History details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<List<GrantOrderViewModel>> GetLesseeGrantOrderApprovedQuantityLogDetailsView(GrantOrderViewModel objGrantorderModel)
        {
            List<GrantOrderViewModel> ObjECLogDetails = new List<GrantOrderViewModel>();
            try
            {
                var paramList = new
                {
                    UserId = objGrantorderModel.UserId,
                    MODIFIED_ON = objGrantorderModel.MODIFIED_ON,
                    GrantOrderId = objGrantorderModel.GRANT_ORDER_ID,
                    STATUS = objGrantorderModel.STATUS,
                    CHECK = 12
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<GrantOrderViewModel>("[USP_LESSEE_GRANT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjECLogDetails = result.ToList();
                }
                return ObjECLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Compare details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        public async Task<List<MiningProductionModel>> GetLesseeGrantOrderApprovedQuantityCompareDetails(MiningProductionModel objGrantorderModel)
        {
            List<MiningProductionModel> ObjECLogDetails = new List<MiningProductionModel>();
            try
            {
                var paramList = new
                {
                    UserId = objGrantorderModel.CREATED_BY,
                    CHECK = 13
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<MiningProductionModel>("[USP_LESSEE_GRANT]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjECLogDetails = result.ToList();
                }
                return ObjECLogDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
