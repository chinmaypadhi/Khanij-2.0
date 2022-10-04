using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Graph
{
    public interface IResources
    {
        MessageEF Edit(EditResourcesModel obj);
        EditResourcesModel ViewByID(ViewResourcesModel obj);
        ViewResourcesModel View(ViewResourcesModel obj);
    }
}
