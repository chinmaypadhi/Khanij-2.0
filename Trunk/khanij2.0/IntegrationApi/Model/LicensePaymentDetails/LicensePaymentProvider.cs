using Dapper;
using IntegrationApi.Factory;
using IntegrationApi.Repository;
using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApi.Model.LicensePaymentDetails
{
    public class LicensePaymentProvider : RepositoryBase, ILicensePaymentProvider
    {
        public LicensePaymentProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        /// <summary>
        /// Get License Payment Details
        /// </summary>
        /// <param name="licensePaymentDetail"></param>
        /// <returns></returns>

        public async Task<MessageEF> GetLicensePaymentDetails(LicensePaymentDetail licensePaymentDetail)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@LicenseAppId", licensePaymentDetail.LicenseAppId);
                param.Add("@UserId", licensePaymentDetail.UserId);
                param.Add("@Check", 2);
                param.Add("@UserLoginId", licensePaymentDetail.UserLoginId);
                param.Add("@TotalPayment", licensePaymentDetail.TotalPayment);
                param.Add("@PaymentBank", licensePaymentDetail.PaymentBank);
                param.Add("@PaymentMode", licensePaymentDetail.PaymentMode);
                var result = await Connection.ExecuteScalarAsync("SP_FORM4", param, commandType: System.Data.CommandType.StoredProcedure);

                if (!string.IsNullOrEmpty(result.ToString()))
                {
                    messageEF.Satus = result.ToString();
                }
                return messageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                messageEF = null;
            }
        }

        /// <summary>
        /// Get Payment Gateway
        /// </summary>
        /// <param name="licensePaymentDetail"></param>
        /// <returns></returns>

        public async Task<PaymentModel> GetLicensePaymentGateway(LicensePaymentDetail licensePaymentDetail)
        {
            PaymentModel paymentModel = new PaymentModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Bank", licensePaymentDetail.PaymentBank);
                param.Add("@UserId", licensePaymentDetail.UserId);
                //param.Add("@PaymentRefId", licensePaymentDetail.PaymentRefId);
                IDataReader dr = await Connection.ExecuteReaderAsync("getPaymentGateway", param, commandType: System.Data.CommandType.StoredProcedure);

                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (ds.Tables.Count > 1)
                    {
                        DataTable dt2 = ds.Tables[1];
                        if (dt2 != null && dt2.Rows.Count > 0)
                        {
                            licensePaymentDetail.TotalPayment = Convert.ToDecimal(dt2.Rows[0]["TotalPayment"].ToString());
                        }
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        paymentModel.RequestType = dt.Rows[0]["RequestType"].ToString();
                        paymentModel.MerchantCode = dt.Rows[0]["MerchantCode"].ToString();
                        paymentModel.ErrorFile = dt.Rows[0]["ErrorFile"].ToString();
                        paymentModel.PropertyPath = dt.Rows[0]["PropertyPath"].ToString();
                        paymentModel.LogFilePath = dt.Rows[0]["LogFilePath"].ToString();
                        paymentModel.Bankcode = dt.Rows[0]["BankCode"].ToString();
                        paymentModel.ITC = dt.Rows[0]["ITC"].ToString() + ":" + Convert.ToDecimal(licensePaymentDetail.TotalPayment).ToString("0.00") + "";
                        paymentModel.uniqueCustomerID = dt.Rows[0]["UniqueCustomerID"].ToString();
                        paymentModel.MerchantTxnRefNumber = licensePaymentDetail.PaymentRefId;
                        paymentModel.customerName = dt.Rows[0]["CustomerName"].ToString();
                        paymentModel.mobileNo = dt.Rows[0]["UserMobileNumber"].ToString();
                        paymentModel.Email = dt.Rows[0]["UserEmail"].ToString();
                        paymentModel.TxnDate = dt.Rows[0]["TxnDate"].ToString();
                    }

                }
                return paymentModel;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                paymentModel = null;
            }
        }

        /// <summary>
        /// Insert License Payment Request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MessageEF> InsertLicensePaymentRequest(PaymentModel model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@PAYMENTFOR", 0);
                p.Add("@UserId", model.UserId);
                p.Add("@RequestType", model.RequestType);
                p.Add("@MerchantCode", model.MerchantCode);
                p.Add("@MerchantTxnRefNumber", model.MerchantTxnRefNumber);
                p.Add("@ITC", model.ITC);
                p.Add("@Amount", model.Amount);
                p.Add("@CurrencyCode", model.Currencycode);
                p.Add("@UniqueCustomerID", model.uniqueCustomerID);
                p.Add("@ReturnUrl", model.returnURL);
                p.Add("@S2SReturnURL", model.S2SReturnURL);
                p.Add("@TPSLTXNID", model.TPSLTXNID);
                p.Add("@Shoppingcartdetails", model.Shoppingcartdetails);
                p.Add("@TxnDate", model.TxnDate);
                p.Add("@Email", model.Email);
                p.Add("@MobileNo", model.mobileNo);
                p.Add("@Bankcode", model.Bankcode);
                p.Add("@CustomerName", model.customerName);
                p.Add("@PropertyPath", model.PropertyPath);
                p.Add("@PaymentEncryptedData", model.PaymentEncryptedData);
                p.Add("@PaymentMode", "NET-BANKING");
                var result = await Connection.ExecuteScalarAsync("InsertUpdatePaymentRecords", p, commandType: CommandType.StoredProcedure);

                if (!string.IsNullOrEmpty(Convert.ToString(result)))
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

        /// <summary>
        /// Add Security Deposit
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddSecurityDeposit(LicenseApplication licenseApplication)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                p.Add("@UserId", licenseApplication.UserId);
                p.Add("@Check", 11);
                p.Add("@UserLoginId", licenseApplication.UserLoginId);
                p.Add("@TotalPayment", licenseApplication.TotalPayment);
                p.Add("@SecurityAmountBank", licenseApplication.PaymentBank);
                p.Add("@SecurityAmountMode", licenseApplication.PaymentMode);
                var rr = await Connection.ExecuteScalarAsync("SP_FORM4", p, commandType: CommandType.StoredProcedure);
                objMessage.Satus = rr.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public async Task<MessageEF> AddLeaseDeedFine(LicenseApplication licenseApplication)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@LicenseAppId", licenseApplication.LicenseAppId);
                p.Add("@UserId", licenseApplication.UserId);
                p.Add("@Check", 15);
                p.Add("@UserLoginId", licenseApplication.UserLoginId);
                p.Add("@DeedFineAmountPaid", licenseApplication.TotalPayment);
                p.Add("@DeedBankName", licenseApplication.PaymentBank);
                p.Add("@DeedAmountMode", licenseApplication.PaymentMode);
                var rr = await Connection.ExecuteScalarAsync("SP_FORM4", p, commandType: CommandType.StoredProcedure);
                objMessage.Satus = rr.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
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
