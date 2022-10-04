// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 2-Feb-2021
// ***********************************************************************
using System.Collections.Generic;
using MasterApi.Model.RoyaltyMapping;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class RoyaltyMappingController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        public IRoyaltyMappingProvider _objIRoyaltyMappingProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objRoyaltyMappingProvider"></param>
        public RoyaltyMappingController(IRoyaltyMappingProvider objRoyaltyMappingProvider)
        {
            _objIRoyaltyMappingProvider = objRoyaltyMappingProvider;
        }
        /// <summary>
        /// To Add Royalty Mapping
        /// </summary>
        /// <param name="objRoyaltyMappingmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            return _objIRoyaltyMappingProvider.AddRoyaltyMappingmaster(objRoyaltyMappingmaster);
        }
        /// <summary>
        /// To View Royalty Mapping
        /// </summary>
        /// <param name="objRoyaltyMappingmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RoyaltyMappingmaster> View(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            return _objIRoyaltyMappingProvider.ViewRoyaltyMappingmaster(objRoyaltyMappingmaster);
        }
        /// <summary>
        /// To Edit Royalty Mapping
        /// </summary>
        /// <param name="objRoyaltyMappingmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public RoyaltyMappingmaster Edit(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            return _objIRoyaltyMappingProvider.EditRoyaltyMappingmaster(objRoyaltyMappingmaster);
        }
        /// <summary>
        /// To Delete Royalty Mapping
        /// </summary>
        /// <param name="objRoyaltyMappingmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            return _objIRoyaltyMappingProvider.DeleteRoyaltyMappingmaster(objRoyaltyMappingmaster);
        }
        [HttpPost]
        public List<RoyaltyMappingmaster> ViewPaymentType(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            return _objIRoyaltyMappingProvider.ViewPaymentType(objRoyaltyMappingmaster);
        }
        [HttpPost]
        public List<RoyaltyMappingmaster> ViewRoyaltyType(RoyaltyMappingmaster objRoyaltyMappingmaster)
        {
            return _objIRoyaltyMappingProvider.ViewRoyaltyType(objRoyaltyMappingmaster);
        }
    }
}