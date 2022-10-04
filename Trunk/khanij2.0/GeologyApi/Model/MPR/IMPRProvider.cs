// ***********************************************************************
//  Interface Name           : IMPRProvider
//  Desciption               : CRUD,Create,Approve,Forward Monthly Progress Report
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Repository;
using GeologyEF;

namespace GeologyApi.Model.MPR
{
    public interface IMPRProvider: IDisposable, IRepository
    {
        #region MPR Creator
        /// <summary>
        /// To Add the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddMPRMaster(MPRmaster objFPOMaster);
        /// <summary>
        /// To View the Monthly Progress Report list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<MPRmaster>> ViewMPRMaster(MPRmaster objFPOMaster);
        /// <summary>
        /// To Edit the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MPRmaster> EditMPRMaster(MPRmaster objFPOMaster);
        /// <summary>
        /// To Delete the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> DeleteMPRMaster(MPRmaster objFPOMaster);
        /// <summary>
        /// To Update the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateMPRMaster(MPRmaster objFPOMaster);
        #region Dropdowns
        /// <summary>
        /// To bind the Monthly Progress Report code list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<MPRmaster>> GetMPRCodeList(MPRmaster objFPOMaster);
        /// <summary>
        /// To bind the Mineral list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<MPRmaster>> GetMineralList(MPRmaster objFPOMaster);
        /// <summary>
        /// To bind the Division list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<MPRmaster>> GetDivisionList(MPRmaster objFPOMaster);
        /// <summary>
        /// To bind the District list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<MPRmaster>> GetDistrictList(MPRmaster objFPOMaster);
        /// <summary>
        /// To bind the Tehsil list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<MPRmaster>> GetTehsilList(MPRmaster objFPOMaster);
        /// <summary>
        /// To bind the Village list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<MPRmaster>> GetVillageList(MPRmaster objFPOMaster);
        /// <summary>
        /// To bind the Regional list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<MPRmaster>> GetRegionalOfficeList(MPRmaster objFPOMaster);
        #endregion
        /// <summary>
        /// To Get the Officer details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MPRmaster> GetOfficerNameAndDesignation(MPRmaster objFPOMaster);
        /// <summary>
        /// To Get the Field Program Order details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MPRmaster> GetFPOdetailsByFPOCode(MPRmaster objFPOMaster);
        /// <summary>
        /// To send the data for approval
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> SendForApproval(MPRmaster objFPOMaster);
        /// <summary>
        /// To Get the Mail details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MPRmaster> GetMaildata(MPRmaster objFPOMaster);
        /// <summary>
        /// To Preview the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MPRmaster> PreviewMPRMaster(MPRmaster objFPOMaster);
        #endregion
        #region MPR Approver
        /// <summary>
        /// To bind the Monthly Progress Report approver list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<MPRmaster>> ViewMPRApprover(MPRmaster objFPOMaster);
        /// <summary>
        /// To Update the Monthly Progress Report status
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateMPR_Status(MPRmaster objFPOMaster);
        /// <summary>
        /// To Update the Monthly Progress Report refer status
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateMPR_Referback(MPRmaster objFPOMaster);
        #endregion
        #region MPR Forwarder
        /// <summary>
        /// To bind the Monthly Progress Report Forwarder list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<List<MPRmaster>> ViewMPRForwarder(MPRmaster objFPOMaster);
        /// <summary>
        /// To Forward the Monthly Progress Report Forwarder list details data to DGM
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> FORWARD_TO_DGM(MPRmaster objFPOMaster);
        /// <summary>
        /// To Forward refer back the Monthly Progress Report Forwarder list details data to DGM
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        Task<MessageEF> FORWARDER_REFER_BACK(MPRmaster objFPOMaster);
        #endregion
        #region MPR Work
        /// <summary>
        /// To Add the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddMPRWorkMaster(MPRWorkmaster objMPRWorkMaster);
        /// <summary>
        /// To View the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        Task<List<MPRWorkmaster>> ViewMPRWorkMaster(MPRWorkmaster objMPRWorkMaster);
        /// <summary>
        /// To Edit the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        Task<MPRWorkmaster> EditMPRWorkMaster(MPRWorkmaster objMPRWorkMaster);
        /// <summary>
        /// To Delete the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        Task<MessageEF> DeleteMPRWorkMaster(MPRWorkmaster objMPRWorkMaster);
        /// <summary>
        /// To Update the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkMaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateMPRWorkMaster(MPRWorkmaster objMPRWorkMaster);
        #endregion
    }
}
