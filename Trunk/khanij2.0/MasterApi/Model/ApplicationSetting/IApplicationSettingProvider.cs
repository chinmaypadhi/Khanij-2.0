// ***********************************************************************
//  Interface Name           : IApplicationSettingProvider
//  Description              : Add,View,Edit,Update,Delete Application Setting details
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Jan 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.ApplicationSetting
{
    public interface IApplicationSettingProvider
    {
        /// <summary>
        /// View Setting details
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        List<ApplicationSettingmaster> ViewApplicationSettingmaster(ApplicationSettingmaster objApplicationSettingmaster);
        /// <summary>
        /// Edit Application Setting details
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        ApplicationSettingmaster EditApplicationSettingmaster(ApplicationSettingmaster objApplicationSettingmaster);
        /// <summary>
        /// Update Application Setting details
        /// </summary>
        /// <param name="objApplicationSettingmaster"></param>
        /// <returns></returns>
        MessageEF UpdateApplicationSettingmaster(ApplicationSettingmaster objApplicationSettingmaster);
    }
}
