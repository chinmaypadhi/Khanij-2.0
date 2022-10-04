// ***********************************************************************
//  Controller Name          : LeaveManagement
//  Desciption               : Leave Management Details 
//  Created By               : Suresh Kumar Behera
//  Created On               : 13-Jul-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EstablishmentApp.Areas.LeaveManagement.Models.LeaveManagement
{
    public class LeaveManagementModel : ILeaveManagementModel
    {

        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public LeaveManagementModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }


        #region LeaveRule
        /// <summary>
        /// Add leave rule master
        /// </summary>
        /// <param name="objLeaveRule"></param>
        /// <returns></returns>
        public MessageEF AddLeaveRuleMaster(LeaveRuleMasterEF objLeaveRule)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/AddLeaveRuleMaster", JsonConvert.SerializeObject(objLeaveRule)));

            }
            catch (Exception ex)
            {
                throw;
            }
            return objMessageEF;
        }
        /// <summary>
        /// Delete leave rule
        /// </summary>
        /// <param name="objLeaveRule"></param>
        /// <returns></returns>
        public MessageEF DeleteLeaveRuleDetails(LeaveRuleMasterEF objLeaveRule)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/DeleteLeaveRuleDetails", JsonConvert.SerializeObject(objLeaveRule)));

                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(EstablishmentApp.Models.Utility.HttpWebClients.PostRequest("LeaveManagement/DeleteLeaveRuleDetails", JsonConvert.SerializeObject(objLeaveRule)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
        /// <summary>
        /// view leave rule master
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        public async Task<List<LeaveRuleMasterEF>> ViewLeaveRuleMaster(LeaveRuleMasterEF objLeaveRuleMaster)
        {
            try
            {
                List<LeaveRuleMasterEF> objlistRule = new List<LeaveRuleMasterEF>();

                //JsonConvert.SerializeObject(objLeaveRuleMaster);
                objlistRule = JsonConvert.DeserializeObject<List<LeaveRuleMasterEF>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewLeaveRuleMaster", JsonConvert.SerializeObject(objLeaveRuleMaster)));

                return objlistRule;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// view leave rule master details
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        public async Task<LeaveRuleMasterEF> ViewLeaveRuleMasterDetails(LeaveRuleMasterEF objLeaveRuleMaster)
        {
            try
            {
                LeaveRuleMasterEF objRule = new LeaveRuleMasterEF();
                objRule = JsonConvert.DeserializeObject<LeaveRuleMasterEF>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewLeaveRuleMasterDetails", JsonConvert.SerializeObject(objLeaveRuleMaster)));
                return objRule;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region LeaveType
        public async Task<List<LeaveDropDown>> BindLeaveRule(LeaveDropDown objRule)
        {
            try
            {
                List<LeaveDropDown> objListRule = new List<LeaveDropDown>();
                objListRule = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindLeaveRule", JsonConvert.SerializeObject(objRule)));
                return objListRule;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Add leave type
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        public MessageEF AddLeaveTypeMaster(LeaveTypeMasterEF objLeaveType)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/AddLeaveTypeMaster", JsonConvert.SerializeObject(objLeaveType)));

                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(EstablishmentApp.Models.Utility.HttpWebClients.PostRequest("LeaveManagement/AddLeaveTypeMaster", JsonConvert.SerializeObject(objLeaveType)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
        /// <summary>
        /// view leave type
        /// </summary>
        /// <param name="objLeaveTypeMaster"></param>
        /// <returns></returns>
        public async Task<LeaveTypeMasterEF> ViewLeaveTypeMasterDetails(LeaveTypeMasterEF objLeaveTypeMaster)
        {
            try
            {
                LeaveTypeMasterEF objRule = new LeaveTypeMasterEF();
                objRule = JsonConvert.DeserializeObject<LeaveTypeMasterEF>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewLeaveTypeMasterDetails", JsonConvert.SerializeObject(objLeaveTypeMaster)));
                return objRule;


                //objRule = JsonConvert.DeserializeObject<LeaveTypeMasterEF>(EstablishmentApp.Models.Utility.HttpWebClients.PostRequest("LeaveManagement/ViewLeaveTypeMasterDetails", JsonConvert.SerializeObject(objLeaveTypeMaster)));


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// view leave type master
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        public async Task<List<LeaveTypeMasterEF>> ViewLeaveTypeMaster(LeaveTypeMasterEF objLeaveTypeMaster)
        {
            try
            {
                List<LeaveTypeMasterEF> objlistRule = new List<LeaveTypeMasterEF>();

                //JsonConvert.SerializeObject(objLeaveTypeMaster);
                objlistRule = JsonConvert.DeserializeObject<List<LeaveTypeMasterEF>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewLeaveTypeMaster", JsonConvert.SerializeObject(objLeaveTypeMaster)));
                return objlistRule;

                //objlistRule = JsonConvert.DeserializeObject<List<LeaveTypeMasterEF>>(EstablishmentApp.Models.Utility.HttpWebClients.PostRequest("LeaveManagement/ViewLeaveTypeMaster", JsonConvert.SerializeObject(objLeaveTypeMaster)));
                //return objlistRule;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// delete leave type 
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        public MessageEF DeleteLeaveTypeDetails(LeaveTypeMasterEF objLeaveType)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/DeleteLeaveTypeDetails", JsonConvert.SerializeObject(objLeaveType)));

                //objMessageEF = JsonConvert.DeserializeObject<MessageEF>(EstablishmentApp.Models.Utility.HttpWebClients.PostRequest("LeaveManagement/DeleteLeaveTypeDetails", JsonConvert.SerializeObject(objLeaveType)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }


        #endregion

        #region HolidayType
        public async Task<List<HolidayTypeMasterEF>> ViewHolidayTypeMaster(HolidayTypeMasterEF objHolidayTypeMaster)
        {
            List<HolidayTypeMasterEF> objListHolidayType = new List<HolidayTypeMasterEF>();
            try
            {
                objListHolidayType = JsonConvert.DeserializeObject<List<HolidayTypeMasterEF>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewHolidayTypeMaster", JsonConvert.SerializeObject(objHolidayTypeMaster)));
                return objListHolidayType;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objListHolidayType = null;
            }

        }

        public MessageEF AddHolidayType(HolidayTypeMasterEF objHolidayType)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/AddHolidayType", JsonConvert.SerializeObject(objHolidayType)));
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<HolidayTypeMasterEF> ViewHolidayTypeDetails(HolidayTypeMasterEF objHolidayTypeDetails)
        {
            HolidayTypeMasterEF objHolidayType = new HolidayTypeMasterEF();
            try
            {
                objHolidayType = JsonConvert.DeserializeObject<HolidayTypeMasterEF>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewHolidayTypeDetails", JsonConvert.SerializeObject(objHolidayTypeDetails)));
                return objHolidayType;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objHolidayType = null;
            }

        }

        public MessageEF DeleteHolidayType(HolidayTypeMasterEF objHolidayType)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/DeleteHolidayType", JsonConvert.SerializeObject(objHolidayType)));
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }


        #endregion

        #region Holiday
        public MessageEF AddHoliday(HolidayMasterEF objHoliday)
        {

            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/AddHoliday", JsonConvert.SerializeObject(objHoliday)));
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<List<LeaveDropDown>> BindDropdown(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> objListHoliday = new List<LeaveDropDown>();
            try
            {
                objListHoliday = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindDropdown", JsonConvert.SerializeObject(objLeaveDropDown)));
                return objListHoliday;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<HolidayMasterEF>> ViewHoliday(HolidayMasterEF objHoliday)
        {
            List<HolidayMasterEF> objListHoliday = new List<HolidayMasterEF>();
            try
            {
                objListHoliday = JsonConvert.DeserializeObject<List<HolidayMasterEF>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewHoliday", JsonConvert.SerializeObject(objHoliday)));
                return objListHoliday;
            }
            catch (Exception)
            {
                throw;
            }
            //finally
            //{
            //    objListHoliday = null;
            //}
        }

        public async Task<HolidayMasterEF> ViewHolidayDetails(HolidayMasterEF objHoliday)
        {
            HolidayMasterEF objHolidayDetails = new HolidayMasterEF();
            try
            {
                objHolidayDetails = JsonConvert.DeserializeObject<HolidayMasterEF>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewHolidayDetails", JsonConvert.SerializeObject(objHoliday)));
                return objHolidayDetails;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteHoliday(HolidayMasterEF objHoliday)
        {

            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/DeleteHoliday", JsonConvert.SerializeObject(objHoliday)));
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;

        }


        #endregion

        #region RiderLeave
        public async Task<List<LeaveDropDown>> BindDistrict(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> objListHoliday = new List<LeaveDropDown>();
            try
            {
                objListHoliday = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindDistrict", JsonConvert.SerializeObject(objLeaveDropDown)));
                return objListHoliday;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LeaveDropDown>> BindDesignation(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> objListHoliday = new List<LeaveDropDown>();
            try
            {
                objListHoliday = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindDesignation", JsonConvert.SerializeObject(objLeaveDropDown)));
                return objListHoliday;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LeaveDropDown>> BindLeaveType(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> objListHoliday = new List<LeaveDropDown>();
            try
            {
                objListHoliday = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindLeaveType", JsonConvert.SerializeObject(objLeaveDropDown)));
                return objListHoliday;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF AddRiderLeave(RiderLeave objRiderLeave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/AddRiderLeave", JsonConvert.SerializeObject(objRiderLeave)));
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<List<RiderLeave>> ViewRiderleave(RiderLeave objRiderLeave)
        {
            List<RiderLeave> objListRiderLeave = new List<RiderLeave>();
            try
            {
                objListRiderLeave = JsonConvert.DeserializeObject<List<RiderLeave>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewRiderleave", JsonConvert.SerializeObject(objRiderLeave)));
                return objListRiderLeave;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<RiderLeave> ViewRiderleaveDetails(RiderLeave objRiderLeave)
        {
            RiderLeave objListRiderLeave = new RiderLeave();
            try
            {
                objListRiderLeave = JsonConvert.DeserializeObject<RiderLeave>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewRiderleaveDetails", JsonConvert.SerializeObject(objRiderLeave)));
                return objListRiderLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteRiderLeave(RiderLeave objRiderLeave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/DeleteRiderLeave", JsonConvert.SerializeObject(objRiderLeave)));
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }
        #endregion

        #region AuthoritySetting
        public async Task<List<LeaveDropDown>> BindState_Authority(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindState_Authority", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<LeaveDropDown>> BindDistrict_Authority(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindDistrict_Authority", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<LeaveDropDown>> BindDepartment_Authority(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindDepartment_Authority", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LeaveDropDown>> BindVerifyDesignation(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindVerifyDesignation", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindForwardDepartment_Authority(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindForwardDepartment_Authority", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindForwardDesignation(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindForwardDesignation", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LeaveDropDown>> BindOICOfficer(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindOICOfficer", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LeaveDropDown>> BindOICApproveDesignation(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindOICApproveDesignation", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindOICApproveUser(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindOICApproveUser", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<List<LeaveDropDown>> BindNoOfDaysExceed_FirstLevel(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindNoOfDaysExceed_FirstLevel", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindNextApproveDesignation1(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindNextApproveDesignation1", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindNextApproveUser1(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindNextApproveUser1", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<List<LeaveDropDown>> BindNoOfDaysExceed_secondLevel(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindNoOfDaysExceed_secondLevel", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindNextApproveDesignation2(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindNextApproveDesignation2", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindNextApproveUser2(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindNextApproveUser2", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF AddAuthoritySetting(AuthoritySetting objAuthoritySetting)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/AddAuthoritySetting", JsonConvert.SerializeObject(objAuthoritySetting)));

            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<List<AuthoritySettingQuery>> ViewAuthoritySetting(AuthoritySettingQuery objAuthoritySetting)
        {

            List<AuthoritySettingQuery> listAuthoritySetting = new List<AuthoritySettingQuery>();
            try
            {
                listAuthoritySetting = JsonConvert.DeserializeObject<List<AuthoritySettingQuery>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewAuthoritySetting", JsonConvert.SerializeObject(objAuthoritySetting)));
                return listAuthoritySetting;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AuthoritySetting> ViewAuthoritySettingDetails(AuthoritySetting objAuthoritySetting)
        {
            AuthoritySetting objAuthority = new AuthoritySetting();
            try
            {
                objAuthority = JsonConvert.DeserializeObject<AuthoritySetting>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewAuthoritySettingDetails", JsonConvert.SerializeObject(objAuthoritySetting)));
                return objAuthority;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteAuthoritySetting(AuthoritySetting objAuthoritySetting)
        {

            MessageEF objMessage = new MessageEF();
            try
            {
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/DeleteAuthoritySetting", JsonConvert.SerializeObject(objAuthoritySetting)));
            }
            catch (Exception)
            {

                throw;
            }
            return objMessage;
        }

        #endregion



        #region TribalDistrictLeave

        public MessageEF AddTribalDistrictLeave(TribalDistLeave objApplyLeave)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/AddTribalDistrictLeave", JsonConvert.SerializeObject(objApplyLeave)));
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TribalDistLeaveQuery>> ViewTribalDistrictLeave(TribalDistLeaveQuery objApplyLeave)
        {
            List<TribalDistLeaveQuery> listLeave = new List<TribalDistLeaveQuery>();
            try
            {
                listLeave = JsonConvert.DeserializeObject<List<TribalDistLeaveQuery>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewTribalDistrictLeave", JsonConvert.SerializeObject(objApplyLeave)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TribalDistLeave> ViewTribalDistrictLeaveDetails(TribalDistLeave objApplyLeave)
        {
            TribalDistLeave listLeave = new TribalDistLeave();
            try
            {
                listLeave = JsonConvert.DeserializeObject<TribalDistLeave>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewTribalDistrictLeaveDetails", JsonConvert.SerializeObject(objApplyLeave)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteTribalDistrictLeave(TribalDistLeave objApplyLeave)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/DeleteTribalDistrictLeave", JsonConvert.SerializeObject(objApplyLeave)));
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        #region userwise set authority
        public async Task<List<LeaveDropDown>> BindDropDownSetAuthority(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listLeave = new List<LeaveDropDown>();
            try
            {
                listLeave = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindDropDownSetAuthority", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF AddUserWiseSetAuthority(UserWiseSetAuthority objAuthoritySetting)
        {

            MessageEF objMessage = new MessageEF();
            try
            {
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/AddUserWiseSetAuthority", JsonConvert.SerializeObject(objAuthoritySetting)));
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<UserWiseSetAuthority> ViewUserWiseSetAuthoritySettingDetails(UserWiseSetAuthority objUserWiseAuthority)
        {
            UserWiseSetAuthority listLeave = new UserWiseSetAuthority();
            try
            {
                listLeave = JsonConvert.DeserializeObject<UserWiseSetAuthority>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewUserWiseSetAuthoritySettingDetails", JsonConvert.SerializeObject(objUserWiseAuthority)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UserWiseSetAuthorityChild>> ViewUserWiseSetAuthorityChild(UserWiseSetAuthority objUserWiseAuthority)
        {
            List<UserWiseSetAuthorityChild> listLeave = new List<UserWiseSetAuthorityChild>();
            try
            {
                listLeave = JsonConvert.DeserializeObject<List<UserWiseSetAuthorityChild>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewUserWiseSetAuthorityChild", JsonConvert.SerializeObject(objUserWiseAuthority)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF RemoveUserWiseSetAuthoritychild(UserWiseSetAuthorityChild objAuthoritySetting)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/RemoveUserWiseSetAuthoritychild", JsonConvert.SerializeObject(objAuthoritySetting)));
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UserWiseSetAuthorityQuery>> ViewUserWiseSetAuthority(UserWiseSetAuthorityQuery objUserWiseAuthority)
        {
            List<UserWiseSetAuthorityQuery> listAuthority = new List<UserWiseSetAuthorityQuery>();
            try
            {
                listAuthority = JsonConvert.DeserializeObject<List<UserWiseSetAuthorityQuery>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewUserWiseSetAuthority", JsonConvert.SerializeObject(objUserWiseAuthority)));
                return listAuthority;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public MessageEF DeleteUserWiseSetAuthoritySetting(UserWiseSetAuthority objAuthoritySetting)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/DeleteUserWiseSetAuthoritySetting", JsonConvert.SerializeObject(objAuthoritySetting)));
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region ApplyLeave
        public async Task<List<LeaveDropDown>> BindEmployee(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindEmployee", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindLeaveType_ApplyLeave(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindLeaveType_ApplyLeave", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task<LeaveDetails> BindLeaveDetails(LeaveDetails objLeaveDetails)
        //{
        //    LeaveDetails objLeave = new LeaveDetails();
        //    try
        //    {
        //        objLeave = JsonConvert.DeserializeObject<LeaveDetails>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindLeaveDetails", JsonConvert.SerializeObject(objLeaveDetails)));
        //        return objLeave;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public MessageEF AddApplyLeave(ApplyLeave objApplyleave)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/AddApplyLeave", JsonConvert.SerializeObject(objApplyleave)));
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ApplyLeaveQuery>> ViewApplyLeave(ApplyLeaveQuery objApplyLeave)
        {
            List<ApplyLeaveQuery> listLeave = new List<ApplyLeaveQuery>();
            try
            {
                listLeave = JsonConvert.DeserializeObject<List<ApplyLeaveQuery>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewApplyLeave", JsonConvert.SerializeObject(objApplyLeave)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ApplyLeave> ViewApplyLeaveDetails(ApplyLeave objApplyLeave)

        {
            ApplyLeave listLeave = new ApplyLeave();
            try
            {
                listLeave = JsonConvert.DeserializeObject<ApplyLeave>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewApplyLeaveDetails", JsonConvert.SerializeObject(objApplyLeave)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteApplyLeave(ApplyLeave objApplyLeave)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/DeleteApplyLeave", JsonConvert.SerializeObject(objApplyLeave)));
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LeaveDetails> BindLeaveCount(LeaveDetails objLeaveDetails)
        {
            LeaveDetails listLeave = new LeaveDetails();
            try
            {
                listLeave = JsonConvert.DeserializeObject<LeaveDetails>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/BindLeaveCount", JsonConvert.SerializeObject(objLeaveDetails)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }



        #endregion
        #region leaveinbox
        public async Task<List<LeaveInboxQuery>> ViewLeaveInbox(LeaveInboxQuery objApplyLeave)
        {
            List<LeaveInboxQuery> listLeave = new List<LeaveInboxQuery>();
            try
            {
                listLeave = JsonConvert.DeserializeObject<List<LeaveInboxQuery>>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewLeaveInbox", JsonConvert.SerializeObject(objApplyLeave)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LeaveInboxDetails> ViewLeaveInboxDetails(LeaveInboxDetails objLeaveInbox)
        {
            LeaveInboxDetails _objLeaveInbox = new LeaveInboxDetails();
            try
            {
                _objLeaveInbox = JsonConvert.DeserializeObject<LeaveInboxDetails>(await _objIHttpWebClients.AwaitPostRequest("LeaveManagement/ViewLeaveInboxDetails", JsonConvert.SerializeObject(objLeaveInbox)));
                return _objLeaveInbox;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF TakeAction(LeaveInboxDetails objLeave)
        {

            MessageEF objMessage = new MessageEF();
            try
            {
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveManagement/TakeAction", JsonConvert.SerializeObject(objLeave)));
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
                //_listActionType = JsonConvert.DeserializeObject<List<LeaveDropDown>>(_objIHttpWebClients.PostRequest("LeaveManagement/BindActionType", JsonConvert.SerializeObject(objActionType)));

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
