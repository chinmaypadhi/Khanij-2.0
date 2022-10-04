using HomeEF;
using System;
using System.Collections.Generic;
using HomeApp.Models.Utility;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HomeApp.Areas.Website.Models.Graph
{
    public class Revenue : IRevenue
    {
        IHttpWebClients _objIHttpWebClients;
        public Revenue(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public MessageEF Add(EditRevenueModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Revenue/Add", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }

        public MessageEF Check(EditRevenueModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Revenue/Check", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }

        public MessageEF Edit(EditRevenueModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Revenue/Edit", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }

        public List<ViewRevenueModel> View(ViewRevenueModel obj)
        {
            try
            {
                List<ViewRevenueModel> objlist = new List<ViewRevenueModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewRevenueModel>>(_objIHttpWebClients.PostRequest("Revenue/View", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EditRevenueModel ViewByID(ViewRevenueModel obj)
        {
            EditRevenueModel editrevenuemodel = new EditRevenueModel();
            editrevenuemodel = JsonConvert.DeserializeObject<EditRevenueModel>(_objIHttpWebClients.PostRequest("Revenue/ViewByID", JsonConvert.SerializeObject(obj)));
            return editrevenuemodel;
        }

        public List<ViewRevenueModel> ViewByFinancialYear(ViewRevenueModel obj)
        {
            try
            {
                List<ViewRevenueModel> objlist = new List<ViewRevenueModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewRevenueModel>>(_objIHttpWebClients.PostRequest("Revenue/ViewByFinancialYear", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
