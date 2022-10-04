using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.WeightBridge.Models
{
    public class WeighBridgeTag : IWeighBridgeTag
    {
        IHttpWebClients _objIHttpWebClients;
        public WeighBridgeTag(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<ViewWeighBridgeTagModel> ViewDistrict(ViewWeighBridgeTagModel obj)
        {
            try
            {
                List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeTagModel>>(_objIHttpWebClients.PostRequest("WeighBridgeTag/ViewDistrict", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ViewWeighBridgeTagModel> ViewUserByDistrict(ViewWeighBridgeTagModel obj)
        {
            try
            {
                List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeTagModel>>(_objIHttpWebClients.PostRequest("WeighBridgeTag/ViewUserByDistrict", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ViewWeighBridgeTagModel> ViewUserType(ViewWeighBridgeTagModel obj)
        {
            try
            {
                List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeTagModel>>(_objIHttpWebClients.PostRequest("WeighBridgeTag/ViewUserByDistrict", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ViewWeighBridgeTagModel> ViewWeighBridgeByUser(ViewWeighBridgeTagModel obj)
        {
            try
            {
                List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeTagModel>>(_objIHttpWebClients.PostRequest("WeighBridgeTag/ViewWeighBridgeByUser", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ViewWeighBridgeTagModel> ViewWeighBridgeTag(ViewWeighBridgeTagModel obj)
        {
            try
            {
                List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeTagModel>>(_objIHttpWebClients.PostRequest("WeighBridgeTag/ViewWeighBridgeTag", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ViewWeighBridgeTagModel> ViewWeighBridgeTagHistory(ViewWeighBridgeTagModel obj)
        {
            try
            {
                List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeTagModel>>(_objIHttpWebClients.PostRequest("WeighBridgeTag/ViewWeighBridgeTagHistory", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ViewWeighBridgeTagModel> ViewWeighBridgeTagApproval(ViewWeighBridgeTagModel obj)
        {
            try
            {
                List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeTagModel>>(_objIHttpWebClients.PostRequest("WeighBridgeTag/ViewWeighBridgeTagApproval", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ViewWeighBridgeTagModel> ViewWeighBridgeTagRequest(ViewWeighBridgeTagModel obj)
        {
            try
            {
                List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeTagModel>>(_objIHttpWebClients.PostRequest("WeighBridgeTag/ViewWeighBridgeTagRequest", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AddWeighBridgeTagModel WBTagByTagID(ViewWeighBridgeTagModel obj)
        {
            try
            {
                AddWeighBridgeTagModel objaddmodel = new AddWeighBridgeTagModel();
                objaddmodel = JsonConvert.DeserializeObject<AddWeighBridgeTagModel>(_objIHttpWebClients.PostRequest("WeighBridgeTag/WBTagByTagID", JsonConvert.SerializeObject(obj)));
                return objaddmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF WBTagApprove(ViewWeighBridgeTagModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeTag/WBTagApprove", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }
        public MessageEF WBTagEdit(AddWeighBridgeTagModel objmodel)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeTag/WBTagEdit", JsonConvert.SerializeObject(objmodel)));
            return objmessageEF;
        }
        public MessageEF WBTagForward(ViewWeighBridgeTagModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeTag/WBTagForward", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }
        public MessageEF WBTagReject(ViewWeighBridgeTagModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeTag/WBTagReject", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }
        public MessageEF WBTagSave(AddWeighBridgeTagModel objmodel)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeTag/WBTagSave", JsonConvert.SerializeObject(objmodel)));
            return objmessageEF;
        }
        public MessageEF WBTagCheck(AddWeighBridgeTagModel objmodel)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeTag/WBTagCheck", JsonConvert.SerializeObject(objmodel)));
            return objmessageEF;
        }
        public MessageEF WBTagRequest(ViewWeighBridgeTagModel objmodel)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("WeighBridgeTag/WBTagRequest", JsonConvert.SerializeObject(objmodel)));
            return objmessageEF;
        }
        public List<ViewWeighBridgeTagModel> ViewWeighBridgeActionList(ViewWeighBridgeTagModel obj)
        {
            try
            {
                List<ViewWeighBridgeTagModel> objlist = new List<ViewWeighBridgeTagModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeTagModel>>(_objIHttpWebClients.PostRequest("WeighBridgeTag/ViewWeighBridgeActionList", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
