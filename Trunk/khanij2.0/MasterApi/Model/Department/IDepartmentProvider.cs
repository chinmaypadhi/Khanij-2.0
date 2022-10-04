// ***********************************************************************
//  Interface Name           : IDepartmentProvider
//  Description              : Add,View,Edit,Update,Delete Department details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Department
{
   public interface IDepartmentProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        MessageEF AddDepartment(RoleTypeModel objRoleTypeModel);
        /// <summary>
        /// View Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        List<RoleTypeModel> ViewDepartment(RoleTypeModel roleTypeModel);
        /// <summary>
        /// Edit Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        RoleTypeModel EditDepartment(RoleTypeModel roleTypeModel);
        /// <summary>
        /// Delete Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        MessageEF DeleteDepartment(RoleTypeModel roleTypeModel);
        /// <summary>
        /// Update Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        MessageEF UpdateDespartment(RoleTypeModel roleTypeModel);
    }
}
