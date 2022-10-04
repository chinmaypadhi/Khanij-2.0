using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.EndUserProfile.Models
{
    public class EndUserModel: IEndUserModel
    {
        //public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public EndUserModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public EndUserProfileViewModel ViewProfile(EndUserProfileViewModel endUserProfile)
        {
            try
            { 
                Result<List<EndUserProfileViewModel>> endUserProfileViewModel = new Result<List<EndUserProfileViewModel>>();
                endUserProfileViewModel = JsonConvert.DeserializeObject<Result<List<EndUserProfileViewModel>>>(_objIHttpWebClients.PostRequest("EndUserProfile/ViewProfile", JsonConvert.SerializeObject(endUserProfile)));
                return endUserProfileViewModel.Data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { endUserProfile = null; }

        }
        public GetIndustryType GetIType(userregistrationEF.EndUserModel ObjEU)
        {
            try
            {
                List<userregistrationEF.EndUserModel> objlistDD = new List<userregistrationEF.EndUserModel>();
                return JsonConvert.DeserializeObject<GetIndustryType>(_objIHttpWebClients.PostRequest("EndUserReg/ViewIType", JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public GetListState GetState(userregistrationEF.EndUserModel ObjEU)
        {
            try
            {
                List<userregistrationEF.EndUserModel> objlistDD = new List<userregistrationEF.EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/ViewLState", JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public GetListState GetDistrict(userregistrationEF.EndUserModel ObjEU)
        {
            try
            {
                List<userregistrationEF.EndUserModel> objlistDD = new List<userregistrationEF.EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/ViewLDistrict", JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public GetListState GetState_O(userregistrationEF.EndUserModel ObjEU)
        {
            try
            {
                List<userregistrationEF.EndUserModel> objlistDD = new List<userregistrationEF.EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/ViewLState_O", JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public GetListState GetDistrict_O(userregistrationEF.EndUserModel ObjEU)
        {
            try
            {
                List<userregistrationEF.EndUserModel> objlistDD = new List<userregistrationEF.EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/ViewLDistrict_O", JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public GetListState GetSQ(userregistrationEF.EndUserModel ObjEU)
        {
            try
            {
                List<userregistrationEF.EndUserModel> objlistDD = new List<userregistrationEF.EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/ViewLSQ", JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public GetListState GetMineral(userregistrationEF.EndUserModel ObjEU)
        {
            try
            {
                List<userregistrationEF.EndUserModel> objlistDD = new List<userregistrationEF.EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/GetMineral", JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public GetListState GetMineralForm(userregistrationEF.EndUserModel ObjEU)
        {
            try
            {
                List<userregistrationEF.EndUserModel> objlistDD = new List<userregistrationEF.EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/GetMineralForm", JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public GetListState GetMineralGrade(userregistrationEF.EndUserModel ObjEU)
        {
            try
            {
                List<userregistrationEF.EndUserModel> objlistDD = new List<userregistrationEF.EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/GetMineralGrade", JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public userregistrationEF.EndUserModel EditEndUserProfile(userregistrationEF.EndUserModel endUserProfile)
        {
            try
            {
                userregistrationEF.EndUserModel endUserProfileViewModel = new userregistrationEF.EndUserModel();
                endUserProfileViewModel = JsonConvert.DeserializeObject<userregistrationEF.EndUserModel>(_objIHttpWebClients.PostRequest("EndUserProfile/EditEndUserProfile", JsonConvert.SerializeObject(endUserProfile)));
                return endUserProfileViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public MessageEF UpdateEndUserProfile(userregistrationEF.EndUserModel endUserProfile)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("EndUserProfile/UpdateEndUserProfile", JsonConvert.SerializeObject(endUserProfile)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
