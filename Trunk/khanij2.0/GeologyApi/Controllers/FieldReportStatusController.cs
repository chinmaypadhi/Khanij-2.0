// ***********************************************************************
//  Controller Name          : FieldReportStatusController
//  Desciption               : Add,Edit,Update,Delete Field Report
//  Created By               : Lingaraj Dalai
//  Created On               : 18 March 2021
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Model.FieldReportStatus;
using GeologyEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class FieldReportStatusController : ControllerBase
    {
        /// <summary>
        /// Global variable declaration
        /// </summary>
        public IFieldReportStatusProvider _objIIFieldReportStatusProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIIFieldReportStatusProvider"></param>
        public FieldReportStatusController(IFieldReportStatusProvider objIIFieldReportStatusProvider)
        {
            _objIIFieldReportStatusProvider = objIIFieldReportStatusProvider;
        }
        #region Field Report Status
        /// <summary>
        /// Post method to Add Field Report Status
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            return await _objIIFieldReportStatusProvider.AddFieldReportStatusMaster(objFieldReportStatusmaster);
        }
        /// <summary>
        /// Post method to View Field Report Status
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<FieldReportStatusmaster>> View(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            return await _objIIFieldReportStatusProvider.ViewFieldReportStatusMaster(objFieldReportStatusmaster);
        }
        /// <summary>
        /// Post method to Edit Field Report Status
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<FieldReportStatusmaster> Edit(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            return await _objIIFieldReportStatusProvider.EditFieldReportStatusMaster(objFieldReportStatusmaster);
        }
        /// <summary>
        /// Post method to Update Field Report Status
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            return await _objIIFieldReportStatusProvider.UpdateFieldReportStatusMaster(objFieldReportStatusmaster);
        }
        /// <summary>
        /// Post method to Delete Field Report Status
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Delete(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            return await _objIIFieldReportStatusProvider.DeleteFieldReportStatusMaster(objFieldReportStatusmaster);
        }
        /// <summary>
        /// To bind Regional Office list details in view
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<FieldReportStatusmaster>> GetRegionalOfficeList(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            return await _objIIFieldReportStatusProvider.GetRegionalOfficeList(objFieldReportStatusmaster);
        }
        /// <summary>
        /// Post method to Submit Field Report to Regional Office
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ForwardToRO(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            return await _objIIFieldReportStatusProvider.UpdateStatusOfReport_STOREGIONALOFFICE(objFieldReportStatusmaster);
        }
        /// <summary>
        /// To Fetch Email Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<FieldReportStatusmaster> ViewEmailDetails(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            return await _objIIFieldReportStatusProvider.ViewEmailDetails(objFieldReportStatusmaster);
        }
        #endregion
    }
}
