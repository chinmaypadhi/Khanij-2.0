// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 02-Feb-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;

namespace MasterApi.Model.RoyaltyMapping
{
    public interface IRoyaltyMappingProvider
    {
        MessageEF AddRoyaltyMappingmaster(RoyaltyMappingmaster objRoyaltyMappingmaster);
        List<RoyaltyMappingmaster> ViewRoyaltyMappingmaster(RoyaltyMappingmaster objRoyaltyMappingmaster);
        RoyaltyMappingmaster EditRoyaltyMappingmaster(RoyaltyMappingmaster objRoyaltyMappingmaster);
        MessageEF DeleteRoyaltyMappingmaster(RoyaltyMappingmaster objRoyaltyMappingmaster);
        List<RoyaltyMappingmaster> ViewPaymentType(RoyaltyMappingmaster objRoyaltyMappingmaster);
        List<RoyaltyMappingmaster> ViewRoyaltyType(RoyaltyMappingmaster objRoyaltyMappingmaster);
    }
}
