// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 31-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.RoyaltyForward
{
    public interface IRoyaltyForwardProvider
    {
        List<RoyaltyForwardmaster> ViewRoyaltyForwardMaster(RoyaltyForwardmaster objRoyaltyForwardmaster);
        MessageEF Submit(RoyaltyForwardmaster objRoyaltyForwardmaster);
        List<RoyaltyForwardmaster> DownloadRoyaltyForwardMaster(RoyaltyForwardmaster objRoyaltyForwardmaster);


        List<RoyaltyForwardmaster> RoyaltyInbox(RoyaltyForwardmaster objRoyaltyForwardmaster);
        List<RoyaltyApprovedLogEF> ViewRoyaltyActionHistory(RoyaltyApprovedLogEF objRoyalty);
        List<RoyaltyApprovedEF> RoyaltyInboxView(RoyaltyApprovedEF objRoyalty);
        MessageEF TakeAction(RoyaltyForwardmaster objRoyalty);
    }
}
