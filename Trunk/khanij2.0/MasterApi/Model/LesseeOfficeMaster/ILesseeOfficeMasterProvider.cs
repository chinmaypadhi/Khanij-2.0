// ***********************************************************************
//  Interface Name           : ILesseeOfficeMasterProvider
//  Description              : Lessee Office Master View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 13 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;

namespace MasterApi.Model.LesseeOfficeMaster
{
    public interface ILesseeOfficeMasterProvider
    {
        /// <summary>
        /// To bind Company/Association details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        Task<List<OfficeMasterViewModel>> GetAssociationListDetails(OfficeMasterViewModel objOfficemasterModel);
        /// <summary>
        /// To bind Office Master details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        OfficeMasterViewModel GetOfficeMasterDetails(OfficeMasterViewModel objOfficemasterModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Office details
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        MessageEF UpdateOfficeMasterDetails(OfficeMasterViewModel objOfficemasterModel);
        /// <summary>
        /// To bind Last approved Lessee Office Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeOfficeMasterCompareDetails(OfficeMasterViewModel objOfficemasterModel);
        /// <summary>
        /// To Approve Lesse Office details by DD
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeOfficeMasterDetails(OfficeMasterViewModel objOfficemasterModel);
        /// <summary>
        /// To Reject Lesse Office details by DD
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeOfficeMasterDetails(OfficeMasterViewModel objOfficemasterModel);
        /// <summary>
        /// To bind Lessee Category Log Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeCategoryLogDetails(OfficeMasterViewModel objOfficemasterModel);
        /// <summary>
        /// To bind Lessee Corporate Office Log Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeCorporateOfficeLogDetails(OfficeMasterViewModel objOfficemasterModel);
        /// <summary>
        /// To bind Lessee Branch Office Log Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeBranchOfficeLogDetails(OfficeMasterViewModel objOfficemasterModel);
        /// <summary>
        /// To bind Lessee Site Office Log Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeSiteOfficeLogDetails(OfficeMasterViewModel objOfficemasterModel);
        /// <summary>
        /// To bind Lessee Agent Office Log Details in view
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        List<OfficeMasterViewModel> GetLesseeAgentOfficeLogDetails(OfficeMasterViewModel objOfficemasterModel);
        /// <summary>
        /// To Delete Lesse Office Master details
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeOfficeMasterDetails(OfficeMasterViewModel objOfficemasterModel);
    }
}
