// ***********************************************************************
//  Controller Name          : DepartmentController
//  Description              : Add,View,Edit,Update,Delete Department details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.Department;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        private readonly IDepartmentProvider departmentProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        #region Constructor
        public DepartmentController(IDepartmentProvider departmentProvider)
        {
            this.departmentProvider = departmentProvider;
        }
        #endregion
        /// <summary>
        /// Add Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        #region Add
        [HttpPost]
        public MessageEF Add(RoleTypeModel roleTypeModel)
        {
            return departmentProvider.AddDepartment(roleTypeModel);
        }
        #endregion
        /// <summary>
        /// View Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        #region View
        [HttpPost]
        public List<RoleTypeModel> ViewDetails(RoleTypeModel roleTypeModel)
        {
            return departmentProvider.ViewDepartment(roleTypeModel);
        }
        #endregion
        /// <summary>
        /// Edit Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        #region Edit
        [HttpPost]
        public RoleTypeModel Edit(RoleTypeModel roleTypeModel)
        {
            return departmentProvider.EditDepartment(roleTypeModel);
        }
        #endregion
        /// <summary>
        /// Delete Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        #region Delete 
        [HttpPost]
        public MessageEF Delete(RoleTypeModel roleTypeModel)
        {
            return departmentProvider.DeleteDepartment(roleTypeModel);
        }
        #endregion
        /// <summary>
        /// Update Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        #region Update
        [HttpPost]
        public MessageEF Update(RoleTypeModel roleTypeModel)
        {
            return departmentProvider.UpdateDespartment(roleTypeModel);
        }
        #endregion
    }
}