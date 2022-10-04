// ***********************************************************************
//  Interface Name           : IMineralMapModel
//  Desciption               : View Mineral Map Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2022
// ***********************************************************************
using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.MineralMap
{
    public interface IMineralMapModel
    {
        /// <summary>
        /// View Mineral Map Count details in view
        /// </summary>
        /// <param name="objMineralMapModel"></param>
        /// <returns></returns>
        ViewMineralMapModel ViewMineralMapCount(ViewMineralMapModel objMineralMapModel);
        /// <summary>
        /// Bind District details in view
        /// </summary>
        /// <param name="objViewMineralMapModel"></param>
        /// <returns></returns>
        List<ViewMineralMapModel> View(ViewMineralMapModel objMineralMapModel);
    }
}
