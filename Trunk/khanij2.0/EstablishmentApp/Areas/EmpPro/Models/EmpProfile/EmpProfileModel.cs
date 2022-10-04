using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.EmpPro.Models.EmpProfile
{
    public class EmpProfileModel : IEmpProfileModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;

        public EmpProfileModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }


        //IHttpWebClients _objHttpWebClients;
        //public EmpProfileModel(IHttpWebClients objHttpWebClients)
        //{
        //    _objHttpWebClients = objHttpWebClients;
        //}
        public MessageEF AddEmpProfile(EmpProfileEf objEmpProfileEf)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("EmpProfile/AddEmpProfile", JsonConvert.SerializeObject(objEmpProfileEf)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
        public List<EmpDropDown> Dropdown(EmpDropDown objEmpDropDown)
        {
            List<EmpDropDown> ListofficeLevelEF = new List<EmpDropDown>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<EmpDropDown>>(_objIHttpWebClients.PostRequest("EmpProfile/Dropdown", JsonConvert.SerializeObject(objEmpDropDown)));
                //ListofficeLevelEF = JsonConvert.DeserializeObject<List<EmpDropDown>>(_objHttpWebClients.PostRequest("EmpProfile/Dropdown", objEmpDropDown));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }
        public MessageEF AddAddress(EmpProfileEf objEmpProfileEf)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("EmpProfile/AddAddress", JsonConvert.SerializeObject(objEmpProfileEf)));

                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objHttpWebClients.PostRequest("EmpProfile/AddAddress", objEmpProfileEf));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
        public MessageEF AddPostingAddress(EmpProfileEf objEmpProfileEf)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("EmpProfile/AddPostingAddress", JsonConvert.SerializeObject(objEmpProfileEf)));
                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objHttpWebClients.PostRequest("EmpProfile/AddPostingAddress", objEmpProfileEf));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
        public List<EmpProfileEf> getList(EmpProfileEf objEmpProfileEf)
        {
            List<EmpProfileEf> objListEmpProfileEf = new List<EmpProfileEf>();
            try
            {
                objListEmpProfileEf = JsonConvert.DeserializeObject<List<EmpProfileEf>>(_objIHttpWebClients.PostRequest("EmpProfile/getList", JsonConvert.SerializeObject(objEmpProfileEf)));

                //objListEmpProfileEf = JsonConvert.DeserializeObject<List<EmpProfileEf>>(_objHttpWebClients.PostRequest("EmpProfile/getList", objEmpProfileEf));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objListEmpProfileEf;
        }

        public EmpProfileEf ViewDetails(EmpProfileEf objEmpProfileEf)
        {
            EmpProfileEf _objEmpProfileEf = new EmpProfileEf();
            try
            {
                _objEmpProfileEf = JsonConvert.DeserializeObject<EmpProfileEf>(_objIHttpWebClients.PostRequest("EmpProfile/ViewDetails", JsonConvert.SerializeObject(objEmpProfileEf)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _objEmpProfileEf;
        }

        //public EmpProfileEf GetUserId(EmpProfileEf objEmpProfileEf)
        //{
        //    EmpProfileEf _objEmpProfileEf = new EmpProfileEf();
        //    try
        //    {
        //        _objEmpProfileEf = JsonConvert.DeserializeObject<EmpProfileEf>(_objIHttpWebClients.PostRequest("EmpProfile/GetUserId", JsonConvert.SerializeObject(objEmpProfileEf)));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return _objEmpProfileEf;
        //}

        public EmpProfileEf ViewUserInformation(EmpProfileEf objEmpProfileEf)
        {
            EmpProfileEf _objEmpProfileEf = new EmpProfileEf();
            try
            {
                _objEmpProfileEf = JsonConvert.DeserializeObject<EmpProfileEf>(_objIHttpWebClients.PostRequest("EmpProfile/ViewUserInformation", JsonConvert.SerializeObject(objEmpProfileEf)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _objEmpProfileEf;
        }



        #region EmployeeProfileInbox
        public List<EmployeeProfileInboxQuery> ViewEmployeeProfileInbox(EmployeeProfileInboxQuery objEmpProfileEf)
        {
            List<EmployeeProfileInboxQuery> listLeave = new List<EmployeeProfileInboxQuery>();
            try
            {
                listLeave = JsonConvert.DeserializeObject<List<EmployeeProfileInboxQuery>>( _objIHttpWebClients.PostRequest("EmpProfile/ViewEmployeeProfileInbox", JsonConvert.SerializeObject(objEmpProfileEf)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  EmployeeProfileInboxDetails ViewEmployeeProfileInboxDetails(EmployeeProfileInboxDetails objProfile)
        {
            EmployeeProfileInboxDetails _objProfile = EmployeeProfileInboxDetails.GetInstance();
            try
            {
                _objProfile = JsonConvert.DeserializeObject<EmployeeProfileInboxDetails>(_objIHttpWebClients.PostRequest("EmpProfile/ViewEmployeeProfileInboxDetails", JsonConvert.SerializeObject(objProfile)));
                return _objProfile;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public async Task<LeaveInboxDetails> ViewLeaveInboxDetails(LeaveInboxDetails objLeaveInbox)
        //{
        //    LeaveInboxDetails _objLeaveInbox = new LeaveInboxDetails();
        //    try
        //    {
        //        _objLeaveInbox = JsonConvert.DeserializeObject<LeaveInboxDetails>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewLeaveInboxDetails", JsonConvert.SerializeObject(objLeaveInbox)));
        //        return _objLeaveInbox;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public MessageEF ProfileTakeAction(EmployeeProfileInboxDetails objLeave)
        {

            MessageEF objMessage = new MessageEF();
            try
            {
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("EmpProfile/ProfileTakeAction", JsonConvert.SerializeObject(objLeave)));
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<WorkFlowDropDown> BindActionType(WorkFlowDropDown objActionType)
        {
            List<WorkFlowDropDown> _listActionType = new List<WorkFlowDropDown>();
            try
            {
                _listActionType = JsonConvert.DeserializeObject<List<WorkFlowDropDown>>(_objIHttpWebClients.PostRequest("WorkFlow/BindActionType", JsonConvert.SerializeObject(objActionType)));
                return _listActionType;
            }
            catch (Exception)
            {
                throw;
            }
        }




        #endregion
    }
}
