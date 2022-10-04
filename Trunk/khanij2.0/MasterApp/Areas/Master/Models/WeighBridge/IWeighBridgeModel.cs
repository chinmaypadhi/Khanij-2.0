// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 21-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;

namespace MasterApp.Areas.Master.Models.WeighBridge
{
    public interface IWeighBridgeModel
    {
        MessageEF Add(WeighBridgemaster objWeighBridgemaster);
        MessageEF Update(WeighBridgemaster objWeighBridgemaster);
        List<WeighBridgemaster> View(WeighBridgemaster objWeighBridgemaster);
        MessageEF Delete(WeighBridgemaster objWeighBridgemaster);
        WeighBridgemaster Edit(WeighBridgemaster objWeighBridgemaster);
        List<WeighBridgemaster> GetDistrictList(WeighBridgemaster districtResult);
    }
}
