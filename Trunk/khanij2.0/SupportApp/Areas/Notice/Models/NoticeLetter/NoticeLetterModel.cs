using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportEF;
using Newtonsoft.Json;
using SupportApp.Models.Utility;

namespace SupportApp.Areas.Notice.Models.NoticeLetter
{
    public class NoticeLetterModel:INoticeLetterModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIHttpWebClients"></param>
        public NoticeLetterModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Send Notice Letter details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public MessageEF SendNoticeLetter(NoticeLetterEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("NoticeLetter/SendNoticeLetter", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Submitted Notice details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public List<NoticeLetterEF> GetSubmittedNotice(NoticeLetterEF objNotice)
        {
            try
            {
                List<NoticeLetterEF> objlistNotice = new List<NoticeLetterEF>();
                objlistNotice = JsonConvert.DeserializeObject<List<NoticeLetterEF>>(_objIHttpWebClients.PostRequest("NoticeLetter/GetSubmittedNotice", JsonConvert.SerializeObject(objNotice)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Send Notice details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public List<NoticeLetterEF> GetSendNotice(NoticeLetterEF objNotice)
        {
            try
            {
                List<NoticeLetterEF> objlistNotice = new List<NoticeLetterEF>();
                objlistNotice = JsonConvert.DeserializeObject<List<NoticeLetterEF>>(_objIHttpWebClients.PostRequest("NoticeLetter/GetSendNotice", JsonConvert.SerializeObject(objNotice)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Uploaded Files by Nitice Id details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public List<NoticeLetterEF> GetUploadedFilesByNoticeID(NoticeLetterEF objNotice)
        {
            try
            {
                List<NoticeLetterEF> objlistNotice = new List<NoticeLetterEF>();
                objlistNotice = JsonConvert.DeserializeObject<List<NoticeLetterEF>>(_objIHttpWebClients.PostRequest("NoticeLetter/GetUploadedFilesByNoticeID", JsonConvert.SerializeObject(objNotice)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Manage UserType details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public List<NoticeLetterEF> ManageUserTypeView(NoticeLetterEF objNotice)
        {
            try
            {
                Result<List<NoticeLetterEF>> r = new Result<List<NoticeLetterEF>>();
                // MessageEF objMessageEF = new MessageEF();
                // objMessageEF = JsonConvert.DeserializeObject<UserTypeResult>(_objIHttpWebClients.PostRequest("NoticeLetter/ManageUserTypeView", objNotice));
                r= JsonConvert.DeserializeObject<Result<List<NoticeLetterEF>>>(_objIHttpWebClients.PostRequest("NoticeLetter/ManageUserTypeView", JsonConvert.SerializeObject(objNotice)));
                return r.Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind User List by Role Type details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public List<NoticeLetterEF> GetUserListByRoleType(NoticeLetterEF objNotice)
        {
            try
            {

                Result<List<NoticeLetterEF>> r = new Result<List<NoticeLetterEF>>();
                // MessageEF objMessageEF = new MessageEF();
                // objMessageEF = JsonConvert.DeserializeObject<UserTypeResult>(_objIHttpWebClients.PostRequest("NoticeLetter/ManageUserTypeView", objNotice));
                r= JsonConvert.DeserializeObject<Result<List<NoticeLetterEF>>>(_objIHttpWebClients.PostRequest("NoticeLetter/GetUserListByRoleType", JsonConvert.SerializeObject(objNotice)));
                return r.Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Uploaded files Reply details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public ReplyNotice Reply_GetUploadedFiles(NoticeLetterEF objNotice)
        {
            try
            {
                // MessageEF objMessageEF = new MessageEF();
                // objMessageEF = JsonConvert.DeserializeObject<UserTypeResult>(_objIHttpWebClients.PostRequest("NoticeLetter/ManageUserTypeView", objNotice));
                return JsonConvert.DeserializeObject<ReplyNotice>(_objIHttpWebClients.PostRequest("NoticeLetter/Reply_GetUploadedFiles", JsonConvert.SerializeObject(objNotice)));
                //  return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Insert Notice Replay details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public MessageEF InsertNoticeReplay(NoticeLetterEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("NoticeLetter/InsertNoticeReplay", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Notice reply details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public List<NoticeLetterEF> GetNoticeReply(NoticeLetterEF objNotice)
        {
            try
            {
                List<NoticeLetterEF> objlistNotice = new List<NoticeLetterEF>();
                objlistNotice = JsonConvert.DeserializeObject<List<NoticeLetterEF>>(_objIHttpWebClients.PostRequest("NoticeLetter/GetNoticeReply", JsonConvert.SerializeObject(objNotice)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Replied details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public ReplyNotice Reply_GetRepliedData(NoticeLetterEF objNotice)
        {
            try
            {
                // MessageEF objMessageEF = new MessageEF();
                // objMessageEF = JsonConvert.DeserializeObject<UserTypeResult>(_objIHttpWebClients.PostRequest("NoticeLetter/ManageUserTypeView", objNotice));
                return JsonConvert.DeserializeObject<ReplyNotice>(_objIHttpWebClients.PostRequest("NoticeLetter/Reply_GetRepliedData", JsonConvert.SerializeObject(objNotice)));
                //  return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Result status details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public MessageEF UpdateStatusResult(NoticeLetterEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("NoticeLetter/UpdateStatusResult", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Notice Penalty reply details data in view
        /// </summary>
        /// <param name="objNotice"></param>
        /// <returns></returns>
        public List<NoticeLetterEF> GetNoticePenaltyReplyGrid(NoticeLetterEF objNotice)
        {
            try
            {
                List<NoticeLetterEF> objlistNotice = new List<NoticeLetterEF>();
                objlistNotice = JsonConvert.DeserializeObject<List<NoticeLetterEF>>(_objIHttpWebClients.PostRequest("NoticeLetter/GetNoticePenaltyReplyGrid", JsonConvert.SerializeObject(objNotice)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
