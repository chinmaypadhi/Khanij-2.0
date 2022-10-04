using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.StateMaster
{
    public class StateMasterProvider : RepositoryBase, IStateMasterProvider
    {
        public StateMasterProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddStateMaster(Statemaster objStatemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
            //    object[] objArray = new object[] {                      
            //            "StateName"  ,objStatemaster.StateName,
            //            "CreatedBy"    ,objStatemaster.CreatedBy,
            //            "IsActive"     ,objStatemaster.IsActive,
            //            "UserLoginId"  ,objStatemaster.UserLoginID,
            //            "Chk",1
            //};
            //    DynamicParameters _param = new DynamicParameters();
            //    _param = objArray.ToDynamicParameters("Result");
            var p = new DynamicParameters();
            p.Add("StateName", objStatemaster.StateName);
            p.Add("CreatedBy", objStatemaster.CreatedBy);
            p.Add("IsActive", objStatemaster.IsActive);
            p.Add("UserLoginId", objStatemaster.UserLoginID);
            p.Add("Chk", "1");
            p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            Connection.Query<int>("Usp_StateMaster", p, commandType: CommandType.StoredProcedure);
            int newID = p.Get<int>("Result");
            //var result = Connection.Query<string>("Usp_StateMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
            //    string response = _param.Get<string>("Result");
            string response = newID.ToString();
                if (response == "1")
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
        public List<Statemaster> ViewStateMaster(Statemaster objStatemaster)
        {
            List<Statemaster> ListStatemaster = new List<Statemaster>();
            try
            {
                var paramList = new
                {
                    StateName = objStatemaster.StateName,
                    Chk = "2",
                };
                var result = Connection.Query<Statemaster>("Usp_StateMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListStatemaster = result.ToList();
                }
                return ListStatemaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListStatemaster = null;
            }
        }
        public Statemaster EditStatemaster(Statemaster objStatemaster)
        {
            Statemaster LobjMStatemaster = new Statemaster();
            try
            {
                var paramList = new
                {
                    StateID = objStatemaster.StateID,
                    Chk = "3",
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<Statemaster>("Usp_StateMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    LobjMStatemaster = result.FirstOrDefault();
                }
                return LobjMStatemaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjMStatemaster = null;
            }
        }
        public MessageEF DeleteStatemaster(Statemaster objStatemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "StateID",objStatemaster.StateID,                       
                        "Chk",5
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("Result");
                var result = Connection.Query<string>("Usp_StateMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("Result");
                if (response == "1")
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
        public MessageEF UpdateStatemaster(Statemaster objStatemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {               
                var p = new DynamicParameters();
                p.Add("StateName", objStatemaster.StateName);
                p.Add("StateID", objStatemaster.StateID);
                p.Add("ModifiedBy", objStatemaster.CreatedBy);
                p.Add("UserLoginId", objStatemaster.UserLoginID);
                p.Add("IsActive",objStatemaster.IsActive);
                p.Add("Chk", "6");
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("Usp_StateMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Result");
                //var result = Connection.Query<string>("Usp_StateMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                //string response = _param.Get<string>("Result");
                string response = newID.ToString();
                if (response == "1")
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
