
// ***********************************************************************
//  Model Name               : IMineral.cs
//  Desciption               : Used to manage preferred Bidder information
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 11-may-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MineralConcessionApi.Repository;
using MineralConcessionEF;
namespace MineralConcessionApi.Model.Mineral
{
    public interface IMineral: IDisposable, IRepository
    {
        /// <summary>
        /// Added by suroj 1-may-2021 to get Auction type
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        List<PreferredBidder> GetAuctionType(PreferredBidder objRaiseTicket);
        /// <summary>
        /// Added by suroj 1-may-2021 to fetch Lease Type
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        List<PreferredBidder> FetchLeaseType(PreferredBidder objRaiseTicket);
        /// <summary>
        /// Added by suroj 2-may-2021 to get Mineral list Non Coal
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        List<PreferredBidder> GetMineralNonCoal(PreferredBidder objRaiseTicket);
        /// <summary>
        /// Added by suroj 4-may-2021 to get District list agnaist state id
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        List<PreferredBidder> GetDistrictListByState(PreferredBidder objRaiseTicket);
        /// <summary>
        /// Added by suroj 2-may-2021 to get tehsil list aganast district id
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        List<PreferredBidder> GetTehsilListByDistrict(PreferredBidder objRaiseTicket);
        /// <summary>
        /// Added by suroj 2-may-2021 to get village list against tehsil id
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        List<PreferredBidder> GetVillageListByTehsil(PreferredBidder objRaiseTicket);
        /// <summary>
        /// Added by suroj 2-may-2021 to Add preferred bidder request
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        MessageEF Add(LeaseApplicationModel model);
        /// <summary>
        /// Added by suroj 6-may-2021 to get Auction No already present or not
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        int CheckAuctionNo(LeaseApplicationModel model);
        /// <summary>
        /// Added by suroj 10-may-2021 to view preferred bidder request
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        List<LeaseApplicationModel> GetPreferredBidderRequest(LeaseApplicationModel objRaiseTicket);
        /// <summary>
        /// Added by suroj on 8-may-2021 to get Edit preferred bidder data
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        PreferredBidder GetEditPreferredBidderRequest(PreferredBidder objRaiseTicket);
        /// <summary>
        /// First payment installisation data fetch added by suroj
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        LeaseApplicationModel GetFirstinstallment(LeaseApplicationModel objRaiseTicket);
        /// <summary>
        /// Added by suroj 13-may-2021 to submit payment data
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        MessageEF AddPayment(LeaseApplicationModel model);
        /// <summary>
        /// Added by suroj 21-may-2021 to get mineral TimeLine
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        DataTable GetTimeline(PreferredBidder model);
        /// <summary>
        /// Added by suroj 23-may-2021 to add digital signature data
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        int InsertDSCRespnseData(DSCResponseModel model);
    }
}
