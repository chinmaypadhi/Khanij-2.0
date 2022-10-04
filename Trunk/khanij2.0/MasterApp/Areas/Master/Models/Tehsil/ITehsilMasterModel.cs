using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Tehsil
{
    public interface ITehsilMasterModel
    {
        MessageEF Add(TehsilModel tehsilModel);
        MessageEF Update(TehsilModel tehsilModel);
        List<TehsilModel> View(TehsilModel tehsilModel);
        MessageEF Delete(TehsilModel tehsilModel);
        TehsilModel Edit(TehsilModel tehsilModel);
    }
}
