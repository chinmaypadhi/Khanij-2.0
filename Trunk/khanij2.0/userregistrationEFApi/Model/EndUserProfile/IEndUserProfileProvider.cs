using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEFApi.Repository;
using userregistrationEF;

namespace userregistrationEFApi.Model.EndUserProfile
{
    public interface IEndUserProfileProvider : IDisposable, IRepository
    {

        Task<Result<List<EndUserProfileViewModel>>> ViewProfile(EndUserProfileViewModel endUserProfile);
        Task<EndUserModel> EditEndUserProfile(EndUserModel objER);
        Task<MessageEF> UpdateEndUserProfile(EndUserModel objER);
    }
}
