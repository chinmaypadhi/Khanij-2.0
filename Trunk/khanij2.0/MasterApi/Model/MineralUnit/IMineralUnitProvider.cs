// ***********************************************************************
//  Interface Name           : IMineralUnitProvider
//  Description              : Add,View,Edit,Update,Delete Mineral Unit details
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Jan 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.MineralUnit
{
    public interface IMineralUnitProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        MessageEF AddMineralUnitMaster(MineralUnitmaster objPrioritymaster);
        /// <summary>
        /// View Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        List<MineralUnitmaster> ViewMineralUnitMaster(MineralUnitmaster objPrioritymaster);
        /// <summary>
        /// Edit Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        MineralUnitmaster EditMineralUnitMaster(MineralUnitmaster objPrioritymaster);
        /// <summary>
        /// Delete Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        MessageEF DeleteMineralUnitMaster(MineralUnitmaster objPrioritymaster);
        /// <summary>
        /// Update Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        MessageEF UpdateMineralUnitMaster(MineralUnitmaster objPrioritymaster);
        /// <summary>
        /// View Lessee Mineral Unit details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        List<MineralUnitmaster> ViewLesseeMineralUnitMaster(MineralUnitmaster objPrioritymaster);
    }
}
