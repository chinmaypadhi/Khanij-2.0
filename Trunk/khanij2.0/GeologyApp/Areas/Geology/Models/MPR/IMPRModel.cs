// ***********************************************************************
//  Interface Name           : IMPRModel
//  Desciption               : CRUD,Create,Approve,Forward Monthly Progress Report
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2021
// ***********************************************************************
using GeologyEF;
using System.Collections.Generic;

namespace GeologyApp.Models.MPR
{
    public interface IMPRModel
    {
        #region MPR Creator
        /// <summary>
        /// To Add the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        MessageEF Add(MPRmaster objMPRmaster);
        /// <summary>
        /// To Update the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        MessageEF Update(MPRmaster objMPRmaster);
        /// <summary>
        /// To View the Monthly Progress Report list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        List<MPRmaster> View(MPRmaster objMPRmaster);
        /// <summary>
        /// To Delete the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        MessageEF Delete(MPRmaster objMPRmaster);
        /// <summary>
        /// To Edit the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        MPRmaster Edit(MPRmaster objMPRmaster);
        /// <summary>
        /// To Get the Officer details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        MPRmaster GetOfficerNameAndDesignation(MPRmaster objMPRmaster);
        /// <summary>
        /// To Get the Field Program Order details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        MPRmaster GetFPOdetailsByFPOCode(MPRmaster objMPRmaster);
        /// <summary>
        /// To send the data for approval
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        MessageEF SendForApproval(MPRmaster objMPRmaster);
        /// <summary>
        /// To Get the Mail details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        MPRmaster GetMaildata(MPRmaster objMPRmaster);
        /// <summary>
        /// To Preview the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        MPRmaster PreviewMPRMaster(MPRmaster objMPRmaster);
        #region Bind dropdowns
        /// <summary>
        /// To bind the Monthly Progress Report code list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        List<MPRmaster> GetMPRCodeList(MPRmaster objMPRMaster);
        /// <summary>
        /// To bind the Mineral list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        List<MPRmaster> GetMineralList(MPRmaster objMPRMaster);
        /// <summary>
        /// To bind the Division list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        List<MPRmaster> GetDivisionList(MPRmaster objMPRMaster);
        /// <summary>
        /// To bind the District list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        List<MPRmaster> GetDistrictList(MPRmaster objMPRMaster);
        /// <summary>
        /// To bind the Tehsil list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        List<MPRmaster> GetTehsilList(MPRmaster objMPRMaster);
        /// <summary>
        /// To bind the Village list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        List<MPRmaster> GetVillageList(MPRmaster objMPRMaster);
        /// <summary>
        /// To bind the Regional list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        List<MPRmaster> GetRegionalOfficeList(MPRmaster objMPRMaster);
        #endregion
        #endregion
        #region MPR Approver
        /// <summary>
        /// To bind the Monthly Progress Report approver list details data in view
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        List<MPRmaster> ViewMPRApprover(MPRmaster objMPRmaster);
        /// <summary>
        /// To Update the Monthly Progress Report status
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        MessageEF UpdateMPR_Status(MPRmaster objMPRmaster);
        /// <summary>
        /// To Update the Monthly Progress Report refer status
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        MessageEF UpdateMPR_Referback(MPRmaster objMPRmaster);
        #endregion
        #region MPR Forwarder
        /// <summary>
        /// To bind the Monthly Progress Report Forwarder list details data in view
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        List<MPRmaster> ViewMPRForwarder(MPRmaster objMPRmaster);
        /// <summary>
        /// To Forward the Monthly Progress Report Forwarder list details data to DGM
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        MessageEF FORWARD_TO_DGM(MPRmaster objMPRmaster);
        /// <summary>
        /// To Forward refer back the Monthly Progress Report Forwarder list details data to DGM
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        MessageEF FORWARDER_REFER_BACK(MPRmaster objMPRmaster);
        #endregion
        #region MPR Work
        /// <summary>
        /// To Add the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkmaster"></param>
        /// <returns></returns>
        MessageEF AddMPRWorkMaster(MPRWorkmaster objMPRWorkmaster);
        /// <summary>
        /// To View the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkmaster"></param>
        /// <returns></returns>
        List<MPRWorkmaster> ViewMPRWorkMaster(MPRWorkmaster objMPRWorkmaster);
        /// <summary>
        /// To Update the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkmaster"></param>
        /// <returns></returns>
        MessageEF UpdateMPRWorkMaster(MPRWorkmaster objMPRWorkmaster);
        /// <summary>
        /// To Delete the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkmaster"></param>
        /// <returns></returns>
        MessageEF DeleteMPRWorkMaster(MPRWorkmaster objMPRWorkmaster);
        /// <summary>
        /// To Edit the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkmaster"></param>
        /// <returns></returns>
        MPRWorkmaster EditMPRWorkMaster(MPRWorkmaster objMPRWorkmaster);
        #endregion
    }
}
