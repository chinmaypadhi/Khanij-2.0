using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Model.Graph
{
    public interface IResourcesProvider
    {
        MessageEF Edit(EditResourcesModel objmodel);
        Task<EditResourcesModel> ViewByID(ViewResourcesModel objmodel);
        Task<ViewResourcesModel> View(ViewResourcesModel objmodel);
    }
}
