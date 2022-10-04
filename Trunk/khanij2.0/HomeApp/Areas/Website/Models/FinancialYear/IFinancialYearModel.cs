using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.FinancialYear
{
    public interface IFinancialYearModel
    {
        List<string> GetFinancialYear();
    }
}
