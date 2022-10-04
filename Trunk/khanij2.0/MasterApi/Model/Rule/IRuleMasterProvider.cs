// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 11-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Rule
{
   public interface IRuleMasterProvider: IDisposable, IRepository
    {
        MessageEF AddRuleMaster(RuleMaster objRulemaster);
        List<RuleMaster> ViewRuleMaster(RuleMaster objRulemaster);
        RuleMaster EditRulemaster(RuleMaster objRulemaster);
        MessageEF DeleteRulemaster(RuleMaster objRulemaster);
        MessageEF UpdateRulemaster(RuleMaster objRulemaster);
    }
}
