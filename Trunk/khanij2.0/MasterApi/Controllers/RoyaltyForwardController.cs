// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 31-Jan-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterApi.Model.RoyaltyForward;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class RoyaltyForwardController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        public IRoyaltyForwardProvider _objIRoyaltyForwardProvider;
        MessageEF objobjmodel = new MessageEF();
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objRoyaltyForwardProvider"></param>
        public RoyaltyForwardController(IRoyaltyForwardProvider objRoyaltyForwardProvider)
        {
            _objIRoyaltyForwardProvider = objRoyaltyForwardProvider;
        }

        [HttpPost]
        public List<RoyaltyForwardmaster> View(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            return _objIRoyaltyForwardProvider.ViewRoyaltyForwardMaster(objRoyaltyForwardmaster);
        }
        [HttpPost]
        public MessageEF Submit(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            return _objIRoyaltyForwardProvider.Submit(objRoyaltyForwardmaster);
        }
        [HttpPost]
        public List<RoyaltyForwardmaster> Download(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            return _objIRoyaltyForwardProvider.DownloadRoyaltyForwardMaster(objRoyaltyForwardmaster);
        }




        [HttpPost]
        public List<RoyaltyForwardmaster> RoyaltyInbox(RoyaltyForwardmaster objRoyaltyForwardmaster)
        {
            return _objIRoyaltyForwardProvider.RoyaltyInbox(objRoyaltyForwardmaster);
        }

        [HttpPost]
        public MessageEF TakeAction(RoyaltyForwardmaster objRoyalty)
        {
            return _objIRoyaltyForwardProvider.TakeAction(objRoyalty);
        }
        [HttpPost]
        public List<RoyaltyApprovedLogEF> ViewRoyaltyActionHistory(RoyaltyApprovedLogEF objRoyalty)
        {
            return _objIRoyaltyForwardProvider.ViewRoyaltyActionHistory(objRoyalty);
        }

        [HttpPost]
        public List<RoyaltyApprovedEF> RoyaltyInboxView(RoyaltyApprovedEF objRoyaltyForwardmaster)
        {
            return _objIRoyaltyForwardProvider.RoyaltyInboxView(objRoyaltyForwardmaster);
        }

    }
}