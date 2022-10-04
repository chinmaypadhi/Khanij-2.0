// ***********************************************************************
//  Interface Name           : IModule
//  Description              : Add,View,Edit,Update,Delete Module Master details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 27 Dec 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Module
{
    public interface IModuleModel
    {
        /// <summary>
        /// To Add Module Name
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        MessageEF Add(ModuleMasterModel moduleMasterModel);
        /// <summary>
        /// To Update Module Name
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        MessageEF Update(ModuleMasterModel moduleMasterModel);
        /// <summary>
        /// To View Module Names
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        List<ModuleMasterModel> View(ModuleMasterModel moduleMasterModel);
        /// <summary>
        /// To Delete Module Name
        /// </summary>
        /// <param name="ModuleMasterModel"></param>
        /// <returns></returns>
        MessageEF Delete(ModuleMasterModel ModuleMasterModel);
        /// <summary>
        /// To Edit Module Name
        /// </summary>
        /// <param name="ModuleMasterModel"></param>
        /// <returns></returns>
        ModuleMasterModel Edit(ModuleMasterModel ModuleMasterModel);
    }
}
