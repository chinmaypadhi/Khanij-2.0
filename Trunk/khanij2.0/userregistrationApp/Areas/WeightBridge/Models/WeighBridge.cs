using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.WeightBridge.Models
{
    public class WeighBridge : IWeighBridge
    {
        IHttpWebClients _objIHttpWebClients;
        public WeighBridge(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        public List<ViewWeighBridgeModel> ViewWBByDistrict(ViewWeighBridgeModel obj)
        {
            try
            {
                List<ViewWeighBridgeModel> objlist = new List<ViewWeighBridgeModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeModel>>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/ViewWBByDistrict", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ViewWeighBridgeModel> ViewWBByUserID(ViewWeighBridgeModel obj)
        {
            try
            {
                List<ViewWeighBridgeModel> objlist = new List<ViewWeighBridgeModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeModel>>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/ViewWBByUserID", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ViewWeighBridgeModel ViewWBByWeighBridgeID(ViewWeighBridgeModel obj)
        {
            try
            {
                ViewWeighBridgeModel objmodel = new ViewWeighBridgeModel();
                objmodel = JsonConvert.DeserializeObject<ViewWeighBridgeModel>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/ViewWBByWeighBridgeID", JsonConvert.SerializeObject(obj)));
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ViewIndependentUserDetailModel ViewIndependentByUserID(ViewIndependentUserDetailModel obj)
        {
            try
            {
                ViewIndependentUserDetailModel objmodel = new ViewIndependentUserDetailModel();
                objmodel = JsonConvert.DeserializeObject<ViewIndependentUserDetailModel>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/ViewIndependentByUserID", JsonConvert.SerializeObject(obj)));
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF WBForward(ViewWeighBridgeModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/WBForward", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }
        public MessageEF WBApprove(ViewWeighBridgeModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/WBApprove", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }
        public MessageEF WBRegister(AddWeighBridgeModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/WBRegister", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }
        public MessageEF WBIndependentRegister(AddIndependentWeighBridgeModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/WBIndependentRegister", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }
        public MessageEF WBCheck(ViewWeighBridgeModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/WBCheck", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }
        public MessageEF WBCheckContact(ViewWeighBridgeModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/WBCheckContact", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }
        public MessageEF WBRenewal(AddWeighBridgeRenewal obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/WBRenewal", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }
        public MessageEF WBRegisterEdit(AddWeighBridgeModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/WBRegisterEdit", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }

        public AddWeighBridgeModel WBByID(ViewWeighBridgeModel obj)
        {
            try
            {
                AddWeighBridgeModel objmodel = new AddWeighBridgeModel();
                objmodel = JsonConvert.DeserializeObject<AddWeighBridgeModel>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/WBByID", JsonConvert.SerializeObject(obj)));
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ViewWeighBridgeModel> RenewalWBByUserID(ViewWeighBridgeModel obj)
        {
            try
            {
                List<ViewWeighBridgeModel> objlist = new List<ViewWeighBridgeModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeModel>>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/RenewalWBByUserID", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ViewWeighBridgeModel> HistoryWBByID(ViewWeighBridgeModel obj)
        {
            try
            {
                List<ViewWeighBridgeModel> objlist = new List<ViewWeighBridgeModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeModel>>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/HistoryWBByID", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ViewWeighBridgeModel> ViewWeighBridgeTagActionList(ViewWeighBridgeModel obj)
        {
            try
            {
                List<ViewWeighBridgeModel> objlist = new List<ViewWeighBridgeModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeModel>>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/ViewWeighBridgeTagActionList", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
