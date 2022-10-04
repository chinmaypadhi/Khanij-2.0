using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Models.PastaffAppraisal
{
    public class PAstaffApprasalModel : IPAstaffApprasalModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;

        public PAstaffApprasalModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        //IHttpWebClients _objHttpWebClients;
        //public PAstaffApprasalModel(IHttpWebClients objHttpWebClients)
        //{
        //    _objHttpWebClients = objHttpWebClients;
        //}
        public List<PastaffEF> getList(PastaffEF objClassIIIAppraisalEF)
        {
            List<PastaffEF> objListPastaffEF = new List<PastaffEF>();
            try
            {
                objListPastaffEF = JsonConvert.DeserializeObject<List<PastaffEF>>(_objIHttpWebClients.PostRequest("PAStatffAppraisal/getList", JsonConvert.SerializeObject(objClassIIIAppraisalEF)));

                //objListPastaffEF = JsonConvert.DeserializeObject<List<PastaffEF>>(_objHttpWebClients.PostRequest("PAStatffAppraisal/getList", objClassIIIAppraisalEF));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objListPastaffEF;
        }
        public MessageEF ReportingAuthority(PastaffEF objPastaffEF)

        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PAStatffAppraisal/ReportingAuthority", JsonConvert.SerializeObject(objPastaffEF)));


                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objHttpWebClients.PostRequest("PAStatffAppraisal/ReportingAuthority", objPastaffEF));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }

        public PastaffEF ReportingAuthorityEdit(PastaffEF objPastaffEF)
        {
            try
            {
                objPastaffEF = JsonConvert.DeserializeObject<PastaffEF>(_objIHttpWebClients.PostRequest("PAStatffAppraisal/ReportingAuthorityEdit", JsonConvert.SerializeObject(objPastaffEF)));
                //objPastaffEF = JsonConvert.DeserializeObject<PastaffEF>(_objHttpWebClients.PostRequest("PAStatffAppraisal/ReportingAuthorityEdit", objPastaffEF));


            }
            catch (Exception ex)
            {

                throw;
            }
            return objPastaffEF;
        }
    }
}
