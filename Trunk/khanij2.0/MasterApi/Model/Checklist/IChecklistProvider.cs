// ***********************************************************************
//  Interface Name           : IChecklistProvider
//  Description              : Add,View,Edit,Update,Delete Checklist Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterApi.Model.Checklist
{
    public interface IChecklistProvider
    {
        /// <summary>
        /// Add Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddChecklistmaster(ChecklistMaster objChecklistMaster);
        /// <summary>
        /// View Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        Task<List<ChecklistMaster>> ViewChecklistMaster(ChecklistMaster objChecklistMaster);
        /// <summary>
        /// Edit Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        Task<ChecklistMaster> EditChecklistMaster(ChecklistMaster objChecklistMaster);
        /// <summary>
        /// Delete Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        Task<MessageEF> DeleteChecklistMaster(ChecklistMaster objChecklistMaster);
        /// <summary>
        /// Update Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateChecklistMaster(ChecklistMaster objChecklistMaster);
        /// <summary>
        /// Bind Module List Details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        Task<List<ChecklistMaster>> GetModuleList(ChecklistMaster objChecklistMaster);
    }
}
