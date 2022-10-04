using Dapper;
using IntegrationApi.Factory;
using IntegrationApi.Repository;
using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApi.Model.Noticeltr
{
    public class NoticeLtr :RepositoryBase,INoticeLtr
    {

        public NoticeLtr(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<List<Notice>> PaymentsView(Notice objmodel)
        {
            List<Notice> objlist = new List<Notice>();
            try
            {
                var paramList = new
                {
                    OtherPaymentType = objmodel.OtherPaymentType,
                    PaymentID =objmodel.arr.Replace('\"', ' '),
                    LesseeOtherPayment = objmodel.totalPayableAmt,
                    UserId = objmodel.UserId,
                    MineralType = objmodel.MineralTypeName,
                    Check = objmodel.Check,
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<Notice>("uspGetTotalOtherPayment", paramList, commandType: System.Data.CommandType.StoredProcedure);
                objlist = result.ToList();
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<MessageEF> PaymentsStatus(Notice objmodel)
        {
            MessageEF obj = new MessageEF();
            try
            {
                var paramList = new
                {
                    OtherPaymentType = objmodel.OtherPaymentType,
                    UserId = objmodel.UserId,
                    LesseeId = objmodel.UserId,
                    MineralType = objmodel.MineralTypeName,
                    LesseeOtherPayment = objmodel.OtherPaymentAmount,
                    PaymentID = objmodel.paymentIDs,
                    totalPayableAmt = objmodel.ArrtotalPayableAmt,      
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.ExecuteScalarAsync<string>("uspGetTotalOtherPayment", paramList, commandType: CommandType.StoredProcedure);
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
