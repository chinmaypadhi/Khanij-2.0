using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Models.AppraisalDriver
{
    public class AppraisalDriverModel:IAppraisalDriverModel 
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;

        public AppraisalDriverModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        //IHttpWebClients _objHttpWebClients;
        //public AppraisalDriverModel(IHttpWebClients objHttpWebClients)
        //{
        //    _objHttpWebClients = objHttpWebClients;
        //}
        public MessageEF AddAppraisal(AppraisalDriverEF objAppraisalDriverEF)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AppraisalDriver/AddAppraisal", JsonConvert.SerializeObject(objAppraisalDriverEF)));
                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objHttpWebClients.PostRequest("AppraisalDriver/AddAppraisal", objAppraisalDriverEF));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
        public List<AppraisalDriverEF> getList(AppraisalDriverEF objAppraisalDriverEF)
        {
            List<AppraisalDriverEF> objListAppraisalDriverEF = new List<AppraisalDriverEF>();
            try
            {
                objListAppraisalDriverEF = JsonConvert.DeserializeObject<List<AppraisalDriverEF>>(_objIHttpWebClients.PostRequest("AppraisalDriver/getList", JsonConvert.SerializeObject(objAppraisalDriverEF)));

                //objListAppraisalDriverEF = JsonConvert.DeserializeObject<List<AppraisalDriverEF>>(_objHttpWebClients.PostRequest("AppraisalDriver/getList", objAppraisalDriverEF));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objListAppraisalDriverEF;
        }
        public AppraisalDriverEF getdataedit(AppraisalDriverEF objAppraisalDriverEF)
        {
            //try
            //{
                try
                {

                    objAppraisalDriverEF = JsonConvert.DeserializeObject<AppraisalDriverEF>(_objIHttpWebClients.PostRequest("AppraisalDriver/getdataedit", JsonConvert.SerializeObject( objAppraisalDriverEF)));

                    //objAppraisalDriverEF = JsonConvert.DeserializeObject<AppraisalDriverEF>(_objHttpWebClients.PostRequest("AppraisalDriver/getdataedit", objAppraisalDriverEF));
                }
                catch (Exception ex)
                {

                    throw;
                }
                return objAppraisalDriverEF;
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }
    }
}
