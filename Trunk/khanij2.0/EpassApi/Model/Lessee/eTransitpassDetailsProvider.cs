using EpassApi.Factory;
using EpassApi.Repository;
using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using System.Data;

namespace EpassApi.Model.Lessee
{
    public class eTransitpassDetailsProvider : RepositoryBase, ITransitpassDetailsProvider
    {
        string OutputResult = "";
        public eTransitpassDetailsProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        ////Akash 25Apr2022
        public MessageEF CancelTP(TransitpassCancelEF obj)
        {
            MessageEF objmessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@TPid", obj.TPID);
                p.Add("@Check", 4);
                p.Add("@Remarks", obj.Remarks);
                p.Add("@UpdateIn", "TP");
                p.Add("@UserId", obj.UserID);
                p.Add("@UserLoginId", obj.UserLoginId);   
                var result = Connection.Query<string>("TPCancellationProcess", p, commandType: System.Data.CommandType.StoredProcedure);
                int ID = Convert.ToInt32(obj.ID);
                var returnId = string.Empty;
                if (ID == 0)
                {
                    p.Add("@TPid", obj.TPID);
                    p.Add("@Check", 1);
                    p.Add("@Remarks", obj.Remarks);
                    p.Add("@UpdateIn", "TP");
                    p.Add("@UserId", obj.UserID);
                    p.Add("@UserLoginId", obj.UserLoginId);
                    var result1 = Connection.Query<string>("TPCancellationProcess", p, commandType: System.Data.CommandType.StoredProcedure);
                    //object _ID = Convert.ToInt32(result1.ToString());
                    var _returnId = string.Empty;
                   
                    if (result1 != null && !string.IsNullOrEmpty(Convert.ToString(result1)))
                    {
                         // _returnId = Convert.ToInt32(_ID).ToString();
                         // OutputResult = _returnId;
                        objmessage.Satus = result1.FirstOrDefault().ToString();
                    }
                    else
                    {
                        objmessage.Satus = result1.ToString();
                    }
                }
                else
                {
                    objmessage.Satus = Convert.ToString(ID);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return objmessage;
        }

        public async Task<List<TransitpassCancelEF>> eTransitpassDetails(TransitpassCancelEF objTPDetails)
        {
            List<TransitpassCancelEF> objlistmodel = new List<TransitpassCancelEF>();
            try
            {
                 var paramlist = new
                 {
                     UserId = objTPDetails.UserID,
                     SubUserID = objTPDetails.SubUserID,
                     PassType = objTPDetails.ePassType,
                     BulkPermitNo = objTPDetails.ePermit
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<TransitpassCancelEF>("uspGetLesseeWisePassDetails", paramlist, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objlistmodel = result.ToList();
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return objlistmodel;
        }

       
    }
}
