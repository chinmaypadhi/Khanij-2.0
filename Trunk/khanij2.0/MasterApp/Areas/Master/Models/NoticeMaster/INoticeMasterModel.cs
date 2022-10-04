using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.NoticeMaster
{
    public interface INoticeMasterModel
    {
        MessageEF Add(Noticemaster objNoticemaster);
        MessageEF Update(Noticemaster objNoticemaster);
        List<Noticemaster> View(Noticemaster objNoticemaster);
        MessageEF Delete(Noticemaster objNoticemaster);
        Noticemaster Edit(Noticemaster objNoticemaster);
    }
}
