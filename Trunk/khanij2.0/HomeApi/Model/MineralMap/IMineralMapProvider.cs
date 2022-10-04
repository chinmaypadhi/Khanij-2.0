// ***********************************************************************
//  Interface Name           : IMineralMapProvider
//  Desciption               : View Mineral Map Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2022
// ***********************************************************************
using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Model.MineralMap
{
    public interface IMineralMapProvider
    {
        /// <summary>
        /// View Mineral Map Count details in view
        /// </summary>
        /// <param name="objMineralMapModel"></param>
        /// <returns></returns>
        Task<ViewMineralMapModel> ViewMineralMapCount(ViewMineralMapModel objMineralMapModel);
    }
}
