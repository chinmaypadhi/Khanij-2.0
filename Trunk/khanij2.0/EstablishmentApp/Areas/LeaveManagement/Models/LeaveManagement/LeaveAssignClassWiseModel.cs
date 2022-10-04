// ***********************************************************************
//  Controller Name          : LeaveManagement
//  Desciption               : Leave Management Details 
//  Created By               : Suresh Kumar Behera
//  Created On               : 13-Jul-2021
// ***********************************************************************
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using EstablishmentApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace EstablishmentApp.Areas.LeaveManagement.Models.LeaveManagement
{
    public class LeaveAssignClassWiseModel : ILeaveAssignClassWiseModel
    {
        //public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public LeaveAssignClassWiseModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            //_objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        public MessageEF AddLeaveAssignClassWise(LeaveAssignClassWise objApplyLeave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveAssignClassWise/AddLeaveAssignClassWise", JsonConvert.SerializeObject(objApplyLeave)));

            }
            catch (Exception ex)
            {
                throw;
            }
            return objMessageEF;
        }

        public async Task<List<LeaveDropDown>> BindEmployeeClass(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveAssignClassWise/BindEmployeeClass", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LeaveDropDown>> BindLeaveTypeClass(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listDropDown = new List<LeaveDropDown>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveDropDown>>(await _objIHttpWebClients.AwaitPostRequest("LeaveAssignClassWise/BindLeaveTypeClass", JsonConvert.SerializeObject(objLeaveDropDown)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<List<LeaveAssignClassWiseQuery>> ViewLeaveAssignClassWise(LeaveAssignClassWiseQuery objApplyLeave)
        {
            List<LeaveAssignClassWiseQuery> listDropDown = new List<LeaveAssignClassWiseQuery>();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<List<LeaveAssignClassWiseQuery>>(await _objIHttpWebClients.AwaitPostRequest("LeaveAssignClassWise/ViewLeaveAssignClassWise", JsonConvert.SerializeObject(objApplyLeave)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LeaveAssignClassWise> ViewLeaveAssignClassWiseDetails(LeaveAssignClassWise objApplyLeave)
        {

            LeaveAssignClassWise listDropDown = new LeaveAssignClassWise();
            try
            {
                listDropDown = JsonConvert.DeserializeObject<LeaveAssignClassWise>(await _objIHttpWebClients.AwaitPostRequest("LeaveAssignClassWise/ViewLeaveAssignClassWiseDetails", JsonConvert.SerializeObject(objApplyLeave)));
                return listDropDown;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public MessageEF DeleteLeaveAssignClassWise(LeaveAssignClassWise objApplyLeave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LeaveAssignClassWise/DeleteLeaveAssignClassWise", JsonConvert.SerializeObject(objApplyLeave)));

            }
            catch (Exception ex)
            {
                throw;
            }
            return objMessageEF;
        }
    }
}
