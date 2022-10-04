using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.EmpPro.Models
{
    public class OfficeLevelModul:IofficeLevelModul 
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;

        public OfficeLevelModul(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        //IHttpWebClients _objHttpWebClients;
        //public OfficeLevelModul(IHttpWebClients objHttpWebClients)
        //{
        //    _objHttpWebClients = objHttpWebClients;
        //}
        public MessageEF AddUpdateDelete(officeLevelEF officeLevel)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {

                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("OfficeLevel/AddUpdateDelete", JsonConvert.SerializeObject( officeLevel)));

                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objHttpWebClients.PostRequest("OfficeLevel/AddUpdateDelete", officeLevel));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
        public List<officeLevelEF> GetOfficeLevel(officeLevelEF officeLevel)
        {
            List<officeLevelEF> ListofficeLevelEF = new List<officeLevelEF>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<officeLevelEF>>(_objIHttpWebClients.PostRequest("OfficeLevel/GetOfficeLevel", JsonConvert.SerializeObject(officeLevel)));
                //ListofficeLevelEF = JsonConvert.DeserializeObject<List<officeLevelEF>>(_objHttpWebClients.PostRequest("OfficeLevel/GetOfficeLevel", officeLevel));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }
        public officeLevelEF EditOfficeLevel(officeLevelEF officeLevel)
        {
            officeLevelEF objofficeLevelEF = new officeLevelEF();
            try
            {

                objofficeLevelEF = JsonConvert.DeserializeObject<officeLevelEF>(_objIHttpWebClients.PostRequest("OfficeLevel/EditOfficeLevel", JsonConvert.SerializeObject( officeLevel)));

                //objofficeLevelEF = JsonConvert.DeserializeObject<officeLevelEF>(_objHttpWebClients.PostRequest("OfficeLevel/EditOfficeLevel", officeLevel));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objofficeLevelEF;
        }
    }
}
