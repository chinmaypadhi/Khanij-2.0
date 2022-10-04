using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.AdminUtility
{
    public interface IAdminUtility
    {
        MessageEF CancleTPApproval(TPCancelModelEF objcancel);
    }
}
