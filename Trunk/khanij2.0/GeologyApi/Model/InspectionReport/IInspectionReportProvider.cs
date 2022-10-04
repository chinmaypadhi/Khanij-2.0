// ***********************************************************************
//  Interface Name           : IInspectionReportProvider
//  Desciption               : Add,View,Edit,Update,Delete Inspection Report
//  Created By               : Lingaraj Dalai
//  Created On               : 01 March 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Repository;
using GeologyEF;

namespace GeologyApi.Model.InspectionReport
{
    public interface IInspectionReportProvider: IDisposable, IRepository
    {
        #region Submit Inspection Report
        /// <summary>
        /// To Add the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddInspectionReportsmaster(InspectionReportmaster objInspectionReportsmaster);
        /// <summary>
        /// To View the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        Task<List<InspectionReportmaster>> ViewInspectionReportsmaster(InspectionReportmaster objInspectionReportsmaster);
        /// <summary>
        /// To Edit the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        Task<InspectionReportmaster> EditInspectionReportsmaster(InspectionReportmaster objInspectionReportsmaster);
        /// <summary>
        /// To Delete the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        Task<MessageEF> DeleteInspectionReportsmaster(InspectionReportmaster objInspectionReportsmaster);
        /// <summary>
        /// To Update the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateInspectionReportsmaster(InspectionReportmaster objInspectionReportsmaster);
        /// <summary>
        /// To Get the MPR code list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<InspectionReportmaster>> GetMPRCodeList(InspectionReportmaster objFPOMaster);
        /// <summary>
        /// To Get the Officer list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<InspectionReportmaster> GetOfficerNameAndDesignation(InspectionReportmaster objFPOMaster);
        Task<MessageEF> AddGeologyNew(GeologyMainData objInspectionReportmaster);
        Task<List<GeologyMainData>> GetDistrict(GeologyMainData objLabReportmaster);
        Task<List<GeologyMainData>> GetTahasil(GeologyMainData objLabReportmaster);
        Task<List<GeologyMainData>> GetVillage(GeologyMainData objLabReportmaster);
        Task<List<GeologyMainData>> GetDesig(GeologyMainData objLabReportmaster);
        Task<List<GeologyMainData>> GetVehicle(GeologyMainData objLabReportmaster);
        Task<SelectQueryMultiple> GetAllRecord(GeologyMainData objLabReportmaster);
        Task<MessageEF> DeleteInspection(GeologyMainData objInspectionReportmaster);
        Task<SelectQueryMultiple> SelectDataForUpdate(GeologyMainData objLabReportmaster);
        Task<MessageEF> UpdateGeologyNew(GeologyMainData objInspectionReportmaster);
        #endregion
    }
}
