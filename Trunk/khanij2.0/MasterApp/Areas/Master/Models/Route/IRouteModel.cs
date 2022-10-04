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

namespace MasterApp.Areas.Master.Models.Route
{
    public interface IRouteModel
    {
        MessageEF Add(Routemaster objRouteMaster);
        MessageEF Update(Routemaster objRouteMaster);
        List<Routemaster> View(Routemaster objRouteMaster);
        MessageEF Delete(Routemaster objRouteMaster);
        Routemaster Edit(Routemaster objRouteMaster);
       List<Routemaster> GetDistrictList(Routemaster districtResult);
    }
}
