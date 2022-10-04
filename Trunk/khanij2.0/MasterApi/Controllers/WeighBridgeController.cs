// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 21-Jan-2021
// ***********************************************************************
using System.Collections.Generic;
using MasterApi.Model.WeighBridge;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class WeighBridgeController : ControllerBase
    {
        /// <summary>
        /// Global Declartion
        /// </summary>
        public IWeighBridgeProvider _objIWeighBridgeProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objWeighBridgeProvider"></param>
        public WeighBridgeController(IWeighBridgeProvider objWeighBridgeProvider)
        {
            _objIWeighBridgeProvider = objWeighBridgeProvider;
        }
        /// <summary>
        /// To Add Weigh Bridge
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(WeighBridgemaster objWeighBridgemaster)
        {
            return _objIWeighBridgeProvider.AddWeighBridgemaster(objWeighBridgemaster);
        }
        /// <summary>
        /// To View Weigh Bridge
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<WeighBridgemaster> View(WeighBridgemaster objWeighBridgemaster)
        {
            return _objIWeighBridgeProvider.ViewWeighBridgemaster(objWeighBridgemaster);
        }
        /// <summary>
        /// To Edit Weigh Bridge
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public WeighBridgemaster Edit(WeighBridgemaster objWeighBridgemaster)
        {
            return _objIWeighBridgeProvider.EditWeighBridgemaster(objWeighBridgemaster);
        }
        /// <summary>
        /// To Delete Weigh Bridge
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(WeighBridgemaster objWeighBridgemaster)
        {
            return _objIWeighBridgeProvider.DeleteWeighBridgemaster(objWeighBridgemaster);
        }
        /// <summary>
        /// To Update Weigh Bridge
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(WeighBridgemaster objWeighBridgemaster)
        {
            return _objIWeighBridgeProvider.UpdateWeighBridgemaster(objWeighBridgemaster);
        }
        /// <summary>
        /// To Get District List
        /// </summary>
        /// <param name="objWeighBridgemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<WeighBridgemaster> GetDistrictList(WeighBridgemaster objWeighBridgemaster)
        {
            return _objIWeighBridgeProvider.GetDistrictList(objWeighBridgemaster);
        }
    }
}