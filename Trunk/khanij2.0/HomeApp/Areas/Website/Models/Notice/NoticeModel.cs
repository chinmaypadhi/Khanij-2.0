using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HomeApp.Areas.Website.Models.Notice
{
    public class NoticeModel : INoticeModel
    {
        #region Global Declaration
        IHttpWebClients _objIHttpWebClients;
        #endregion
        #region Consructor Dependency Injection
        public NoticeModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }
        #endregion

        /// <summary>
        /// To View Notice in Website
        /// </summary>
        /// <param name="webNotice"></param>
        /// <returns></returns>
        public List<WebNotice> ViewWebsiteNotice(WebNotice webNotice)
        {
            try
            {
                List<WebNotice> objNoticelist = new List<WebNotice>();
                objNoticelist = JsonConvert.DeserializeObject<List<WebNotice>>(_objIHttpWebClients.PostRequest("Transparncy/ViewNotice", JsonConvert.SerializeObject(webNotice)));
                return objNoticelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
