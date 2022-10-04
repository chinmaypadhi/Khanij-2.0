// ***********************************************************************
//  Controller Name          : MineralController
//  Description              : Add,View,Edit,Update,Delete Mineral details
//  Created By               : Akshaya Dalei
//  Created On               : 18 March 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.Mineral;
using MasterApi.Model.MineralName;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MineralController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public IMineralProvider _objIMineralProvider;
        private readonly IMineralNameProvider mineralNameProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIMineralProvider"></param>
        /// <param name="mineralNameProvider"></param>
        public MineralController (IMineralProvider objIMineralProvider, IMineralNameProvider mineralNameProvider)
        {
            _objIMineralProvider = objIMineralProvider;
            this.mineralNameProvider = mineralNameProvider;
        }
        #region Mineral Category
        /// <summary>
        /// Add Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(MineralCategory objMineralCategory)
        {
            return _objIMineralProvider.AddMineral(objMineralCategory);
        }
        /// <summary>
        /// View Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        [HttpPost]
        public List<MineralCategory> View(MineralCategory objMineralCategory)
        {
            return _objIMineralProvider.ViewMineral(objMineralCategory);
        }
        /// <summary>
        /// Edit Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        [HttpPost]
        public MineralCategory Edit(MineralCategory objMineralCategory)
        {
            return _objIMineralProvider.EditMineral(objMineralCategory);
        }
        /// <summary>
        /// Delete Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(MineralCategory objMineralCategory)
        {
            return _objIMineralProvider.DeleteMineral(objMineralCategory);
        }
        /// <summary>
        /// Update Mineral Category Details in view
        /// </summary>
        /// <param name="objMineralCategory"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(MineralCategory objMineralCategory)
        {
            return _objIMineralProvider.UpdateMineral(objMineralCategory);
        }
        [HttpGet]
        public string test()
        {
            return "test";
        }
        #endregion

        #region Mineral
        #region Add
        /// <summary>
        /// Add Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddMineral(MineralModel mineralModel)
        {
            return mineralNameProvider.AddMineralName(mineralModel);
        }
        #endregion

        #region View
        /// <summary>
        /// View Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<MineralModel> ViewMineral(MineralModel mineralModel)
        {
            return mineralNameProvider.ViewMineralName(mineralModel);
        }
        #endregion

        #region Edit
        /// <summary>
        /// Edit Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MineralModel EditMineral(MineralModel mineralModel)
        {
            return mineralNameProvider.EditMineralName(mineralModel);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF DeleteMineral(MineralModel mineralModel)
        {
            return mineralNameProvider.DeleteMineralName(mineralModel);
        }
        #endregion
        #region Update
        /// <summary>
        /// Update Mineral Details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF UpdateMineral(MineralModel mineralModel)
        {
            return mineralNameProvider.UpdateMineralName(mineralModel);
        }
        #endregion
        #endregion

        #region Other Mineral
        /// <summary>
        /// Add Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddOtherMineral(OtherMineralsmaster objOtherMineral)
        {
            return _objIMineralProvider.AddOtherMineral(objOtherMineral);
        }
        /// <summary>
        /// View Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OtherMineralsmaster> ViewOtherMineral(OtherMineralsmaster objOtherMineral)
        {
            return _objIMineralProvider.ViewOtherMineral(objOtherMineral);
        }
        /// <summary>
        /// Edit Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        [HttpPost]
        public OtherMineralsmaster EditOtherMineral(OtherMineralsmaster objOtherMineral)
        {
            return _objIMineralProvider.EditOtherMineral(objOtherMineral);
        }
        /// <summary>
        /// Delee Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF DeleteOtherMineral(OtherMineralsmaster objOtherMineral)
        {
            return _objIMineralProvider.DeleteOtherMineral(objOtherMineral);
        }
        /// <summary>
        /// Update Other Mineral Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF UpdateOtherMineral(OtherMineralsmaster objOtherMineral)
        {
            return _objIMineralProvider.UpdateOtherMineral(objOtherMineral);
        }
        /// <summary>
        /// Get Other Mineral List Details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        [HttpPost]
        public List<OtherMineralsmaster> GetOtherMineralList(OtherMineralsmaster objOtherMineral)
        {
            return _objIMineralProvider.GetOtherMineralList(objOtherMineral);
        }
        /// <summary>
        /// Update Publish Status details in view
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF UpdatePublishStatus(OtherMineralsmaster objOtherMineral)
        {
            return _objIMineralProvider.UpdatePublishStatus(objOtherMineral);
        }
        /// <summary>
        /// Download Other Mineral Details in veiw
        /// </summary>
        /// <param name="objOtherMineral"></param>
        /// <returns></returns>
        [HttpPost]
        public OtherMineralsmaster Download_OtherMinerals(OtherMineralsmaster objOtherMineral)
        {
            return _objIMineralProvider.Download_OtherMinerals(objOtherMineral);
        }
        #endregion
    }
}