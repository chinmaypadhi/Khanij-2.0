using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.Village;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class VillageController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        private readonly IVillageProvider villageProvider;
       /// <summary>
       /// Constructor Declaration
       /// </summary>
       /// <param name="villageProvider"></param>
        public VillageController(IVillageProvider villageProvider)
        {
            this.villageProvider = villageProvider;
        }

        #region Add
        /// <summary>
        /// To Add Village
        /// </summary>
        /// <param name="villageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(VillageModel villageModel)
        {
            return villageProvider.AddVillage(villageModel);
        }
        #endregion

        #region View
        /// <summary>
        /// 
        /// </summary>
        /// <param name="villageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<VillageModel> ViewDetails(VillageModel villageModel)
        {
            return villageProvider.ViewVillage(villageModel);
        }
        #endregion

        #region Edit
        /// <summary>
        /// To Edit Village
        /// </summary>
        /// <param name="villageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public VillageModel Edit(VillageModel villageModel)
        {
            return villageProvider.EditVillage(villageModel);
        }
        #endregion

        #region Delete
        /// <summary>
        /// To Delete Village
        /// </summary>
        /// <param name="villageModel"></param>
        /// <returns></returns>
       [HttpPost]
        public MessageEF Delete(VillageModel villageModel)
        {
            return villageProvider.DeleteVillage(villageModel);
        }
        #endregion

        #region Update
        /// <summary>
        /// To Update Village
        /// </summary>
        /// <param name="villageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(VillageModel villageModel)
        {
            return villageProvider.UpdateVillage(villageModel);
        }
        #endregion
    }
}