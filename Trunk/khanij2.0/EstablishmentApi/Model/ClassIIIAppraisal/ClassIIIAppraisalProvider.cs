using Dapper;
using EstablishmentApi.Factory;
using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.ClassIIIAppraisal
{
    public class ClassIIIAppraisalProvider: RepositoryBase,IClassIIIAppraisalProvider 
    {
        public ClassIIIAppraisalProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
           
        }
        public List<ClassIIIAppraisalEF> GetList(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            List<ClassIIIAppraisalEF> objlistClassIIIAppraisalEF = new List<ClassIIIAppraisalEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Status", objClassIIIAppraisalEF.Satus);
               
           
                var result = Connection.Query<ClassIIIAppraisalEF>("USP_T_Appraisal_ClassIII", p, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objlistClassIIIAppraisalEF = result.ToList();
                }
                return objlistClassIIIAppraisalEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public ClassIIIAppraisalEF GetDetails(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Status", objClassIIIAppraisalEF.Satus);
                p.Add("P_AppraisalId", objClassIIIAppraisalEF.AppraisalId);
               
                var result = Connection.Query<ClassIIIAppraisalEF>("USP_T_Appraisal_ClassIII", p, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objClassIIIAppraisalEF = result.FirstOrDefault(); 
                }
                return objClassIIIAppraisalEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objClassIIIAppraisalEF;
        }
        public MessageEF AddPersonaldetails(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Status", objClassIIIAppraisalEF.Satus);
                p.Add("P_AppraisalId"                  ,objClassIIIAppraisalEF.AppraisalId);
                p.Add("P_Department"                   ,objClassIIIAppraisalEF.Department);
                p.Add("P_Designation", objClassIIIAppraisalEF.Designation);
                p.Add("P_Personname", objClassIIIAppraisalEF.Personname);           
                p.Add("P_Paygrade"                     ,objClassIIIAppraisalEF.Paygrade);               
                p.Add("P_description"                  ,objClassIIIAppraisalEF.description);            
                p.Add("P_Naturebehavior"               ,objClassIIIAppraisalEF.Naturebehavior);         
                p.Add("P_Character"                    ,objClassIIIAppraisalEF.Character);              
                p.Add("P_Relationcolleague"            ,objClassIIIAppraisalEF.Relationcolleague);      
                p.Add("P_Punctuality_work"             ,objClassIIIAppraisalEF.Punctuality_work);       
                p.Add("P_Accuracytyping"               ,objClassIIIAppraisalEF.Accuracytyping);         
                p.Add("P_Allegiance"                   ,objClassIIIAppraisalEF.Allegiance);             
                p.Add("P_Arrangementfiles"             ,objClassIIIAppraisalEF.Arrangementfiles);       
                p.Add("P_importantwork"                ,objClassIIIAppraisalEF.importantwork);          
                p.Add("P_Promotion"                    ,objClassIIIAppraisalEF.Promotion);              
                p.Add("P_workdetails"                  ,objClassIIIAppraisalEF.workdetails);            
                p.Add("P_Grade"                        ,objClassIIIAppraisalEF.Grade);
                //
                p.Add("P_VchReviewingWorkDetails", objClassIIIAppraisalEF.VchReviewingWorkDetails);
                p.Add("P_ReviewingGrade", objClassIIIAppraisalEF.ReviewingGrade);
                p.Add("P_Reviewingdate", objClassIIIAppraisalEF.Reviewingdate);
                p.Add("P_Reviewingby", objClassIIIAppraisalEF.Reviewingby);
                p.Add("P_VchAcceptingWorkDetails", objClassIIIAppraisalEF.VchAcceptingWorkDetails);
                p.Add("P_AcceptingGrade", objClassIIIAppraisalEF.AcceptingGrade);
                p.Add("P_Acceptingdate", objClassIIIAppraisalEF.Acceptingdate);
                p.Add("P_Acceptingby", objClassIIIAppraisalEF.Acceptingby);
                //
                p.Add("P_intCreatedBy"                 ,objClassIIIAppraisalEF.intCreatedBy);           
                p.Add("P_dateCreatedOn"                ,objClassIIIAppraisalEF.dateCreatedOn);          
                p.Add("P_intUpdatedBy"                 ,objClassIIIAppraisalEF.intUpdatedBy);           
                p.Add("P_dateUpdatedOn"                ,objClassIIIAppraisalEF.dateUpdatedOn);
                //p.Add("P_bitDeleted", objClassIIIAppraisalEF.bitDeleted);
                //p.Add("P_FinancialYear", objClassIIIAppraisalEF.FinancialYear);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_T_Appraisal_ClassIII", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                string S = ex.Message.ToString();
                throw ex;
            }
            return objMessageEF;
        }
    }
}
