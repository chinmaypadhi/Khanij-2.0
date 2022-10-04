using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Rule
{
    public class RuleMasterProvider : RepositoryBase, IRuleMasterProvider
    {
        public RuleMasterProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddRuleMaster(RuleMaster objRulemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("RuleName", objRulemaster.RuleName);
                p.Add("CreatedBy", objRulemaster.CreatedBy);
                p.Add("IsActive", objRulemaster.IsActive);
                p.Add("Chk", "1");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("SP_IUDRuleMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public List<RuleMaster> ViewRuleMaster(RuleMaster objRulemaster)
        {
            List<RuleMaster> ListRulemaster = new List<RuleMaster>();
            try
            {
                var paramList = new
                {
                    RuleName = objRulemaster.RuleName,
                    Chk = "2",
                };
                var result = Connection.Query<RuleMaster>("SP_IUDRuleMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListRulemaster = result.ToList();
                }
                return ListRulemaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListRulemaster = null;
            }
        }
        public RuleMaster EditRulemaster(RuleMaster objRulemaster)
        {
            RuleMaster LobjRuleMaster = new RuleMaster();
            try
            {
                var paramList = new
                {
                    RuleID = objRulemaster.RuleID,
                    Chk = "5",
                };
                DynamicParameters param = new DynamicParameters();
                var result = Connection.Query<RuleMaster>("SP_IUDRuleMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    LobjRuleMaster = result.FirstOrDefault();
                }
                return LobjRuleMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LobjRuleMaster = null;
            }
        }
        public MessageEF DeleteRulemaster(RuleMaster objRulemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("Chk", "4");
                p.Add("RuleID", objRulemaster.RuleID);
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("SP_IUDRuleMaster", p, commandType: System.Data.CommandType.StoredProcedure);
                int response = p.Get<int>("Output");
                objMessage.Satus = response.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public MessageEF UpdateRulemaster(RuleMaster objRulemaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("RuleName", objRulemaster.RuleName);
                p.Add("RuleID", objRulemaster.RuleID);
                p.Add("ModifiedBy", objRulemaster.CreatedBy);
                p.Add("IsActive", objRulemaster.IsActive);
                p.Add("Chk", "3");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("SP_IUDRuleMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");

                //var result = Connection.Query<string>("Usp_StateMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                //string response = _param.Get<string>("Result");

                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;

        }
    }
}
