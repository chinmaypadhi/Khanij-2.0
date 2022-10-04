// ***********************************************************************
//  Controller Name          : InspectionReportController
//  Desciption               : Add,Edit,Update,View,Delete Inspection Report Controller
//  Created By               : Lingaraj Dalai
//  Created On               : 01 March 2021
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Model.InspectionReport;
using GeologyEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class InspectionReportController : ControllerBase
    {
        /// <summary>
        /// Global variable declaration
        /// </summary>
        public IInspectionReportProvider _objIIInspectionReportProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIIInspectionReportProvider"></param>
        public InspectionReportController(IInspectionReportProvider objIIInspectionReportProvider)
        {
            _objIIInspectionReportProvider = objIIInspectionReportProvider;
        }
        #region Submit Inspection Report
        /// <summary>
        /// Post method to Add Inspection Report
        /// </summary>
        /// <param name="objInspectionReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(InspectionReportmaster objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.AddInspectionReportsmaster(objInspectionReportmaster);
        }
        /// <summary>
        /// Post method to View Inspection Report
        /// </summary>
        /// <param name="objInspectionReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<InspectionReportmaster>> ViewInspectionReportsmaster(InspectionReportmaster objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.ViewInspectionReportsmaster(objInspectionReportmaster);
        }
        /// <summary>
        /// Post method to Edit Inspection Report
        /// </summary>
        /// <param name="objInspectionReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<InspectionReportmaster> Edit(InspectionReportmaster objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.EditInspectionReportsmaster(objInspectionReportmaster);
        }
        /// <summary>
        /// Post method to Update Inspection Report
        /// </summary>
        /// <param name="objInspectionReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update(InspectionReportmaster objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.UpdateInspectionReportsmaster(objInspectionReportmaster);
        }
        /// <summary>
        /// Post method to Delete Inspection Report
        /// </summary>
        /// <param name="objInspectionReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Delete(InspectionReportmaster objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.DeleteInspectionReportsmaster(objInspectionReportmaster);
        }
        /// <summary>
        /// Post method to bind MPR code list details
        /// </summary>
        /// <param name="objInspectionReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<InspectionReportmaster>> GetMPRCodeList(InspectionReportmaster objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.GetMPRCodeList(objInspectionReportmaster);
        }
        /// <summary>
        /// Post method to Get Officer details
        /// </summary>
        /// <param name="objInspectionReportmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<InspectionReportmaster> GetOfficerNameAndDesignation(InspectionReportmaster objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.GetOfficerNameAndDesignation(objInspectionReportmaster);
        }

        [HttpPost]
        public async Task<MessageEF> AddGeologyNew(GeologyMainData objInspectionGeology)
        {
            return await _objIIInspectionReportProvider.AddGeologyNew(objInspectionGeology);
        }

        [HttpPost]
        public async Task<List<GeologyMainData>> GetDistrict(GeologyMainData objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.GetDistrict(objInspectionReportmaster);
        }
         [HttpPost]
        public async Task<List<GeologyMainData>> GetTahasil(GeologyMainData objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.GetTahasil(objInspectionReportmaster);
        }
        [HttpPost]
        public async Task<List<GeologyMainData>> GetVillage(GeologyMainData objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.GetVillage(objInspectionReportmaster);
        }
          [HttpPost]
        public async Task<List<GeologyMainData>> GetDesig(GeologyMainData objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.GetDesig(objInspectionReportmaster);
        }
        [HttpPost]
        public async Task<List<GeologyMainData>> GetVehicle(GeologyMainData objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.GetVehicle(objInspectionReportmaster);
        }

        [HttpPost]
        public async Task<SelectQueryMultiple> GetAllRecord(GeologyMainData objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.GetAllRecord(objInspectionReportmaster);
        }
        [HttpPost]
        public async Task<MessageEF> DeleteInspection(GeologyMainData objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.DeleteInspection(objInspectionReportmaster);
        }
        [HttpPost]
        public async Task<SelectQueryMultiple> SelectDataForUpdate(GeologyMainData objInspectionReportmaster)
        {
            return await _objIIInspectionReportProvider.SelectDataForUpdate(objInspectionReportmaster);
        }
        [HttpPost]
        public async Task<MessageEF> UpdateGeologyNew(GeologyMainData objInspectionGeology)
        {
            return await _objIIInspectionReportProvider.UpdateGeologyNew(objInspectionGeology);
        }

        #endregion
    }
}