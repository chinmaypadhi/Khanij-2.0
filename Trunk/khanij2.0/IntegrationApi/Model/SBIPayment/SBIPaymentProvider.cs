using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationEF;
using Dapper;

using IntegrationApi.Factory;
using IntegrationApi.Repository;
using System.Data;
using System.Data.SqlClient;

namespace IntegrationApi.Model.SBIPayment
{
    public class SBIPaymentProvider : RepositoryBase, ISBIPaymentProvider
    {
        public SBIPaymentProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<PaymentResult> GetPaymentGateway(PaymentEF objUser)
        {

            PaymentResult UserInfo = new PaymentResult();
            try
            {

                DynamicParameters param = new DynamicParameters();
               
                    var paramList = new
                    {
                        Bank = objUser.PaymentBank,
                        BulkPermitId = objUser.BulkPermitId,
                        UserId=objUser.UserId

                    };
                    var result = await Connection.QueryMultipleAsync("getPaymentGateway_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                    var TransData = result.Read<PaymentEF>().ToList();
                    var PaymentData = result.Read<PaymentEF>().ToList();

                    UserInfo.TransLst = TransData;
                    UserInfo.PaymentLst = PaymentData;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        public async Task<MessageEF> InsertPaymentRequest(PaymentEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                
                p.Add("PAYMENTFOR", model.PAYMENTFOR);              //model.LeaseInfoId
                p.Add("UserId", model.UserId);
                p.Add("RequestType", model.RequestType);
                p.Add("MerchantCode", model.MerchantCode);
                p.Add("MerchantTxnRefNumber", model.MerchantTxnRefNumber);
                p.Add("ITC", model.ITC);
                p.Add("Amount", model.AMOUNT);
                p.Add("CurrencyCode", model.Currencycode);
                p.Add("UniqueCustomerID", model.UniqueCustomerID);
                p.Add("ReturnUrl", model.returnURL);
                p.Add("S2SReturnURL", model.S2SReturnURL);
                p.Add("TPSLTXNID", model.TPSLTXNID);
                p.Add("Shoppingcartdetails", model.Shoppingcartdetails);
                p.Add("TxnDate", model.TxnDate);
                p.Add("Email", model.Email);
                p.Add("MobileNo", model.MobileNo);
                p.Add("Bankcode", model.BankCode);
                p.Add("CustomerName", model.CustomerName);
                p.Add("PropertyPath", model.PropertyPath);
                p.Add("PaymentEncryptedData", model.PaymentEncryptedData);            //model.LesseeId
                p.Add("PaymentMode", model.PaymentModeString);
                var result =await Connection.ExecuteScalarAsync<Int32>("InsertUpdatePaymentRecords_New", p, commandType: CommandType.StoredProcedure);
                // int response = p.Get<int>("RESULT");

                if (result != null && !string.IsNullOrEmpty(Convert.ToString(result)))
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
                objMessage.Satus = "-1";
                throw ex;
            }
            return objMessage;
        }
        public async Task<PaymentResult> PaymentStatusReport(PaymentEF objUser)
        {

            PaymentResult UserInfo = new PaymentResult();
            try
            {

                DynamicParameters param = new DynamicParameters();

                var paramList = new
                {
                    MerchantTxnRefNumber = objUser.MerchantTxnRefNumber,
                    UserId = objUser.UserId,
                    PaymentTYpe = objUser.PaymentType

                };
                var result =await Connection.QueryMultipleAsync("getPaymentStatusReport_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var TransData = result.Read<PaymentEF>().ToList();
                var PaymentData = result.Read<PaymentEF>().ToList();

                UserInfo.TransLst = TransData;
                UserInfo.PaymentLst = PaymentData;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;

        }
        public async Task<MessageEF> PaymentStatusReportInsert(PaymentEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();


                p.Add("UserId", model.UserId);
                p.Add("PaymentTYpe", model.PaymentType);
                p.Add("MerchantTxnRefNumber", model.MerchantTxnRefNumber);
               
                var result =await Connection.ExecuteScalarAsync<string>("getPaymentStatusReport", p, commandType: CommandType.StoredProcedure);
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
        public async Task<MessageEF> InsertPaymentRequestOnFailed(PaymentEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();


                p.Add("TXN_STATUS", model.Txn_Status);              //model.LeaseInfoId
                p.Add("UserId", model.UserId);
                p.Add("CLNT_TXN_REF", model.Permit_Type);
                p.Add("TPSL_BANK_CD", model.BankCode);
                p.Add("TPSL_TXN_ID", model.TPSLTXNID);
                p.Add("TXN_AMT", model.AMOUNT);
                p.Add("TPSL_TXN_TIME", System.DateTime.Now);
                p.Add("strPGRESPONSE", model.Responce);
                p.Add("PAYMENTFOR", 1);
                p.Add("PaymentResponseID", 0);
                var result =await Connection.ExecuteScalarAsync<string>("InsertUpdatePaymentRecords", p, commandType: CommandType.StoredProcedure);
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
        public async Task<PaymentResult> LesseeWisePaymentDetails(PaymentEF objUser)
        {

            PaymentResult UserInfo = new PaymentResult();
            try
            {

                DynamicParameters param = new DynamicParameters();

                var paramList = new
                {
                    UserId = objUser.UserId,
                    SubUserID = objUser.SubUserId,
                    PaymentTypeId = objUser.PaymentType,
                    PaymentStatus= "SUCCESS",
                    PayableAmount=objUser.AMOUNT,
                    strPG_TRANSACTION_DATE=objUser.TxnDate,
                    Check=3,
                };
                var result =await Connection.QueryAsync<PaymentEF>("uspLesseeWisePaymentDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo.LesseeList = result.ToList(); ;
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
        public async Task<MessageEF> MakeFinalCoalPayment(PaymentEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();


                p.Add("BulkPermitId", model.BulkPermitId);              //model.LeaseInfoId
                p.Add("UserId", model.UserId);
                p.Add("PaymentStatus", "SUCCESS");
                p.Add("strPG_TRANSACTION_DATE", model.PG_Transaction_Date);
                p.Add("CHALLAN_INITIATE_DATE", model.Challan_Initiate_Date);
                p.Add("CHALLAN_SETTLEMENT_DATE", model.Challan_Settlement_Date);
                p.Add("ICICI_TXN_NO", model.ICICI_TXN_NO);
                p.Add("UTR_NUMBER", model.UTR_Number);
                p.Add("ChallanNumber", model.Challan_Number);
                p.Add("STRRESPONSE", model.Responce);
                p.Add("BANK", model.BankCode);
                var result =await Connection.ExecuteScalarAsync<string>("MakeFinalCoalPaymentNew", p, commandType: CommandType.StoredProcedure);
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
        public async Task<PaymentResult> GetCoalEPermit(PaymentEF objUser)
        {

            PaymentResult UserInfo = new PaymentResult();
            try
            {

                DynamicParameters param = new DynamicParameters();

                var paramList = new
                {
                    Check = 18,
                    BulkPermitId = objUser.BulkPermitId,
                   
                };
                var result = await Connection.QueryAsync<PaymentEF>("uspCoalEPermit", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo.CoalEPermitList = result.ToList(); ;
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
        public async Task<MessageEF> SaveSuperLesseeDashboardData(PaymentEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();


                p.Add("PaymentID", model.PaymentID);
                p.Add("UserId", model.UserId);
                p.Add("PaymentStatus", "SUCCESS");
                p.Add("Check", 6);
                p.Add("strPG_TRANSACTION_DATE", model.PG_Transaction_Date);
               
                var result = await Connection.ExecuteScalarAsync<string>("uspSuperLesseeDashboardData", p, commandType: CommandType.StoredProcedure);
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
        public async Task<PaymentResult> InsertVehicleMasterPaymentDetails(PaymentEF objUser)
        {

            PaymentResult UserInfo = new PaymentResult();
            try
            {

                DynamicParameters param = new DynamicParameters();

                var paramList = new
                {
                    PaymentVehicleID = objUser.PaymentVehicleID,
                    UserId = objUser.UserId,
                    PaymentStatus = "SUCCESS",
                    UserLoginId = objUser.UserLoginId,
                    CHECK = objUser.CHECK,
                    strPG_TRANSACTION_DATE = objUser.PG_Transaction_Date,
                    CheckStatusCall = 1,
                };
                var result =await Connection.QueryAsync<PaymentEF>("upsInsertVehicleMasterPaymentDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    UserInfo.LesseeList = result.ToList(); ;
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
        public async Task<List<BankRemittanceModel>> GetSBIPaymentStatus(PaymentEF objUser)
        {
            List<BankRemittanceModel> ObjUserTypeList = new List<BankRemittanceModel>();
            try
            {
                var paramList = new
                {
                    BankName=objUser.PaymentBank,
                    FromDate=objUser.FromDATE,
                    ToDate = objUser.ToDATE,

                };
                DynamicParameters param = new DynamicParameters();

                var result =await Connection.QueryAsync<BankRemittanceModel>("uspICICIRemitanceMerchantRefNo", paramList, commandType: System.Data.CommandType.StoredProcedure);
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

        #region-------------------For ReLogin And Get The User Details-----------------------------
        public async Task<List<MCPaymentUserDetails>> GetReLoginUser(MCPaymentUserDetails model)
        {
            List<MCPaymentUserDetails> objUserLoginSession = new List<MCPaymentUserDetails>();
            try
            {
                var paramList = new
                {
                    CLNT_TXN_REF = model.CLNT_TXN_REF,
                    //UserName = model.UserName,
                    //Password = model.Password,
                    //EncryptPassword = model.Password,
                    //LoginUserType = model.UserType,
                    Check =model.Check
                    //RemoteIp = model.Remoteid,
                    //LocalIp = model.Localip,
                    //UserAgent = model.Browserinfo
                };

                var result = await Connection.QueryAsync<MCPaymentUserDetails>("UserModelSessionFilled", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objUserLoginSession = result.ToList();
                }

                return objUserLoginSession;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            //finally
            //{

            //    objUserLoginSession = null;
            //}



        }

        //var remoteIp = Request.UserHostAddress;
        //var localIp = Convert.ToString(Request.ServerVariables["LOCAL_ADDR"]);
        //var browserInfo = Request.UserAgent;
        //cmdSessionUpdate.CommandType = System.Data.CommandType.StoredProcedure;
        //                    cmdSessionUpdate.CommandText = "UserModelSessionFilled";
        //                    cmdSessionUpdate.Parameters.AddWithValue("@UserName", model.UserName);
        public async Task<List<MCPaymentUserDetails>> GetReLoginUserDetails(MCPaymentUserDetails model)
        {
            List<MCPaymentUserDetails> objUserLoginSession = new List<MCPaymentUserDetails>();
            try
            {
                var paramList = new
                {
                    UserName= model.USR_NAME,
                    Password= model.USR_PW,
                    Check = model.Check,
                    RemoteIp = model.RemoteIp,
                    LocalIp = model.LocalIp,
                    UserAgent = model.UserAgent
                };

                var result = await Connection.QueryAsync<MCPaymentUserDetails>("UserModelSessionFilled", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objUserLoginSession = result.ToList();
                }

                return objUserLoginSession;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objUserLoginSession = null;
            }



        }

        public async Task<PaymentResult> GetDetailsOfConfig(PaymentEF objUser)
        {
            PaymentResult UserInfo = new PaymentResult();
            try
            {

                DynamicParameters param = new DynamicParameters();

                var paramList = new
                {
                    UserID = objUser.UserId,
                    BulkPermitID = objUser.PaymentTypeID,
                    Check = 4

                };
                var result = await Connection.QueryMultipleAsync("uspEPermitOperation_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var PaymentData = result.Read<PaymentEF>().ToList();
                UserInfo.PaymentLst = PaymentData;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return UserInfo;
        }
        #endregion---------------------------------------------------------------------------------
    }

}
