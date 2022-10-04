using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MineralConcessionEF;
using MineralConcessionApi.Model.Mineral;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace MineralConcessionApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MinorMineralController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public IMineral _objICompanyProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        public MinorMineralController(IMineral objICompanyProvider)
        {
            _objICompanyProvider = objICompanyProvider;
        }
        /// <summary>
        /// Bind Auction type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<PreferredBidder> GetAuctionType(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetAuctionType(objPaymentTypeMaster);
        }
        /// <summary>
        /// Bind Lease type details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<PreferredBidder> FetchLeaseType(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.FetchLeaseType(objPaymentTypeMaster);
        }
        /// <summary>
        /// Bind Mineral Non coal details data in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<PreferredBidder> GetMineralNonCoal(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetMineralNonCoal(objPaymentTypeMaster);
        }
        /// <summary>
        /// Bind District details data statewise in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<PreferredBidder> GetDistrictListByState(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetDistrictListByState(objPaymentTypeMaster);
        }
        /// <summary>
        /// Bind Tehsil details data districtwise in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<PreferredBidder> GetTehsilListByDistrict(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetTehsilListByDistrict(objPaymentTypeMaster);
        }
        /// <summary>
        /// Bind Village details data tehsilwise in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<PreferredBidder> GetVillageListByTehsil(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetVillageListByTehsil(objPaymentTypeMaster);
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
        /// Get Auction No details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public int CheckAuctionNo(LeaseApplicationModel objPaymentTypeMaster)
        {
            return _objICompanyProvider.CheckAuctionNo(objPaymentTypeMaster);
        }
        /// <summary>
        /// Get preferred bidder request details in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<LeaseApplicationModel> GetPreferredBidderRequest(LeaseApplicationModel objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetPreferredBidderRequest(objPaymentTypeMaster);
        }
        /// <summary>
        /// Edit preferred bidder request details in view 
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public PreferredBidder GetEditPreferredBidderRequest(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetEditPreferredBidderRequest(objPaymentTypeMaster);
        }
        /// <summary>
        /// Get first installment data in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public LeaseApplicationModel GetFirstinstallment(LeaseApplicationModel objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetFirstinstallment(objPaymentTypeMaster);
        }
        /// <summary>
        /// Add payment data in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddPayment(LeaseApplicationModel objPaymentTypeMaster)
        {
            return _objICompanyProvider.AddPayment(objPaymentTypeMaster);
        }
        /// <summary>
        /// Get timeline data in view
        /// </summary>
        /// <param name="objPaymentTypeMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public DataTable GetTimeline(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetTimeline(objPaymentTypeMaster);
        }
        /// <summary>
        /// Insert DSC respnse data in view
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int InsertDSCRespnseData(DSCResponseModel model)
        {
            return _objICompanyProvider.InsertDSCRespnseData(model);
        }
    }
}
