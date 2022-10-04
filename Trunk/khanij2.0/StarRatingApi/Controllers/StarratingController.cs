// ***********************************************************************
//  Controller Name          : StarratingController
//  Desciption               : Api Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 16 April 2021
// ***********************************************************************
using System.Collections.Generic;
using StarRatingApi.Model.Assessment;
using StarRatingApi.Model.Create;
using StarratingEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace StarRatingApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class StarratingController : ControllerBase
    {
        /// <summary>
        /// Variable declaration
        /// </summary>
        public IAssessmentProvider _objIAssessmentProvider;
        public ICreateProvider _objICreateProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objAssessmentProvider"></param>
        /// <param name="objICreateProvider"></param>
        public StarratingController(IAssessmentProvider objAssessmentProvider, ICreateProvider objICreateProvider)
        {
            _objIAssessmentProvider = objAssessmentProvider;
            _objICreateProvider = objICreateProvider;
        }
        /// <summary>
        /// Api for ViewAssessmentTemplate
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public AssessmentListmaster ViewAssessmentTemplate(AssessmentListmaster objAssessmentListmaster)
        {
            return _objIAssessmentProvider.ViewAssessmentTemplateListmaster(objAssessmentListmaster);
        }
        /// <summary>
        /// Bind Financial Year list
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<AssessmentListmaster> GetFYList(AssessmentListmaster objAssessmentListmaster)
        {
            return _objIAssessmentProvider.GetFYList(objAssessmentListmaster);
        }
        #region CreateLesseeAssessment
        /// <summary>
        /// Bind Mineral list
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SR_Assesment_Master> GetMineralList(SR_Assesment_Master objAllModelmaster)
        {
            return _objICreateProvider.GetMineralList(objAllModelmaster);
        }
        /// <summary>
        /// Bind Lease Area Type
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SR_Assesment_Master> GetLeaseAreaType(SR_Assesment_Master objAllModelmaster)
        {
            return _objICreateProvider.GetLeaseAreaType(objAllModelmaster);
        }
        /// <summary>
        /// Get Assessment count
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public AllModel GetAssessmentCount(AllModel objAllModelmaster)
        {
            return _objICreateProvider.GetAssessmentCount(objAllModelmaster);
        }
        /// <summary>
        /// Get User master details
        /// </summary>
        /// <param name="objUserLoginmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public UserLoginSession GetUserMaster(UserLoginSession objUserLoginmaster)
        {
            return _objICreateProvider.GetUserMaster(objUserLoginmaster);
        }
        /// <summary>
        /// Get Tehsil details
        /// </summary>
        /// <param name="objUserLoginmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public UserLoginSession GetTehsilVillage(UserLoginSession objUserLoginmaster)
        {
            return _objICreateProvider.GetTehsilVillage(objUserLoginmaster);
        }
        /// <summary>
        /// Get Mineral Id
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public SR_Assesment_Master GetMineralId(SR_Assesment_Master objAllModelmaster)
        {
            return _objICreateProvider.GetMineralId(objAllModelmaster);
        }
        /// <summary>
        /// Get Lease Period details
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public SR_Assesment_Master GetLeasePeriod(SR_Assesment_Master objAllModelmaster)
        {
            return _objICreateProvider.GetLeasePeriod(objAllModelmaster);
        }
        /// <summary>
        /// Get Approved Plan details
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public SR_Assesment_Master GetApprovedPlan(SR_Assesment_Master objAllModelmaster)
        {
            return _objICreateProvider.GetApprovedPlan(objAllModelmaster);
        }
        /// <summary>
        /// Get Environment Clearanace Validity details
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public SR_Assesment_Master GetEnvironmentClearanceValidity(SR_Assesment_Master objAllModelmaster)
        {
            return _objICreateProvider.GetEnvironmentClearanceValidity(objAllModelmaster);
        }
        /// <summary>
        /// Get Forest Clearanace details
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public SR_Assesment_Master GetForestClearanceValidityUpto(SR_Assesment_Master objAllModelmaster)
        {
            return _objICreateProvider.GetForestClearanceValidityUpto(objAllModelmaster);
        }
        /// <summary>
        /// Add method api
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(SR_Assesment_Master objAllModelmaster)
        {
            return _objICreateProvider.LesseeStarratingAssessment(objAllModelmaster);
        }
        /// <summary>
        /// File upload api api method
        /// </summary>
        /// <param name="objFilemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF FileUpload(SR_FileMaster objFilemaster)
        {
            return _objICreateProvider.FileUploadAssessment(objFilemaster);
        }
        /// <summary>
        /// Add Systamatic sustainable api method
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddSystSust(AllModel objAllModelmaster)
        {
            return _objICreateProvider.AddSystSust(objAllModelmaster);
        }
        /// <summary>
        /// Add Protection Environment api method
        /// </summary>
        /// <param name="objFilemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddPE(SR_FileMaster objFilemaster)
        {
            return _objICreateProvider.AddPE(objFilemaster);
        }
        /// <summary>
        /// Add Health Safety api method
        /// </summary>
        /// <param name="objFilemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddHS(SR_FileMaster objFilemaster)
        {
            return _objICreateProvider.AddHS(objFilemaster);
        }
        /// <summary>
        /// Get Statuatory Clearance api method
        /// </summary>
        /// <param name="objFilemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddSC(SR_FileMaster objFilemaster)
        {
            return _objICreateProvider.AddSC(objFilemaster);
        }
        /// <summary>
        /// Add more api method
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddMore(AllModel objAllModelmaster)
        {
            return _objICreateProvider.AddMore(objAllModelmaster);
        }
        #endregion
        #region EditLesseeAssessment
        /// <summary>
        /// Edit api of Starrating Assessment
        /// </summary>
        /// <param name="objAllModelmaster"></param>
        /// <returns></returns>
        [HttpPost]
        public SR_Assesment_Master Edit(SR_Assesment_Master objAllModelmaster)
        {
            return _objICreateProvider.EditLesseeStarratingAssessment(objAllModelmaster);
        }
        /// <summary>
        /// Edit Protection Environment Lessee api of Starrating Assessment
        /// </summary>
        /// <param name="objMapFile"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SR_Protection_Environment> EditLesseePE(SR_Protection_Environment objMapFile)
        {
            return _objICreateProvider.EditLesseePE(objMapFile);
        }
        /// <summary>
        /// Edit Systamatic Sustainable Lessee api of Starrating Assessment
        /// </summary>
        /// <param name="objMapFile"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SR_Systematic_Sustainable> EditLesseeSS(SR_Systematic_Sustainable objMapFile)
        {
            return _objICreateProvider.EditLesseeSS(objMapFile);
        }
        /// <summary>
        /// Edit Health Safety Lessee api of Starrating Assessment
        /// </summary>
        /// <param name="objMapFile"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SR_Health_Saftey> EditLesseeHS(SR_Health_Saftey objMapFile)
        {
            return _objICreateProvider.EditLesseeHS(objMapFile);
        }
        /// <summary>
        /// Edit Stuatory Compliance Lessee api of Starrating Assessment
        /// </summary>
        /// <param name="objMapFile"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SR_Statutory_Compliance> EditLesseeSC(SR_Statutory_Compliance objMapFile)
        {
            return _objICreateProvider.EditLesseeSC(objMapFile);
        }
        /// <summary>
        /// Edit other files Lessee api of Starrating Assessment
        /// </summary>
        /// <param name="objMapFile"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SR_Additional_MappFile> GetOtherFiles(SR_Additional_MappFile objMapFile)
        {
            return _objICreateProvider.GetOtherFiles(objMapFile);
        }
        /// <summary>
        /// Edit Info Files Lessee api of Starrating Assessment
        /// </summary>
        /// <param name="objFile"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SR_FileMaster> GetInfoFiles(SR_FileMaster objFile)
        {
            return _objICreateProvider.GetInfoFiles(objFile);
        }
        /// <summary>
        /// Edit Coordinate List Lessee api of Starrating Assessment
        /// </summary>
        /// <param name="objFile"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SR_Coordinate_Master> GetCoordinateList(SR_Coordinate_Master objFile)
        {
            return _objICreateProvider.GetCoordinateList(objFile);
        }
        /// <summary>
        /// Edit Lease Area Lessee api of Starrating Assessment
        /// </summary>
        /// <param name="objFile"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SR_Lease_Area_Master> GetLeaseAreaList(SR_Lease_Area_Master objFile)
        {
            return _objICreateProvider.GetLeaseAreaList(objFile);
        }
        /// <summary>
        /// Edit Lease Area Type Lessee api of Starrating Assessment
        /// </summary>
        /// <param name="objFile"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SR_Lease_Area_Mineral> GetLeaseTypeList(SR_Lease_Area_Mineral objFile)
        {
            return _objICreateProvider.GetLeaseTypeList(objFile);
        }
        #endregion
    }
}
