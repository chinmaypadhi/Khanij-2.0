// ***********************************************************************
//  Interface Name           : ICreateProvider
//  Desciption               : Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 04 May 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using StarRatingApi.Repository;
using StarratingEF;

namespace StarRatingApi.Model.Create
{
    public interface ICreateProvider: IDisposable, IRepository
    {
        #region CreateLesseeAssessment
        /// <summary>
        /// To Bind the Mineral Details Data in View
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        List<SR_Assesment_Master> GetMineralList(SR_Assesment_Master SR_Assesment_Master);
        /// <summary>
        /// To Bind the Lease Area Type Details Data in View
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        List<SR_Assesment_Master> GetLeaseAreaType(SR_Assesment_Master objAllModelmaster);
        /// <summary>
        /// To Get the Assessment Count Data in View
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        AllModel GetAssessmentCount(AllModel objAllModelmaster);
        /// <summary>
        /// To Bind the User Details Data in View
        /// </summary>
        /// <param name="objUserLoginMaster"></param>
        /// <returns></returns>
        UserLoginSession GetUserMaster(UserLoginSession objUserLoginMaster);
        /// <summary>
        /// To Bind the Tehsil Details Data in View
        /// </summary>
        /// <param name="objUserLoginMaster"></param>
        /// <returns></returns>
        UserLoginSession GetTehsilVillage(UserLoginSession objUserLoginMaster);
        /// <summary>
        /// To Bind the Mineral Details Data in View
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        SR_Assesment_Master GetMineralId(SR_Assesment_Master objAllModelmaster);
        /// <summary>
        /// To Bind the Lease Period Details Data in View
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        SR_Assesment_Master GetLeasePeriod(SR_Assesment_Master objAllModelmaster);
        /// <summary>
        /// To Bind the Approved Plan Details Data in View
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        SR_Assesment_Master GetApprovedPlan(SR_Assesment_Master objAllModelmaster);
        /// <summary>
        /// To Bind the Environment Clearance Details Data in View
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        SR_Assesment_Master GetEnvironmentClearanceValidity(SR_Assesment_Master objAllModelmaster);
        /// <summary>
        /// To Bind the Forest Clearance Details Data in View
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        SR_Assesment_Master GetForestClearanceValidityUpto(SR_Assesment_Master objAllModelmaster);
        /// <summary>
        /// To Bind the Lessee Assessment Details Data in View
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        MessageEF LesseeStarratingAssessment(SR_Assesment_Master objAllModelmaster);
        /// <summary>
        /// File Upload Details Data in View
        /// </summary>
        /// <param name="objFilemaster"></param>
        /// <returns></returns>
        MessageEF FileUploadAssessment(SR_FileMaster objFilemaster);
        /// <summary>
        /// Module 1. Add Systamatic Sustainable
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <param name="Assessment_ID"></param>
        MessageEF AddSystSust(AllModel objAllModelmaster);
        /// <summary>
        /// Module 2. Add Coordinate,LeaseArea,LeaseType list
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        MessageEF AddMore(AllModel objAllModelmaster);
        /// <summary>
        /// Module 2. Add Protection Environment
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        MessageEF AddPE(SR_FileMaster objFilemaster);
        /// <summary>
        /// Module 3. Add Health Safety
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        MessageEF AddHS(SR_FileMaster objFilemaster);
        /// <summary>
        /// Module 1. Add Statuatory Compliance
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        MessageEF AddSC(SR_FileMaster objFilemaster);
        #endregion
        #region EditLesseeAssessment
        /// <summary>
        /// Edit Lessee Starrating Assessment
        /// </summary>
        /// <param name="objSRAM"></param>
        /// <returns></returns>
        SR_Assesment_Master EditLesseeStarratingAssessment(SR_Assesment_Master objSRAM);
        /// <summary>
        /// Module 1. Edit Systamatic Sustainable
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <param name="Assessment_ID"></param>
        List<SR_Systematic_Sustainable> EditLesseeSS(SR_Systematic_Sustainable objSS);
        /// <summary>
        /// Module 2. Edit Protection Environment
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        List<SR_Protection_Environment> EditLesseePE(SR_Protection_Environment objPE);
        /// <summary>
        /// Module 3. Edit Health Safety
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        List<SR_Health_Saftey> EditLesseeHS(SR_Health_Saftey objHS);
        /// <summary>
        /// Module 1. Edit Statuatory Compliance
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        List<SR_Statutory_Compliance> EditLesseeSC(SR_Statutory_Compliance objSC);
        /// <summary>
        /// Bind Other files info
        /// </summary>
        /// <param name="objMapFilemaster"></param>
        /// <returns></returns>
        List<SR_Additional_MappFile> GetOtherFiles(SR_Additional_MappFile objMapFile);
        /// <summary>
        /// Bind Info files details
        /// </summary>
        /// <param name="objMapFilemaster"></param>
        /// <returns></returns>
        List<SR_FileMaster> GetInfoFiles(SR_FileMaster objFile);
        /// <summary>
        /// Bind Coordinate list details
        /// </summary>
        /// <param name="objMapFilemaster"></param>
        /// <returns></returns>
        List<SR_Coordinate_Master> GetCoordinateList(SR_Coordinate_Master objFile);
        /// <summary>
        /// Bind Lease Area list details
        /// </summary>
        /// <param name="objMapFilemaster"></param>
        /// <returns></returns>
        List<SR_Lease_Area_Master> GetLeaseAreaList(SR_Lease_Area_Master objFile);
        /// <summary>
        /// Bind Lease Type list details
        /// </summary>
        /// <param name="objMapFilemaster"></param>
        /// <returns></returns>
        List<SR_Lease_Area_Mineral> GetLeaseTypeList(SR_Lease_Area_Mineral objFile);
        #endregion
    }
}
