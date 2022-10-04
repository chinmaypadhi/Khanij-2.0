// ***********************************************************************
//  Interface Name           : IModuleProvider
//  Description              : Add,View,Edit,Update,Delete Module Master details
//  Created By               : Praksh Chandra Biswal
//  Created On               : 26 Dec 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Module
{
    public interface IModuleProvider
    {
        /// <summary>
        /// To Add new Module Name 
        /// </summary>
        /// <param name="moduleMaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddModule(ModuleMasterModel moduleMasterModel);
        /// <summary>
        /// To View Module Details in View
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        Task<List<ModuleMasterModel>> ViewModule(ModuleMasterModel moduleMasterModel);
        /// <summary>
        /// To Edit Module Name
        /// </summary>
        /// <param name="ModuleMasterModel"></param>
        /// <returns></returns>
        Task<ModuleMasterModel> EditModule(ModuleMasterModel moduleMasterModel);
        /// <summary>
        /// To Update Module Name
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateModule(ModuleMasterModel moduleMasterModel);
        /// <summary>
        /// To Delete Module Name
        /// </summary>
        /// <param name="ModuleMasterModel"></param>
        /// <returns></returns>
        Task<MessageEF> DeleteModule(ModuleMasterModel ModuleMasterModel);
    }
}
