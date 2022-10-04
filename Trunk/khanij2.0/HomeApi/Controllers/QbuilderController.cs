// ***********************************************************************
//  Controller Name          : QbuilderController
//  Desciption               : Query builder 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 Nov 2021
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.Model.Qbuilder;
using HomeEF;
using System.Data;

namespace HomeApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class QbuilderController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public IQbuilderProvider _objIQbuilderProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public QbuilderController(IQbuilderProvider objIQbuilderProvider)
        {
            _objIQbuilderProvider = objIQbuilderProvider;
        }
        /// <summary>
        /// Execute Query details in view
        /// </summary>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<MessageEF> ExecuteQuery(QuerybuilderModel objQuerybuilderModel)
        //{
        //    return await _objIQbuilderProvider.ExecuteQuery(objQuerybuilderModel);
        //}
        [HttpPost]
        public async Task<DataSet> ExecuteQuery(QuerybuilderModel objQuerybuilderModel)
        {
            return await _objIQbuilderProvider.ExecuteQuery(objQuerybuilderModel);
        }
        /// <summary>
        /// Fetch query details in view
        /// </summary>
        /// <param name="query"></param>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> FetchQuerydtls(string query, QuerybuilderModel objQuerybuilderModel)
        {
            return await _objIQbuilderProvider.FetchQuerydtls(query, objQuerybuilderModel);
        }
        /// <summary>
        /// Query insert statment details in view
        /// </summary>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> Queryinsert(QuerybuilderModel objQuerybuilderModel)
        {
            return await _objIQbuilderProvider.Queryinsert(objQuerybuilderModel);
        }
    }
}
