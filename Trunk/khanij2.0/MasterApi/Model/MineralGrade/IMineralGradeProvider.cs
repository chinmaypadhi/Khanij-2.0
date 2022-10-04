// ***********************************************************************
//  Interface Name           : IMineralGradeProvider
//  Description              : Add,View,Edit,Update,Delete Mineral Grade details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.MineralGrade
{
    public interface IMineralGradeProvider : IDisposable, IRepository
    {
        /// <summary>
        /// Add Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        MessageEF AddMineralGrade(MineralGradeModel mineralGradeModel);
        /// <summary>
        /// View Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        List<MineralGradeModel> ViewMineralGrade(MineralGradeModel mineralGradeModel);
        /// <summary>
        /// Edit Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        MineralGradeModel EditMineralGrade(MineralGradeModel mineralGradeModel);
        /// <summary>
        /// Delete Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        MessageEF DeleteMineralGrade(MineralGradeModel mineralGradeModel);
        /// <summary>
        /// Update Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        MessageEF UpdateMineralGrade(MineralGradeModel mineralGradeModel); 
    }
}
