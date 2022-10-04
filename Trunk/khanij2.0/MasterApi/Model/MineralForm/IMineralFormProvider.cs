// ***********************************************************************
//  Interface Name           : IMineralFormProvider
//  Description              : Add,View,Edit,Update,Delete Mineral Form details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.MineralForm
{
    public interface IMineralFormProvider : IDisposable, IRepository
    {
        /// <summary>
        /// Add Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        MessageEF AddMineralForm(MineralNatureModel mineralNatureModel);
        /// <summary>
        /// View Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        List<MineralNatureModel> ViewMineralForm(MineralNatureModel mineralNatureModel);
        /// <summary>
        /// Edit Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        MineralNatureModel EditMineralForm(MineralNatureModel mineralNatureModel);
        /// <summary>
        /// Delete Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        MessageEF DeleteMineralForm(MineralNatureModel mineralNatureModel);
        /// <summary>
        /// Update Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        MessageEF UpdateMineralForm(MineralNatureModel mineralNatureModel);
    }
}
