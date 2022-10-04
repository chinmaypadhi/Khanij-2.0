using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using userregistrationApp.Models.Utility;
using userregistrationEF;
using Newtonsoft.Json;


namespace userregistrationApp.Areas.CommonRailwaySiding.Models
{
    public class CommonRailwaySidingModel : ICommonRailwaySidingModel
    {
        IHttpWebClients _objIHttpWebClients;
        public CommonRailwaySidingModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        public MessageEF AddCommonRailwaySiding(userregistrationEF.CommonRailwaySidingModel objCRS)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CommonRailwaySiding/AddCommonRailwaySiding", JsonConvert.SerializeObject(objCRS)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CRSDropDown> BindCRSDDL(CRSDropDown objWorkFlow)
        {
            List<CRSDropDown> listLeave = new List<CRSDropDown>();
            try
            {
                listLeave = JsonConvert.DeserializeObject<List<CRSDropDown>>(_objIHttpWebClients.PostRequest("CommonRailwaySiding/BindCRSDDL", JsonConvert.SerializeObject(objWorkFlow)));
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CommonRailwaySidingInboxEF_Query> CommonRailwaySidinginbox(CommonRailwaySidingInboxEF_Query objCommon)
        {
            List<CommonRailwaySidingInboxEF_Query> listCommon = new List<CommonRailwaySidingInboxEF_Query>();
            try
            {
                listCommon = JsonConvert.DeserializeObject<List<CommonRailwaySidingInboxEF_Query>>(_objIHttpWebClients.PostRequest("CommonRailwaySiding/CommonRailwaySidinginbox", JsonConvert.SerializeObject(objCommon)));
                return listCommon;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteCommonRailwaySiding(userregistrationEF.CommonRailwaySidingModel objCRS)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CommonRailwaySiding/DeleteCommonRailwaySiding", JsonConvert.SerializeObject(objCRS)));
                return objMessageEF;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF TakeAction(CommonRailwaySidingTakeAction objCommon)
        {
            try
            {
                MessageEF objMessage = new MessageEF();
                objMessage = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CommonRailwaySiding/TakeAction", JsonConvert.SerializeObject(objCommon)));
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CommonRailwaySidingModel_Query> ViewCommonRailwaySiding(CommonRailwaySidingModel_Query objCommon)
        {
            List<CommonRailwaySidingModel_Query> listCommon = new List<CommonRailwaySidingModel_Query>();
            try
            {
                listCommon = JsonConvert.DeserializeObject<List<CommonRailwaySidingModel_Query>>(_objIHttpWebClients.PostRequest("CommonRailwaySiding/ViewCommonRailwaySiding", JsonConvert.SerializeObject(objCommon)));
                return listCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public userregistrationEF.CommonRailwaySidingModel ViewCommonRailwaySidingDetails(userregistrationEF.CommonRailwaySidingModel objCommon)
        {
            userregistrationEF.CommonRailwaySidingModel objModel = new userregistrationEF.CommonRailwaySidingModel();
            try
            {
                objModel = JsonConvert.DeserializeObject<userregistrationEF.CommonRailwaySidingModel>(_objIHttpWebClients.PostRequest("CommonRailwaySiding/ViewCommonRailwaySidingDetails", JsonConvert.SerializeObject(objCommon)));
                return objModel;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public MessageEF CreatenewUser(CommonRailwaySidingTakeAction objCRS)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CommonRailwaySiding/CreatenewUser", JsonConvert.SerializeObject(objCRS)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public MessageEF Main(SMS sMS)
        //{
        //    try
        //    {
        //        MessageEF messageEF = new MessageEF();
        //        messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SMSService/Main", JsonConvert.SerializeObject(sMS)));
        //        return messageEF;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        public MessageEF Main(SMS sMS)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CommonRailwaySiding/Main", JsonConvert.SerializeObject(sMS)));
                return messageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public MessageEF fileupload(ExcelDataValues objuploadfile)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CommonRailwaySiding/ExcelFileUpload", JsonConvert.SerializeObject(objuploadfile)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
