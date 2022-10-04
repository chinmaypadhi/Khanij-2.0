// ***********************************************************************
//  Controller Name          : CheckPostController
//  Description              : Add,View,Edit,Update,Delete Checkpost details
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Jan 2021
// ***********************************************************************
using System.Collections.Generic;
using MasterApi.Model.Checkpost;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class CheckPostController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public ICheckPostProvider _objICheckpostProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        public CheckPostController(ICheckPostProvider objCheckpostProvider)
        {
            _objICheckpostProvider = objCheckpostProvider;
        }
        /// <summary>
        /// Add Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(Checkpostmaster objCheckPostmaster)
        {
            return _objICheckpostProvider.AddCheckPostmaster(objCheckPostmaster);
        }
        /// <summary>
        /// View Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Checkpostmaster> View(Checkpostmaster objCheckPostmaster)
        {
            return _objICheckpostProvider.ViewCheckPostmaster(objCheckPostmaster);
        }
        /// <summary>
        /// Edit Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public Checkpostmaster Edit(Checkpostmaster objCheckPostmaster)
        {
            return _objICheckpostProvider.EditCheckPostmaster(objCheckPostmaster);
        }
        /// <summary>
        /// Delete Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(Checkpostmaster objCheckPostmaster)
        {
            return _objICheckpostProvider.DeleteCheckPostmaster(objCheckPostmaster);
        }
        /// <summary>
        /// Update Checkpost details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(Checkpostmaster objCheckPostmaster)
        {
            return _objICheckpostProvider.UpdateCheckPostmaster(objCheckPostmaster);
        }
        /// <summary>
        /// Bind District List Details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Checkpostmaster> GetDistrictList(Checkpostmaster objCheckPostmaster)
        {
            return _objICheckpostProvider.GetDistrictList(objCheckPostmaster);
        }
        /// <summary>
        /// Bind User List details in view
        /// </summary>
        /// <param name="objCheckPostmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Checkpostmaster> GetUserList(Checkpostmaster objCheckPostmaster)
        {
            return _objICheckpostProvider.GetUserList(objCheckPostmaster);
        }
    }
}