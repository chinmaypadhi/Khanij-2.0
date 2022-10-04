using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInformationEF;
using UserInformationApi.Model.Mineral;
using System.Data;

namespace UserInformationApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class MinorMineralController : Controller
    {
        public IMineral _objICompanyProvider;
        public MinorMineralController(IMineral objICompanyProvider)
        {
            _objICompanyProvider = objICompanyProvider;
        }
        public List<PreferredBidder> GetAuctionType(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetAuctionType(objPaymentTypeMaster);
        }
        public List<PreferredBidder> FetchLeaseType(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.FetchLeaseType(objPaymentTypeMaster);
        }
        public List<PreferredBidder> GetMineralNonCoal(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetMineralNonCoal(objPaymentTypeMaster);
        }
        public List<PreferredBidder> GetDistrictListByState(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetDistrictListByState(objPaymentTypeMaster);
        }

        public List<PreferredBidder> GetTehsilListByDistrict(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetTehsilListByDistrict(objPaymentTypeMaster);
        }

        public List<PreferredBidder> GetVillageListByTehsil(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetVillageListByTehsil(objPaymentTypeMaster);
        }

        public MessageEF Add(LeaseApplicationModel objPaymentTypeMaster)
        {
            return _objICompanyProvider.Add(objPaymentTypeMaster);
        }

        public int CheckAuctionNo(LeaseApplicationModel objPaymentTypeMaster)
        {
            return _objICompanyProvider.CheckAuctionNo(objPaymentTypeMaster);
        }

        public List<LeaseApplicationModel> GetPreferredBidderRequest(LeaseApplicationModel objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetPreferredBidderRequest(objPaymentTypeMaster);
        }

        public PreferredBidder GetEditPreferredBidderRequest(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetEditPreferredBidderRequest(objPaymentTypeMaster);
        }
        public LeaseApplicationModel GetFirstinstallment(LeaseApplicationModel objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetFirstinstallment(objPaymentTypeMaster);
        }

        public MessageEF AddPayment(LeaseApplicationModel objPaymentTypeMaster)
        {
            return _objICompanyProvider.AddPayment(objPaymentTypeMaster);
        }

        public DataTable GetTimeline(PreferredBidder objPaymentTypeMaster)
        {
            return _objICompanyProvider.GetTimeline(objPaymentTypeMaster);
        }

        public int InsertDSCRespnseData(DSCResponseModel model)
        {
            return _objICompanyProvider.InsertDSCRespnseData(model);
        }
    }
}
