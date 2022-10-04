using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Graph
{
    public interface IProduction
    {
        MessageEF Add(EditProductionModel obj);
        MessageEF Edit(EditProductionModel obj);
        List<ViewProductionModel> View(ViewProductionModel obj);
        EditProductionModel ViewByID(ViewProductionModel obj);
        List<ViewProductionModel> ViewByFinancialYear(ViewProductionModel obj);
        MessageEF Check(EditProductionModel obj);
    }
}
