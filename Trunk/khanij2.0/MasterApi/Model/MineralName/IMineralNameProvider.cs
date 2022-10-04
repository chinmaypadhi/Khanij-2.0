// ***********************************************************************
//  Interface Name           : IMineralNameProvider
//  Description              : Add,View,Edit,Update,Delete Mineral details
//  Created By               : Akshaya Dalei
//  Created On               : 18 March 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.MineralName
{
    public interface IMineralNameProvider : IDisposable, IRepository
    {
        /// <summary>
        /// Add Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        MessageEF AddMineralName(MineralModel mineralModel);
        /// <summary>
        /// View Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        List<MineralModel> ViewMineralName(MineralModel mineralModel);
        /// <summary>
        /// Edit Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        MineralModel EditMineralName(MineralModel mineralModel);
        /// <summary>
        /// Delete Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        MessageEF DeleteMineralName(MineralModel mineralModel);
        /// <summary>
        /// Update Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        MessageEF UpdateMineralName(MineralModel mineralModel);
    }
}
