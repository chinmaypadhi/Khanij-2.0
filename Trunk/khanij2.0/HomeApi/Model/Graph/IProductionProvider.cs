using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Model.Graph
{
    public interface IProductionProvider
    {
        MessageEF Add(EditProductionModel objmodel);
        MessageEF Edit(EditProductionModel objmodel);
        Task<List<ViewProductionModel>> View(ViewProductionModel objmodel);
        Task<EditProductionModel> ViewByID(ViewProductionModel objmodel);
        Task<List<ViewProductionModel>> ViewByFinancialYear(ViewProductionModel objmodel);
        MessageEF CheckProduction(EditProductionModel objmodel);
    }
}
