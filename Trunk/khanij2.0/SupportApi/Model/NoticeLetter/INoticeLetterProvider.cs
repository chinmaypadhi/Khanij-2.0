using SupportApi.Repository;

using SupportEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SupportApi.Model.NoticeLetter
{
    public interface INoticeLetterProvider : IDisposable, IRepository
    {
        MessageEF SendNoticeLetter(NoticeLetterEF noticeLetterEF);
       // List<NoticeLetterEF> ViewUserType(NoticeLetterEF objNoticeType);
        List<NoticeLetterEF> GetSubmittedNotice(NoticeLetterEF objNoticeType);
        List<NoticeLetterEF> GetSendNotice(NoticeLetterEF objNoticeType);
        List<NoticeLetterEF> GetUploadedFilesByNoticeID(NoticeLetterEF objNoticeType);
        Task<Result<List<NoticeLetterEF>>> ManageUserTypeView(NoticeLetterEF objNotice);
        Task<Result<List<NoticeLetterEF>>>  GetUserListByRoleType(NoticeLetterEF objNotice);
        ReplyNotice Reply_GetUploadedFiles(NoticeLetterEF objNotice);
        MessageEF InsertNoticeReplay(NoticeLetterEF noticeLetterEF);
        List<NoticeLetterEF> GetNoticeReply(NoticeLetterEF objNoticeType);
        ReplyNotice Reply_GetRepliedData(NoticeLetterEF objNotice);
        MessageEF UpdateStatusResult(NoticeLetterEF noticeLetterEF);        
        List<NoticeLetterEF> GetNoticePenaltyReplyGrid(NoticeLetterEF objNoticeType);

    }
}
