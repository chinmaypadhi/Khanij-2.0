using Dapper;
using EstablishmentApi.Factory;
using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.AppraisalDriver
{
    public class AppraisalDriverProvider:RepositoryBase, IAppraisalDriverProvider
    {
        public AppraisalDriverProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddAppraisal(AppraisalDriverEF objAppraisalDriverEF)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Action", objAppraisalDriverEF.Action);

                p.Add("id"                      ,objAppraisalDriverEF.id);
                p.Add("VchName"                 ,objAppraisalDriverEF.VchName);
                p.Add("DtmDaterequirement"      ,objAppraisalDriverEF.DtmDaterequirement    );
                p.Add("Vchbehavior"             ,objAppraisalDriverEF.Vchbehavior           );
                p.Add("VchPhysicalfitness"      ,objAppraisalDriverEF.VchPhysicalfitness    );
                p.Add("vchAbilitydrive"         ,objAppraisalDriverEF.vchAbilitydrive       );
                p.Add("VchSafety"               ,objAppraisalDriverEF.VchSafety             );
                p.Add("VchBOL"                  ,objAppraisalDriverEF.VchBOL                );
                p.Add("vchMaintenancevehicle"   ,objAppraisalDriverEF.vchMaintenancevehicle );
                p.Add("VchPresent"              ,objAppraisalDriverEF.VchPresent            );
                p.Add("Vchpunctual"             ,objAppraisalDriverEF.Vchpunctual           );
                p.Add("VchUniform"              ,objAppraisalDriverEF.VchUniform            );
                p.Add("VchCharacter"            ,objAppraisalDriverEF.VchCharacter          );
                p.Add("VchAppreciation"         ,objAppraisalDriverEF.VchAppreciation       );
                p.Add("VchGrade"                ,objAppraisalDriverEF.VchGrade              );
                p.Add("intCreatedBy"            ,objAppraisalDriverEF.intCreatedBy          );
                p.Add("dateCreatedOn"           ,objAppraisalDriverEF.dateCreatedOn         );
                p.Add("intUpdatedBy"            ,objAppraisalDriverEF.intUpdatedBy          );
                p.Add("dateUpdatedOn", objAppraisalDriverEF.dateUpdatedOn);




                p.Add("@Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("usp_T_AppraisalDriver", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessageEF;
        }
        public List<AppraisalDriverEF> getList(AppraisalDriverEF objAppraisalDriverEF)
        {
            List<AppraisalDriverEF> objListAppraisalDriverEF = new List<AppraisalDriverEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("Action", objAppraisalDriverEF.Action);


                var result = Connection.Query<AppraisalDriverEF>("usp_T_AppraisalDriver", p, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objListAppraisalDriverEF = result.ToList();
                }
                return objListAppraisalDriverEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public AppraisalDriverEF getdataedit(AppraisalDriverEF objAppraisalDriverEF)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("Action", objAppraisalDriverEF.Action);
                p.Add("id", objAppraisalDriverEF.id);

                var result = Connection.Query<AppraisalDriverEF>("usp_T_AppraisalDriver", p, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objAppraisalDriverEF = result.FirstOrDefault();
                }
                return objAppraisalDriverEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
