using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.eCancel
{
    public interface IeCancel
    {
        List<eCancelModel> eCancelPermit(eCancelModel objOpenModel);
        List<DD> ddmodule(DD objOpenModel);
        List<TPCancelModelEF> GetTP_Cancel(TPCancelModelEF objOpenModel);
        
    }
}
