using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Notice
{
    public interface INoticeModel 
    {
        List<WebNotice> ViewWebsiteNotice(WebNotice webNotice);
    }
}
