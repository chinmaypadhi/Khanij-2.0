// ***********************************************************************
//  Interface Name           : ILesseeOfficeMasterModel
//  Description              : Lessee Office Master View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 13 July 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.LesseeProfile.Models.OfficeDetails
{
    public interface ILesseeOfficeMasterModel
    {
        /// <summary>
        /// To bind Company/Association details in view
        /// </summary>
        /// <param name="officemasterlistResult"></param>
        /// <returns></returns>
        Task<List<OfficeMasterViewModel>> GetAssociationListDetails(OfficeMasterViewModel officemasterlistResult);
        /// <summary>
        /// To bind Company/Association details in view
        /// </summary>
        /// <param name="officemasterResult"></param>
        /// <returns></returns>
        OfficeMasterViewModel GetOfficeMasterDetails(OfficeMasterViewModel officemasterResult);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Office details
        /// </summary>
        /// <param name="officemasterResult"></param>
        /// <returns></returns>
        MessageEF UpdateOfficeMasterDetails(OfficeMasterViewModel officemasterResult);
        /// <summary>
        /// To bind Last approved Lessee Office Details in view
        /// </summary>
        /// <param name="officemasterResult"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeOfficeMasterCompareDetails(OfficeMasterViewModel officemasterResult);
        /// <summary>
        /// To Approve Lesse Office details by DD
        /// </summary>
        /// <param name="officemasterResult"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeOfficeMasterDetails(OfficeMasterViewModel officemasterResult);
        /// <summary>
        /// To Reject Lesse Office details by DD
        /// </summary>
        /// <param name="officemasterResult"></param>
        /// <returns></returns>
        MessageEF RejectLesseeOfficeMasterDetails(OfficeMasterViewModel officemasterResult);
        /// <summary>
        /// To bind Lessee Category Log Details in view
        /// </summary>
        /// <param name="officemasterResult"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeCategoryLogDetails(OfficeMasterViewModel officemasterResult);
        /// <summary>
        /// To bind Lessee Corporate Office Log Details in view
        /// </summary>
        /// <param name="officemasterResult"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeCorporateOfficeLogDetails(OfficeMasterViewModel officemasterResult);
        /// <summary>
        /// To bind Lessee Branch Office Log Details in view
        /// </summary>
        /// <param name="officemasterResult"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeBranchOfficeLogDetails(OfficeMasterViewModel officemasterResult);
        /// <summary>
        /// To bind Lessee Site Office Log Details in view
        /// </summary>
        /// <param name="officemasterResult"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeSiteOfficeLogDetails(OfficeMasterViewModel officemasterResult);
        /// <summary>
        /// To bind Lessee Agent Office Log Details in view
        /// </summary>
        /// <param name="officemasterResult"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeAgentOfficeLogDetails(OfficeMasterViewModel officemasterResult);
        /// <summary>
        /// To Delete Lesse Office Master details
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeOfficeMasterDetails(OfficeMasterViewModel officemasterResult);
    }
}
