using SupportEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApp.Areas.Inspection.Models
{
    public interface IinspectionModel
    {
        InspectionModel GetUDetails(InspectionModel ObjEU);
        FillDDlInspection GetUserType(InspectionModel ObjEU);
        List<NoticeModel> GetLst(NoticeModel model);
        FillDDlInspection GetUserList(InspectionModel ObjEU);
        InspectionModel GetUserDetails(InspectionModel ObjEU);
        MessageEF AddInspectionData(InspectionModel ObjEU);
        List<InspectionModel> ViewLst(InspectionModel model);
        List<InspectionModel> GetInspectionDetails(InspectionModel ObjEU);
    }
}
