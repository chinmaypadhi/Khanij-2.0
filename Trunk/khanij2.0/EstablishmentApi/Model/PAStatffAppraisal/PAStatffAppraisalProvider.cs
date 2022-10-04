using Dapper;
using EstablishmentApi.Factory;
using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.PAStatffAppraisal
{
    public class PAStatffAppraisalProvider : RepositoryBase, IPAStatffAppraisalProvider
    {
        public PAStatffAppraisalProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public MessageEF ReportingAuthority(PastaffEF objPastaffEF)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Action", objPastaffEF.Action);
                p.Add("intApprisalld", objPastaffEF.intApprisalld);
                p.Add("Department", objPastaffEF.Department);
                p.Add("Designation", objPastaffEF.Designation);
                p.Add("Person_name", objPastaffEF.Person_name);
                p.Add("PayGrade", objPastaffEF.PayGrade);
                p.Add("RepAutname", objPastaffEF.RepAutname);
                p.Add("Stenographyspeed", objPastaffEF.Stenographyspeed);
                p.Add("Abilitytowritingremarks", objPastaffEF.Abilitytowritingremarks);
                p.Add("Maintainrelvisitor", objPastaffEF.Maintainrelvisitor);
                p.Add("Abilityinformationconfidential", objPastaffEF.Abilityinformationconfidential);
                p.Add("TelComSkill", objPastaffEF.TelComSkill);
                p.Add("Arrtmeeting", objPastaffEF.Arrtmeeting);
                p.Add("MangLetabsentofficer", objPastaffEF.MangLetabsentofficer);
                p.Add("AbilitCompletetask", objPastaffEF.AbilitCompletetask);
                p.Add("Punctuality", objPastaffEF.Punctuality);
                p.Add("Extraqualification", objPastaffEF.Extraqualification);
                p.Add("Grade", objPastaffEF.Grade);
                p.Add("intCreatedBy", objPastaffEF.intCreatedBy);
                p.Add("dateCreatedOn", objPastaffEF.dateCreatedOn);
                p.Add("@Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_T_AppraisalPAStaff", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessageEF;

        }
        public List<PastaffEF> getList(PastaffEF objPastaffEF)
        {
            List<PastaffEF> ListPastaffEF = new List<PastaffEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("Action", objPastaffEF.Action);


                var result = Connection.Query<PastaffEF>("USP_T_AppraisalPAStaff", p, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListPastaffEF = result.ToList();
                }
                return ListPastaffEF;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public PastaffEF ReportingAuthorityEdit(PastaffEF objPastaffEF)
        {
            PastaffEF ListPastaffEF = new PastaffEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Action", objPastaffEF.Action);
                p.Add("intApprisalld", objPastaffEF.intApprisalld);

                var result = Connection.Query<PastaffEF>("USP_T_AppraisalPAStaff", p, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListPastaffEF = result.FirstOrDefault();
                }
                return ListPastaffEF;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
