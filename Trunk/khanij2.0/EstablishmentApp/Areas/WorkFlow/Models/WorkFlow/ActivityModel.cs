using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EstablishmentApp.Areas.WorkFlow.Models.WorkFlow
{
    public class ActivityModel:IActivityModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public ActivityModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        #region activity
        public MessageEF AddWorkFlowActivity(ActivityEF objWorkFlow)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WorkFlowActivity/AddWorkFlowActivity", JsonConvert.SerializeObject(objWorkFlow)));
                return objMessageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<WorkFlowDropDown> BindActivityDDL(WorkFlowDropDown objWorkFlow)
        {
            List<WorkFlowDropDown> listLeave = new List<WorkFlowDropDown>();
            try
            {
                listLeave = JsonConvert.DeserializeObject<List<WorkFlowDropDown>>(_objIHttpWebClients.PostRequest("WorkFlowActivity/BindActivityDDL", JsonConvert.SerializeObject(objWorkFlow)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteWorkFlowActivity(ActivityEF objWorkFlow)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WorkFlowActivity/DeleteWorkFlowActivity", JsonConvert.SerializeObject(objWorkFlow)));
                return objMessageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ActivityEFQuery> ViewWorkFlowActivity(ActivityEFQuery objWorkFlow)
        {
            List<ActivityEFQuery> listActivity = new List<ActivityEFQuery>();
            try
            {
                listActivity = JsonConvert.DeserializeObject<List<ActivityEFQuery>>(_objIHttpWebClients.PostRequest("WorkFlowActivity/ViewWorkFlowActivity", JsonConvert.SerializeObject(objWorkFlow)));
                return listActivity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActivityEF ViewWorkFlowActivityDetails(ActivityEF objWorkFlow)
        {
            ActivityEF objActivity = ActivityEF.GetInstance();
            try
            {
                objActivity = JsonConvert.DeserializeObject<ActivityEF>(_objIHttpWebClients.PostRequest("WorkFlowActivity/ViewWorkFlowActivityDetails", JsonConvert.SerializeObject(objWorkFlow)));
                return objActivity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion activity
    }
}
