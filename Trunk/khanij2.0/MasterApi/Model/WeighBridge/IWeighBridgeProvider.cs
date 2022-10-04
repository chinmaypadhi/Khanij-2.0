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

namespace MasterApi.Model.WeighBridge
{
    public interface IWeighBridgeProvider
    {
        MessageEF AddWeighBridgemaster(WeighBridgemaster objWeighBridgemaster);
        List<WeighBridgemaster> ViewWeighBridgemaster(WeighBridgemaster objWeighBridgemaster);
        WeighBridgemaster EditWeighBridgemaster(WeighBridgemaster objWeighBridgemaster);
        MessageEF DeleteWeighBridgemaster(WeighBridgemaster objWeighBridgemaster);
        MessageEF UpdateWeighBridgemaster(WeighBridgemaster objWeighBridgemaster);
        List<WeighBridgemaster> GetDistrictList(WeighBridgemaster objWeighBridgemaster);
    }
}
