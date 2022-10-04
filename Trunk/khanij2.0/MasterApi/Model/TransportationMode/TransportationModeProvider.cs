using Dapper;

using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.TransportationMode
{
    public class TransportationModeProvider : RepositoryBase, ITransportationModeProvider
    {
        public TransportationModeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddTransportationMode(TransportationModeMaster objTR)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("TransportationMode", objTR.TransportationModeName);
                p.Add("CreatedBy", objTR.CreatedBy);
                p.Add("IsActive", objTR.IsActive);
                p.Add("UserLoginId", objTR.UserLoginId);
                p.Add("Chk", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_TransportationMode_MASTER", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public List<TransportationModeMaster> ViewTransportationMode(TransportationModeMaster objTR)
        {
            List<TransportationModeMaster> ListTR = new List<TransportationModeMaster>();
            try
            {
                var paramList = new
                {
                    TransportationMode = objTR.TransportationModeName,
                    Chk = "5",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<TransportationModeMaster>("USP_TransportationMode_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListTR = result.ToList();
                }

                return ListTR;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListTR = null;
            }



        }
        public TransportationModeMaster EditTransportationMode(TransportationModeMaster objTR)
        {
            TransportationModeMaster LobjTR = new TransportationModeMaster();
            try
            {
                var paramList = new
                {
                    TransportationModeId = objTR.TransportationModeId,
                    Chk = "2",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<TransportationModeMaster>("USP_TransportationMode_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjTR = result.FirstOrDefault();
                }

                return LobjTR;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjTR = null;
            }
        }
        public MessageEF UpdateTransportationMode(TransportationModeMaster objTR)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("TransportationMode", objTR.TransportationModeName);
                p.Add("TransportationModeId", objTR.TransportationModeId);
                p.Add("CreatedBy", objTR.CreatedBy);
                p.Add("IsActive", objTR.IsActive);
                p.Add("UserLoginId", objTR.UserLoginId);
                p.Add("Chk", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_TransportationMode_MASTER", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");


                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        public MessageEF DeleteTransportationMode(TransportationModeMaster objTR)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("TransportationModeId", objTR.TransportationModeId);
                p.Add("CreatedBy", objTR.CreatedBy);
                p.Add("UserLoginId", objTR.UserLoginId);
                p.Add("Chk", 4);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_TransportationMode_MASTER", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");

                if (response.ToString() == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;

        }
    }
}
