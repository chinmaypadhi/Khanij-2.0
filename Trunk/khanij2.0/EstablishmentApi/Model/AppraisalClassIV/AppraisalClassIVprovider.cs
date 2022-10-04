using Dapper;
using EstablishmentApi.Factory;
using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.AppraisalClassIV
{
    public class AppraisalClassIVprovider: RepositoryBase, IAppraisalClassIVprovider
    {
        public AppraisalClassIVprovider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddAppraisal(AppraisalClassIVEF objAppraisalClassIVEF)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Status",objAppraisalClassIVEF.Status);
                p.Add("id"                     ,objAppraisalClassIVEF.id);
                p.Add("vchName"                ,objAppraisalClassIVEF.vchName);
                p.Add("vchFatherName"          ,objAppraisalClassIVEF.vchFatherName);
                p.Add("vchHighereducation"     ,objAppraisalClassIVEF.vchHighereducation);
                p.Add("vchPost"                ,objAppraisalClassIVEF.vchPost);
                p.Add("dtmJoiningdate"         ,objAppraisalClassIVEF.dtmJoiningdate);
                p.Add("vchPaceofwork"          ,objAppraisalClassIVEF.vchPaceofwork);
                p.Add("intTimeperiod"          ,objAppraisalClassIVEF.intTimeperiod);
                p.Add("vchbehavior"            ,objAppraisalClassIVEF.vchbehavior);
                p.Add("vchpunctual"            ,objAppraisalClassIVEF.vchpunctual);
                p.Add("vchPhysicalcapacity"    ,objAppraisalClassIVEF.vchPhysicalcapacity);
                p.Add("VchResponsibility"      ,objAppraisalClassIVEF.VchResponsibility);
                p.Add("VchTransform"           ,objAppraisalClassIVEF.VchTransform);
                p.Add("VchGrade"               ,objAppraisalClassIVEF.VchGrade);
                p.Add("intCreatedBy"           ,objAppraisalClassIVEF.intCreatedBy);
                p.Add("dateCreatedOn"          ,objAppraisalClassIVEF.dateCreatedOn);
                p.Add("intUpdatedBy"           ,objAppraisalClassIVEF.intCreatedBy);
                p.Add("dateUpdatedOn", objAppraisalClassIVEF.dateCreatedOn);       



                p.Add("@Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_T_AppraisalClassIV", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessageEF;
        }
        public List<AppraisalClassIVEF> getList(AppraisalClassIVEF objAppraisalClassIVEF)
        {
            List<AppraisalClassIVEF> objListAppraisalClassIVEF = new List<AppraisalClassIVEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("Status", objAppraisalClassIVEF.Status);


                var result = Connection.Query<AppraisalClassIVEF>("USP_T_AppraisalClassIV", p, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objListAppraisalClassIVEF = result.ToList();
                }
                return objListAppraisalClassIVEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public AppraisalClassIVEF getdataedit(AppraisalClassIVEF objAppraisalClassIVEF)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("Status", objAppraisalClassIVEF.Status);
                p.Add("id", objAppraisalClassIVEF.id);

                var result = Connection.Query<AppraisalClassIVEF>("USP_T_AppraisalClassIV", p, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objAppraisalClassIVEF = result.FirstOrDefault();
                }
                return objAppraisalClassIVEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
