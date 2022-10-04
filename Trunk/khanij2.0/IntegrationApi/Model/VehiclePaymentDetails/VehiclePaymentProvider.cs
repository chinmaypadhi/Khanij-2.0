using Dapper;
using IntegrationApi.Factory;
using IntegrationApi.Repository;
using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApi.Model.VehiclePaymentDetails
{
    public class VehiclePaymentProvider : RepositoryBase, IVehiclePaymentProvider
    {
        public VehiclePaymentProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        /// <summary>
        /// Get Vehicle Payment Details
        /// </summary>
        /// <param name="vehiclePayment"></param>
        /// <returns></returns>
        
        public async Task<MessageEF> GetVehiclePaymentDetails(VehiclePayment vehiclePayment)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@PaymentVehicleID", vehiclePayment.PaymentVehicleID);
                param.Add("@UserId", vehiclePayment.UserId);
                param.Add("@CHECK", 1);
                var result = await Connection.ExecuteScalarAsync("upsInsertVehicleMasterPaymentDetails", param, commandType: System.Data.CommandType.StoredProcedure);

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
        /// <param name="vehiclePayment"></param>
        /// <returns></returns>
       
        public async Task<PaymentModel> GetVehiclePaymentGateway(VehiclePayment vehiclePayment)
        {
            PaymentModel paymentModel = new PaymentModel();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Bank", vehiclePayment.PaymentBank);
                param.Add("@UserId", vehiclePayment.UserId);
                IDataReader dr = await Connection.ExecuteReaderAsync("getPaymentGateway", param, commandType: System.Data.CommandType.StoredProcedure);

                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    paymentModel.RequestType = dt.Rows[0]["RequestType"].ToString();
                    paymentModel.MerchantCode = dt.Rows[0]["MerchantCode"].ToString();
                    paymentModel.ErrorFile = dt.Rows[0]["ErrorFile"].ToString();
                    paymentModel.PropertyPath = dt.Rows[0]["PropertyPath"].ToString();
                    paymentModel.LogFilePath = dt.Rows[0]["LogFilePath"].ToString();
                    paymentModel.Bankcode = dt.Rows[0]["BankCode"].ToString();
                    paymentModel.ITC = "Vehicle Payment:" + Convert.ToDecimal(vehiclePayment.total).ToString("0.00") + "";
                    paymentModel.uniqueCustomerID = vehiclePayment.UserName;
                    paymentModel.MerchantTxnRefNumber = vehiclePayment.ReturnID;
                    paymentModel.customerName = dt.Rows[0]["CustomerName"].ToString();
                    paymentModel.mobileNo = dt.Rows[0]["UserMobileNumber"].ToString();
                    paymentModel.Email = dt.Rows[0]["UserEmail"].ToString();
                    paymentModel.TxnDate = dt.Rows[0]["TxnDate"].ToString();
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
        /// Insert Vehicle Payment Request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        
        public async Task<MessageEF> InsertVehiclePaymentRequest(PaymentEF model)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters(); 
                p.Add("PAYMENTFOR",0);              //model.LeaseInfoId
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
                p.Add("PaymentMode", "NET-BANKING");
                var result = await Connection.ExecuteScalarAsync("InsertUpdatePaymentRecords", p, commandType: CommandType.StoredProcedure);
               

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
