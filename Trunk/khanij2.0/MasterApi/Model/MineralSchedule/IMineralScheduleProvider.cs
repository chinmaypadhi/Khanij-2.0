// ***********************************************************************
//  Interface Name           : IMineralScheduleProvider
//  Description              : Add,View,Edit,Update,Delete Mineral Schedule details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.MineralSchedule
{
    public interface IMineralScheduleProvider : IDisposable, IRepository
    {
        /// <summary>
        /// Add Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        MessageEF AddMineralSchedule(MineralScheduleModel mineralScheduleModel);
        /// <summary>
        /// View Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        List<MineralScheduleModel> ViewMineralSchedule(MineralScheduleModel mineralScheduleModel);
        /// <summary>
        /// Edit Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        MineralScheduleModel EditMineralSchedule(MineralScheduleModel mineralScheduleModel);
        /// <summary>
        /// Delete Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        MessageEF DeleteMineralSchedule(MineralScheduleModel mineralScheduleModel);
        /// <summary>
        /// Update Mineral Schedule details in view
        /// </summary>
        /// <param name="mineralScheduleModel"></param>
        /// <returns></returns>
        MessageEF UpdateMineralSchedule(MineralScheduleModel mineralScheduleModel);
    }
}
