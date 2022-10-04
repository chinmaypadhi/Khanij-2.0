using HomeApp.Models.Utility;
using HomeEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Graph
{
    public class Production : IProduction
    {
        IHttpWebClients _objIHttpWebClients;
        public Production(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public MessageEF Add(EditProductionModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Production/Add", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }

        public MessageEF Check(EditProductionModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Production/Check", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }

        public MessageEF Edit(EditProductionModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Production/Edit", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }

        public List<ViewProductionModel> View(ViewProductionModel obj)
        {
            try
            {
                List<ViewProductionModel> objlist = new List<ViewProductionModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewProductionModel>>(_objIHttpWebClients.PostRequest("Production/View", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ViewProductionModel> ViewByFinancialYear(ViewProductionModel obj)
        {
            try
            {
                List<ViewProductionModel> objlist = new List<ViewProductionModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewProductionModel>>(_objIHttpWebClients.PostRequest("Production/ViewByFinancialYear", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EditProductionModel ViewByID(ViewProductionModel obj)
        {
            EditProductionModel editproductionmodel = new EditProductionModel();
            editproductionmodel = JsonConvert.DeserializeObject<EditProductionModel>(_objIHttpWebClients.PostRequest("Production/ViewByID", JsonConvert.SerializeObject(obj)));
            return editproductionmodel;
        }
    }
}
