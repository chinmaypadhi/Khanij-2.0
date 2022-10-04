using IntegrationApp.Models.Utility;
using IntegrationEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Areas.Payment.Models.NoticeLtrDetails
{
    public class NoticeLtr : INoticeLtr
    {
        IHttpWebClients _objIHttpWebClients;
        public NoticeLtr(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        public List<Notice> NoticeLtrPaynalty(Notice objmodel)
        {
            try
            {
                List<Notice> objlistNotice = new List<Notice>();
                objlistNotice = JsonConvert.DeserializeObject<List<Notice>>(_objIHttpWebClients.PostRequest("NoticeLtr/Payments", JsonConvert.SerializeObject(objmodel)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
