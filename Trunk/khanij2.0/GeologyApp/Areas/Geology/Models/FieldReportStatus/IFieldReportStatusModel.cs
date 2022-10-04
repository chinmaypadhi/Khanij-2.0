// ***********************************************************************
//  Interface Name           : IFieldReportStatusModel
//  Desciption               : Field Report Status
//  Created By               : Lingaraj Dalai
//  Created On               : 19 March 2021
// ***********************************************************************
using GeologyEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GeologyApp.Areas.Geology.Models.FieldReportStatus
{
    public interface IFieldReportStatusModel
    {
        #region Field Report Status
        /// <summary>
        /// To Add Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        MessageEF Add(FieldReportStatusmaster objFieldReportStatusmaster);
        /// <summary>
        /// To Update Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        MessageEF Update(FieldReportStatusmaster objFieldReportStatusmaster);
        /// <summary>
        /// To View Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        List<FieldReportStatusmaster> View(FieldReportStatusmaster objFieldReportStatusmaster);
        /// <summary>
        /// To Delete Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        MessageEF Delete(FieldReportStatusmaster objFieldReportStatusmaster);
        /// <summary>
        /// To Edit Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        FieldReportStatusmaster Edit(FieldReportStatusmaster objFieldReportStatusmaster);
        /// <summary>
        /// To Bind the Regional Office Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        List<FieldReportStatusmaster> GetRegionalOfficeList(FieldReportStatusmaster objFieldReportStatusmaster);
        /// <summary>
        /// To Submit Field Report to Regional Office
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        MessageEF UpdateStatusOfReport_STOREGIONALOFFICE(FieldReportStatusmaster objFieldReportStatusmaster);
        /// <summary>
        /// To Fetch Email Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        FieldReportStatusmaster ViewEmailDetails(FieldReportStatusmaster objFieldReportStatusmaster);
        #endregion
    }
}
