
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.LeaseType
{
    public interface ILeaseTypeModel
    {
        MessageEF Add(LeaseTypeMaster objLeaseType);
        MessageEF Update(LeaseTypeMaster objLeaseType);
        List<LeaseTypeMaster> View(LeaseTypeMaster objLeaseType);
        MessageEF Delete(LeaseTypeMaster objLeaseType);
        LeaseTypeMaster Edit(LeaseTypeMaster objLeaseType);
    }
}
