// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created on          : 21-Jan-2021
// ***********************************************************************
using System.Collections.Generic;
using MasterApi.Model.Policy;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class PolicyController : ControllerBase
    {
        public IPolicyProvider _objIPolicyProvider;
        public PolicyController(IPolicyProvider objPolicyProvider)
        {
            _objIPolicyProvider = objPolicyProvider;
        }
        /// <summary>
        /// To Add Policy Master
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(Policymaster objPolicymaster)
        {
            return _objIPolicyProvider.AddPolicymaster(objPolicymaster);
        }
        /// <summary>
        /// To View Policy Master
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Policymaster> View(Policymaster objPolicymaster)
        {
            return _objIPolicyProvider.ViewPolicymaster(objPolicymaster);
        }
        /// <summary>
        /// To Edit Policy Master
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public Policymaster Edit(Policymaster objPolicymaster)
        {
            return _objIPolicyProvider.EditPolicymaster(objPolicymaster);
        }
        /// <summary>
        /// To Delete Policy Master
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(Policymaster objPolicymaster)
        {
            return _objIPolicyProvider.DeletePolicymaster(objPolicymaster);
        }
        /// <summary>
        /// To Update Policy Master
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(Policymaster objPolicymaster)
        {
            return _objIPolicyProvider.UpdatePolicymaster(objPolicymaster);
        }
        /// <summary>
        /// To Get Policy Type List
        /// </summary>
        /// <param name="objPolicymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Policymaster> GetPolicyTypeList(Policymaster objPolicymaster)
        {
            return _objIPolicyProvider.GetPolicyTypeList(objPolicymaster);
        }
    }
}