// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 29-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;

namespace MasterApp.Areas.Master.Models.ChangeStatus
{
    public interface IChangeStatusModel
    {
        MessageEF Add(ChangeStatusmaster objChangeStatusmaster);
        List<ChangeStatusmaster> GetDistrictList(ChangeStatusmaster districtResult);
        List<ChangeStatusmaster> GetDivisionList(ChangeStatusmaster userResult);
        List<ChangeStatusmaster> GetUserTypeList(ChangeStatusmaster districtResult);
        List<ChangeStatusmaster> GetUserNameList(ChangeStatusmaster userResult);
        List<ChangeStatusmaster> GetChangeStatusList(ChangeStatusmaster districtResult);
        ChangeStatusmaster GetCurrentStatusList(ChangeStatusmaster districtResult);
    }
}
