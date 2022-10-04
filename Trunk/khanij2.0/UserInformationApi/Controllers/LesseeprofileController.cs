using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInformationEF;

using System.Data;
using UserInformationApi.Model.LesseeProfile;

namespace UserInformationApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class LesseeprofileController : Controller
    {
        public ILesseprofile _objICompanyProvider;
        public LesseeprofileController(ILesseprofile objICompanyProvider)
        {
            _objICompanyProvider = objICompanyProvider;
        }

        public List<LeaseApplicationModel> GetCompMasterData(LeaseApplicationModel objRaiseTicket)
        {
            return _objICompanyProvider.GetCompMasterData(objRaiseTicket);
        }
        public MessageEF Add(LeaseApplicationModel objPaymentTypeMaster)
        {
            return _objICompanyProvider.Add(objPaymentTypeMaster);
        }
        public LeaseApplicationModel GetlesseEditdata(LeaseApplicationModel objRaiseTicket)
        {
            return _objICompanyProvider.GetlesseEditdata(objRaiseTicket);
        }
    }
}
