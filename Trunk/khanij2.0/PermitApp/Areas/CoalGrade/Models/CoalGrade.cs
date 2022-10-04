using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PermitApp.Models.Utility;
using PermitEF;

namespace PermitApp.Areas.CoalGrade.Models
{
    public class CoalGrade : ICoalGrade
    {
        IHttpWebClients objIHttpWebClients;
        public CoalGrade(IHttpWebClients objIHttpWebClients)
        {
            this.objIHttpWebClients = objIHttpWebClients;
        }
        public ePermitModel CoalGradeDetailsByPermitID(ePermitModel obj)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitModel>(objIHttpWebClients.PostRequest("CoalGrade/CoalGradeDetailsByPermitID", JsonConvert.SerializeObject(obj)));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<SampleGradeModel> CoalGradeDetailsByUserID(SampleGradeModel obj)
        {
            try
            {
                List<SampleGradeModel> objlist = new List<SampleGradeModel>();
                objlist = JsonConvert.DeserializeObject<List<SampleGradeModel>>(objIHttpWebClients.PostRequest("CoalGrade/CoalGradeDetailsByUserID", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ePermitModel> GetMineralGradeCascadFromMineralNature(ePermitModel obj)
        {
            try
            {
                List<ePermitModel> objlist = new List<ePermitModel>();
                objlist = JsonConvert.DeserializeObject<List<ePermitModel>>(objIHttpWebClients.PostRequest("CoalGrade/GetMineralGradeCascadFromMineralNature", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ePaymentData> RevisedPayableRoyaltyRate(RevisedPayableRoyaltyRate obj)
        {
            try
            {
                List<ePaymentData> objlist = new List<ePaymentData>();
                objlist = JsonConvert.DeserializeObject<List<ePaymentData>>(objIHttpWebClients.PostRequest("CoalGrade/RevisedPayableRoyaltyRate", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
