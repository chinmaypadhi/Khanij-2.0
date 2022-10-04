// ***********************************************************************
//  Interface Name           : ILabReportsModel
//  Desciption               : CRUD,Forward,Get Status,Get sample of Lab Reports
//  Created By               : Lingaraj Dalai
//  Created On               : 24 Feb 2021
// ***********************************************************************
using GeologyEF;
using System.Collections.Generic;

namespace GeologyApp.Models.LabReports
{
    public interface ILabReportsModel
    {
        #region Submit New Samples
        /// <summary>
        /// To Add the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        MessageEF Add(LabReportmaster objLabReportmaster);
        /// <summary>
        /// To Update the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        MessageEF Update(LabReportmaster objLabReportmaster);
        /// <summary>
        /// To View the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        List<LabReportmaster> View(LabReportmaster objLabReportmaster);
        /// <summary>
        /// To Delete the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        MessageEF Delete(LabReportmaster objLabReportmaster);
        /// <summary>
        /// To Edit the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        LabReportmaster Edit(LabReportmaster objLabReportmaster);
        /// <summary>
        /// To Forward the Lab Report master details data
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        MessageEF SendForForward(LabReportmaster objLabReportmaster);
        #region Bind dropdowns
        /// <summary>
        /// To bind MPR code list details in view
        /// </summary>
        /// <param name="mprcodeResult"></param>
        /// <returns></returns>
        List<LabReportmaster> GetMPRCodeList(LabReportmaster mprcodeResult);
        /// <summary>
        /// To bind Mineral list details in view
        /// </summary>
        /// <param name="mineralResult"></param>
        /// <returns></returns>
        List<LabReportmaster> GetMineralList(LabReportmaster mineralResult);
        /// <summary>
        /// To bind Division list details in view
        /// </summary>
        /// <param name="divisionResult"></param>
        /// <returns></returns>
        List<LabReportmaster> GetDivisionList(LabReportmaster divisionResult);
        /// <summary>
        /// To bind Regional Office list details in view
        /// </summary>
        /// <param name="regionalofficeResult"></param>
        /// <returns></returns>
        List<LabReportmaster> GetRegionalOfficeList(LabReportmaster regionalofficeResult);
        /// <summary>
        /// To Get Study Analysis details in view
        /// </summary>
        /// <param name="studyanalysisResult"></param>
        /// <returns></returns>
        List<LabReportmaster> GetTypeOfStudyAnalysis(LabReportmaster studyanalysisResult);
        #endregion
        /// <summary>
        /// To bind Officer details in view
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        LabReportmaster GetOfficerNameAndDesignation(LabReportmaster objLabReportmaster);
        #endregion
        #region Lab Report Forward
        /// <summary>
        /// To View the Lab Report details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        List<LabReportmaster> ViewLabReportForward(LabReportmaster objLabReportmaster);
        /// <summary>
        /// To Add the Lab Report details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        MessageEF SendForApproval(LabReportmaster objLabReportmaster);
        #endregion
        #region StatusofLabReport
        /// <summary>
        /// To View the Lab Report status Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        List<LabReportmaster> ViewStatusOfLabReport(LabReportmaster objLabReportmaster);
        /// <summary>
        /// To Upload result in Lab report
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        MessageEF UploadResult(LabReportmaster objLabReportmaster);
        #endregion
        #region GetAnalysedSamples
        /// <summary>
        /// To View the Analysed samples Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        List<LabReportmaster> ViewAnalysedSamples(LabReportmaster objLabReportmaster);
        /// <summary>
        /// To View the Files list Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        List<LabReportmaster> ViewFilesList(LabReportmaster objLabReportmaster);
        #endregion
    }
}
