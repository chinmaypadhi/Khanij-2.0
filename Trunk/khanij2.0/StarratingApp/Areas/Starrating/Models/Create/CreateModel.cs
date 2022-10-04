// ***********************************************************************
//  Class Name               : CreateModel
//  Desciption               : Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 04 May 2021
// ***********************************************************************
using StarratingEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using StarratingApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace StarratingApp.Areas.Starrating.Models.Create
{
    public class CreateModel:ICreateModel
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public CreateModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region CreateLesseeAssessment
        public List<SR_Assesment_Master> GetMineralList(SR_Assesment_Master objAllModelmaster)
        {
            try
            {
                List<SR_Assesment_Master> objlistMineral = new List<SR_Assesment_Master>();
                objlistMineral = JsonConvert.DeserializeObject<List<SR_Assesment_Master>>(_objIHttpWebClients.PostRequest("Starrating/GetMineralList", JsonConvert.SerializeObject(objAllModelmaster)));
                return objlistMineral;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SR_Assesment_Master> GetLeaseAreaType(SR_Assesment_Master objAllModelmaster)
        {
            try
            {
                List<SR_Assesment_Master> objlistMineral = new List<SR_Assesment_Master>();
                objlistMineral = JsonConvert.DeserializeObject<List<SR_Assesment_Master>>(_objIHttpWebClients.PostRequest("Starrating/GetLeaseAreaType",JsonConvert.SerializeObject(objAllModelmaster)));
                return objlistMineral;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AllModel GetAssessmentCount(AllModel objAllModelmaster)
        {
            try
            {
                AllModel objlistMineral = new AllModel();
                objlistMineral = JsonConvert.DeserializeObject<AllModel>(_objIHttpWebClients.PostRequest("Starrating/GetAssessmentCount",JsonConvert.SerializeObject(objAllModelmaster)));
                return objlistMineral;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserLoginSession GetUserMaster(UserLoginSession objUserLoginMaster)
        {
            try
            {
                UserLoginSession objlistuser = new UserLoginSession();
                objlistuser = JsonConvert.DeserializeObject<UserLoginSession>(_objIHttpWebClients.PostRequest("Starrating/GetUserMaster", JsonConvert.SerializeObject(objUserLoginMaster)));
                return objlistuser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserLoginSession GetTehsilVillage(UserLoginSession objUserLoginMaster)
        {
            try
            {
                UserLoginSession objTehsilVillage = new UserLoginSession();
                objTehsilVillage = JsonConvert.DeserializeObject<UserLoginSession>(_objIHttpWebClients.PostRequest("Starrating/GetTehsilVillage", JsonConvert.SerializeObject(objUserLoginMaster)));
                return objTehsilVillage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SR_Assesment_Master GetMineralId(SR_Assesment_Master objAllModelmaster)
        {
            try
            {
                SR_Assesment_Master objlistMineral = new SR_Assesment_Master();
                objlistMineral = JsonConvert.DeserializeObject<SR_Assesment_Master>(_objIHttpWebClients.PostRequest("Starrating/GetMineralId",JsonConvert.SerializeObject(objAllModelmaster)));
                return objlistMineral;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SR_Assesment_Master GetLeasePeriod(SR_Assesment_Master objAllModelmaster)
        {
            try
            {
                SR_Assesment_Master objlistMineral = new SR_Assesment_Master();
                objlistMineral = JsonConvert.DeserializeObject<SR_Assesment_Master>(_objIHttpWebClients.PostRequest("Starrating/GetLeasePeriod",JsonConvert.SerializeObject(objAllModelmaster)));
                return objlistMineral;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SR_Assesment_Master GetApprovedPlan(SR_Assesment_Master objAllModelmaster)
        {
            try
            {
                SR_Assesment_Master objlistMineral = new SR_Assesment_Master();
                objlistMineral = JsonConvert.DeserializeObject<SR_Assesment_Master>(_objIHttpWebClients.PostRequest("Starrating/GetApprovedPlan",JsonConvert.SerializeObject(objAllModelmaster)));
                return objlistMineral;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SR_Assesment_Master GetEnvironmentClearanceValidity(SR_Assesment_Master objAllModelmaster)
        {
            try
            {
                SR_Assesment_Master objlistMineral = new SR_Assesment_Master();
                objlistMineral = JsonConvert.DeserializeObject<SR_Assesment_Master>(_objIHttpWebClients.PostRequest("Starrating/GetEnvironmentClearanceValidity",JsonConvert.SerializeObject(objAllModelmaster)));
                return objlistMineral;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SR_Assesment_Master GetForestClearanceValidityUpto(SR_Assesment_Master objAllModelmaster)
        {
            try
            {
                SR_Assesment_Master objlistMineral = new SR_Assesment_Master();
                objlistMineral = JsonConvert.DeserializeObject<SR_Assesment_Master>(_objIHttpWebClients.PostRequest("Starrating/GetForestClearanceValidityUpto",JsonConvert.SerializeObject(objAllModelmaster)));
                return objlistMineral;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF Add(SR_Assesment_Master objAllModelmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("Starrating/Add",JsonConvert.SerializeObject(objAllModelmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF FileUpload(SR_FileMaster objfileUpload)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Starrating/FileUpload", JsonConvert.SerializeObject(objfileUpload)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF AddSystSust(AllModel objAllModelmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("Starrating/AddSystSust",JsonConvert.SerializeObject(objAllModelmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF AddPE(SR_FileMaster objAllModelmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("Starrating/AddPE",JsonConvert.SerializeObject(objAllModelmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF AddHS(SR_FileMaster objAllModelmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("Starrating/AddHS",JsonConvert.SerializeObject(objAllModelmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF AddSC(SR_FileMaster objAllModelmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("Starrating/AddSC",JsonConvert.SerializeObject(objAllModelmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF AddMore(AllModel objAllModelmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("Starrating/AddMore",JsonConvert.SerializeObject(objAllModelmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region EditLesseeAssessment
        public SR_Assesment_Master Edit(SR_Assesment_Master objSRAM)
        {
            try
            {
                SR_Assesment_Master SR_AM = new SR_Assesment_Master();
                SR_AM = JsonConvert.DeserializeObject<SR_Assesment_Master>(_objIHttpWebClients.PostRequest("Starrating/Edit", JsonConvert.SerializeObject(objSRAM)));
                return SR_AM;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<SR_Systematic_Sustainable> EditSS(SR_Systematic_Sustainable objSS)
        {
            try
            {
                List<SR_Systematic_Sustainable> objlistFile = new List<SR_Systematic_Sustainable>();
                objlistFile = JsonConvert.DeserializeObject<List<SR_Systematic_Sustainable>>(_objIHttpWebClients.PostRequest("Starrating/EditLesseeSS", JsonConvert.SerializeObject(objSS)));
                return objlistFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SR_Protection_Environment> EditPE(SR_Protection_Environment objPE)
        {
            try
            {
                List<SR_Protection_Environment> objlistFile = new List<SR_Protection_Environment>();
                objlistFile = JsonConvert.DeserializeObject<List<SR_Protection_Environment>>(_objIHttpWebClients.PostRequest("Starrating/EditLesseePE", JsonConvert.SerializeObject(objPE)));
                return objlistFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SR_Health_Saftey> EditHS(SR_Health_Saftey objHS)
        {
            try
            {
                List<SR_Health_Saftey> objlistFile = new List<SR_Health_Saftey>();
                objlistFile = JsonConvert.DeserializeObject<List<SR_Health_Saftey>>(_objIHttpWebClients.PostRequest("Starrating/EditLesseeHS", JsonConvert.SerializeObject(objHS)));
                return objlistFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SR_Statutory_Compliance> EditSC(SR_Statutory_Compliance objSC)
        {
            try
            {
                List<SR_Statutory_Compliance> objlistFile = new List<SR_Statutory_Compliance>();
                objlistFile = JsonConvert.DeserializeObject<List<SR_Statutory_Compliance>>(_objIHttpWebClients.PostRequest("Starrating/EditLesseeSC", JsonConvert.SerializeObject(objSC)));
                return objlistFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SR_Additional_MappFile> GetOtherFiles(SR_Additional_MappFile objOtherFile)
        {
            try
            {
                List<SR_Additional_MappFile> objlistFile = new List<SR_Additional_MappFile>();
                objlistFile = JsonConvert.DeserializeObject<List<SR_Additional_MappFile>>(_objIHttpWebClients.PostRequest("Starrating/GetOtherFiles", JsonConvert.SerializeObject(objOtherFile)));
                return objlistFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SR_FileMaster> GetInfoFiles(SR_FileMaster objOtherFile)
        {
            try
            {
                List<SR_FileMaster> objlistFile = new List<SR_FileMaster>();
                objlistFile = JsonConvert.DeserializeObject<List<SR_FileMaster>>(_objIHttpWebClients.PostRequest("Starrating/GetInfoFiles", JsonConvert.SerializeObject(objOtherFile)));
                return objlistFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SR_Coordinate_Master> GetCoordinateList(SR_Coordinate_Master objOtherFile)
        {
            try
            {
                List<SR_Coordinate_Master> objlistFile = new List<SR_Coordinate_Master>();
                objlistFile = JsonConvert.DeserializeObject<List<SR_Coordinate_Master>>(_objIHttpWebClients.PostRequest("Starrating/GetCoordinateList", JsonConvert.SerializeObject(objOtherFile)));
                return objlistFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
        public List<SR_Lease_Area_Master> GetLeaseAreaList(SR_Lease_Area_Master objOtherFile)
        {
            try
            {
                List<SR_Lease_Area_Master> objlistFile = new List<SR_Lease_Area_Master>();
                objlistFile = JsonConvert.DeserializeObject<List<SR_Lease_Area_Master>>(_objIHttpWebClients.PostRequest("Starrating/GetLeaseAreaList", JsonConvert.SerializeObject(objOtherFile)));
                return objlistFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SR_Lease_Area_Mineral> GetLeaseTypeList(SR_Lease_Area_Mineral objOtherFile)
        {
            try
            {
                List<SR_Lease_Area_Mineral> objlistFile = new List<SR_Lease_Area_Mineral>();
                objlistFile = JsonConvert.DeserializeObject<List<SR_Lease_Area_Mineral>>(_objIHttpWebClients.PostRequest("Starrating/GetLeaseTypeList", JsonConvert.SerializeObject(objOtherFile)));
                return objlistFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
