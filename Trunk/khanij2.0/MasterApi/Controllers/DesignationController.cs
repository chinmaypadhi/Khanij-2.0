// ***********************************************************************
//  Controller Name          : DesignationController
//  Description              : Add,View,Edit,Update,Delete Designation details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.Designation;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class DesignationController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        private readonly IDesignationProvider designationProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="designationProvider"></param>
        #region Constructor
        public DesignationController(IDesignationProvider designationProvider)
        {
            this.designationProvider = designationProvider;
        }
        #endregion
        /// <summary>
        /// Add Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        #region Add
        [HttpPost]
        public MessageEF Add(RoleListModel roleListModel)
        {
            return designationProvider.AddDesignation(roleListModel);
        }
        #endregion
        /// <summary>
        /// View Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        #region View
        [HttpPost]
        public List<RoleListModel> ViewDetails(RoleListModel roleListModel)
        {
            return designationProvider.ViewDesignation(roleListModel);
        }
        #endregion
        /// <summary>
        /// Edit Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        #region Edit
        [HttpPost]
        public RoleListModel Edit(RoleListModel roleListModel)
        {
            return designationProvider.EditDesignation(roleListModel);
        }
        #endregion
        /// <summary>
        /// Delete Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        #region Delete 
        [HttpPost]
        public MessageEF Delete(RoleListModel roleListModel)
        {
            return designationProvider.DeleteDesignation(roleListModel);
        }
        #endregion
        /// <summary>
        /// Update Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        #region Update
        [HttpPost]
        public MessageEF Update(RoleListModel roleListModel)
        {
            return designationProvider.UpdateDesignation(roleListModel);
        }
        #endregion
    }
}