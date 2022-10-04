// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 2-Feb-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;

namespace MasterApp.Areas.Master.Models.RoyaltyMapping
{
    public interface IRoyaltyMappingModel
    {
        MessageEF Add(RoyaltyMappingmaster objRoyaltyMappingmaster);
        List<RoyaltyMappingmaster> View(RoyaltyMappingmaster objRoyaltyMappingmaster);
        MessageEF Delete(RoyaltyMappingmaster objRoyaltyMappingmaster);
        RoyaltyMappingmaster Edit(RoyaltyMappingmaster objRoyaltyMappingmaster);
        List<RoyaltyMappingmaster> ViewPaymentType(RoyaltyMappingmaster objRoyaltyMappingmaster);
        List<RoyaltyMappingmaster> ViewRoyaltyType(RoyaltyMappingmaster objRoyaltyMappingmaster);
    }
}
