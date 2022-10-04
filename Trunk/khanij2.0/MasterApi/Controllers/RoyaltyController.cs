using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.Royalty;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class RoyaltyController : ControllerBase
    {
        /// <summary>
        /// Global Declartion
        /// </summary>
        private readonly IRoyaltyProvider royaltyProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="royaltyProvider"></param>
        public RoyaltyController(IRoyaltyProvider royaltyProvider)
        {
            this.royaltyProvider = royaltyProvider;
        }

        #region Add
        /// <summary>
        /// To Add Royalty
        /// </summary>
        /// <param name="royaltyModel"></param>
        /// <returns></returns>
        public MessageEF Add(RoyaltyModel royaltyModel)
        {
            return royaltyProvider.AddRoyalty(royaltyModel);
        }
        #endregion

        #region View
        /// <summary>
        /// To View Royalty
        /// </summary>
        /// <param name="royaltyModel"></param>
        /// <returns></returns>
        public List<RoyaltyModel> ViewDetails(RoyaltyModel royaltyModel)
        {
            return royaltyProvider.ViewRoyalty(royaltyModel);
        }
        #endregion

        #region Delete
        /// <summary>
        /// To Delete Royalty
        /// </summary>
        /// <param name="royaltyModel"></param>
        /// <returns></returns>
        public MessageEF Delete(RoyaltyModel royaltyModel)
        {
            return royaltyProvider.DeleteRoyalty(royaltyModel);
        }
        #endregion

        #region Edit
        /// <summary>
        /// To Edit Royalty
        /// </summary>
        /// <param name="royaltyModel"></param>
        /// <returns></returns>
        public RoyaltyModel Edit(RoyaltyModel royaltyModel)
        {
            return royaltyProvider.EditRoyalty(royaltyModel);
        }
        #endregion

        #region Update
        /// <summary>
        /// To Update Royalty
        /// </summary>
        /// <param name="royaltyModel"></param>
        /// <returns></returns>
        public MessageEF Update(RoyaltyModel royaltyModel)
        {
            return royaltyProvider.UpdateRoyalty(royaltyModel);
        }
        #endregion
    }
}