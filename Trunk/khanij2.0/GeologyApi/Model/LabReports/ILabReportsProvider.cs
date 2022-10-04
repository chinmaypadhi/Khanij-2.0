// ***********************************************************************
//  Interface Name           : ILabReportsProvider
//  Desciption               : CRUD,Forward,Get Status,Get sample of Lab Reports
//  Created By               : Lingaraj Dalai
//  Created On               : 24 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Repository;
using GeologyEF;

namespace GeologyApi.Model.LabReports
{
    public interface ILabReportsProvider:IDisposable, IRepository
    {
        #region Submit New Samples
        /// <summary>
        /// To Add the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddLabReportsmaster(LabReportmaster objLabReportsmaster);
        /// <summary>
        /// To View the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<List<LabReportmaster>> ViewLabReportsmaster(LabReportmaster objLabReportsmaster);
        /// <summary>
        /// To Edit the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<LabReportmaster> EditLabReportsmaster(LabReportmaster objLabReportsmaster);
        /// <summary>
        /// To Delete the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<MessageEF> DeleteLabReportsmaster(LabReportmaster objLabReportsmaster);
        /// <summary>
        /// To Update the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateLabReportsmaster(LabReportmaster objLabReportsmaster);
        /// <summary>
        /// To Forward the Lab Report master details data
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<MessageEF> SendForForward(LabReportmaster objLabReportsmaster);
        #region Dropdowns
        /// <summary>
        /// To Get the MPR code list Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<LabReportmaster>> GetMPRCodeList(LabReportmaster objFPOMaster);
        /// <summary>
        /// To Bind the Mineral list Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<LabReportmaster>> GetMineralList(LabReportmaster objFPOMaster);
        /// <summary>
        /// To Bind the Division list Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<LabReportmaster>> GetDivisionList(LabReportmaster objFPOMaster);
        /// <summary>
        /// To Bind the Regional office list Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<LabReportmaster>> GetRegionalOfficeList(LabReportmaster objFPOMaster);
        /// <summary>
        /// To Get the Study analysis Details Data in View
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<LabReportmaster>> GetTypeOfStudyAnalysis(LabReportmaster objFPOMaster);
        #endregion
        /// <summary>
        /// To get Office details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<LabReportmaster> GetOfficerNameAndDesignation(LabReportmaster objFPOMaster);
        #endregion
        #region Lab Report Forward
        /// <summary>
        /// To View the Lab Report details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<List<LabReportmaster>> ViewLabReportForward(LabReportmaster objLabReportsmaster);
        /// <summary>
        /// To Add the Lab Report details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<MessageEF> SendForApproval(LabReportmaster objLabReportsmaster);
        #endregion
        #region StatusofLabReport
        /// <summary>
        /// To View the Lab Report status Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<List<LabReportmaster>> ViewStatusOfLabReport(LabReportmaster objLabReportsmaster);
        /// <summary>
        /// To Upload result in Lab report
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<MessageEF> UploadResult(LabReportmaster objLabReportsmaster);
        #endregion
        #region GetAnalysedSamples
        /// <summary>
        /// To View the Analysed samples Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<List<LabReportmaster>> ViewAnalysedSamples(LabReportmaster objLabReportsmaster);
        /// <summary>
        /// To View the Files list Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        Task<List<LabReportmaster>> ViewFilesList(LabReportmaster objLabReportsmaster);
        #endregion
    }
}
