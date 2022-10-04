// ***********************************************************************
//  Interface Name           : IChecklistModel
//  Description              : Add,View,Edit,Update,Delete Checklist Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using System.Collections.Generic;
using MasterEF;

namespace MasterApp.Areas.Master.Models.Checklist
{
    public interface IChecklistModel
    {
        /// <summary>
        /// Add Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        MessageEF Add(ChecklistMaster objChecklistMaster);
        /// <summary>
        /// Update Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        MessageEF Update(ChecklistMaster objChecklistMaster);
        /// <summary>
        /// Bind Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        List<ChecklistMaster> View(ChecklistMaster objChecklistMaster);
        /// <summary>
        /// Delete Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        MessageEF Delete(ChecklistMaster objChecklistMaster);
        /// <summary>
        /// Edit Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        ChecklistMaster Edit(ChecklistMaster objChecklistMaster);
        /// <summary>
        /// Bind Module List details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        List<ChecklistMaster> GetModuleList(ChecklistMaster moduleResult);
    }
}
