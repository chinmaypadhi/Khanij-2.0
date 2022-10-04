using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EstablishmentApp.Areas.Aec.Models.SelfAppraisal
{
    public class SelfAppraisalModel:ISelfAppraisalModel 
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;

        public SelfAppraisalModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        //IHttpWebClients _objHttpWebClients;
        //public SelfAppraisalModel(IHttpWebClients objHttpWebClients)
        //{
        //    _objHttpWebClients = objHttpWebClients;
        //}
        public List<SalfeAprasialEf> GetListData(SalfeAprasialEf objSalfeAprasialEf)
        {
            List<SalfeAprasialEf> ListSalfeAprasialEf = new List<SalfeAprasialEf>();
            try
            {

                ListSalfeAprasialEf = JsonConvert.DeserializeObject<List<SalfeAprasialEf>>(_objIHttpWebClients.PostRequest("SalfeAprasial/GetListData", JsonConvert.SerializeObject(objSalfeAprasialEf)));

                //ListSalfeAprasialEf = JsonConvert.DeserializeObject<List<SalfeAprasialEf>>(_objHttpWebClients.PostRequest("SalfeAprasial/GetListData", objSalfeAprasialEf));
           
        }
            catch (Exception ex)
            {

                throw;
            }
            return ListSalfeAprasialEf;
        }
        public SalfeAprasialEf GetAprasialDetails(SalfeAprasialEf objSalfeAprasialEf)
        {
            
            try
            {
  objSalfeAprasialEf = JsonConvert.DeserializeObject<SalfeAprasialEf>(_objIHttpWebClients.PostRequest("SalfeAprasial/Edit", JsonConvert.SerializeObject( objSalfeAprasialEf)));

                //objSalfeAprasialEf = JsonConvert.DeserializeObject<SalfeAprasialEf>(_objHttpWebClients.PostRequest("SalfeAprasial/Edit", objSalfeAprasialEf));

            }
            catch (Exception ex)
            {

                throw;
            }
            return objSalfeAprasialEf;
        }
        public MessageEF RevAuthoReviewUpdate(SalfeAprasialEf objSalfeAprasialEf)
        {

            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SalfeAprasial/update", JsonConvert.SerializeObject(objSalfeAprasialEf)));
                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objHttpWebClients.PostRequest("SalfeAprasial/update", objSalfeAprasialEf));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
        public MessageEF AddSalfeAprasial(SalfeAprasialEf objSalfeAprasialEf)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SalfeAprasial/AddSalfeAprasial", JsonConvert.SerializeObject(objSalfeAprasialEf)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return objMessageEF;
        }



    }
}
