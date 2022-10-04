// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 20-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;

namespace MasterApp.Areas.Master.Models.Checkpost
{
    public interface ICheckPostModel
    {
        MessageEF Add(Checkpostmaster objCheckPostmaster);
        MessageEF Update(Checkpostmaster objCheckPostmaster);
        List<Checkpostmaster> View(Checkpostmaster objCheckPostmaster);
        MessageEF Delete(Checkpostmaster objCheckPostmaster);
        Checkpostmaster Edit(Checkpostmaster objCheckPostmaster);
        List<Checkpostmaster> GetDistrictList(Checkpostmaster districtResult);
        List<Checkpostmaster> GetUserList(Checkpostmaster userResult);
    }
}
