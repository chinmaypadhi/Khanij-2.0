using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Graph
{
    public interface IRevenue
    {
        MessageEF Add(EditRevenueModel obj);
        MessageEF Edit(EditRevenueModel obj);
        List<ViewRevenueModel> View(ViewRevenueModel obj);
        EditRevenueModel ViewByID(ViewRevenueModel obj);
        List<ViewRevenueModel> ViewByFinancialYear(ViewRevenueModel obj);
        MessageEF Check(EditRevenueModel obj);
    }
}
