using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Models.AppraisalClassIV
{
    public class AppraisalClassIVModel:IAppraisalClassIVModel 
    {

        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;

        public AppraisalClassIVModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        //IHttpWebClients _objHttpWebClients;
        //public AppraisalClassIVModel(IHttpWebClients objHttpWebClients)
        //{
        //    _objHttpWebClients = objHttpWebClients;
        //}


        public MessageEF AddAppraisal(AppraisalClassIVEF objAppraisalClassIVEF)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AppraisalClassIV/AddAppraisal", JsonConvert.SerializeObject(objAppraisalClassIVEF)));

                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objHttpWebClients.PostRequest("AppraisalClassIV/AddAppraisal", objAppraisalClassIVEF));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
       public List<AppraisalClassIVEF> getList(AppraisalClassIVEF objAppraisalClassIVEF)
        {
            List<AppraisalClassIVEF> objListAppraisalClassIVEF = new List<AppraisalClassIVEF>();
            try
            {
                objListAppraisalClassIVEF = JsonConvert.DeserializeObject<List<AppraisalClassIVEF>>(_objIHttpWebClients.PostRequest("AppraisalClassIV/getList", JsonConvert.SerializeObject(objAppraisalClassIVEF)));


                //objListAppraisalClassIVEF = JsonConvert.DeserializeObject<List<AppraisalClassIVEF>>(_objHttpWebClients.PostRequest("AppraisalClassIV/getList", objAppraisalClassIVEF));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objListAppraisalClassIVEF;
        }
       public AppraisalClassIVEF getdataedit(AppraisalClassIVEF objAppraisalClassIVEF)
        {
            try
            {
                try
                {
                    objAppraisalClassIVEF = JsonConvert.DeserializeObject<AppraisalClassIVEF>(_objIHttpWebClients.PostRequest("AppraisalClassIV/getdataedit", JsonConvert.SerializeObject(objAppraisalClassIVEF)));

                    //objAppraisalClassIVEF = JsonConvert.DeserializeObject<AppraisalClassIVEF>(_objHttpWebClients.PostRequest("AppraisalClassIV/getdataedit", objAppraisalClassIVEF));
                }
                catch (Exception ex)
                {

                    throw;
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
