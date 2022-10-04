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

namespace MasterApp.Areas.Master.Models.Policy
{
    public interface IPolicyModel
    {
        MessageEF Add(Policymaster objPolicymaster);
        MessageEF Update(Policymaster objPolicymaster);
        List<Policymaster> View(Policymaster objPolicymaster);
        MessageEF Delete(Policymaster objPolicymaster);
        Policymaster Edit(Policymaster objPolicymaster);
        List<Policymaster> GetPolicyTypeList(Policymaster policytypeResult);
    }
}
