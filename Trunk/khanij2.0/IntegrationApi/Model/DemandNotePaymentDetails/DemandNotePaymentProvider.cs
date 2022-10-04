using Dapper;
using IntegrationApi.Factory;
using IntegrationApi.Repository;
using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApi.Model.DemandNotePaymentDetails
{
    public class DemandNotePaymentProvider : RepositoryBase, IDemandNotePaymentProvider
    {




        public DemandNotePaymentProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public async Task<MessageEF> AddpayStatus(DemandNotePaymentEF objmodel)
        {
            MessageEF obj = new MessageEF();
            try
            {
                var paramList = new
                {
                    UserId = objmodel.UserId,
                    DemandNoteCode = objmodel.DemandNoteCode,
                    SpMode = "MakePayment",
                    UserLoginId=objmodel.UserLoginId,
                    TotalPayableAmount = objmodel.TotalPayableAmount,
                    TotalPaidAmount=objmodel.TotalPaidAmount,
                    InterestValue = objmodel.TotalIntersetCalc,
                    PayableRoyalty = objmodel.PayableRoyalty,
                    DMF = objmodel.DMF,
                    NMET = objmodel.NMET,
                    TCS = objmodel.TCS,
                    iCess = objmodel.Infrastructure_Development_Cess,
                    eCess = objmodel.Environmental_Cess,
                    monthlyPeriodicAmount = objmodel.Monthly_Periodic_Amount,
                    Interest_PayableRoyalty = objmodel.INT_PayableRoyalty,
                    Interest_DMF = objmodel.INT_DMF,
                    Interest_NMET = objmodel.INT_NMET,
                    Interest_TCS = objmodel.INT_TCS,
                    Interest_iCess = objmodel.INT_iCess,
                    Interest_eCess = objmodel.INT_eCess,
                    Interest_monthlyPeriodicAmount = objmodel.INT_monthlyPeriodicAmount,
                    TotalAmount = objmodel.TotalAmount,

                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.ExecuteScalarAsync<string>("uspGetDemandNotePaymentList", paramList, commandType: CommandType.StoredProcedure);
                obj.Msg = result;
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<DemandNotePaymentEF>> getDemandNoteSummaryData(DemandNotePaymentEF objmodel)
        {
            List<DemandNotePaymentEF> objlist = new List<DemandNotePaymentEF>();
            try
            {
                var paramList = new
                {
                    UserId = objmodel.UserId,
                    DemandNoteCode = objmodel.DemandNoteCode,
                    SpMode = "GET_TRANSACTIONID",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<DemandNotePaymentEF>("uspGetDemandNotePaymentList", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objlist = result.ToList();
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<DemandNotePaymentEF>> getDemandNoteSummaryDataAll(DemandNotePaymentEF objmodel)
        {
            List<DemandNotePaymentEF> objlist = new List<DemandNotePaymentEF>();
            try
            {
                var paramList = new
                {
                    UserId = objmodel.UserId,
                    DemandNoteCode = objmodel.DemandNoteCode,
                    SpMode = "GETBYID",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<DemandNotePaymentEF>("uspGetDemandNotePaymentList", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objlist = result.ToList();
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PaymentDetailsQmultiple> getPaymentGetwayDetails(DemandNotePaymentEF objmodel)
        {
            PaymentDetailsQmultiple obj = new PaymentDetailsQmultiple();

            try
            {
                var paramList = new
                {
                    UserId = objmodel.UserId,
                    Bank = objmodel.PaymentBank,
                    DNIDs=objmodel.DemandNoteCode,
                };
                DynamicParameters param = new DynamicParameters();               
                var result = await Connection.QueryMultipleAsync("getPaymentGateway", paramList, commandType: System.Data.CommandType.StoredProcedure);
                obj.PaymentDetailsList= result.Read<DemandNotePaymentEF>().ToList();
                obj.PaymentHeadList= result.Read<DemandNotePaymentEF>().ToList();
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<MessageEF> GetpayStatus(DemandNotePaymentEF objmodel)
        {
            MessageEF obj = new MessageEF();
            try
            {
                var paramList = new
                {
                    UserId = objmodel.UserId,
                    DemandNoteCode = objmodel.DemandNoteCode,
                    SpMode = "GETBYID",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.ExecuteScalarAsync<string>("uspGetDemandNotePaymentList", paramList, commandType: CommandType.StoredProcedure);
                obj.Msg = result;
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
