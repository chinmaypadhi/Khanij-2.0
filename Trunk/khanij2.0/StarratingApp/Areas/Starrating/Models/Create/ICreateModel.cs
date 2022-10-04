// ***********************************************************************
//  Interface Name           : ICreateModel
//  Desciption               : Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 04 May 2021
// ***********************************************************************
using StarratingEF;
using System.Collections.Generic;

namespace StarratingApp.Areas.Starrating.Models.Create
{
    public interface ICreateModel
    {
        #region CreateLesseeAssessment
        List<SR_Assesment_Master> GetMineralList(SR_Assesment_Master mineralResult);
        List<SR_Assesment_Master> GetLeaseAreaType(SR_Assesment_Master mineralResult);
        AllModel GetAssessmentCount(AllModel mineralResult);
        UserLoginSession GetUserMaster(UserLoginSession userLoginResult);
        UserLoginSession GetTehsilVillage(UserLoginSession userLoginResult);
        SR_Assesment_Master GetMineralId(SR_Assesment_Master mineralResult);
        SR_Assesment_Master GetLeasePeriod(SR_Assesment_Master mineralResult);
        SR_Assesment_Master GetApprovedPlan(SR_Assesment_Master mineralResult);
        SR_Assesment_Master GetEnvironmentClearanceValidity(SR_Assesment_Master mineralResult);
        SR_Assesment_Master GetForestClearanceValidityUpto(SR_Assesment_Master mineralResult);
        MessageEF Add(SR_Assesment_Master mineralResult);
        MessageEF FileUpload(SR_FileMaster fileUpload);
        MessageEF AddSystSust(AllModel objAllModelmaster);
        MessageEF AddPE(SR_FileMaster fileUpload);
        MessageEF AddHS(SR_FileMaster fileUpload);
        MessageEF AddSC(SR_FileMaster fileUpload);
        MessageEF AddMore(AllModel objAllModelmaster);
        #endregion
        #region EditLesseeAssessment
        SR_Assesment_Master Edit(SR_Assesment_Master objSRAM);
        List<SR_Systematic_Sustainable> EditSS(SR_Systematic_Sustainable objSRSS);
        List<SR_Protection_Environment> EditPE(SR_Protection_Environment objSRPE);
        List<SR_Health_Saftey> EditHS(SR_Health_Saftey objSRHS);
        List<SR_Statutory_Compliance> EditSC(SR_Statutory_Compliance objSRSC);
        List<SR_Additional_MappFile> GetOtherFiles(SR_Additional_MappFile otherfileResult);
        List<SR_FileMaster> GetInfoFiles(SR_FileMaster fileResult);
        List<SR_Coordinate_Master> GetCoordinateList(SR_Coordinate_Master objCoordinate);
        List<SR_Lease_Area_Master> GetLeaseAreaList(SR_Lease_Area_Master objLeaseArea);
        List<SR_Lease_Area_Mineral> GetLeaseTypeList(SR_Lease_Area_Mineral objLeaseType);
        #endregion
    }
}
