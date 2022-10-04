// ***********************************************************************
//  Controller Name          : MineralFormController
//  Description              : Add,View,Edit,Update,Delete Mineral Form details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.MineralForm;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MineralFormController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        private readonly IMineralFormProvider mineralFormProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="mineralFormProvider"></param>
        #region Constructor
        public MineralFormController(IMineralFormProvider mineralFormProvider)
        {
            this.mineralFormProvider = mineralFormProvider;
        }
        #endregion
        /// <summary>
        /// Add Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        #region Add
        [HttpPost]
        public MessageEF Add(MineralNatureModel mineralNatureModel)
        {
            return mineralFormProvider.AddMineralForm(mineralNatureModel);
        }
        #endregion
        /// <summary>
        /// View Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        #region View
        [HttpPost]
        public List<MineralNatureModel> ViewDetails(MineralNatureModel mineralNatureModel)
        {
            return mineralFormProvider.ViewMineralForm(mineralNatureModel);
        }
        #endregion
        /// <summary>
        /// Edit Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        #region Edit
        [HttpPost]
        public MineralNatureModel Edit(MineralNatureModel mineralNatureModel)
        {
            return mineralFormProvider.EditMineralForm(mineralNatureModel);
        }
        #endregion
        /// <summary>
        /// Delete Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        #region Delete 
        [HttpPost]
        public MessageEF Delete(MineralNatureModel mineralNatureModel)
        {
            return mineralFormProvider.DeleteMineralForm(mineralNatureModel);
        }
        #endregion
        /// <summary>
        /// Update Mineral Form details in view
        /// </summary>
        /// <param name="mineralNatureModel"></param>
        /// <returns></returns>
        #region Update
        [HttpPost]
        public MessageEF Update(MineralNatureModel mineralNatureModel)
        {
            return mineralFormProvider.UpdateMineralForm(mineralNatureModel);
        }
        #endregion
    }
}