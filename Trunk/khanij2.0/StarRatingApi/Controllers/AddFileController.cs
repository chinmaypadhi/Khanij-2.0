// ***********************************************************************
//  Controller Name          : AddFileController
//  Desciption               : Upload Other Files to Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 19 April 2021
// ***********************************************************************
using System.Collections.Generic;
using StarRatingApi.Model.AddFile;
using StarratingEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace StarRatingApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class AddFileController : Controller
    {
        public IAddFileProvider _objIAddFileProvider;
        #region Add Additional File
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objIAddFileProvider"></param>
        public AddFileController(IAddFileProvider objIAddFileProvider)
        {
            _objIAddFileProvider = objIAddFileProvider;
        }
        /// <summary>
        /// POST method of AddFile
        /// </summary>
        /// <param name="objAddFilemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(AddFilemaster objAddFilemaster)
        {
            return _objIAddFileProvider.AddAdditionalFile(objAddFilemaster);
        }
        /// <summary>
        /// POST method of View
        /// </summary>
        /// <param name="objAddFilemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<AddFilemaster> View(AddFilemaster objAddFilemaster)
        {
            return _objIAddFileProvider.ViewAdditionalFile(objAddFilemaster);
        }
        #endregion
    }
}
