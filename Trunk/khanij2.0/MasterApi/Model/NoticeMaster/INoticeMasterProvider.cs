// ***********************************************************************
//  Interface Name           : INoticeMasterProvider
//  Description              : Add,View,Edit,Update,Delete Notice Master details
//  Created By               : Debaraj Swain
//  Created On               : 08 Jan 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.NoticeMaster
{
    public interface INoticeMasterProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        MessageEF AddNoticeMaster(Noticemaster objNoticemaster);
        /// <summary>
        /// View Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        List<Noticemaster> ViewNoticeMaster(Noticemaster objNoticemaster);
        /// <summary>
        /// Edit Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        Noticemaster EditNoticemaster(Noticemaster objNoticemaster);
        /// <summary>
        /// Delete Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        MessageEF DeleteNoticemaster(Noticemaster objNoticemaster);
        /// <summary>
        /// Update Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        MessageEF UpdateNoticemaster(Noticemaster objNoticemaster);
    }
}
