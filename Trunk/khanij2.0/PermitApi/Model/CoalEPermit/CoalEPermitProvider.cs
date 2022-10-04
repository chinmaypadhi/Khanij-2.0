using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;

namespace PermitApi.Model.CoalEPermit
{
    public class CoalEPermitProvider : RepositoryBase, ICoalEPermitProvider
    {
        public CoalEPermitProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Get the details of Coal type
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetTypeOfCoal(ePermitModel objLease)
        {

            ePermitResult ObjResult = new ePermitResult();

            List<ePermitModel> ObjUserTypeList = new List<ePermitModel>();
            try
            {
                var paramList = new
                {
                    UserId = objLease.UserID,
                    Check = 4,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("uspSampleGrade_Master", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    foreach (ePermitModel dr in result)
                    {
                        ObjUserTypeList.Add(new ePermitModel()
                        {
                            Production_Id = Convert.ToInt32(dr.eAuctionTypeId.ToString()),
                            ProductionFrom = dr.SchemeOfCoal.ToString(),


                        });
                    }
                    ObjResult.TypeOfCoalLst = ObjUserTypeList;
                }
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

                var result = await Connection.QueryAsync<ePermitModel>("CheckTotalPermitByUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo.TotalPermitLstByUserID = result.ToList(); ;
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

                var result = await Connection.QueryAsync<ePermitModel>("getDetailsByUserID", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo.DetailsPermitLstByUserID = result.ToList(); ;
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
                var result = await Connection.QueryMultipleAsync("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var PermitData = result.Read<ePermitModel>().ToList();
                UserInfo.DetailsPermitLstByUserID = PermitData;
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

                var result = await Connection.QueryMultipleAsync("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
        /// Get the permit payment data
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


                var paramList = new
                {
                    UserID = objUser.UserID,
                    BulkPermitID = objUser.BulkPermitId,
                    Check = "1",

                };
                var result = await Connection.QueryMultipleAsync("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var PermitData = result.Read<ePermitModel>().ToList();
                var PaymentData = result.Read<ePaymentData>().ToList();
                var WalletData = result.Read<ePaymentData>().ToList();

                UserInfo.PermitOperationLst = PermitData;
                UserInfo.PermitPaymentLst = PaymentData;
                UserInfo.WalletLst = WalletData;


            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        /// <summary>
        /// Get the saved coal permit list
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<List<ListCoalPermit>> GetSavedCoalPermit(ePermitModel objUser)
        {
            List<ListCoalPermit> ObjUserTypeList = new List<ListCoalPermit>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                    FromDATE = objUser.FromDATE,
                    ToDATE = objUser.ToDATE,
                    Check = 1,
                    SubUserId = objUser.SubUserID

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ListCoalPermit>("uspCoalEPermit", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Delete coal permit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteCoalData(ePermitModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("UserId", model.UserID);
                p.Add("BulkPermitId", model.BulkPermitId);
                var result = await Connection.ExecuteScalarAsync<string>("uspDeletePermit", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
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
        /// Download draft coal permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public async Task<ePermitResult> GetPermitViewWithoutDSC(ePermitModel objUser)
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

                var result = await Connection.QueryMultipleAsync("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);

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

        public async Task<List<ePaymentData>> GetDetailsOfConfig(ePermitModel objUser)
        {
            List<ePaymentData> ObjUserTypeList = new List<ePaymentData>();
            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,
                    BulkPermitID = objUser.PaymentTypeId,
                    Check = 4

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePaymentData>("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
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

        public async Task<MessageEF> UpgradeMineral(ePermitModel objUser)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                p.Add("Check", 2);
                p.Add("BulkPermitId", objUser.BulkPermitId);
                p.Add("LesseeId", objUser.UserID);
                p.Add("SampleQty", objUser.ProposedQty);
                p.Add("SampleGradeId", objUser.MineralGradeId);
                p.Add("SampleBasicRate", objUser.BasicRate);
                p.Add("PayableRoyalty", objUser.PayableRoyalty);
                p.Add("TCS", objUser.TCS);
                p.Add("Cess", objUser.Cess);
                p.Add("eCess", objUser.eCess);
                p.Add("DMF", objUser.DMF);
                p.Add("NMET", objUser.NMET);
                p.Add("TotalPayableAmount", objUser.TotalPayableAmount);
                p.Add("MineralId", objUser.MineralId);
                p.Add("RoyaltyId", objUser.RoyaltyRateID);
                p.Add("MineralNatureId", objUser.MineralNatureID);
                p.Add("NetBanking_mode", objUser.NetBanking_mode);
                var result = await Connection.ExecuteScalarAsync<string>("uspSampleGrade_Master", p, commandType: CommandType.StoredProcedure);
                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
                {
                    objMessage.Satus = result.ToString();
                }
                else
                {
                    objMessage.Satus = "3";
                }
            }
            catch (Exception ex)
            {
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }

        public async Task<ePermitModel> GetDetailsOfUpgrade(ePermitModel objUser)
        {
            ePermitModel ObjUserTypeList = new ePermitModel();
            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,
                    BulkPermitId = objUser.BulkPermitId,
                    Check = 5

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("uspSampleGrade_Master", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    ObjUserTypeList = result.FirstOrDefault();
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;
        }

        public async Task<ePermitResult> GetMinesDetails(ePermitModel objUser)
        {
            ePermitResult UserInfo = new ePermitResult();
            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,
                    Check=6,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("uspEPermitOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo.CheckList = result.ToList(); ;
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;
        }

        public async Task<ePermitModel> GetComapny(ePermitModel objUser)
        {
            ePermitModel UserInfo = new ePermitModel();
            try
            {
                var paramList = new
                {
                    UserID = objUser.UserID,
                    Check = 8,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("uspEPermitOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo = result.FirstOrDefault();
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;
        }

        public async Task<ePermitModel> GetCoalRoyalty(ePermitModel objUser)
        {
            ePermitModel UserInfo = new ePermitModel();
            try
            {
                var paramList = new
                {
                    MineralId = objUser.MineralId,
                    MineralNatureId = objUser.MineralNatureId,
                    MineralTypeId = objUser.MineralGradeId,
                    DistrictId= objUser.DistrictId,
                    Check = 46,

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePermitModel>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo = result.FirstOrDefault();
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;
        }

        public async Task<List<ePaymentData>> GetPaymentStatus(ePermitModel objUser)
        {
            List<ePaymentData> ObjUserTypeList = new List<ePaymentData>();
            try
            {
                var paramList = new
                {
                    Description= objUser.BulkPermitId,
                    Check = 48

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ePaymentData>("USPDYNAMICPAYMENTCONFIG", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
    }
}
