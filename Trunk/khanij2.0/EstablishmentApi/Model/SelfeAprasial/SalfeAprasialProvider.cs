using Dapper;
using EstablishmentApi.Factory;
using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.SelfeAprasial
{
    public class SalfeAprasialProvider:RepositoryBase,ISalfeAprasialProvider 
    {
        public SalfeAprasialProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public List<SalfeAprasialEf> GetListData(SalfeAprasialEf objSalfeAprasialEf)
        {
            try
            {

           
            List<SalfeAprasialEf> ListSalfeAprasialEf = new List<SalfeAprasialEf>();
            var paramList = new
            {
                Action = "V"

            };


                var result = Connection.Query<SalfeAprasialEf>("SP_SalfeAprasialView", paramList, commandType: System.Data.CommandType.StoredProcedure);

           
            if (result.Count() > 0)
            {

                ListSalfeAprasialEf = result.ToList();
            }
            return ListSalfeAprasialEf;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public SalfeAprasialEf Edit(SalfeAprasialEf objSalfeAprasialEf)
        {
            try
            {


               
                var paramList = new
                {
                    Action = "E",
                    P_intID= objSalfeAprasialEf.intID

                };


                var result = Connection.Query<SalfeAprasialEf>("SP_SalfeAprasialView", paramList, commandType: System.Data.CommandType.StoredProcedure);


                if (result.Count() > 0)
                {

                    objSalfeAprasialEf = result.FirstOrDefault();
                }
                return objSalfeAprasialEf;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageEF Update(SalfeAprasialEf objSalfeAprasialEf)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Action", objSalfeAprasialEf.action);
                p.Add("@P_intID", objSalfeAprasialEf.intID);
                p.Add("@P_Grade", objSalfeAprasialEf.VchReviewingGrade);
                p.Add("@P_intuserid", objSalfeAprasialEf.intReviewingBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("SP_SalfeAprasialUpdate", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");



                string response = newID.ToString();
                if (response == "1")
                {
                    objMessageEF.Satus = "1";

                }
                else if (response == "2")
                {
                    objMessageEF.Satus = "2";

                }
                else
                {
                    objMessageEF.Satus = "3";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessageEF;
        }
        public MessageEF AddSalfeAprasial(SalfeAprasialEf objSalfeAprasialEf)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
p.Add("Action" , objSalfeAprasialEf.action);
                p.Add("intID", objSalfeAprasialEf.intID);
                p.Add("intDepartment", objSalfeAprasialEf.intDepartment);
                p.Add("intDesignation", objSalfeAprasialEf.intDesignation);
                p.Add("intPersonname", objSalfeAprasialEf.intPersonname);
                p.Add("VchRequirementtype", objSalfeAprasialEf.VchRequirementtype);
                p.Add("DateJoiningdate", objSalfeAprasialEf.datejoiningdate);
                p.Add("VchWorkdescription", objSalfeAprasialEf.VchWorkdescription);
                p.Add("Vchgoal", objSalfeAprasialEf.Vchgoal);
                p.Add("Vchachievegoal", objSalfeAprasialEf.Vchachievegoal);
                p.Add("VchContributiongoal", objSalfeAprasialEf.VchContributiongoal);
                p.Add("Vchtargetachievement", objSalfeAprasialEf.Vchtargetachievement);
                p.Add("vchqualitywork", objSalfeAprasialEf.vchqualitywork);
                p.Add("Vchworkdetails", objSalfeAprasialEf.Vchworkdetails);
                p.Add("Vchworkconsternation", objSalfeAprasialEf.Vchworkconsternation);
                p.Add("VCHDictackingquality", objSalfeAprasialEf.VCHDictackingquality);
                p.Add("Vchhandlingcapacity", objSalfeAprasialEf.Vchhandlingcapacity);
                p.Add("Vchtrustcolleagues", objSalfeAprasialEf.Vchtrustcolleagues);
                p.Add("vchCommunication", objSalfeAprasialEf.vchCommunication);
                p.Add("VchRespect_others", objSalfeAprasialEf.VchRespect_others);
                p.Add("VchPublicRelation", objSalfeAprasialEf.VchPublicRelation);
                p.Add("vchmakingplan", objSalfeAprasialEf.vchmakingplan);
                p.Add("VchAbilitycheck", objSalfeAprasialEf.VchAbilitycheck);
                p.Add("VchSincere", objSalfeAprasialEf.VchSincere);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("usp_AddSalfeAprasia", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");



                string response = newID.ToString();
                if (response == "1")
                {
                    objMessageEF.Satus = "1";

                }
                else if (response == "2")
                {
                    objMessageEF.Satus = "2";

                }
                else
                {
                    objMessageEF.Satus = "3";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return objMessageEF;
        }
    }
  
}
