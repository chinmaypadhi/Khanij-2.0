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
using MasterEF;
using System.Collections.Generic;

namespace MasterApp.Areas.Master.Models.RoyaltyForward
{
    public interface IRoyaltyForwardModel
    {
        List<RoyaltyForwardmaster> View(RoyaltyForwardmaster objRoyaltyForwardmaster);
        MessageEF Submit(RoyaltyForwardmaster objRoyaltyForwardmaster);
        List<RoyaltyForwardmaster> Download(RoyaltyForwardmaster objRoyaltyForwardmaster);




        List<RoyaltyForwardmaster> RoyaltyInbox(RoyaltyForwardmaster objRoyaltyForwardmaster);
        MessageEF TakeAction(RoyaltyForwardmaster objRoyalty);
        List<WorkFlowDropDown> BindActionType(WorkFlowDropDown objActionType);
        List<RoyaltyApprovedLogEF> ViewRoyaltyActionHistory(RoyaltyApprovedLogEF objRoyalty);

        List<RoyaltyApprovedEF> RoyaltyInboxView(RoyaltyApprovedEF objRoyalty);

    }
}
