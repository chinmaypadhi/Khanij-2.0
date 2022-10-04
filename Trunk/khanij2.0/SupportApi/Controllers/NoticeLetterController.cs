using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportApi.Model.NoticeLetter;
using SupportEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SupportApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class NoticeLetterController : ControllerBase
    {
        public INoticeLetterProvider _objINoticeLetterProvider;
        public NoticeLetterController(INoticeLetterProvider objINoticeLetterProvider)
        {
            _objINoticeLetterProvider = objINoticeLetterProvider;
        }
        [HttpPost]
        public MessageEF SendNoticeLetter(NoticeLetterEF objNoticeLetter)
        {
            return _objINoticeLetterProvider.SendNoticeLetter(objNoticeLetter);
        }      
        [HttpPost]
        public List<NoticeLetterEF> GetSubmittedNotice(NoticeLetterEF objNoticeLetter)
        {
            return _objINoticeLetterProvider.GetSubmittedNotice(objNoticeLetter);
        }
        [HttpPost]
        public List<NoticeLetterEF> GetSendNotice(NoticeLetterEF objNoticeLetter)
        {
            return _objINoticeLetterProvider.GetSendNotice(objNoticeLetter);
        }
        [HttpPost]
        public List<NoticeLetterEF> GetUploadedFilesByNoticeID(NoticeLetterEF objNoticeLetter)
        {
            return _objINoticeLetterProvider.GetUploadedFilesByNoticeID(objNoticeLetter);
        }
        [HttpPost]
        public async Task<Result<List<NoticeLetterEF>>> ManageUserTypeView(NoticeLetterEF objNoticeLetter)
        {
            return await _objINoticeLetterProvider.ManageUserTypeView(objNoticeLetter);
        }
        [HttpPost]
        public async Task<Result<List<NoticeLetterEF>>> GetUserListByRoleType(NoticeLetterEF objNoticeLetter)
        {
            return await _objINoticeLetterProvider.GetUserListByRoleType(objNoticeLetter);
        }
        [HttpPost]
        public ReplyNotice Reply_GetUploadedFiles(NoticeLetterEF objNoticeLetter)
        {
            return _objINoticeLetterProvider.Reply_GetUploadedFiles(objNoticeLetter);
        }
        [HttpPost]
        public MessageEF InsertNoticeReplay(NoticeLetterEF objNoticeLetter)
        {
            return _objINoticeLetterProvider.InsertNoticeReplay(objNoticeLetter);
        }
        [HttpPost]
        public List<NoticeLetterEF> GetNoticeReply(NoticeLetterEF objNoticeLetter)
        {
            return _objINoticeLetterProvider.GetNoticeReply(objNoticeLetter);
        }
        [HttpPost]
        public ReplyNotice Reply_GetRepliedData(NoticeLetterEF objNoticeLetter)
        {
            return _objINoticeLetterProvider.Reply_GetRepliedData(objNoticeLetter);
        }
        [HttpPost]
        public MessageEF UpdateStatusResult(NoticeLetterEF objNoticeLetter)
        {
            return _objINoticeLetterProvider.UpdateStatusResult(objNoticeLetter);
        }
        [HttpPost]
        public List<NoticeLetterEF> GetNoticePenaltyReplyGrid(NoticeLetterEF objNoticeLetter)
        {
            return _objINoticeLetterProvider.GetNoticePenaltyReplyGrid(objNoticeLetter);
        }
    }
}