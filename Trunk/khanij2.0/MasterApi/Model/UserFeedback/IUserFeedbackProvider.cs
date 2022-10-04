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

namespace MasterApi.Model.UserFeedback
{
    public interface IUserFeedbackProvider
    {
        MessageEF PublishUserFeedback(UserFeedbackmaster objUserFeedbackmaster);
        MessageEF UndoPublishUserFeedback(UserFeedbackmaster objUserFeedbackmaster);
        List<UserFeedbackmaster> ViewUserFeedbackmaster(UserFeedbackmaster objUserFeedbackmaster);
    }
}
