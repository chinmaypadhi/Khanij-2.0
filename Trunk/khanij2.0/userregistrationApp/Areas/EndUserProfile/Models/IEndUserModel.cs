using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
namespace userregistrationApp.Areas.EndUserProfile.Models
{
    public interface IEndUserModel
    {
        EndUserProfileViewModel ViewProfile(EndUserProfileViewModel endUserProfile);
        GetIndustryType GetIType(userregistrationEF.EndUserModel ObjEU);
        GetListState GetState(userregistrationEF.EndUserModel ObjEU);
        GetListState GetDistrict(userregistrationEF.EndUserModel ObjEU);
        GetListState GetState_O(userregistrationEF.EndUserModel ObjEU);
        GetListState GetDistrict_O(userregistrationEF.EndUserModel ObjEU);
        GetListState GetSQ(userregistrationEF.EndUserModel ObjEU);
        GetListState GetMineral(userregistrationEF.EndUserModel ObjEU);
        GetListState GetMineralForm(userregistrationEF.EndUserModel ObjEU);
        GetListState GetMineralGrade(userregistrationEF.EndUserModel ObjEU);
        userregistrationEF.EndUserModel EditEndUserProfile(userregistrationEF.EndUserModel endUserProfile);
        MessageEF UpdateEndUserProfile(userregistrationEF.EndUserModel objER);
    }
}
