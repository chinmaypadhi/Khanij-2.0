// ***********************************************************************
//  Interface Name           : IFieldReportStatusProvider
//  Desciption               : Add,View,Edit,Update,Delete Field Report Status
//  Created By               : Lingaraj Dalai
//  Created On               : 18 March 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Repository;
using GeologyEF;

namespace GeologyApi.Model.FieldReportStatus
{
    public interface IFieldReportStatusProvider: IDisposable, IRepository
    {
        #region Field Report Status
        /// <summary>
        /// To Add Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddFieldReportStatusMaster(FieldReportStatusmaster objFieldReportStatusMaster);
        /// <summary>
        /// To View Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        Task<List<FieldReportStatusmaster>> ViewFieldReportStatusMaster(FieldReportStatusmaster objFieldReportStatusMaster);
        /// <summary>
        /// To Edit Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        Task<FieldReportStatusmaster> EditFieldReportStatusMaster(FieldReportStatusmaster objFieldReportStatusMaster);
        /// <summary>
        /// To Delete Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        Task<MessageEF> DeleteFieldReportStatusMaster(FieldReportStatusmaster objFieldReportStatusMaster);
        /// <summary>
        /// To Update Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateFieldReportStatusMaster(FieldReportStatusmaster objFieldReportStatusMaster);
        /// <summary>
        /// To Bind the Regional Office Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        Task<List<FieldReportStatusmaster>> GetRegionalOfficeList(FieldReportStatusmaster objFieldReportStatusMaster);
        /// <summary>
        /// To Submit Field Report to Regional Office
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateStatusOfReport_STOREGIONALOFFICE(FieldReportStatusmaster objFieldReportStatusMaster);
        /// <summary>
        /// To Fetch Email Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusMaster"></param>
        /// <returns></returns>
        Task<FieldReportStatusmaster> ViewEmailDetails(FieldReportStatusmaster objFieldReportStatusMaster);
        #endregion
    }
}
