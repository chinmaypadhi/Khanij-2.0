using EpassApp.Models.Utility;
using EpassEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.AdminUtility
{
    public class AdminUtility : IAdminUtility
    {
        IHttpWebClients _objIHttpWebClients;
        public AdminUtility(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public MessageEF CancleTPApproval(TPCancelModelEF objcancel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AdminUtility/CancleTPApproval", JsonConvert.SerializeObject(objcancel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
