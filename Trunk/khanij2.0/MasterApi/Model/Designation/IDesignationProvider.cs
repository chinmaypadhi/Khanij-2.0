// ***********************************************************************
//  Interface Name           : IDesignationProvider
//  Description              : Add,View,Edit,Update,Delete Designation details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Designation
{
    public interface IDesignationProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        MessageEF AddDesignation(RoleListModel roleListModel);
        /// <summary>
        /// View Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        List<RoleListModel> ViewDesignation(RoleListModel roleListModel);
        /// <summary>
        /// Edit Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        RoleListModel EditDesignation(RoleListModel roleListModel);
        /// <summary>
        /// Delete Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        MessageEF DeleteDesignation(RoleListModel roleListModel);
        /// <summary>
        /// Update Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        MessageEF UpdateDesignation(RoleListModel roleListModel); 
    }
}
