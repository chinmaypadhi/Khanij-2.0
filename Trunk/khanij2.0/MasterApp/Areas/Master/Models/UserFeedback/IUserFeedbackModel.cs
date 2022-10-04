// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 22-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;

namespace MasterApp.Areas.Master.Models.UserFeedback
{
    public interface IUserFeedbackModel
    {
        MessageEF PublishUserFeedback(UserFeedbackmaster objUserFeedbackmaster);
        MessageEF UndoPublish(UserFeedbackmaster objUserFeedbackmaster);
        List<UserFeedbackmaster> View(UserFeedbackmaster objUserFeedbackmaster);
    }
}
