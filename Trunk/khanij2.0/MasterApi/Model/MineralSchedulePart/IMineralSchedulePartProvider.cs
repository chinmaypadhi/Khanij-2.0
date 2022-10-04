// ***********************************************************************
//  Interface Name           : IMineralSchedulePartProvider
//  Description              : Add,View,Edit,Update,Delete Mineral Schedule Part details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.MineralSchedulePart
{
    public interface IMineralSchedulePartProvider : IDisposable, IRepository
    {
        /// <summary>
        /// Add Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        MessageEF AddMineralSchedulePart(MineralSchedulePartModel mineralSchedulePartModel);
        /// <summary>
        /// View Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        List<MineralSchedulePartModel> ViewMineralSchedulePart(MineralSchedulePartModel mineralSchedulePartModel);
        /// <summary>
        /// Edit Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        MineralSchedulePartModel EditMineralSchedulePart(MineralSchedulePartModel mineralSchedulePartModel);
        /// <summary>
        /// Delete Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        MessageEF DeleteMineralSchedulePart(MineralSchedulePartModel mineralSchedulePartModel);
        /// <summary>
        /// Update Mineral Schedule Part details in view
        /// </summary>
        /// <param name="mineralSchedulePartModel"></param>
        /// <returns></returns>
        MessageEF UpdateMineralSchedulePart(MineralSchedulePartModel mineralSchedulePartModel);
    }
}
