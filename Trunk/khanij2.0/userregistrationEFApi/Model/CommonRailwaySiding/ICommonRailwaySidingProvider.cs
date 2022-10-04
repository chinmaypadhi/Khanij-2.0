using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using userregistrationEFApi.Repository;
using userregistrationEF;

namespace userregistrationEFApi.Model.CommonRailwaySiding
{
   public interface ICommonRailwaySidingProvider:IDisposable,IRepository
    {
        MessageEF AddCommonRailwaySiding(CommonRailwaySidingModel objCRS);
        Task<List<CRSDropDown>> BindCRSDDL(CRSDropDown objWorkFlow);
        Task<List<CommonRailwaySidingModel_Query>> ViewCommonRailwaySiding(CommonRailwaySidingModel_Query objCommon);
        MessageEF DeleteCommonRailwaySiding(CommonRailwaySidingModel objCRS);
        Task<CommonRailwaySidingModel> ViewCommonRailwaySidingDetails(CommonRailwaySidingModel objCommon);
        Task<List<CommonRailwaySidingInboxEF_Query>> CommonRailwaySidinginbox(CommonRailwaySidingInboxEF_Query objCommon);
        MessageEF TakeAction(CommonRailwaySidingTakeAction objCommon);

        MessageEF CreatenewUser(CommonRailwaySidingTakeAction objCRS);
        MessageEF ExcelfileUpload(ExcelDataValues objupload);

        MessageEF Main(SMS sMS);

    }
}
