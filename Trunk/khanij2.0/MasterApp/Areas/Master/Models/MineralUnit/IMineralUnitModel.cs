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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.MineralUnit
{
    public interface IMineralUnitModel
    {
        MessageEF Add(MineralUnitmaster objMineralUnitMaster);
        MessageEF Update(MineralUnitmaster objMineralUnitMaster);
        List<MineralUnitmaster> View(MineralUnitmaster objMineralUnitMaster);
        MessageEF Delete(MineralUnitmaster objMineralUnitMaster);
        MineralUnitmaster Edit(MineralUnitmaster objMineralUnitMaster);
        List<MineralUnitmaster> ViewLesseeUnit(MineralUnitmaster objMineralUnitMaster);
    }
}
