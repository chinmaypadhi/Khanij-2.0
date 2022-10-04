﻿using Dapper;
using MasterApi.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.PaymentResponse
{
    public class PaymentResponseProvider : RepositoryBase, IPaymentResponseProvider
    {
        string strPG_TxnStatus = string.Empty, strPG_TxnStatusDesc = string.Empty,
       strPG_ClintTxnRefNo = string.Empty,
               strPG_TPSLTxnBankCode = string.Empty, strPG_Paymode = string.Empty,
               strPG_TPSLTxnID = string.Empty,
               strPG_TxnAmount = string.Empty,
               strPG_TxnDateTime = string.Empty,
               strPG_TxnDate = string.Empty,
               strPG_TxnTime = string.Empty;
        public PaymentResponseProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        /// <summary>
        /// Get Payment Response ID
        /// </summary>
        /// <param name="paymentResponseDetails"></param>
        /// <returns></returns>
        public async Task<MessageEF> GetPaymentResponseID(PaymentResponseDetails paymentResponseDetails)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@SessionBank", paymentResponseDetails.SessionBank);
                p.Add("@DocContent", paymentResponseDetails.DocContent);
                p.Add("@PAYMENTFOR", 2);
                IDataReader dr = await Connection.ExecuteReaderAsync("InsertUpdatePaymentRecords", p, commandType: System.Data.CommandType.StoredProcedure);
                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    messageEF.Satus = Convert.ToString(dt.Rows[0]["PaymentResponseID"]);
                }
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add Payment Response
        /// </summary>
        /// <param name="paymentTransaction"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddPaymentResponse(PaymentTransaction paymentTransaction)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@TXN_STATUS", paymentTransaction.TXN_STATUS);
                p.Add("@UserId", paymentTransaction.UserId);
                p.Add("@CLNT_TXN_REF", paymentTransaction.CLNT_TXN_REF);
                p.Add("@TPSL_BANK_CD", paymentTransaction.TPSL_BANK_CD);
                p.Add("@TPSL_TXN_ID", paymentTransaction.TPSL_TXN_ID);
                p.Add("@TXN_AMT", paymentTransaction.TXN_AMT);
                p.Add("@TPSL_TXN_TIME", paymentTransaction.TPSL_TXN_TIME);
                p.Add("@strPGRESPONSE", paymentTransaction.strPGRESPONSE);
                p.Add("@GIB_TXN_No", paymentTransaction.GIBNo);
                p.Add("@PAYMENTFOR", 1); // this value should be change as per payment recived. 
                if (!string.IsNullOrEmpty(paymentTransaction.PaymentResponseID))
                {
                    p.Add("@PaymentResponseID", paymentTransaction.PaymentResponseID);
                }
                IDataReader dr = await Connection.ExecuteReaderAsync("InsertUpdatePaymentRecords", p, commandType: System.Data.CommandType.StoredProcedure);
                messageEF.Satus = "success";
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add Vehicle Payment Response
        /// </summary>
        /// <param name="paymentTransaction"></param>
        /// <returns></returns>
        public async Task<TransporterModel> AddVehiclePaymentResponse(PaymentResponseDetails paymentResponseDetails)
        {
            TransporterModel TModel = new TransporterModel();
            try
            {
                var p = new DynamicParameters();
                p.Add("@PaymentVehicleID", paymentResponseDetails.PaymentVehicleID);
                p.Add("@UserId", paymentResponseDetails.UserId);
                p.Add("@PaymentStatus", paymentResponseDetails.TXN_STATUS);
                p.Add("@UserLoginId", paymentResponseDetails.UserLoginId);
                p.Add("@CHECK", 2);
                IDataReader dr = await Connection.ExecuteReaderAsync("upsInsertVehicleMasterPaymentDetails", p, commandType: System.Data.CommandType.StoredProcedure);
                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {

                    TModel.EmailID = Convert.ToString(dt.Rows[0]["EmailID"]);
                    TModel.TotalVehiclesPayment = Convert.ToString(dt.Rows[0]["RegFees"]);
                    TModel.VehicleCount = Convert.ToInt32(dt.Rows[0]["TotalVehicleCount"]);
                    TModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                    TModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                    TModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
                    TModel.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                }
                return TModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add License First Payment
        /// </summary>
        /// <param name="paymentResponseDetails"></param>
        /// <returns></returns>
        public async Task<UserMasterModel> AddLicenseFirstPayment(PaymentResponseDetails paymentResponseDetails)
        {
            UserMasterModel userMasterModel = new UserMasterModel();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Check", "22");
                p.Add("@PaymentRecieptId", paymentResponseDetails.PaymentRecieptId);
                p.Add("@UserId", paymentResponseDetails.UserId);
                p.Add("@ChallanNumber", paymentResponseDetails.ChallanNumber);
                p.Add("@PaymentStatus", paymentResponseDetails.PaymentStatus);
                IDataReader dr = await Connection.ExecuteReaderAsync("SP_FORM4", p, commandType: System.Data.CommandType.StoredProcedure);
                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    userMasterModel.EMailId = Convert.ToString(dt.Rows[0]["EmailID"]);
                    userMasterModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                    userMasterModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                    userMasterModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
                }
                return userMasterModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                userMasterModel = null;
            }
        }

        /// <summary>
        /// Add License Security Payment
        /// </summary>
        /// <param name="paymentResponseDetails"></param>
        /// <returns></returns>
        public async Task<UserMasterModel> AddLicenseSecurityPayment(PaymentResponseDetails paymentResponseDetails)
        {
            UserMasterModel userMasterModel = new UserMasterModel();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Check", "44");
                p.Add("@PaymentRecieptId", paymentResponseDetails.PaymentRecieptId);
                p.Add("@UserId", paymentResponseDetails.UserId);
                p.Add("@ChallanNumber", paymentResponseDetails.ChallanNumber);
                p.Add("@PaymentStatus", paymentResponseDetails.PaymentStatus);
                IDataReader dr = await Connection.ExecuteReaderAsync("SP_FORM4", p, commandType: System.Data.CommandType.StoredProcedure);
                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    userMasterModel.EMailId = Convert.ToString(dt.Rows[0]["EmailID"]);
                    userMasterModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                    userMasterModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                    userMasterModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
                }
                return userMasterModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                userMasterModel = null;
            }
        }
        public DataSet ConvertDataReaderToDataSet(IDataReader data)
        {
            DataSet ds = new DataSet();
            int i = 0;
            while (!data.IsClosed)
            {
                ds.Tables.Add("Table" + (i + 1));
                ds.EnforceConstraints = false;
                ds.Tables[i].Load(data);
                i++;
            }
            return ds;
        }
    }
}
