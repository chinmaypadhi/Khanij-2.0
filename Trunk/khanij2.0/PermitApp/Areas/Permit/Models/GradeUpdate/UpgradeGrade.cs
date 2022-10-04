using Newtonsoft.Json;
using PermitApp.Models.Utility;
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApp.Areas.Permit.Models.GradeUpdate
{
    public class UpgradeGrade : IUpgradeGrade
    {
        IHttpWebClients _objIHttpWebClients;
        public UpgradeGrade(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        public List<SampleGradeModel> GetGradeDetails(SampleGradeModel objUser)
        {
            try
            {
                List<SampleGradeModel> objlistNotice = new List<SampleGradeModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<SampleGradeModel>>(_objIHttpWebClients.PostRequest("CoalEPermit/GetGradeDetails", JsonConvert.SerializeObject(objUser)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
