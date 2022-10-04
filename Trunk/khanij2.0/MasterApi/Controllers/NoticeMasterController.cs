// ***********************************************************************
//  Controller Name          : NoticeMasterController
//  Description              : Add,View,Edit,Update,Delete Notice Master details
//  Created By               : Debaraj Swain
//  Created On               : 12 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.NoticeMaster;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class NoticeMasterController : Controller
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public INoticeMasterProvider _objINoticeMasterProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objNoticeMasterProvider"></param>
        public NoticeMasterController(INoticeMasterProvider objNoticeMasterProvider)
        {
            _objINoticeMasterProvider = objNoticeMasterProvider;
        }
        /// <summary>
        /// Add Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(Noticemaster objNoticemaster)
        {
            return _objINoticeMasterProvider.AddNoticeMaster(objNoticemaster);
        }
        /// <summary>
        /// View Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Noticemaster> View(Noticemaster objNoticemaster)
        {
            return _objINoticeMasterProvider.ViewNoticeMaster(objNoticemaster);
        }
        /// <summary>
        /// Edit Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public Noticemaster Edit(Noticemaster objNoticemaster)
        {
            return _objINoticeMasterProvider.EditNoticemaster(objNoticemaster);
        }
        /// <summary>
        /// Delete Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(Noticemaster objNoticemaster)
        {
            return _objINoticeMasterProvider.DeleteNoticemaster(objNoticemaster);
        }
        /// <summary>
        /// Update Notice Master details in view
        /// </summary>
        /// <param name="objNoticemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(Noticemaster objNoticemaster)
        {
            return _objINoticeMasterProvider.UpdateNoticemaster(objNoticemaster);
        }

        [HttpPost]
        public string test()
        {
            return "test";
        }
    }
}
