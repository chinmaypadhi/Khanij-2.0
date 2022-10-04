using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;

namespace PermitApi.Model.Permit
{
    public class LesseeProvider : RepositoryBase, ILesseeProvider
    {
        public LesseeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Get the mineral nature list
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetCoalMineralNatureList(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserId = objLease.UserID,
                    Coal = 1,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("GetCoalMineralNatureList", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            MineralNatureId = Convert.ToInt32(dr.MineralNatureId.ToString()),
                            MineralNature = dr.MineralNature.ToString(),


                        });
                    }
                    ObjResult.MineralNatureLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Get the mineral grade list
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetMineralGradeListOnNatureList(ePermitModel objLease)
        {
            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();

            try
            {
                var paramList = new
                {
                    UserId = objLease.UserID,
                    MineralNatureId = objLease.MineralNatureId,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("GetCoalMineralGradeList", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
        /// Save Bulk permit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddBulkPermit(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                if (model != null && model.BulkPermitId > 0)
                {
                    p.Add("BulkPermitId", model.BulkPermitId);
                    p.Add("Check", 2);
                }
                else
                {
                    p.Add("Check", 1);
                }
                p.Add("LeaseInfoId", model.UserID);              //model.LeaseInfoId
                p.Add("MineralId", model.MineralId);
                p.Add("MineralGradeId", model.MineralGradeId);
                p.Add("ProposedQty", model.ProposedQty);
                p.Add("ApprovedQty", model.ApprovedQty);
                p.Add("PayableRoyalty", model.PayableRoyalty);
                p.Add("TCS", model.TCS);
                p.Add("Cess", model.Cess);
                p.Add("eCess", model.eCess);
                p.Add("DMF", model.DMF);
                p.Add("NMET", model.NMET);
                p.Add("TotalPayableAmount", model.TotalPayableAmount);
                p.Add("TransactionalID", model.TransactionalID);
                p.Add("PaymentStatus", model.PaymentStatus);
                p.Add("PaymentReceiptID", model.PaymentReceiptID);
                p.Add("ActiveStatus", null);
                p.Add("Remarks", null);
                p.Add("IsMailed", model.IsMailed);
                p.Add("IsSMS", model.IsSMS);
                p.Add("LesseeId", model.UserID);            //model.LesseeId
                p.Add("UserLoginId", model.UserLoginId);
                p.Add("UserId", model.UserID);
                p.Add("IsCoal", model.IsCoal);
                p.Add("DONumber", model.DONumber);
                p.Add("DODate", model.DODate);
                p.Add("TypeOfCoalDispatched", model.TypeOfCoalDispatched);
                p.Add("EAuctionType", model.EAuctionType);
                p.Add("MineralSizeId", model.MineralSizeId);
                p.Add("BasicRate", model.BasicRate);
                p.Add("isForwarded", model.isForwarded);
                p.Add("MineralNatureId", model.MineralNatureId);

                p.Add("RoyaltyRate", model.RoyaltyRate);
                p.Add("RoyaltyRateID", model.RoyaltyRateID);
                p.Add("SubUserId", model.SubUserID);

                p.Add("AluminaContent", model.AluminaContent);
                p.Add("TinContent", model.TinContent);
                p.Add("MergeEPermitId", model.BulkPermitIdList);
                p.Add("ActualGrade", model.ActualGradeName);
                p.Add("IsWalletAdjusted", model.IsWalletAdjusted);


                // p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.ExecuteScalarAsync<string>("uspBulkPermit_New", p, commandType: CommandType.StoredProcedure);
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
        /// Check for available permit of perticula user
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> CheckTotalPermitByUser(ePermitModel objUser)
        {
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                var paramList = new
                {
                    USER_ID = objUser.UserID,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("CheckTotalPermitByUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo.TotalPermitLstByUserID = result.ToList(); ;
                }
                else
                {
                    UserInfo = null;
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get the permit details list of perticular user
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetPermitDetailsByUserID(ePermitModel objUser)
        {
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("getDetailsByUserID", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo.DetailsPermitLstByUserID = result.ToList(); ;
                }
                else
                {
                    UserInfo = null;
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get the lessee detilas of permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetPermitOperation(ePermitModel objUser)
        {
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo.DetailsPermitLstByUserID = result.ToList();
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get the lessee details on the basis of saved permit number
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetPermitOperationByBulkId(ePermitModel objUser)
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

                var result =await Connection.QueryMultipleAsync("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);

                var ApplDetails = result.Read<ePermitModel>().ToList();
                var PaymentDetails = result.Read<ePaymentData>().ToList();


                UserInfo.PermitOperationBulkIDLst = ApplDetails;
                UserInfo.PermitPaymentLst = PaymentDetails;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get the raimaining quantity
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GradeWiseCheckECQTY(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    MineralGradeID = objUser.MineralGradeId,

                    UserId = objUser.UserID,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("uspGetGradeWiseECCappingQty", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Get the royalty calculation list
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePaymentData>> RevisedPayableRoyaltyRate(ePermitModel objUser)
                {
            ePermitResult ObjResult = new ePermitResult();
            List<ePaymentData> ObjUserTypeList = new List<ePaymentData>();
            try
            {
                var paramList = new
                {
                    MineralNatureId = objUser.MineralNatureId,

                    MineralGradeId = objUser.MineralGradeId,
                    MineralId = objUser.MineralId,
                    Quantity = objUser.Quantity,
                    RoyaltyRate = objUser.RoyaltyRate,
                    BulkPermitId = objUser.BulkPermitId,
                    UserID = objUser.UserID,
                    AluminaContent = objUser.AluminaContent,
                    TinContent = objUser.TinContent,

                };
                DynamicParameters param = new DynamicParameters();

                // var result= 0 ;

                if (objUser.UserCode.ToUpper() == "TAILING DAM")
                {
                    var result =await Connection.QueryAsync<ePaymentData>("RoyaltyCalculationFor_TailingBulkPermit_Revised", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    ObjUserTypeList = result.ToList();
                }
                else
                {
                    
                   // var result =await Connection.QueryAsync<ePaymentData>("RoyaltyCalculationForBulkPermit_Revised", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    var result = await Connection.QueryAsync<ePaymentData>("RoyaltyCalculationForBulkPermit_Revised_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    ObjUserTypeList = result.ToList();
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;

        }
        public async Task<List<ePaymentData>> MergeRevisedPayableRoyaltyRate(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            List<ePaymentData> ObjUserTypeList = new List<ePaymentData>();
           
            try
            {
                var paramList = new
                {
                    MineralNatureId = objUser.MineralNatureID,

                    MineralGradeId = objUser.MineralGradeId,
                    MineralId = objUser.MineralId,
                    Quantity = objUser.Quantity,
                    RoyaltyRate = objUser.RoyaltyRate,
                    BulkPermitId = objUser.BulkPermitId,
                    UserID = objUser.UserID,
                    AluminaContent = objUser.AluminaContent,
                    TinContent = objUser.TinContent,

                };
                DynamicParameters param = new DynamicParameters();

                // var result= 0 ;

                if (objUser.UserCode.ToUpper() == "TAILING DAM")
                {
                    var result = await Connection.QueryAsync<ePaymentData>("RoyaltyCalculationFor_TailingBulkPermit_Revised", paramList, commandType: System.Data.CommandType.StoredProcedure);

                    ObjUserTypeList = result.ToList();
                }
                else
                {
                    var result =await Connection.QueryAsync<ePaymentData>("RoyaltyCalculationForBulkPermit_Revised", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Get the payment detaails of particular permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetePermitPayment(ePermitModel objUser)
        {

            ePermitResult UserInfo = new ePermitResult();
            try
            {

                DynamicParameters param = new DynamicParameters();

                // var result= 0 ;

                if (objUser.UserCode.ToUpper() == "TAILING DAM")
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,
                        BulkPermitID = objUser.BulkPermitId,

                    };
                    var result =await Connection.QueryMultipleAsync("getDetailsByTailingDamUserID_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    var PermitData = result.Read<ePermitModel>().ToList();
                    var PaymentData = result.Read<ePaymentData>().ToList();

                    UserInfo.PermitOperationLst = PermitData;
                    UserInfo.PermitPaymentLst = PaymentData;
                }
                else
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,
                        BulkPermitID = objUser.BulkPermitId,
                        Check = "1",

                    };
                    var result =await Connection.QueryMultipleAsync("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    var PermitData = result.Read<ePermitModel>().ToList();
                    var PaymentData = result.Read<ePaymentData>().ToList();
                    var WalletData = result.Read<ePaymentData>().ToList();

                    UserInfo.PermitOperationLst = PermitData;
                    UserInfo.PermitPaymentLst = PaymentData;
                    UserInfo.WalletLst = WalletData;
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get the merge permit list
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GetMergePermitList(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
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
        /// Get the mineral grade list
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetMergePermitMineralGrade(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();

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
                            MineralGradeId = Convert.ToInt32(dr.MineralGradeId.ToString()),
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
        /// Get the merge permit list
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> MergeEpermitOperation(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                if (objUser.BulkPermitIdList != null)
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,
                        BulkPermitIdList = objUser.BulkPermitIdList
                    };
                    DynamicParameters param = new DynamicParameters();

                    var result =await Connection.QueryAsync<ePermitModel>("uspMergeEPermitOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {

                        UserInfo.MergeEPermitLst = result.ToList(); ;
                    }
                }
                else if (objUser.BulkPermitId != 0)
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,
                        Check = 1,
                        BulkPermitID = objUser.BulkPermitId,
                    };
                    DynamicParameters param = new DynamicParameters();

                    var result =await Connection.QueryAsync<ePermitModel>("uspMergeEPermitOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {

                        UserInfo.MergeEPermitLst = result.ToList(); ;
                    }
                }
                else if (objUser.BulkPermitIdList == null)
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,

                    };
                    DynamicParameters param = new DynamicParameters();

                    var result = await Connection.QueryAsync<ePermitModel>("uspMergeEPermitOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {

                        UserInfo.MergeEPermitLst = result.ToList(); ;
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
        /// Save merge permit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddMergeBulkPermit(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                if (model != null && model.BulkPermitId > 0)
                {
                    p.Add("BulkPermitId", model.BulkPermitId);
                    p.Add("Check", 2);
                }
                else
                {
                    p.Add("Check", 1);
                }
                p.Add("LeaseInfoId", model.UserID);              //model.LeaseInfoId
                p.Add("MineralId", model.MineralId);
                p.Add("MineralGradeId", model.MineralGradeId);
                p.Add("ProposedQty", model.ProposedQty);
                p.Add("ApprovedQty", model.ApprovedQty);
                p.Add("PayableRoyalty", model.PayableRoyalty);
                p.Add("TCS", model.TCS);
                p.Add("Cess", model.Cess);
                p.Add("eCess", model.eCess);
                p.Add("DMF", model.DMF);
                p.Add("NMET", model.NMET);
                p.Add("TotalPayableAmount", model.TotalPayableAmount);
                p.Add("TransactionalID", model.TransactionalID);
                p.Add("PaymentStatus", model.PaymentStatus);
                p.Add("PaymentReceiptID", model.PaymentReceiptID);
                p.Add("ActiveStatus", null);
                p.Add("Remarks", null);
                p.Add("IsMailed", model.IsMailed);
                p.Add("IsSMS", model.IsSMS);
                p.Add("LesseeId", model.UserID);            //model.LesseeId
                p.Add("UserLoginId", model.UserLoginId);
                p.Add("UserId", model.UserID);
                p.Add("IsCoal", model.IsCoal);
                p.Add("DONumber", model.DONumber);
                p.Add("DODate", model.DODate);
                p.Add("TypeOfCoalDispatched", model.TypeOfCoalDispatched);
                p.Add("EAuctionType", model.EAuctionType);
                p.Add("MineralSizeId", model.MineralSizeId);
                p.Add("BasicRate", model.BasicRate);
                p.Add("isForwarded", model.isForwarded);
                p.Add("MineralNatureId", model.MineralNatureId);

                p.Add("RoyaltyRate", model.RoyaltyRate);
                p.Add("RoyaltyRateID", model.RoyaltyRateID);
                p.Add("SubUserId", model.SubUserID);

                p.Add("AluminaContent", model.AluminaContent);
                p.Add("TinContent", model.TinContent);
                p.Add("MergeEPermitId", model.BulkPermitIdList);
                p.Add("ActualGrade", model.ActualGradeName);
                p.Add("IsWalletAdjusted", model.IsWalletAdjusted);


                // p.Add("RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result =await Connection.ExecuteScalarAsync<string>("uspBulkPermit_New", p, commandType: CommandType.StoredProcedure);
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
        /// get the mineral nature name
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetMineralNatureName(ePermitModel objLease)
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
                    MineralId = objLease.MineralId,
                    MineralNatureID = objLease.MineralNatureId,
                    MineralGradeId = objLease.MineralGradeId,
                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("uspGetMineralNatureName", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    //foreach (ePermitModel dr in result)
                    //{
                    //    ObjUserTypeList.Add(new ePermitModel()
                    //    {
                    //        MineralGradeID = Convert.ToInt32(dr.MineralGradeID.ToString()),
                    //        MineralGrade = dr.MineralGrade.ToString(),


                    //    });
                    //}
                    ObjResult.MineralNatureLst = result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Get the details of bulk permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GetBulkPermitDetails(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            DataTable ObjDt = new DataTable();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            ePermitModel UserInfoEF = new ePermitModel();
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                    FromDATE = objUser.FromDATE,
                    ToDATE = objUser.ToDATE,
                    Check = 4,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<ePermitModel>("uspBulkPermit_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Get the permit payment list
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GetApprovedBulkPermitDetails(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            DataTable ObjDt = new DataTable();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            ePermitModel UserInfoEF = new ePermitModel();
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                if (objUser.permittype == "GeneratedPermit")
                {
                    var paramList = new
                    {
                        UserId = objUser.UserID,
                        SubUserId = objUser.SubUserID,
                        FromDate = objUser.FromDATE,
                        ToDate = objUser.ToDATE,
                        Check = 3,

                    };

                    DynamicParameters param = new DynamicParameters();

                    var result =await Connection.QueryAsync<ePermitModel>("uspEPermitStatus", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {

                        ObjUserTypeList = result.ToList();
                    }
                }
                else if (objUser.permittype == "ArchivePermit")
                {
                    var paramList = new
                    {
                        UserId = objUser.UserID,
                        SubUserId = objUser.SubUserID,
                        FromDate = objUser.FromDATE,
                        ToDate = objUser.ToDATE,
                        Check = 4,

                    };

                    DynamicParameters param = new DynamicParameters();

                    var result =await Connection.QueryAsync<ePermitModel>("uspEPermitStatus", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {

                        ObjUserTypeList = result.ToList();
                    }
                }
                else
                {
                    var paramList = new
                    {
                        UserId = objUser.UserID,
                        SubUserId = objUser.SubUserID,
                        FromDate = objUser.FromDATE,
                        ToDate = objUser.ToDATE,
                        Check = 2,

                    };

                    DynamicParameters param = new DynamicParameters();

                    var result =await Connection.QueryAsync<ePermitModel>("uspEPermitStatus", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    if (result.Count() > 0)
                    {

                        ObjUserTypeList = result.ToList();
                    }
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;

        }
        /// <summary>
        /// Get the generated pemit data
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetPermitViewWithoutDSC(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            ePermitModel UserInfoEF = new ePermitModel();
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                if (objUser.UserType.ToUpper() == "TAILING DAM")
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,

                        BulkPermitID = objUser.BulkPermitId,

                    };
                    DynamicParameters param = new DynamicParameters();

                    var result =await Connection.QueryMultipleAsync("getDetailsByTailingDamUserID", paramList, commandType: System.Data.CommandType.StoredProcedure);

                    var ApplDetails = result.Read<ePermitModel>().ToList();
                    var PaymentDetails = result.Read<ePaymentData>().ToList();


                    UserInfo.PermitOperationBulkIDLst = ApplDetails;
                    UserInfo.PermitPaymentLst = PaymentDetails;
                }
                else
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,
                        Check = 1,
                        BulkPermitID = objUser.BulkPermitId,

                    };
                    DynamicParameters param = new DynamicParameters();

                    var result =await Connection.QueryMultipleAsync("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);

                    var ApplDetails = result.Read<ePermitModel>().ToList();
                    var PaymentDetails = result.Read<ePaymentData>().ToList();


                    UserInfo.PermitOperationBulkIDLst = ApplDetails;
                    UserInfo.PermitPaymentLst = PaymentDetails;
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get permit payment data
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetPermitTransDetails(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            //  SqlHelperClass gObjSqlHelper = new SqlHelperClass();
            DataTable ObjDt = new DataTable();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            ePermitModel UserInfoEF = new ePermitModel();
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                if (objUser.UserType.ToUpper() == "TAILING DAM")
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,

                        BulkPermitID = objUser.BulkPermitId,

                    };
                    DynamicParameters param = new DynamicParameters();

                    var result =await Connection.QueryMultipleAsync("getDetailsByTailingDamUserID", paramList, commandType: System.Data.CommandType.StoredProcedure);

                    var ApplDetails = result.Read<ePermitModel>().ToList();
                    var PaymentDetails = result.Read<ePaymentData>().ToList();


                    UserInfo.PermitOperationBulkIDLst = ApplDetails;
                    UserInfo.PermitPaymentLst = PaymentDetails;
                }
                else
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,
                        Check = 1,
                        BulkPermitID = objUser.BulkPermitId,

                    };
                    DynamicParameters param = new DynamicParameters();

                    var result =await Connection.QueryMultipleAsync("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);

                    var ApplDetails = result.Read<ePermitModel>().ToList();
                    var PaymentDetails = result.Read<ePaymentData>().ToList();


                    UserInfo.PermitOperationBulkIDLst = ApplDetails;
                    UserInfo.PermitPaymentLst = PaymentDetails;
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// get RPTP Permit List
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<LicenseInfoRPTP>> GetRPTPPendingPermitList(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            List<LicenseInfoRPTP> ObjUserTypeList = new List<LicenseInfoRPTP>();
            ePermitModel UserInfoEF = new ePermitModel();
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,

                    Check = 1,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<LicenseInfoRPTP>("uspRPTPPermit_CheckClosingStock", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Get the basic details of Licensee for RPTP
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<LicenseeRPTPResult> GetLicenseeRPTPPermit(LicenseInfoRPTP objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            LicenseeRPTPResult UserInfo = new LicenseeRPTPResult();
            try
            {
                var paramList = new
                {
                    CreatedBy = objUser.UserID,
                    MineralId = objUser.MineralId,
                    MineralGradeId = objUser.MineralGradeId,
                    MineralNatureId = objUser.MineralFormId,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<LicenseInfoRPTP>("uspLicensee_GenerateRPTPPermit", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo.RPTPPermitLst = result.ToList(); ;
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get the closing stock of RPTP
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<LicenseeRPTPResult> GetLicenseeRPTPClosingPermit(LicenseInfoRPTP objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            LicenseeRPTPResult UserInfo = new LicenseeRPTPResult();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                    MineralId = objUser.MineralId,
                    MineralGradeId = objUser.MineralGradeId,
                    MineralNatureId = objUser.MineralFormId,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<LicenseInfoRPTP>("uspRPTPPermit_CheckClosingStock", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo.RPTPClosingPermitLst = result.ToList(); ;
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get the RPTP final data
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<LicenseInfoRPTP>> GetDGMApprovedRPTPList(LicenseInfoRPTP objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            List<LicenseInfoRPTP> ObjUserTypeList = new List<LicenseInfoRPTP>();
            ePermitModel UserInfoEF = new ePermitModel();
            ePermitResult UserInfo = new ePermitResult();
            string proc= "uspRPTPPermit";
            int check;
            if (objUser.UserType == "Licensee")
            {
                proc = "uspRPTPPermit";
            }
            else if (objUser.UserType == "End User")
            {
                proc = "uspRPTPPermit_EndUser";
            }
            if (objUser.permittype == "GeneratedPermit")
            {
                check = 19;
            }
            else 
            {
                check = 6;
            }
            try
            {
               
                    var paramList = new
                    {
                        CreatedBy = objUser.UserID,

                        Check = check,
                        FromDate1=objUser.FromDate,
                        ToDate1=objUser.ToDate,
                        SubUserID=objUser.SubUserID,

                    };
                    DynamicParameters param = new DynamicParameters();

                    var result =await Connection.QueryAsync<LicenseInfoRPTP>(proc, paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Archive permit list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> ArchviveUnArchivePermit(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                if (model.permittype == "ArchivePermit")
                {
                    var paramList = new
                    {
                        UserId = model.UserID,
                        BulkPermitId = model.BulkPermitId,
                        chk =1,
                    };

                    DynamicParameters param = new DynamicParameters();
                  
                    var result = await Connection.ExecuteScalarAsync<string>("uspArchivePermit", paramList, commandType: CommandType.StoredProcedure);
                    if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                    {
                        objMessage.Satus = result.ToString();

                    }
                    else
                    {
                        objMessage.Satus = string.Empty;
                    }
                }
               else if (model.permittype == "UnArchivePermit")
                {
                    var paramList = new
                    {
                        UserId = model.UserID,
                        BulkPermitId = model.BulkPermitId,
                        chk = 2,
                    };

                    DynamicParameters param = new DynamicParameters();

                    var result = await Connection.ExecuteScalarAsync<string>("uspArchivePermit", paramList, commandType: CommandType.StoredProcedure);
                    if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                    {
                        objMessage.Satus = result.ToString();

                    }
                    else
                    {
                        objMessage.Satus = string.Empty;
                    }
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
        /// Save bulk permit list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddRPTPBulkPermit(LicenseInfoRPTP model)
        {
            MessageEF objMessage = new MessageEF();
            string proc = "uspRPTPPermit";
            if (model.UserType == "Licensee")
            {
                proc = "uspRPTPPermit";
            }
            else if (model.UserType == "End User")
            {
                proc = "uspRPTPPermit_EndUser";
            }
            try
            {
                var p = new DynamicParameters();


                if (model != null && model.BultPermitId > 0)
                {
                    p.Add("RPTPBulkPermitId", model.BultPermitId);
                    p.Add("BulkPermitNo", model.BulkPermitNo);
                    p.Add("Check", 3);
                }
                else
                {
                    p.Add("listOfSelectedPass", model.listOfSelectedPass);
                    p.Add("Check", 2);
                }
                p.Add("CreatedBy", model.UserID);
                p.Add("LicenseeInfoId", model.UserID);//model.LeaseInfoId
                p.Add("MineralId", model.MineralId);
                p.Add("MineralGradeId", model.MineralGradeId);
                p.Add("MineralNatureId", model.MineralNatureId);
                p.Add("DispatchedQty", model.QuantitytobeDispatched);
                p.Add("FromDate", model.FromDate);
                p.Add("ToDate", model.ToDate);

                p.Add("ApprovedQty", model.ApprovedQty);
               
                p.Add("ActiveStatus", model.ActiveStatus);
                p.Add("Remark", model.Remark);
                p.Add("IsApproved", model.IsApproved);
                p.Add("IsReject", model.IsReject);
                p.Add("TypeOfCoal", model.TypeOfCoal);            //model.LesseeId
                p.Add("TypeOfCoalToBeDistpatch", model.TypeOfCoalTobeDispatch);
                p.Add("isForwarded", model.isForwarded);
                p.Add("SubUserID", model.SubUserID);
               
                var result =await Connection.ExecuteScalarAsync<string>(proc, p, commandType: CommandType.StoredProcedure);
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
        /// Get RPTP details
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<LicenseInfoRPTP>> getRPTPDetails(LicenseInfoRPTP objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            List<LicenseInfoRPTP> ObjUserTypeList = new List<LicenseInfoRPTP>();
            ePermitModel UserInfoEF = new ePermitModel();
            ePermitResult UserInfo = new ePermitResult();
            string proc = "uspRPTPPermit";
            
            if (objUser.UserType == "Licensee")
            {
                proc = "uspRPTPPermit";
            }
            else if (objUser.UserType == "End User")
            {
                proc = "uspRPTPPermit_EndUser";
            }
           
            try
            {

                var paramList = new
                {
                    CreatedBy = objUser.UserID,

                    Check = 1,
                    RPTPBulkPermitId = objUser.RPTPBulkPermitId,
                    

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<LicenseInfoRPTP>(proc, paramList, commandType: System.Data.CommandType.StoredProcedure);
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

                    var result =await Connection.QueryAsync<ePermitModel>("getDetailsByTailingDamUserID", paramList, commandType: System.Data.CommandType.StoredProcedure);
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

                    var result =await Connection.QueryAsync<ePermitModel>("getDetailsByUserID", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
                        Check=1,
                        BulkPermitID = objUser.BulkPermitId,

                    };
                    DynamicParameters param = new DynamicParameters();

                    var result =await Connection.QueryMultipleAsync("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
        /// <summary>
        /// Fill State
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> FillState(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    ACTION="A",
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            StateID = Convert.ToInt32(dr.StateID.ToString()),
                            StateName = dr.StateName.ToString(),


                        });
                    }
                    ObjResult.StateLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Fill District
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> FillDistrict(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    ACTION = "C",
                    StateId=objLease.StateID,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            DistrictId = Convert.ToInt32(dr.DistrictId.ToString()),
                            DistrictName = dr.DistrictName.ToString(),


                        });
                    }
                    ObjResult.DistrictLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Fill District
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> FillUserType(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    ACTION = "F",
                    
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            UserTypeId = Convert.ToInt32(dr.UserTypeId.ToString()),
                            UserType = dr.UserType.ToString(),


                        });
                    }
                    ObjResult.UserTypeLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> FillModuleType(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    ACTION = "G",

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            ModuleId = Convert.ToInt32(dr.ModuleId.ToString()),
                            ModuleName = dr.ModuleName.ToString(),


                        });
                    }
                    ObjResult.ModuleTypeLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        /// <summary>
        /// Bind sub module
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> FillSubModuleType(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    ACTION = "I",
                    ModuleId=objLease.ModuleId,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USP_FILL_COMMON_DATA", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            SubModuleId = Convert.ToInt32(dr.SubModuleId.ToString()),
                            SubModuleName = dr.SubModuleName.ToString(),


                        });
                    }
                    ObjResult.SubModuleTypeLst = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }
        public async Task<List<ePermitModel>> GetCheckListData(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 18,
                    ModuleId = objUser.ModuleId,
                    SubModuleId = objUser.SubModuleId,
                    RiderConfigId = objUser.RiderConfigId,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Save bulk permit list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddRiderConfigMaster(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
           
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 19);
                p.Add("StateID", model.StateID);
                p.Add("DistrictId", model.DistrictId);
                p.Add("LesseeId", model.LesseeId);
                p.Add("UserTypeId", model.UserTypeId);
                p.Add("ModuleId", model.ModuleId);
                p.Add("SubModuleId", model.SubModuleId);
                p.Add("CreatedBy", model.UserID);
                p.Add("CheckListId", model.SelectedRiderList);
                p.Add("RiderConfigId", model.RiderConfigId);
                p.Add("RiderType", model.RiderType);
                p.Add("MineralTypeId", model.MineralTypeId);


                var result = await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
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
        /// View Rider config master
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> ViewRiderConfigMaster(ePermitModel objUser)
        {
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 20,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Delete Rider config
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteRiderConfigMaster(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();

            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 21);
                p.Add("CreatedBy", model.UserID);
                p.Add("RiderConfigId", model.RiderConfigId);
                var result = await Connection.ExecuteScalarAsync<string>("USPDYNAMICPAYMENTCONFIG", p, commandType: CommandType.StoredProcedure);
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
        /// 
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> EditRiderConfigMaster(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    Check = 22,
                    RiderConfigId = objUser.RiderConfigId,

                };
                DynamicParameters param = new DynamicParameters();

                //var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
                //if (result.Count() > 0)
                //{

                //    ObjUserTypeList = result.ToList();
                //}
                var result = await Connection.QueryMultipleAsync("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);

                var ApplDetails = result.Read<ePermitModel>().ToList();
                var ChecklistDetails = result.Read<ePermitModel>().ToList();


                ObjResult.RiderLst = ApplDetails;
                ObjResult.CheckList = ChecklistDetails;

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;

        }
        /// <summary>
        /// Save Checkout payment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> CheckOutPayment(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 5);
                p.Add("UserId", model.UserID);
                p.Add("BulkPermitId", model.BulkPermitId);
                DataTable dt = new DataTable("Payment");
                dt.Columns.Add("BulkPaymentId", typeof(System.Int32));
                dt.Columns.Add("WalletAmt", typeof(System.Decimal));
                dt.Columns.Add("Adjust", typeof(System.Decimal));
                dt.Columns.Add("FinalAmt", typeof(System.Decimal));
                if (model.PaymentDetails != null)
                {
                    for (int i = 0; i < model.PaymentDetails.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["BulkPaymentId"] = model.PaymentDetails[i].BulkPaymentId;
                        dr["WalletAmt"] = model.PaymentDetails[i].WalletAmount;
                        dr["Adjust"] = model.PaymentDetails[i].AdjustmentAmount;
                        dr["FinalAmt"] = model.PaymentDetails[i].Amount;
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                    System.IO.StringWriter strw = new System.IO.StringWriter();
                    dt.WriteXml(strw);
                    string strXML = strw.ToString();
                    strw.Close();
                    strw.Dispose();
                    p.Add("xmlData", strXML);
                }
                var result = await Connection.ExecuteScalarAsync<string>("uspEPermitOperation_New", p, commandType: CommandType.StoredProcedure);

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
        /// Get the payment detaails of particular permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetCheckOutPermitPayment(ePermitModel objUser)
        {

            ePermitResult UserInfo = new ePermitResult();
            try
            {

                DynamicParameters param = new DynamicParameters();

                // var result= 0 ;

                if (objUser.UserCode.ToUpper() == "TAILING DAM")
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,
                        BulkPermitID = objUser.BulkPermitId,

                    };
                    var result = await Connection.QueryMultipleAsync("getDetailsByTailingDamUserID_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    var PermitData = result.Read<ePermitModel>().ToList();
                    var PaymentData = result.Read<ePaymentData>().ToList();

                    UserInfo.PermitOperationLst = PermitData;
                    UserInfo.PermitPaymentLst = PaymentData;
                }
                else
                {
                    var paramList = new
                    {
                        UserID = objUser.UserID,
                        BulkPermitID = objUser.BulkPermitId,
                        Check = "6",

                    };
                    var result = await Connection.QueryMultipleAsync("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    var PermitData = result.Read<ePermitModel>().ToList();
                    var PaymentData = result.Read<ePaymentData>().ToList();
                    var WalletData = result.Read<ePaymentData>().ToList();

                    UserInfo.PermitOperationLst = PermitData;
                    UserInfo.PermitPaymentLst = PaymentData;
                    UserInfo.WalletLst = WalletData;
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get the lessee  permit quantity
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GetPermitQuantity(ePermitModel objUser)
        {
            List<ePermitModel> UserInfo = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,
                    Check=1

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("uspGetLesseDashboardData", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo = result.ToList(); ;
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get the closing  permit quantity
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GetTotalPermitByUser(ePermitModel objUser)
        {
            List<ePermitModel> UserInfo = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objUser.UserID,
                    Check = 2

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("CheckTotalPermitByUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo = result.ToList(); ;
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Save closing permit quantity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddTotalPermitByUser(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Check", 1);
                p.Add("USER_ID", model.UserID);
                p.Add("TillDateDispatchQty", model.TillDateDispatchedQty);
                if (model.TillDateBalanceUpfrontPayment == null)
                {
                    model.TillDateBalanceUpfrontPayment = 0;
                }
                p.Add("TillDateBalanceUpfront", model.TillDateBalanceUpfrontPayment);
                var result = await Connection.ExecuteScalarAsync<string>("CheckTotalPermitByUser", p, commandType: CommandType.StoredProcedure);

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
        /// Get the closing  permit details
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ePermitModel>> GetPermitColosingDtls(ePermitModel objUser)
        {
            List<ePermitModel> UserInfo = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    USER_ID = objUser.UserID,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("CheckTotalPermitByUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    UserInfo = result.ToList();
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }

        public async Task<MessageEF> AddWeighbridge(PermitWeighBridgeMapp objUser)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("UserId", objUser.UserId);
                p.Add("PermitId", objUser.PermitId);
                p.Add("WeighBridgeId", objUser.WeighBridgeId);
                p.Add("Createdby", objUser.Createdby);
                p.Add("Modifiedby", objUser.Modifiedby);
                p.Add("PermitType", objUser.PermitType);
                p.Add("Check", "1");
                var result = await Connection.ExecuteScalarAsync<string>("Sp_PermitWeighBridgeMapping", p, commandType: CommandType.StoredProcedure);
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

        public async Task<MessageEF> UpdateWeighbridge(PermitWeighBridgeMapp objUser)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("PermitWeighBridgeId", objUser.PermitWeighBridgeId);
                p.Add("WeighBridgeId", objUser.WeighBridgeId);
                p.Add("Modifiedby", objUser.Modifiedby);
                p.Add("Check", "2");
                var result = await Connection.ExecuteScalarAsync<string>("Sp_PermitWeighBridgeMapping", p, commandType: CommandType.StoredProcedure);
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

        public async Task<PermitWeighBridgeMapp> EditWeighbridge(PermitWeighBridgeMapp objUser)
        {
            PermitWeighBridgeMapp model = new PermitWeighBridgeMapp();
            try
            {
                var paramList = new
                {
                    PermitWeighBridgeId = objUser.PermitWeighBridgeId,
                    Check = "3",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<PermitWeighBridgeMapp>("Sp_PermitWeighBridgeMapping", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    model = result.FirstOrDefault();
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                model = null;
            }
        }

        public async Task<List<PermitWeighBridgeMapp>> ViewWeighbridge(PermitWeighBridgeMapp objUser)
        {
            List<PermitWeighBridgeMapp> model = new List<PermitWeighBridgeMapp>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserId,
                    Check = "5",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<PermitWeighBridgeMapp>("Sp_PermitWeighBridgeMapping", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    model = result.ToList();
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                model = null;
            }
        }

        public async Task<MessageEF> DeleteWeighbridge(PermitWeighBridgeMapp objUser)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("PermitWeighBridgeId", objUser.PermitWeighBridgeId);
                p.Add("Check", "4");
                var result = await Connection.ExecuteScalarAsync<string>("Sp_PermitWeighBridgeMapping", p, commandType: CommandType.StoredProcedure);
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

        public async Task<PermitWeighBridgeMapp> FilterViewWeighbridge(PermitWeighBridgeMapp objUser)
        {
            PermitWeighBridgeMapp model = new PermitWeighBridgeMapp();
            try
            {
                var paramList = new
                {
                    PermitId = objUser.PermitId,
                    Check = "6",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<PermitWeighBridgeMapp>("Sp_PermitWeighBridgeMapping", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    model = result.FirstOrDefault();
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                model = null;
            }
        }

        public async Task<ePermitResult> GetSECLDODetails(ePermitModel objUser)
        {
            ePermitResult ObjResult = new ePermitResult();
            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();

            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,
                    Check = 20,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("uspBulkPermit_New", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            DONumber = dr.DONumber.ToString(),

                        });
                    }
                    ObjResult.GetSECLDODetails = ObjUserTypeList;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ObjResult;
        }

        public async Task<ePermitModel> GetTaggedDetails(ePermitModel objUser)
        {
            ePermitModel model = new ePermitModel();
            try
            {
                var paramList = new
                {
                    DONumber = objUser.DONumber,
                    Check = 21,
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<ePermitModel>("uspBulkPermit_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    model = result.FirstOrDefault();
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                model = null;
            }
        }
    }
}
