// ***********************************************************************
//  Model Name               : Mineral.cs
//  Desciption               : Used to manage preferred Bidder information
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 11-may-2021
// ***********************************************************************

using Appkey;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MineralConcessionEF;
using MineralConcessionApp.Models.Utility;

namespace MineralConcessionApp.Areas.MajorMineral.Models.Mineral
{
    public class mineral : Imineral
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIHttpWebClients"></param>
        public mineral(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Bind Auction type list details in view
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<PreferredBidder> GetAuctionType(PreferredBidder objPaymentTypemaster)
        {
            List<PreferredBidder> objticket = new List<PreferredBidder>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<PreferredBidder>>(_objIHttpWebClients.PostRequest("MinorMineral/GetAuctionType", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 1-may-2021 to fetch Lease Type
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<PreferredBidder> FetchLeaseType(PreferredBidder objPaymentTypemaster)
        {
            List<PreferredBidder> objticket = new List<PreferredBidder>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<PreferredBidder>>(_objIHttpWebClients.PostRequest("MinorMineral/FetchLeaseType", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 2-may-2021 to get Mineral list Non Coal
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<PreferredBidder> GetMineralNonCoal(PreferredBidder objPaymentTypemaster)
        {
            List<PreferredBidder> objticket = new List<PreferredBidder>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<PreferredBidder>>(_objIHttpWebClients.PostRequest("MinorMineral/GetMineralNonCoal", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 4-may-2021 to get District list agnaist state id
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<PreferredBidder> GetDistrictListByState(PreferredBidder objPaymentTypemaster)
        {
            List<PreferredBidder> objticket = new List<PreferredBidder>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<PreferredBidder>>(_objIHttpWebClients.PostRequest("MinorMineral/GetDistrictListByState", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 2-may-2021 to get tehsil list aganast district id
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<PreferredBidder> GetTehsilListByDistrict(PreferredBidder objPaymentTypemaster)
        {
            List<PreferredBidder> objticket = new List<PreferredBidder>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<PreferredBidder>>(_objIHttpWebClients.PostRequest("MinorMineral/GetTehsilListByDistrict", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 2-may-2021 to get village list against tehsil id
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<PreferredBidder> GetVillageListByTehsil(PreferredBidder objPaymentTypemaster)
        {
            List<PreferredBidder> objticket = new List<PreferredBidder>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<PreferredBidder>>(_objIHttpWebClients.PostRequest("MinorMineral/GetVillageListByTehsil", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 2-may-2021 to Add preferred bidder request
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public MessageEF Add(LeaseApplicationModel objPaymentTypemaster)
        {
            string _result = "";
            try
            {
                MessageEF objMessageEF = new MessageEF();

                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MinorMineral/Add", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 6-may-2021 to get Auction No already present or not
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public int CheckAuctionNo(LeaseApplicationModel objPaymentTypemaster)
        {
            int _result;
            try
            {


                _result = JsonConvert.DeserializeObject<int>(_objIHttpWebClients.PostRequest("MinorMineral/CheckAuctionNo", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return _result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 10-may-2021 to view preferred bidder request
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public List<LeaseApplicationModel> GetPreferredBidderRequest(LeaseApplicationModel objPaymentTypemaster)
        {
            List<LeaseApplicationModel> objticket = new List<LeaseApplicationModel>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<LeaseApplicationModel>>(_objIHttpWebClients.PostRequest("MinorMineral/GetPreferredBidderRequest", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 8-may-2021 to get Edit preferred bidder data
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public PreferredBidder GetEditPreferredBidderRequest(PreferredBidder objPaymentTypemaster)
        {


            try
            {

                objPaymentTypemaster = JsonConvert.DeserializeObject<PreferredBidder>(_objIHttpWebClients.PostRequest("MinorMineral/GetEditPreferredBidderRequest", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objPaymentTypemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 12-may-2021 to load first installment page
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public LeaseApplicationModel GetFirstinstallment(LeaseApplicationModel objPaymentTypemaster)
        {


            try
            {

                objPaymentTypemaster = JsonConvert.DeserializeObject<LeaseApplicationModel>(_objIHttpWebClients.PostRequest("MinorMineral/GetFirstinstallment", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objPaymentTypemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 13-may-2021 to submit payment data
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public MessageEF AddPayment(LeaseApplicationModel objPaymentTypemaster)
        {
            string _result = "";
            try
            {
                MessageEF objMessageEF = new MessageEF();

                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MinorMineral/AddPayment", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 21-may-2021 to get mineral TimeLine
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public DataTable GetTimeline(PreferredBidder objPaymentTypemaster)
        {
            string _result = "";
            try
            {
                DataTable objMessageEF = new DataTable();

                objMessageEF = JsonConvert.DeserializeObject<DataTable>(_objIHttpWebClients.PostRequest("MinorMineral/GetTimeline", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 23-may-2021 to add digital signature data
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public int InsertDSCRespnseData(DSCResponseModel objPaymentTypemaster)
        {
            int _result;
            try
            {
                _result = JsonConvert.DeserializeObject<int>(_objIHttpWebClients.PostRequest("MinorMineral/InsertDSCRespnseData", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return _result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }       
    }
}
   