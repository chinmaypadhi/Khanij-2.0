using HomeApp.Models.Utility;
using HomeEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Graph
{
    public class Resources : IResources
    {
        IHttpWebClients _objIHttpWebClients;
        public Resources(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public MessageEF Edit(EditResourcesModel obj)
        {
            MessageEF objmessageEF = new MessageEF();
            objmessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Resources/Edit", JsonConvert.SerializeObject(obj)));
            return objmessageEF;
        }

        public ViewResourcesModel View(ViewResourcesModel obj)
        {
            ViewResourcesModel viewresourcesmodel = new ViewResourcesModel();
            viewresourcesmodel = JsonConvert.DeserializeObject<ViewResourcesModel>(_objIHttpWebClients.PostRequest("Resources/View", JsonConvert.SerializeObject(obj)));
            return viewresourcesmodel;
        }

        public EditResourcesModel ViewByID(ViewResourcesModel obj)
        {
            EditResourcesModel editresourcesmodel = new EditResourcesModel();
            editresourcesmodel = JsonConvert.DeserializeObject<EditResourcesModel>(_objIHttpWebClients.PostRequest("Resources/ViewByID", JsonConvert.SerializeObject(obj)));
            return editresourcesmodel;
        }
    }
}
