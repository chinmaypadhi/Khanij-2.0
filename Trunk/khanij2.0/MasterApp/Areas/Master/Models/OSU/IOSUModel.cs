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

namespace MasterApp.Areas.Master.Models.OSU
{
    public interface IOSUModel
    {
        MessageEF Add(OSUmaster objOSUmaster);
        List<OSUmaster> GetDistrictList(OSUmaster districtResult);
        List<OSUmaster> GetUserTypeList(OSUmaster usertypeResult);
        List<OSUmaster> GetCompanyList(OSUmaster companyResult);
        List<OSUmaster> GetLesseeTypeList(OSUmaster usertypeResult);
        List<OSUmaster> GetLicenseeTypeList(OSUmaster usertypeResult);
        List<OSUmaster> GetChangeStatusList(OSUmaster changestatusResult);
        /// <summary>
        /// To Update Encrypt Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel);
    }
}
