using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.NoticeMaster
{
    public class NoticeMasterModel : INoticeMasterModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public NoticeMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        public MessageEF Add(Noticemaster objNoticemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("NoticeMaster/Add", JsonConvert.SerializeObject(objNoticemaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        public MessageEF Update(Noticemaster objNoticemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("NoticeMaster/Update", JsonConvert.SerializeObject(objNoticemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        public List<Noticemaster> View(Noticemaster objNoticemaster)
        {
            try
            {
                List<Noticemaster> objlistNoticemaster = new List<Noticemaster>();
                objlistNoticemaster = JsonConvert.DeserializeObject<List<Noticemaster>>(_objIHttpWebClients.PostRequest("NoticeMaster/View", JsonConvert.SerializeObject(objNoticemaster)));
                return objlistNoticemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        public MessageEF Delete(Noticemaster objNoticemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("NoticeMaster/Delete", JsonConvert.SerializeObject(objNoticemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        public Noticemaster Edit(Noticemaster objNoticemaster)
        {
            try
            {
                objNoticemaster = JsonConvert.DeserializeObject<Noticemaster>(_objIHttpWebClients.PostRequest("NoticeMaster/Edit", JsonConvert.SerializeObject(objNoticemaster)));
                return objNoticemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
