// ***********************************************************************
//  Interface Name           : IInspectionReportModel
//  Desciption               : Add,View,Edit,Update,Delete Inspection Report
//  Created By               : Lingaraj Dalai
//  Created On               : 01 March 2021
// ***********************************************************************
using GeologyEF;
using System.Collections.Generic;

namespace GeologyApp.Models.InspectionReport
{
    public interface IInspectionReportModel
    {
        #region Submit Inspection Report
        /// <summary>
        /// To Add the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        MessageEF Add(InspectionReportmaster objInspectionReportmaster);
        /// <summary>
        /// To Update the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        MessageEF Update(InspectionReportmaster objInspectionReportmaster);
        /// <summary>
        /// To View the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        List<InspectionReportmaster> View(InspectionReportmaster objInspectionReportmaster);
        /// <summary>
        /// To Delete the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        MessageEF Delete(InspectionReportmaster objInspectionReportmaster);
        /// <summary>
        /// To Edit the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        InspectionReportmaster Edit(InspectionReportmaster objInspectionReportmaster);
        /// <summary>
        /// To Get the MPR code list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        List<InspectionReportmaster> GetMPRCodeList(InspectionReportmaster mprcodeResult);
        /// <summary>
        /// To Get the Officer list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        InspectionReportmaster GetOfficerNameAndDesignation(InspectionReportmaster objInspectionReportmaster);
        MessageEF AddGeologyNew(GeologyMainData objGeologyMainData);
        List<GeologyMainData> GetDistrict(GeologyMainData objLabReportmaster);
        List<GeologyMainData> GetTahasil(GeologyMainData objLabReportmaster);
        List<GeologyMainData> GetDesig(GeologyMainData objLabReportmaster);
        List<GeologyMainData> GetVillage(GeologyMainData objLabReportmaster);
        List<GeologyMainData> GetVehicle(GeologyMainData objLabReportmaster);
        SelectQueryMultiple GetAllRecord(GeologyMainData objLabReportmaster);
        MessageEF DeleteInspection(GeologyMainData objGeologyMainData);
        SelectQueryMultiple SelectDataForUpdate(GeologyMainData objLabReportmaster);
        MessageEF UpdateGeologyNew(GeologyMainData objGeologyMainData);
        #endregion
    }
}
