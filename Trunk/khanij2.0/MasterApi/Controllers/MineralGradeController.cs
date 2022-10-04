// ***********************************************************************
//  Controller Name          : MineralGradeController
//  Description              : Add,View,Edit,Update,Delete Mineral Grade details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.MineralGrade;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MineralGradeController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        private readonly IMineralGradeProvider mineralGradeProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="mineralGradeProvider"></param>
        #region Constructor
        public MineralGradeController(IMineralGradeProvider mineralGradeProvider)
        {
            this.mineralGradeProvider = mineralGradeProvider;
        }
        #endregion
        /// <summary>
        /// Add Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        #region Add
        [HttpPost]
        public MessageEF Add(MineralGradeModel mineralGradeModel)
        {
            return mineralGradeProvider.AddMineralGrade(mineralGradeModel);
        }
        #endregion
        /// <summary>
        /// View Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        #region View
        [HttpPost]
        public List<MineralGradeModel> ViewDetails(MineralGradeModel mineralGradeModel)
        {
            return mineralGradeProvider.ViewMineralGrade(mineralGradeModel);
        }


        #endregion
        /// <summary>
        /// Edit Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        #region Edit
        [HttpPost]
        public MineralGradeModel Edit(MineralGradeModel mineralGradeModel)
        {
            return mineralGradeProvider.EditMineralGrade(mineralGradeModel);
        }
        #endregion
        /// <summary>
        /// Delete Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        #region Delete
        [HttpPost]
        public MessageEF Delete(MineralGradeModel mineralGradeModel)
        {
            return mineralGradeProvider.DeleteMineralGrade(mineralGradeModel);
        }
        #endregion
        /// <summary>
        /// Update Mineral Grade details in view
        /// </summary>
        /// <param name="mineralGradeModel"></param>
        /// <returns></returns>
        #region Update
        [HttpPost]
        public MessageEF Update(MineralGradeModel mineralGradeModel)
        {
            return mineralGradeProvider.UpdateMineralGrade(mineralGradeModel);
        }
        #endregion
    }
}