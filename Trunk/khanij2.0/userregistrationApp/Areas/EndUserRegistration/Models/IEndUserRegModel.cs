using userregistrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userregistrationApp.Areas.EndUserRegistration.Models
{
    public interface IEndUserRegModel
    {
        EndUserModel GetOTPModel(EndUserModel ObjDP);
        GetIndustryType GetIType(EndUserModel ObjEU);
        GetListState GetState(EndUserModel ObjEU);
        GetListState GetDistrict(EndUserModel ObjEU);
        GetListState GetState_O(EndUserModel ObjEU);
        GetListState GetDistrict_O(EndUserModel ObjEU);
        GetListState GetSQ(EndUserModel ObjEU);
        GetListState GetMineral(EndUserModel ObjEU);
        GetListState GetMineralForm(EndUserModel ObjEU);
        GetListState GetMineralGrade(EndUserModel ObjEU);
        MessageEF VerifyOTP(EndUserModel ObjEU);
        MessageEF AddEuser(EndUserModel ObjEU);
        EndUserModel GetUDModel(EndUserModel ObjEU);
        List<EndUserModel> ViewAllReport(EndUserModel objEU);
        EndUserBasicInfoModel GetallUserWiseData(EndUserModel ObjEU);
        MessageEF ApproveEuser(EndUserBasicInfoModel ObjEU);
        EndUserBasicInfoModel GetallUserDataDetails(EndUserBasicInfoModel ObjEU);
        MessageEF RejectEuser(EndUserBasicInfoModel ObjEU);
        List<EndUserModel> ViewUpdationReport(EndUserModel objEU);
        List<ForceFullDataEndUser> AllActionTakenReport(EndUserModel objEU);
        EndUserBasicInfoModel GetActionTakenUserWiseData(EndUserModel ObjEU);
        MessageEF ViewEndUserDetails(EndUserBasicInfoModel ObjEU);
        EndUserModel GetEuserStatus(EndUserModel ObjEU);
        MessageEF ViewEndUserProfDetails(EndUserModel1 ObjEU);
        MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel);
    }
}
