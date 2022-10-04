// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 18-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;


namespace MasterApi.Model.Route
{
    public interface IRouteProvider
    {
        MessageEF AddRouteMaster(Routemaster objRoutemaster);
        List<Routemaster> ViewRouteMaster(Routemaster objRoutemaster);
        Routemaster EditRouteMaster(Routemaster objRoutemaster);
        MessageEF DeleteRouteMaster(Routemaster objRoutemaster);
        MessageEF UpdateRouteMaster(Routemaster objRoutemaster);
        List<Routemaster> GetDistrictList(Routemaster objRoutemaster);
    }
}
