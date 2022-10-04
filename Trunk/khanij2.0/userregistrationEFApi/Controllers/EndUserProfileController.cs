using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEFApi.Model.EndUserProfile;
using userregistrationEF;

namespace userregistrationEFApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class EndUserProfileController : ControllerBase
    {
        public IEndUserProfileProvider _objIEndUserProfile;
        public EndUserProfileController(IEndUserProfileProvider endUserProfile)
        {
            _objIEndUserProfile = endUserProfile;
        }

        [HttpPost]
        public async Task<Result<List<EndUserProfileViewModel>>> ViewProfile(EndUserProfileViewModel endUserProfile)
        {
            return await _objIEndUserProfile.ViewProfile(endUserProfile);
        }
        [HttpPost]
        public async Task<EndUserModel> EditEndUserProfile(EndUserModel endUserProfile)
        {
            return await _objIEndUserProfile.EditEndUserProfile(endUserProfile);
        }
        [HttpPost]
        public async Task<MessageEF> UpdateEndUserProfile(EndUserModel endUserProfile)
        {
            return await _objIEndUserProfile.UpdateEndUserProfile(endUserProfile);
        }
    }
}
