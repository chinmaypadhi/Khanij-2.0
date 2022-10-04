using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Model.Graph
{
    public interface IRevenueProvider
    {
        MessageEF Add(EditRevenueModel objmodel);
        MessageEF Edit(EditRevenueModel objmodel);
        Task<List<ViewRevenueModel>> View(ViewRevenueModel objmodel);
        Task<EditRevenueModel> ViewByID(ViewRevenueModel objmodel);
        Task<List<ViewRevenueModel>> ViewByFinancialYear(ViewRevenueModel objmodel);
        MessageEF CheckRevenue(EditRevenueModel objmodel);
    }
}
