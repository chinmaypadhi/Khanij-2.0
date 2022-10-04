using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using userregistrationEF;

namespace userregistrationApp.Areas.CommonRailwaySiding.Models
{
    public interface ICommonRailwaySidingModel
    {
        MessageEF AddCommonRailwaySiding(userregistrationEF.CommonRailwaySidingModel objCRS);
        List<CRSDropDown> BindCRSDDL(CRSDropDown objWorkFlow);

        List<CommonRailwaySidingModel_Query> ViewCommonRailwaySiding(CommonRailwaySidingModel_Query objCommon);
        public MessageEF DeleteCommonRailwaySiding(userregistrationEF.CommonRailwaySidingModel objCRS);

        public userregistrationEF.CommonRailwaySidingModel ViewCommonRailwaySidingDetails(userregistrationEF.CommonRailwaySidingModel objCommon);

        public List<CommonRailwaySidingInboxEF_Query> CommonRailwaySidinginbox(CommonRailwaySidingInboxEF_Query objCommon);

        public MessageEF TakeAction(CommonRailwaySidingTakeAction objCommon);

        MessageEF CreatenewUser(CommonRailwaySidingTakeAction objCRS);
        MessageEF Main(SMS sMS);

        MessageEF fileupload(ExcelDataValues objuploadfile);


    }
}
