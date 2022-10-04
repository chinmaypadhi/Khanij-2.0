// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 21-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MasterApi.Model.Policy
{
    public class PolicyProvider: RepositoryBase,IPolicyProvider
    {
        public PolicyProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddPolicymaster(Policymaster objPolicymaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("PolicyName", objPolicymaster.PolicyName);
                p.Add("RuleID", objPolicymaster.RuleID);
                p.Add("AttatchmentName", objPolicymaster.AttachmentName);
                p.Add("AttatchmentPath", objPolicymaster.AttachmentPath);
                p.Add("IsActive", objPolicymaster.IsActive);
                p.Add("CreatedBy", objPolicymaster.CreatedBy);
                p.Add("CreatedOn", DateTime.Now.ToString());
                p.Add("chk", "1");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspPolicyMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response == "0")
                {
                    objMessage.Satus = "3";

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
        public List<Policymaster> ViewPolicymaster(Policymaster objPolicymaster)
        {
            List<Policymaster> ListPolicymaster = new List<Policymaster>();
            try
            {
                var paramList = new
                {
                    PolicyName = objPolicymaster.PolicyName,
                    chk = "2",
                };
                var Output = Connection.Query<Policymaster>("uspPolicyMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    ListPolicymaster = Output.ToList();
                }

                return ListPolicymaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListPolicymaster = null;
            }



        }
        public Policymaster EditPolicymaster(Policymaster objPolicymaster)
        {
            Policymaster LobjPolicymaster = new Policymaster();
            try
            {
                var paramList = new
                {
                    PolicyID = objPolicymaster.PolicyID,
                    chk = "2",

                };
                DynamicParameters param = new DynamicParameters();

                var Output = Connection.Query<Policymaster>("uspPolicyMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    LobjPolicymaster = Output.FirstOrDefault();
                }

                return LobjPolicymaster;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjPolicymaster = null;
            }
        }
        public MessageEF DeletePolicymaster(Policymaster objPolicymaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "PolicyID",objPolicymaster.PolicyID,
                        "chk","4"
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("Output");
                var Output = Connection.Query<string>("uspPolicyMaster", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("Output");
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
        public MessageEF UpdatePolicymaster(Policymaster objPolicymaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("PolicyName", objPolicymaster.PolicyName);
                p.Add("RuleID", objPolicymaster.RuleID);
                p.Add("AttatchmentName", objPolicymaster.AttachmentName);
                p.Add("AttatchmentPath", objPolicymaster.AttachmentPath);
                p.Add("ModifiedBy", objPolicymaster.CreatedBy);
                p.Add("ModifiedOn", DateTime.Now.ToString());
                p.Add("PolicyID", objPolicymaster.PolicyID);
                p.Add("IsActive", objPolicymaster.IsActive);
                p.Add("chk", "3");
                p.Add("Output", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspPolicyMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Output");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response == "0")
                {
                    objMessage.Satus = "3";

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
        public List<Policymaster> GetPolicyTypeList(Policymaster objPolicymaster)
        {
            List<Policymaster> ObjPolicyTypeList = new List<Policymaster>();
            try
            {
                var paramList = new
                {
                    //DistrictId = objPolicymaster.DistrictID
                };
                DynamicParameters param = new DynamicParameters();

                var Output = Connection.Query<Policymaster>("uspGetRuleMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    ObjPolicyTypeList = Output.ToList();
                }

                return ObjPolicyTypeList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
