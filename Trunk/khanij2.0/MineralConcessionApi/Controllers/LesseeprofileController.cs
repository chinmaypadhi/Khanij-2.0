using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MineralConcessionEF;

using System.Data;
using MineralConcessionApi.Model.LesseeProfile;
using Microsoft.AspNetCore.Authorization;

namespace MineralConcessionApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeprofileController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public ILesseprofile _objICompanyProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        public LesseeprofileController(ILesseprofile objICompanyProvider)
        {
            _objICompanyProvider = objICompanyProvider;
        }
        /// <summary>
        /// Bind Compmaster data details in view
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<LeaseApplicationModel> GetCompMasterData(LeaseApplicationModel objRaiseTicket)
        {
            return _objICompanyProvider.GetCompMasterData(objRaiseTicket);
        }
        /// <summary>
        /// Submit details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(LeaseApplicationModel objPaymentTypeMaster)
        {
            return _objICompanyProvider.Add(objPaymentTypeMaster);
        }
        /// <summary>
        /// Bind Lessee details data for edit
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public LeaseApplicationModel GetlesseEditdata(LeaseApplicationModel objRaiseTicket)
        {
            return _objICompanyProvider.GetlesseEditdata(objRaiseTicket);
        }
    }
}
