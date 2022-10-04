using SupportEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApp.Areas.Notice.Models.NoticeLetter
{
    public interface INoticeLetterModel
    {
        MessageEF SendNoticeLetter(NoticeLetterEF objNotice);
      
        List<NoticeLetterEF> GetSubmittedNotice(NoticeLetterEF objNotice);
        List<NoticeLetterEF> GetSendNotice(NoticeLetterEF objNotice);
        List<NoticeLetterEF> GetUploadedFilesByNoticeID(NoticeLetterEF objNotice);
        List<NoticeLetterEF> ManageUserTypeView(NoticeLetterEF objNotice);
        List<NoticeLetterEF> GetUserListByRoleType(NoticeLetterEF objNotice);
        ReplyNotice Reply_GetUploadedFiles(NoticeLetterEF objNotice);
        MessageEF InsertNoticeReplay(NoticeLetterEF objNotice);
        List<NoticeLetterEF> GetNoticeReply(NoticeLetterEF objNotice);
        ReplyNotice Reply_GetRepliedData(NoticeLetterEF objNotice);
        MessageEF UpdateStatusResult(NoticeLetterEF objNotice);
        List<NoticeLetterEF> GetNoticePenaltyReplyGrid(NoticeLetterEF objNotice);
    }
}
