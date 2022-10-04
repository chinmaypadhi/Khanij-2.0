using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MasterEF;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace MasterApp.Areas.WorkFlowEngine.Models.WorkFlow
{
    public class WorkFlowModel : IWorkFlowModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;

        public WorkFlowModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<WorkFlowDropDown> BindWorkFlowDDL(WorkFlowDropDown objWorkFlow)
        {
            List<WorkFlowDropDown> listDDL = new List<WorkFlowDropDown>();
            try
            {
                listDDL = JsonConvert.DeserializeObject<List<WorkFlowDropDown>>(_objIHttpWebClients.PostRequest("WorkFlow/BindWorkFlowDDL", JsonConvert.SerializeObject(objWorkFlow)));
                return listDDL;
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

        public List<WorkFlowDropDown> BindDropDownSetAuthority(WorkFlowDropDown objWorkFlow)
        {
            List<WorkFlowDropDown> listLeave = new List<WorkFlowDropDown>();
            try
            {
                listLeave = JsonConvert.DeserializeObject<List<WorkFlowDropDown>>(_objIHttpWebClients.PostRequest("WorkFlowActivity/BindWorkFlowDDLAuthority", JsonConvert.SerializeObject(objWorkFlow)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF AddWorkFlow(WorkFlowEF objWorkFlow)
        {
            MessageEF objMessageEF = MessageEF.GetInstance();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WorkFlow/AddWorkFlow", JsonConvert.SerializeObject(objWorkFlow)));
                return objMessageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<WorkFlowEFQuery> ViewWorkFlow(WorkFlowEFQuery objWorkFlow)
        {
            List<WorkFlowEFQuery> objListWorkFlow = new List<WorkFlowEFQuery>();
            try
            {
                objListWorkFlow = JsonConvert.DeserializeObject<List<WorkFlowEFQuery>>(_objIHttpWebClients.PostRequest("WorkFlow/ViewWorkFlow", JsonConvert.SerializeObject(objWorkFlow)));
                return objListWorkFlow;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public WorkFlowEF ViewWorkFlowDetails(WorkFlowEF objWorkFlow)
        {
            WorkFlowEF _objWorkFlow = new WorkFlowEF();
            try
            {
                _objWorkFlow = JsonConvert.DeserializeObject<WorkFlowEF>(_objIHttpWebClients.PostRequest("WorkFlow/ViewWorkFlowDetails", JsonConvert.SerializeObject(objWorkFlow)));
                return _objWorkFlow;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteWorkFlow(WorkFlowEF objWorkFlow)
        {
            MessageEF objMessageEF = MessageEF.GetInstance();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WorkFlow/DeleteWorkFlow", JsonConvert.SerializeObject(objWorkFlow)));
                return objMessageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<WorkFlowTransactionEF> ViewWorkFlowDetailsTransaction(WorkFlowEF objWorkFlow)
        {
            List<WorkFlowTransactionEF> objListWorkFlow = new List<WorkFlowTransactionEF>();
            try
            {
                objListWorkFlow = JsonConvert.DeserializeObject<List<WorkFlowTransactionEF>>(_objIHttpWebClients.PostRequest("WorkFlow/ViewWorkFlowDetailsTransaction", JsonConvert.SerializeObject(objWorkFlow)));
                return objListWorkFlow;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF RemoveWorkFlowTransaction(WorkFlowTransactionEF objWorkFlow)
        {
            MessageEF objMessageEF = MessageEF.GetInstance();
            try
            {
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WorkFlow/RemoveWorkFlowTransaction", JsonConvert.SerializeObject(objWorkFlow)));
                return objMessageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<WorkFlowAuthorityLogEF> ViewActionTakingAuthority(WorkFlowAuthorityLogEF objWorkFlow)
        {
            List<WorkFlowAuthorityLogEF> objListWorkFlow = new List<WorkFlowAuthorityLogEF>();
            try
            {
                objListWorkFlow = JsonConvert.DeserializeObject<List<WorkFlowAuthorityLogEF>>(_objIHttpWebClients.PostRequest("WorkFlow/ViewActionTakingAuthority", JsonConvert.SerializeObject(objWorkFlow)));
                return objListWorkFlow;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
