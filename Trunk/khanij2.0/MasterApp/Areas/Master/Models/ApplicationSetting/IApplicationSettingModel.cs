// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 28-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;

namespace MasterApp.Areas.Master.Models.ApplicationSetting
{
    public interface IApplicationSettingModel
    {
        MessageEF Update(ApplicationSettingmaster objApplicationSettingmaster);
        List<ApplicationSettingmaster> View(ApplicationSettingmaster objApplicationSettingmaster);
        ApplicationSettingmaster Edit(ApplicationSettingmaster objApplicationSettingmaster);
    }
}
