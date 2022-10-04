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

namespace MasterApi.Model.Policy
{
    public interface IPolicyProvider
    {
        MessageEF AddPolicymaster(Policymaster objPolicymaster);
        List<Policymaster> ViewPolicymaster(Policymaster objPolicymaster);
        Policymaster EditPolicymaster(Policymaster objPolicymaster);
        MessageEF DeletePolicymaster(Policymaster objPolicymaster);
        MessageEF UpdatePolicymaster(Policymaster objPolicymaster);
        List<Policymaster> GetPolicyTypeList(Policymaster objPolicymaster);
    }
}
