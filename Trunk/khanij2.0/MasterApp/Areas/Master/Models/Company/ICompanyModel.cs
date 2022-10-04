
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Models.Company
{
    public interface ICompanyModel
    {
        MessageEF Add(CompanyMaster objMineralCategory);
        MessageEF Update(CompanyMaster objMineralCategory);
        List<CompanyMaster> View(CompanyMaster objMineralCategory);
        MessageEF Delete(CompanyMaster objMineralCategory);
        CompanyMaster Edit(CompanyMaster objMineralCategory);
    }
}
